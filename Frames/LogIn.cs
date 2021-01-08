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
    public partial class LogIn : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public LogIn(String TipoUser)
        {
            InitializeComponent();
        }
        String GTipoUser = "";
        String GNomUsuario = "";
        private void btn_acceder_Click(object sender, EventArgs e)
        {
            Int16 tipoper = 1;
            String usuario = txt_usuario.Text; 
            String SupuestaContra = txt_contrasena.Text;
            String Identificador = "";
            String contrasena = cbd.RegresaDatosPrimariosSP(tipoper, usuario, SupuestaContra, Identificador);

            //Datos para contener al usuario
            String Rol_inicial = cbd.RegresaDatosPrimariosSP(2, usuario, SupuestaContra, Identificador);
            String Mostrar_Rol = "";
            GTipoUser = usuario;
            GNomUsuario = usuario;
            if (SupuestaContra=="" || usuario=="")
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                if (SupuestaContra == contrasena)
                {
                    
                    Inventario inventario = new Inventario(GTipoUser);
                    inventario.Show();
                    this.Close();

                    if (Rol_inicial == "1")
                    {
                        Mostrar_Rol = "ADMINISTRADOR";
                    }
                    else 
                    {
                        Mostrar_Rol = "USUARIO";
                    }
                    MessageBox.Show("BIENVENIDO "+usuario+":"+Mostrar_Rol);
                }
                else
                {
                    MessageBox.Show("CREDENCIALES INCORRECTAS");
                }
            }

            
            
        }

        private void btn_recuperar_Click(object sender, EventArgs e)
        {
            RecuperarContrasena recuperarcontrasena = new RecuperarContrasena(GTipoUser);
            recuperarcontrasena.Show();
            this.Close();
        }
        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void ChBox_MostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            if(ChBox_MostrarContrasena.Checked == true)
            {
                if(txt_contrasena.PasswordChar == '#')
                {
                    txt_contrasena.PasswordChar = '\0';
                }
            }
            else
            {
                txt_contrasena.PasswordChar = '#';
            }
        }
    }
}
