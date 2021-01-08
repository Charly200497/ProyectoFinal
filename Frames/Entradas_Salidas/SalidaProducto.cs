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
    public partial class SalidaProducto : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public SalidaProducto(String TipoUser)
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

        private void btn_darsalida_Click(object sender, EventArgs e)
        {
            String ValidaIdentificador = txt_identficador.Text;
            String CadenaIdProducto = cbd.RegresaDatosPrimariosSP(3, "", "", ValidaIdentificador);
            String ValidaUnidades = txt_unidades.Text;
            String ValidaPrecio = txt_preciounidad.Text;
            DateTime fsal = DateTime.Today;
            String CadenaIdUsuario = cbd.RegresaDatosPrimariosSP(7, GTipoUser, "", "");
            String ValidaExistencia = cbd.RegresaDatosPrimariosSP(9, "", "", ValidaIdentificador);

            String CadUnidadesExistentes = cbd.RegresaDatosPrimariosSP(10,"","",ValidaIdentificador);

            if (ValidaIdentificador == "" || ValidaUnidades == "" || ValidaPrecio == "")
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
                    int UnidadesExistentes = int.Parse(CadUnidadesExistentes);
                    
                    Int16 IdProducto = Int16.Parse(CadenaIdProducto);
                    int Unidades = int.Parse(ValidaUnidades);
                    if (UnidadesExistentes < Unidades)
                    {
                        MessageBox.Show("NO TIENES SUFICIENTES UNIDADES DE ESTE PRODUCTO, UNIDADES ACTUALES: "+UnidadesExistentes);
                    }
                    else
                    {
                        float Precio = float.Parse(ValidaPrecio);
                        String fechasalida = fsal.ToString("yyyy-MM-dd");
                        Int16 IdUsuario = Int16.Parse(CadenaIdUsuario);
                        cbd.AdministraDatosSalidaSP(IdProducto, Unidades, Precio, fechasalida, IdUsuario);
                        MessageBox.Show("SALIDA DE PRODUCTO EXITOSA ");
                    }
                    
                }
                
            }


        }
    }
}
