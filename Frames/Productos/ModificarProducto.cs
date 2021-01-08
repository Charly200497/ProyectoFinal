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

    public partial class ModificarProducto : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public ModificarProducto(String TipoUser)
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

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            Int16 TipOper = 3; // De ley para Modificar
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
            String nidentificador = txt_nidentificador.Text;
            String nombre = txt_nombre.Text;

            String ValidaExistencia = cbd.RegresaDatosPrimariosSP(9, "", "", identificador);

            if (identificador == "" || nidentificador == ""|| nombre == "")
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                if (ValidaExistencia == "")
                {
                    MessageBox.Show("EL PRODUCTO CON EL IDENTIFICADOR " + identificador + " NO EXISTE");
                }
                else
                {
                    cbd.AdministraDatosProductosSP(TipOper, TipUser, identificador, nidentificador, nombre);
                    MessageBox.Show("MODIFICACIÓN EXITOSA");
                }                
            }
        }
    }
}
