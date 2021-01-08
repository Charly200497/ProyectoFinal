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
    public partial class AltaProductos : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public AltaProductos(String TipoUser)
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

        private void btn_daralta_Click(object sender, EventArgs e)
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

            String ValidaExistencia = cbd.RegresaDatosPrimariosSP(9, "", "", identificador);
            String ValidaExistenciaProductoNom = cbd.RegresaDatosPrimariosSP(15, nombre, "", "");

            if (identificador == "" || nombre == "" )
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                if (ValidaExistencia == "" && ValidaExistenciaProductoNom == "")
                {
                    cbd.AdministraDatosProductosSP(TipOper, TipUser, identificador, nidentificador, nombre);
                    MessageBox.Show("ALTA EXITOSA");
                    // DAR ENTRADA, SALIDA Y MERMA PARA CORRECTO FUNCIONAMIENTO DE LA BD
                    String CadenaIdProducto = cbd.RegresaDatosPrimariosSP(3, "", "", identificador);
                    Int16 IdProducto = Int16.Parse(CadenaIdProducto);
                    cbd.AdministraDatosEntradaSP(IdProducto,0,"ADMIN",0,"0001-01-01","3000-12-30",1);
                    cbd.AdministraDatosSalidaSP(IdProducto,0,0, "0001-01-01", 1);
                    cbd.AdministraDatosMermasSP(IdProducto,0,"0001-01-01", 1,1);
                }
                else
                {
                    MessageBox.Show("DATOS EN USO");
                }
                
            }
        }
    }
}
