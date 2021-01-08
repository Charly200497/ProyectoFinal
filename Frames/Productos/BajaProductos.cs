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
    public partial class BajaProductos : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public BajaProductos(String TipoUser)
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

        private void btn_darbaja_Click(object sender, EventArgs e)
        {
            Int16 TipOper = 2; // De ley para Alta
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
            String identificador = txt_identificador.Text;
            String nidentificador = "";
            String nombre="";
            String ValidaExistencia = cbd.RegresaDatosPrimariosSP(9, "", "", identificador);

            if (identificador == "")
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                if (ValidaExistencia == "")
                {
                    MessageBox.Show("EL PRODUCTO CON EL IDENTIFICADOR "+identificador+" NO EXISTE");
                }
                else
                {
                    cbd.AdministraDatosProductosSP(TipOper, TipUser, identificador, nidentificador, nombre);
                    MessageBox.Show("BAJA EXITOSA");
                }
            }
        }
    }
}
