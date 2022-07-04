using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Web;
using WebApplicationEjercicio.Models;

namespace WebApplicationEjercicio.Data
{
    public class ProductoData
    {
        public static bool Registrar(Producto oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", oProducto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", oProducto.Descripcion);
                cmd.Parameters.AddWithValue("@foto", SqlDbType.Image);


                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Producto oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SKUP", oProducto.SKUP);
                cmd.Parameters.AddWithValue("@Nombre", oProducto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", oProducto.Descripcion);
                cmd.Parameters.AddWithValue("@foto", oProducto.foto);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Producto> Listar()
        {
            List<Producto> oListaProducto = new List<Producto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                   /// cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaProducto.Add(new Producto()
                            {
                                SKUP = Convert.ToInt32(dr["SKUP"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),

                            });
                        }

                    }



                    return oListaProducto;
                }
                catch (Exception ex)
                {
                    return oListaProducto;
                }
            }
        }

        public static Producto Obtener(int SKUP)
        {
            Producto oProducto = new Producto();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SKUP", SKUP);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oProducto = new Producto()
                            {
                                SKUP = Convert.ToInt32(dr["SKUP"]),
                                Nombre= dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                
                            };
                        }

                    }



                    return oProducto;
                }
                catch (Exception ex)
                {
                    return oProducto;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SKUP", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        

    }

}