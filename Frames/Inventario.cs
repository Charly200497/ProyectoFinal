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
    public partial class Inventario : Form
    {
        public ConectaBD cbd = new ConectaBD();
        DataTable dt = new DataTable();
        public Inventario(String TipoUser)
        {
            InitializeComponent();
            GTipoUser = TipoUser;
            String CadenaTipUser = cbd.RegresaDatosPrimariosSP(2, TipoUser, "", "");
            Int16 RolUSer = Int16.Parse(CadenaTipUser);
            dt =cbd.ImprimeTablas(1, RolUSer);
            DataGridViewInventario.DataSource = dt;


        }
        String GTipoUser = "";
        private void Inventario_Load(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn(GTipoUser);
            login.Show();
            this.Close();
        }

        private void btn_herramientas_Click(object sender, EventArgs e)
        {
            Herramientas herramientas = new Herramientas(GTipoUser);
            herramientas.Show();
            this.Close();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
