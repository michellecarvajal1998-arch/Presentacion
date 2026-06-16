using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(
                                        Properties.Settings.Default.BD
            );
        }
    }
    }
