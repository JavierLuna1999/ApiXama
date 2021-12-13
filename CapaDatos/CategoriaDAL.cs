using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
//bd
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace CapaDatos
{
    public class CategoriaDAL
    {

        public int eliminarQueja(int idqueja)
        {
            int rpta = 0;
            string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarQuejasCam", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idquejas", idqueja);
                        //insert,update o delete
                        rpta = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    rpta = 0;
                }
            }
            return rpta;
        }


        public List<CategoriaCLS> listarCategoria()
        {
            List<CategoriaCLS> lista = null;
            //"Data Source=SQL5077.site4now.net;Initial Catalog=db_a7d876_fincam;User Id=db_a7d876_fincam_admin;Password=root90root"
            string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            //definimos conexion
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //abrimos conexion
                    cn.Open();
                    //definio procedure
                    using (SqlCommand cmd = new SqlCommand("uspListarQuejasCam", cn))
                    {
                        //indica procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CategoriaCLS>();
                            CategoriaCLS oCategoriaCLS;
                            while (drd.Read())
                            {
                                oCategoriaCLS = new CategoriaCLS();
                                // int idquejas = drd.GetInt32(0);
                                oCategoriaCLS.iidqueja = drd.IsDBNull(0) ? 0 : drd.GetInt32(0);
                                oCategoriaCLS.localizacion = drd.IsDBNull(1) ? "" : drd.GetString(1);
                                oCategoriaCLS.descripcion = drd.IsDBNull(2) ? "" : drd.GetString(2);
                                oCategoriaCLS.municipio = drd.IsDBNull(3) ? "" : drd.GetString(3);
                                oCategoriaCLS.foto = drd.IsDBNull(4) ? "" : drd.GetString(4);
                                lista.Add(oCategoriaCLS);
                            }
                            cn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = null;
                    cn.Close();
                }

            }


            return lista;
        }
        //Guardar
        public int guardarQueja(CategoriaCLS oCategoriaCLS)
        {
            int rpta = 0;
            string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardaQuejascam", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idquejas", oCategoriaCLS.iidqueja);
                        cmd.Parameters.AddWithValue("@localizacion", oCategoriaCLS.localizacion);
                        cmd.Parameters.AddWithValue("@descripcion", oCategoriaCLS.descripcion);
                        cmd.Parameters.AddWithValue("@municipio", oCategoriaCLS.municipio);
                        cmd.Parameters.AddWithValue("@foto", oCategoriaCLS.foto);
                        //insert,update o delete
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    rpta = 0;
                }
            }
            return rpta;
        }
    }
}
