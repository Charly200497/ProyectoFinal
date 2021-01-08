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
    public partial class ModificarUsuario : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public ModificarUsuario(String TipoUser)
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

        private void ChBox_Contrasena_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBox_Contrasena.Checked == true)
            {
                if (txt_contrsena.PasswordChar == '#')
                {
                    txt_contrsena.PasswordChar = '\0';
                }
            }
            else
            {
                txt_contrsena.PasswordChar = '#';
            }
        }

        private void btn_modificar_usuario_Click(object sender, EventArgs e)
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
            String nidentificador = txt_newidentificador.Text;
            String nombre = txt_newnombre.Text;
            String contrasena = txt_contrsena.Text;
            Int16 rol = 0;
            if (cmb_rol.SelectedIndex.Equals(0))
            {
                rol = 1;
            }
            else
            {
                rol = 2;
            }
            Int16 pregunta = 0;
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

            if (identificador == "" || nombre == "" || contrasena == "" || nidentificador == "" || respuesta == "" | cmb_rol.SelectedIndex.Equals(-1) || cmb_pregunta.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                if (ValidaExistencia == "")
                {
                    MessageBox.Show("EL USUARIO CON EL IDENTIFICADOR " + identificador + " NO EXISTE");
                }
                else
                {
                    if (identificador == "ADMIN")
                    {
                        MessageBox.Show("NO SE PUEDE MODIFICAR AL ADMINIDTRADOR PRINCIPAL");
                    }
                    else
                    {
                        cbd.AdministraDatosUsuarioSP(TipOper, TipUser, identificador, nidentificador, nombre, contrasena, rol, pregunta, respuesta);
                        MessageBox.Show("MODIFICACIÓN EXITOSA");
                    }
                    
                }
               

            }            
        }
    }
}
