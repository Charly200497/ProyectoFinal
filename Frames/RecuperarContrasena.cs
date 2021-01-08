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
    public partial class RecuperarContrasena : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public RecuperarContrasena(String TipoUser)
        {
            InitializeComponent();
            GTipoUser = TipoUser;
            //MessageBox.Show("TipoUsuario" + GTipoUser);
            txt_NuevaContrasena.Visible = false;
            txt_RepetirContrasena.Visible = false;
            ChBox_NuevaContrsena.Visible = false;
            ChBox_RepetirContrsena.Visible = false;
            btn_guardar.Visible = false;
        }
        String GTipoUser = "";

        private void btn_verificar_Click(object sender, EventArgs e)
        {
            String nombre = txt_nombre.Text;
            String SupuestaRespuesta = txt_respuesta.Text;
            String Identificador ="";
            String SupuestaPregunta = "";
            String Pregunta = cbd.RegresaDatosPrimariosSP(6, nombre, SupuestaRespuesta, Identificador); //recibe la pregunta del usuario
            if (comboBox_pregunta.SelectedIndex.Equals(0))
            {
                SupuestaPregunta = "1";
            }
            if (comboBox_pregunta.SelectedIndex.Equals(1))
            {
                SupuestaPregunta = "2";
            }
            if (comboBox_pregunta.SelectedIndex.Equals(2))
            {
                SupuestaPregunta = "3";
            }
            
            String respuesta= cbd.RegresaDatosPrimariosSP(5, nombre, SupuestaRespuesta, Identificador); // recibe la respuesta del usuario

            if (SupuestaRespuesta == "" || comboBox_pregunta.SelectedIndex.Equals(-1) || nombre=="")
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                if (nombre == "ADMIN")
                {
                    MessageBox.Show("NO SE RECUPERAR CONTRASEÑA DEL ADMINIDTRADOR PRINCIPAL");
                }
                else
                {
                    if (respuesta == SupuestaRespuesta && SupuestaPregunta == Pregunta)
                    {
                        MessageBox.Show("DATOS VERIFICADOS; PROCEDE AL CAMBIO DE CONTRASEÑA");
                        txt_NuevaContrasena.Visible = true;
                        txt_RepetirContrasena.Visible = true;
                        ChBox_NuevaContrsena.Visible = true;
                        ChBox_RepetirContrsena.Visible = true;
                        btn_guardar.Visible = true;
                        txt_nombre.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("LOS DATOS NO COINCIDEN ");
                    }
                }
                    
            }            
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn(GTipoUser);
            login.Show();
            this.Close();
        }

        private void ChBox_Respuesta_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBox_Respuesta.Checked == true)
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

        private void ChBox_NuevaContrsena_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBox_NuevaContrsena.Checked == true)
            {
                if (txt_NuevaContrasena.PasswordChar == '#')
                {
                    txt_NuevaContrasena.PasswordChar = '\0';
                }
            }
            else
            {
                txt_NuevaContrasena.PasswordChar = '#';
            }
        }

        private void ChBox_RepetirContrsena_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBox_RepetirContrsena.Checked == true)
            {
                if (txt_RepetirContrasena.PasswordChar == '#')
                {
                    txt_RepetirContrasena.PasswordChar = '\0';
                }
            }
            else
            {
                txt_RepetirContrasena.PasswordChar = '#';
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            String contra1 = txt_NuevaContrasena.Text;
            String contra2 = txt_RepetirContrasena.Text;
            if(contra1=="" || contra2 == "")
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                if(contra1 != contra2)
                {
                    MessageBox.Show("LAS CONTRASEÑAS NO COINCIDEN");
                }
                else
                {
                    cbd.RegresaDatosPrimariosSP(4, txt_nombre.Text, contra1, "");
                    MessageBox.Show("CONTRASEÑA ACTUALIZADA CORRECTAMENTE");

                }
            }
        }
    }
}
