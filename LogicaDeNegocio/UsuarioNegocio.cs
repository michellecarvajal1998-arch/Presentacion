using Datos;
using Entidades;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeNegocio
{
    public class UsuarioNegocio
    {
        UsuarioDatos datos = new UsuarioDatos();

        public List<UsuarioEntidad> Listar()
        {
            return datos.Listar();
        }

        public bool Guardar(UsuarioEntidad usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                return false;

            
            var existentes = datos.Listar();
            if (existentes != null && existentes.Any(u => u.Correo == usuario.Correo))
                return false; 

            return datos.Guardar(usuario);
        }
    }
}
