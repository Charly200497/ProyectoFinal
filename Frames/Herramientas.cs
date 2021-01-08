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
    public partial class Herramientas : Form
    {
        public ConectaBD cbd = new ConectaBD();
        public Herramientas(String TipoUser)
        {
            InitializeComponent();
            GTipoUser = TipoUser;
            //MessageBox.Show("TipoUsuario" + GTipoUser);
            Rol = cbd.RegresaDatosPrimariosSP(2, GTipoUser, "", "");
            if (Rol == "2")
            {
                btn_alta_usuarios.Visible = false;
                btn_baja_usuarios.Visible = false;
                btn_modificar_usuarios.Visible = false;
                btn_consualtar_usuarios.Visible = false;
                btn_baja_productos.Visible = false;
                btn_modificar_productos.Visible = false;
                btn_alertas.Visible = false;
            }
        }
        String GTipoUser = "";
        String Rol = "";


    private void btn_regresar_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario(GTipoUser);
            inventario.Show();
            this.Close();
        }

        private void btn_alta_usuarios_Click(object sender, EventArgs e)
        {
            AltasDeUsuario altasdeusuario = new AltasDeUsuario(GTipoUser);
            altasdeusuario.Show();
            this.Close();
        }

        private void btn_baja_usuarios_Click(object sender, EventArgs e)
        {
            BajasDeUsuario bajasdeusuario = new BajasDeUsuario(GTipoUser);
            bajasdeusuario.Show();
            this.Close();
        }

        private void btn_modificar_usuarios_Click(object sender, EventArgs e)
        {
            ModificarUsuario modificarusuario = new ModificarUsuario(GTipoUser);
            modificarusuario.Show();
            this.Close();
        }

        private void btn_consualtar_usuarios_Click(object sender, EventArgs e)
        {
            ConsultaUsuarios consultarusuario = new ConsultaUsuarios(GTipoUser);
            consultarusuario.Show();
            this.Close();
        }

        private void btn_alta_productos_Click(object sender, EventArgs e)
        {
            AltaProductos altaproductos = new AltaProductos(GTipoUser);
            altaproductos.Show();
            this.Close();
        }

        private void btn_baja_productos_Click(object sender, EventArgs e)
        {
            BajaProductos bajaproductos = new BajaProductos(GTipoUser);
            bajaproductos.Show();
            this.Close();
        }

        private void btn_modificar_productos_Click(object sender, EventArgs e)
        {
            ModificarProducto modificarproducto = new ModificarProducto(GTipoUser);
            modificarproducto.Show();
            this.Close();
        }

        private void btn_historico_productos_Click(object sender, EventArgs e)
        {
            ConsultarProducto consultarproducto = new ConsultarProducto(GTipoUser);
            consultarproducto.Show();
            this.Close();
        }

        private void btn_entradas_Click(object sender, EventArgs e)
        {
            EntradaProducto entradaproducto = new EntradaProducto(GTipoUser);
            entradaproducto.Show();
            this.Close();
        }

        private void btn_salidas_Click(object sender, EventArgs e)
        {
            SalidaProducto salidaproducto = new SalidaProducto(GTipoUser);
            salidaproducto.Show();
            this.Close();
        }

        private void btn_alertas_Click(object sender, EventArgs e)
        {
            ConfiguracionAlertas configuracionalertas = new ConfiguracionAlertas(GTipoUser);
            configuracionalertas.Show();
            this.Close();
        }

        private void btn_listado_alertas_Click(object sender, EventArgs e)
        {
            ListadoAlertas listadoalertas = new ListadoAlertas(GTipoUser);
            listadoalertas.Show();
            this.Close();
        }

        private void btn_mermas_bajas_Click(object sender, EventArgs e)
        {
            Mermas mermas = new Mermas(GTipoUser);
            mermas.Show();
            this.Close();
        }

        private void btn_reportes_Click(object sender, EventArgs e)
        {
            Reportes reportes = new Reportes(GTipoUser);
            reportes.Show();
            this.Close();
        }

    }
}
