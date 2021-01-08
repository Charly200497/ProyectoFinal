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
    public partial class Mermas : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public Mermas(String TipoUser)
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
            Int16 TipoMerma;
            if (ChBox_TipoSalida.SelectedIndex.Equals(0))
            {
                TipoMerma = 1;
            }
            else
            {
                TipoMerma = 2;
            }
            String ValidaIdentificador = txt_identificador.Text;
            String ValidaUnidades = txt_cantidad.Text;

            String CadenaIdProduccto = cbd.RegresaDatosPrimariosSP(3, "", "", ValidaIdentificador);
            String CadenaIdUsuario = cbd.RegresaDatosPrimariosSP(7, GTipoUser, "", "");
            DateTime fsal = DateTime.Today;

            String ValidaExistencia = cbd.RegresaDatosPrimariosSP(9, "", "", ValidaIdentificador);
            String CadUnidadesExistentes = cbd.RegresaDatosPrimariosSP(10, "", "", ValidaIdentificador);

            if (ValidaUnidades == "" || ValidaIdentificador == "" || ChBox_TipoSalida.SelectedIndex.Equals(-1))
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
                    Int16 IdPoducto = Int16.Parse(CadenaIdProduccto);
                    int unidades = int.Parse(ValidaUnidades);
                    if (UnidadesExistentes < unidades)
                    {
                        MessageBox.Show("NO TIENES SUFICIENTES UNIDADES DE ESTE PRODUCTO, UNIDADES ACTUALES: " + UnidadesExistentes);
                    }
                    else
                    {
                        String fechasalida = fsal.ToString("yyyy-MM-dd");
                        //tipo merma
                        Int16 IdUsuario = Int16.Parse(CadenaIdUsuario);
                        cbd.AdministraDatosMermasSP(IdPoducto, unidades, fechasalida, TipoMerma, IdUsuario);
                        MessageBox.Show("SALIDA EXITOSA");
                    }
                    
                }
            }
        }
    }
}
