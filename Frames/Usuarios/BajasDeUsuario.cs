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
    public partial class BajasDeUsuario : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public BajasDeUsuario(String TipoUser)
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

            Int16 TipOper = 2; // De ley para Baja
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
            String contrasena="";
            Int16 rol=1;
            Int16 pregunta=1;
            String respuesta="";

            String ValidaExistencia = cbd.RegresaDatosPrimariosSP(8, "", "", identificador);
            String MiIdentificador = cbd.RegresaDatosPrimariosSP(15, GTipoUser, "", "");

            if (identificador == "")
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
                        MessageBox.Show("NO SE PUEDE DAR DE BAJA AL ADMINIDTRADOR PRINCIPAL");
                    }
                    else
                    {
                        if (MiIdentificador == identificador)
                        {
                            MessageBox.Show("NO TE PUEDES DAR DE BAJA A TI MISMO");
                        }
                        else
                        {
                            cbd.AdministraDatosUsuarioSP(TipOper, TipUser, identificador, nidentificador, nombre, contrasena, rol, pregunta, respuesta);
                            MessageBox.Show("BAJA EXITOSA");
                        }                       
                            
                    }
                    
                }
                
            }
        }
    }
}
