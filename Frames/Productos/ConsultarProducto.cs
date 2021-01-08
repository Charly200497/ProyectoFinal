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
    public partial class ConsultarProducto : Form
    {
        public ConectaBD cbd = new ConectaBD();
        DataTable dt = new DataTable();
        
        public ConsultarProducto(String TipoUser)
        {
            InitializeComponent();
            GTipoUser = TipoUser;
            //MessageBox.Show("TipoUsuario" + GTipoUser);
            String CadenaTipUser = cbd.RegresaDatosPrimariosSP(2, TipoUser, "", "");
            Int16 RolUSer = Int16.Parse(CadenaTipUser);
            dt = cbd.ImprimeTablas(3,RolUSer);
            DataGridViewProductos.DataSource = dt;
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
