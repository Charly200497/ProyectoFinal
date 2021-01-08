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
    public partial class EntradaProducto : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public EntradaProducto(String TipoUser)
        {
            InitializeComponent();
            GTipoUser = TipoUser;
            //MessageBox.Show("TipoUsuario" + GTipoUser);
        }
        String GTipoUser = "";

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Herramientas herramientas = new Herramientas(GTipoUser);
            herramientas.Show();
            this.Close();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            
            String ValidaIdentificador = txt_identificador.Text;
            String CadenaIdProducto = cbd.RegresaDatosPrimariosSP(3, "", "", ValidaIdentificador);
            String ValidaUnidades = txt_unidades.Text;
            String ValidaCostoLote = txt_costolote.Text;
            String CadenaIdUsuario = cbd.RegresaDatosPrimariosSP(7, GTipoUser, "", "");
        
            
            String Proveedor = txt_proveedor.Text;
            
            DateTime fll = DateTime.Today;
            String fechallegada = fll.ToString("yyyy-MM-dd");
            DateTime fcad = monthCalendar_caducidad.SelectionStart;
            String fechacaducidad = fcad.ToString("yyyy-MM-dd");

            String ValidaExistencia = cbd.RegresaDatosPrimariosSP(9, "", "", ValidaIdentificador);

            if (ValidaIdentificador == "" || Proveedor == "" || ValidaUnidades == "" || ValidaCostoLote=="")
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                if (ValidaExistencia == "")
                {
                    MessageBox.Show("EL PRODUCTO CON EL IDENTIFICADOR " + ValidaIdentificador + " NO EXISTE");
                }
                else
                {
                    Int16 IdProducto = Int16.Parse(CadenaIdProducto);
                    int Unidades = int.Parse(txt_unidades.Text);
                    float CostoLote = float.Parse(txt_costolote.Text);
                    Int16 IdUsuario = Int16.Parse(CadenaIdUsuario);
                    cbd.AdministraDatosEntradaSP(IdProducto, Unidades, Proveedor, CostoLote, fechallegada, fechacaducidad, IdUsuario);
                    MessageBox.Show("ENTRADA DE PRODUCTO EXITOSA");
                }
                
            }
        }
    }
}
