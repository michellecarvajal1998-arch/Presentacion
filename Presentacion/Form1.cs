using Entidades;
using LogicaDeNegocio;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        UsuarioNegocio negocio = new UsuarioNegocio();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var usuario = new UsuarioEntidad
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Correo = txtCorreo.Text,
                Clave = txtClave.Text
            };

            var ok = negocio.Guardar(usuario);
            if (ok)
            {
                MessageBox.Show("Usuario guardado correctamente.");
            }
            else
            {
                MessageBox.Show("No se pudo guardar el usuario (campos inválidos o correo duplicado).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}