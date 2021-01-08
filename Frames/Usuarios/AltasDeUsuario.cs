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
    public partial class AltasDeUsuario : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public AltasDeUsuario(String TipoUser)
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

        private void ChBox_MostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBox_MostrarContrasena.Checked == true)
            {
                if (txt_contrasena.PasswordChar == '#')
                {
                    txt_contrasena.PasswordChar = '\0';
                }
            }
            else
            {
                txt_contrasena.PasswordChar = '#';
            }
        }

        private void ChBox_MostrarRespuesta_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBox_MostrarRespuesta.Checked == true)
            {
                if (txt_respuesta.PasswordChar == '#')
                {
                    txt_respuesta.PasswordChar = '\0';
                }
            }
            else
            {
                txt_respuesta.PasswordChar = '#';
            }
        }

        private void btn_DarAlta_Click(object sender, EventArgs e)
        {            
            Int16 TipOper = 1; // De ley para Alta
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
            String nombre = txt_nombre.Text;
            String contrasena = txt_contrasena.Text;
            Int16 rol=0;
            if(cmb_rol.SelectedIndex.Equals(0))
            {
                rol = 1;
            }
            else
            {
                rol = 2;
            }
            Int16 pregunta=0;
            if (cmb_pregunta.SelectedIndex.Equals(0))
            {
                pregunta = 1;
            }
            if (cmb_pregunta.SelectedIndex.Equals(1))
            {
                pregunta = 2;
            }
            if (cmb_pregunta.SelectedIndex.Equals(2))
            {
                pregunta = 3;
            }
            String respuesta = txt_respuesta.Text;

            String ValidaExistencia = cbd.RegresaDatosPrimariosSP(8, "", "", identificador);
            String ValidaExistenciaNom = cbd.RegresaDatosPrimariosSP(7, nombre, "", "");

            if (identificador == "" || nombre == "" || contrasena == "" || respuesta == "" | cmb_rol.SelectedIndex.Equals(-1) || cmb_pregunta.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                if (ValidaExistencia == "" && ValidaExistenciaNom == "")
                {
                    cbd.AdministraDatosUsuarioSP(TipOper, TipUser, identificador, nidentificador, nombre, contrasena, rol, pregunta, respuesta);
                    MessageBox.Show("ALTA EXITOSA");
                }
                else
                {
                    MessageBox.Show("DATOS EN USO ");
                }
                    
                   
            }
        }

        private void cmb_pregunta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_respuesta_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
