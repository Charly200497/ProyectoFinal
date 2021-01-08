using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TakeControl.Datos;


namespace TakeControl
{
    public partial class ConfiguracionAlertas : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public ConfiguracionAlertas(String TipoUser)
        {
            InitializeComponent();
            GTipoUser = TipoUser;
            //MessageBox.Show("TipoUsuario" + GTipoUser);
        }
        String GTipoUser = "";
        int bandera30dias = 0;

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Herramientas herramientas = new Herramientas(GTipoUser);
            herramientas.Show();
            this.Close();
        }

        private void btn_activar_Click(object sender, EventArgs e)
        {
            String ValidaIdentificadorProd = txt_identificador.Text;
            String ValidaAntelacion = txt_dias.Text;
            String ValidaMaximo = txt_maximo.Text;
            String ValidaMinimo = txt_minimo.Text;
            String CadenaIdProduccto = cbd.RegresaDatosPrimariosSP(3, "", "", ValidaIdentificadorProd);
            Int16 TipUser = 0;
            String Rol = cbd.RegresaDatosPrimariosSP(2, GTipoUser, "", "");
            if (Rol == "1")
            {
                TipUser = 1;
            }
            else
            {
                TipUser = 2;
            }
            int conjuntoChBox = 0;
            if(bandera30dias==1 || txt_dias.Text != "")
            {
                conjuntoChBox = 1;
            }
            else
            {
                conjuntoChBox = 1;
            }
            

            String ValidaExistencia = cbd.RegresaDatosPrimariosSP(9, "", "", ValidaIdentificadorProd);

            if (ValidaIdentificadorProd == "" || conjuntoChBox != 1 || ValidaMaximo == "" || ValidaMinimo == "")
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                if (ValidaExistencia == "")
                {
                    MessageBox.Show("EL PRODUCTO CON EL IDENTIFICADOR " + ValidaIdentificadorProd + " NO EXISTE");
                }
                else
                {                    
                    int antelacion = 0;
                    if (bandera30dias == 1)
                    {
                        antelacion = 90;
                    }
                    else
                    {
                        antelacion = int.Parse(txt_dias.Text);
                    }
                    Int16 idproducto = Int16.Parse(CadenaIdProduccto);
                    int maximo = int.Parse(ValidaMaximo);
                    int minimo = int.Parse(ValidaMinimo);
                    cbd.AdministraDatosAlarmaSP(2, TipUser, idproducto, 1, 1, 1); //ELIMINA LAS ALERTAS ANERIORES
                    cbd.AdministraDatosAlarmaSP(1, TipUser, idproducto, maximo, minimo, antelacion); // INGRESA NUEVOS VALORES
                    MessageBox.Show("ALERTA PARA EL PRODUCTO " + ValidaIdentificadorProd + " EXITOSA");
                }                
            }
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            String ValidaIdentificadorProd = txt_identificador.Text;
            String CadenaIdProduccto = cbd.RegresaDatosPrimariosSP(3, "", "", ValidaIdentificadorProd);
            Int16 TipUser = 0;
            String Rol = cbd.RegresaDatosPrimariosSP(2, GTipoUser, "", "");
            if (Rol == "1")
            {
                TipUser = 1;
            }
            else
            {
                TipUser = 2;
            }

            String ValidaExistencia = cbd.RegresaDatosPrimariosSP(9, "", "", ValidaIdentificadorProd);

            if (ValidaIdentificadorProd == "")
            {
                MessageBox.Show("Ingresa el identificador del producto :)");
            }
            else
            {
                if (ValidaExistencia == "")
                {
                    MessageBox.Show("EL PRODUCTO CON EL IDENTIFICADOR " + ValidaIdentificadorProd + " NO EXISTE");
                }
                else
                {
                    Int16 idproducto = Int16.Parse(CadenaIdProduccto);
                    
                    MessageBox.Show("ALERTA DEL PRODUCTO " + ValidaIdentificadorProd + " BORRADA");
                }
                    
            }
        }
        private void ChBox_3meses_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBox_3meses.Checked == true)
            {
                bandera30dias = 1;
                txt_dias.Visible = false;
            }
            else
            {
                bandera30dias = 0;
                txt_dias.Visible = true;
            }
        }
    }
}
