using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class UsuarioDatos
    {
        public List<UsuarioEntidad> Listar()
        {
            var lista = new List<UsuarioEntidad>();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT IdUsuario, Nombre, Apellido, Correo, Clave FROM Usuarios", cn);

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var u = new UsuarioEntidad
                        {
                            IdUsuario = dr["IdUsuario"] != DBNull.Value ? Convert.ToInt32(dr["IdUsuario"]) : 0,
                            Nombre = dr["Nombre"] as string,
                            Apellido = dr["Apellido"] as string,
                            Correo = dr["Correo"] as string,
                            Clave = dr["Clave"] as string
                        };

                        lista.Add(u);
                    }
                }
            }

            return lista;
        }

        public bool Guardar(UsuarioEntidad usuario)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                cn.Open();

                var cmd = new SqlCommand(
                    "INSERT INTO Usuarios (Nombre, Apellido, Correo, Clave)" +
                    " VALUES (@Nombre, @Apellido, @Correo, @Clave)", cn);

                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre ?? string.Empty);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido ?? string.Empty);
                cmd.Parameters.AddWithValue("@Correo", usuario.Correo ?? string.Empty);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave ?? string.Empty);

                var rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}
