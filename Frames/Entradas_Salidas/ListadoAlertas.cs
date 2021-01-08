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
    
    public partial class ListadoAlertas : Form
    {
        public ConectaBD cbd = new ConectaBD();
        DataTable dt = new DataTable();
        public ListadoAlertas(String TipoUser)
        {
            InitializeComponent();
            GTipoUser = TipoUser;
            //MessageBox.Show("TipoUsuario" + GTipoUser);
            String CadenaTipUser = cbd.RegresaDatosPrimariosSP(2, TipoUser, "", "");
            Int16 RolUSer = Int16.Parse(CadenaTipUser);

            dt = cbd.ImprimeTablas(4, RolUSer);
            DataGridViewAlertas.DataSource = dt;
            dt = cbd.ImprimeTablas(5, RolUSer);
            dgv_caducidad.DataSource = dt;
            dt = cbd.ImprimeTablas(6, RolUSer);
            dgv_maximos.DataSource = dt;
            dt = cbd.ImprimeTablas(7, RolUSer);
            dgv_minimos.DataSource = dt;

        }
        String GTipoUser = "";

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Herramientas herramientas = new Herramientas(GTipoUser);
            herramientas.Show();
            this.Close();
        }
    }
}
