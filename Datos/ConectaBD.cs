using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TakeControl.Datos
{
    public class ConectaBD
    {
        private SqlConnection con;
        private SqlDataReader lec;
        private SqlCommand comQry;

        private String CadConexion = "Data Source=DESKTOP-VECU2PJ; Initial Catalog=ISW_TakeControl; Trusted_Connection=True";

        public ConectaBD()
        {
            con = new SqlConnection(CadConexion);
        }

        private void ConBD()
        {
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar abrir la base de datos: " + ex.ToString());
            }
        }
        public void AdministraDatosUsuarioSP(Int16 tipoper, Int16 tipuser, String identificador, String Nidentificador, String nombre, String contrasena, Int16 rol, Int16 pregunta, String respuesta)
        {
            con.Open();
            bool exito = false;

            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.Serializable);

            try
            {
                comQry = new SqlCommand("SP_Data_Usuario", con, trans);
                comQry.CommandType = CommandType.StoredProcedure;
                comQry.Parameters.Clear();

                comQry.Parameters.AddWithValue("@TipOper", tipoper);
                comQry.Parameters.AddWithValue("@TipUser", tipuser);
                comQry.Parameters.AddWithValue("@identificador", identificador);
                comQry.Parameters.AddWithValue("@nuevoidentificador", Nidentificador);
                comQry.Parameters.AddWithValue("@nombre", nombre);
                comQry.Parameters.AddWithValue("@contrasena", contrasena);
                comQry.Parameters.AddWithValue("@rol", rol);
                comQry.Parameters.AddWithValue("@Pregunta_M", pregunta);
                comQry.Parameters.AddWithValue("@Respuesta_PM", respuesta);

                comQry.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("OPERCIÓN SOBRE USUARIO NO EXITOSA" + ex.ToString());
            }

            finally
            {
                if (exito)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
            }
            con.Close();
        }
        public void AdministraDatosProductosSP(Int16 tipoper, Int16 tipuser, String identificador, String Nidentificador, String nombre)
        {
            con.Open();
            bool exito = false;

            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.Serializable);

            try
            {
                comQry = new SqlCommand("SP_Data_Producto", con, trans);
                comQry.CommandType = CommandType.StoredProcedure;
                comQry.Parameters.Clear();

                comQry.Parameters.AddWithValue("@TipOper", tipoper);
                comQry.Parameters.AddWithValue("@TipUser", tipuser);
                comQry.Parameters.AddWithValue("@identificador", identificador);
                comQry.Parameters.AddWithValue("@nuevoidentificador", Nidentificador);
                comQry.Parameters.AddWithValue("@nombreprod", nombre);

                comQry.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("OPERCIÓN SOBRE PRODUCTO NO EXITOSA" + ex.ToString());
            }

            finally
            {
                if (exito)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
            }
            con.Close();
        }
        public void AdministraDatosEntradaSP(Int16 idproducto, int unidadesentrada, String proveedor, float costolote, String fechaentrada, String fechacaducidad, Int16 idusuario)
        {
            con.Open();
            bool exito = false;

            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.Serializable);

            try
            {
                comQry = new SqlCommand("SP_Data_Entradas", con, trans);
                comQry.CommandType = CommandType.StoredProcedure;
                comQry.Parameters.Clear();

                comQry.Parameters.AddWithValue("@idroducto", idproducto);
                comQry.Parameters.AddWithValue("@unidadesentrada", unidadesentrada);
                comQry.Parameters.AddWithValue("@proveedor", proveedor);
                comQry.Parameters.AddWithValue("@costolote", costolote);
                comQry.Parameters.AddWithValue("@fechaentrada", fechaentrada);
                comQry.Parameters.AddWithValue("@fechacaducidad", fechacaducidad);
                comQry.Parameters.AddWithValue("@idusuario", idusuario);

                comQry.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("OPERCIÓN SOBRE PRODUCTO NO EXITOSA" + ex.ToString());
            }

            finally
            {
                if (exito)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
            }
            con.Close();
        }
        public void AdministraDatosSalidaSP(Int16 idproducto, int unidadessalida, float preciounidad, String fechasalida, Int16 idusuario)
        {
            con.Open();
            bool exito = false;

            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.Serializable);

            try
            {
                comQry = new SqlCommand("SP_Data_Salidas", con, trans);
                comQry.CommandType = CommandType.StoredProcedure;
                comQry.Parameters.Clear();

                comQry.Parameters.AddWithValue("@idproducto", idproducto);
                comQry.Parameters.AddWithValue("@unidadessalida", unidadessalida);
                comQry.Parameters.AddWithValue("@preciounidad", preciounidad);
                comQry.Parameters.AddWithValue("@fechasalida", fechasalida);
                comQry.Parameters.AddWithValue("@idusuario", idusuario);

                comQry.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("OPERCIÓN SOBRE PRODUCTO NO EXITOSA" + ex.ToString());
            }

            finally
            {
                if (exito)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
            }
            con.Close();
        }
        public void AdministraDatosAlarmaSP(Int16 TipoOper, Int16 TipoUSer, Int16 idproducto, int maximo, int minimo, int antelacion)
        {
            con.Open();
            bool exito = false;

            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.Serializable);

            try
            {
                comQry = new SqlCommand("SP_Data_Alertas", con, trans);
                comQry.CommandType = CommandType.StoredProcedure;
                comQry.Parameters.Clear();

                comQry.Parameters.AddWithValue("@TipOper", TipoOper);
                comQry.Parameters.AddWithValue("@TipUser", TipoUSer);
                comQry.Parameters.AddWithValue("@idproducto", idproducto);
                comQry.Parameters.AddWithValue("@maximo", maximo);
                comQry.Parameters.AddWithValue("@minimo", minimo);
                comQry.Parameters.AddWithValue("@antelacion", antelacion);

                comQry.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("OPERCIÓN SOBRE PRODUCTO NO EXITOSA" + ex.ToString());
            }

            finally
            {
                if (exito)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
            }
            con.Close();
        }
        public void AdministraDatosMermasSP(Int16 idproducto, int unidades, String fechasalida, Int16 tipoMerma, Int16 IdUsuario)
        {
            con.Open();
            bool exito = false;

            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.Serializable);

            try
            {
                comQry = new SqlCommand("SP_Data_Mermas", con, trans);
                comQry.CommandType = CommandType.StoredProcedure;
                comQry.Parameters.Clear();

                comQry.Parameters.AddWithValue("@idproducto", idproducto);
                comQry.Parameters.AddWithValue("@unidadesmerma", unidades);
                comQry.Parameters.AddWithValue("@fechasalida", fechasalida);
                comQry.Parameters.AddWithValue("@tipomerma", tipoMerma);
                comQry.Parameters.AddWithValue("@idusuario", IdUsuario);

                comQry.ExecuteNonQuery();

                exito = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("OPERCIÓN SOBRE PRODUCTO NO EXITOSA" + ex.ToString());
            }

            finally
            {
                if (exito)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
            }
            con.Close();
        }
        public String RegresaDatosPrimariosSP(Int16 TipOper, String Usuario, String Contrasena, String IdentificadorProd)
        {
            String cadReg = "";
            DataTable tablaReg = new DataTable();
            con.Open();

            try
            {
                SqlDataAdapter datos = new SqlDataAdapter("SP_RegresaDatosPrimarios", con);
                datos.SelectCommand.CommandType = CommandType.StoredProcedure;
                datos.SelectCommand.Parameters.Add("@TipOper", TipOper);
                datos.SelectCommand.Parameters.Add("@Usuario", Usuario);
                datos.SelectCommand.Parameters.Add("@Contrasena", Contrasena);
                datos.SelectCommand.Parameters.Add("@IdentificadorProd", IdentificadorProd);

                datos.Fill(tablaReg);

                for (int i = 0; i < tablaReg.Rows.Count; i++)
                {
                    for (int j = 0; j < tablaReg.Columns.Count; j++)
                    {
                        cadReg += tablaReg.Rows[i][j].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DATOS NO RECUPERADOS" + ex.ToString());
            }
            con.Close();

            return cadReg;
        }

        public DataTable ImprimeTablas(Int16 TipoOper, Int16 IdUsuario)
        {
            String cadReg = "";
            DataTable tablaReg = new DataTable();
            SqlCommand cmd = new SqlCommand();
            con.Open();
            
            try
            {
                SqlDataAdapter datos = new SqlDataAdapter("SP_RegresaTablas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                datos.SelectCommand.CommandType = CommandType.StoredProcedure;
                datos.SelectCommand.Parameters.Add("@TipOper", TipoOper);
                datos.SelectCommand.Parameters.Add("@idUsuario", IdUsuario);

                datos.Fill(tablaReg);

            }
            catch (Exception ex)
            {
                MessageBox.Show("DATOS NO RECUPERADOS" + ex.ToString());
            }
            con.Close();

            return tablaReg ;
        }
        public DataTable MostrarReporte(int num, DateTime inicio, DateTime fin)
        {
            con.Open();
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_RegresaReporte", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@tipOper", num);
                da.SelectCommand.Parameters.Add("@Inicio_Fecha", inicio);
                da.SelectCommand.Parameters.Add("@Fin_Fecha", fin);
                da.Fill(dt);
            }

            catch (Exception ex)
            {
                MessageBox.Show("DATOS NO RECUPERADOS" + ex.ToString());
            }

            con.Close();
            return dt;
        }
        public String MostrarDatosReporte(int num, DateTime inicio, DateTime fin)
        {
            String cadReg = "";
            DataTable tablaReg = new DataTable();
            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_RegresaReporte", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@tipOper", num);
                da.SelectCommand.Parameters.Add("@Inicio_Fecha", inicio);
                da.SelectCommand.Parameters.Add("@Fin_Fecha", fin);
                da.Fill(tablaReg);

                for (int i = 0; i < tablaReg.Rows.Count; i++)
                {
                    for (int j = 0; j < tablaReg.Columns.Count; j++)
                    {
                        cadReg += tablaReg.Rows[i][j].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DATOS NO RECUPERADOS" + ex.ToString());
            }
            con.Close();

            return cadReg;
        }
    }
}