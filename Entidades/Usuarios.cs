using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string ConfirmarContra { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }


        public Usuarios()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            NombreUsuario = string.Empty;
            Email = string.Empty;
            Contrasena = string.Empty;
            ConfirmarContra = string.Empty;
            FechaIngreso = DateTime.Now;
            Telefono = string.Empty;
            Cedula = string.Empty;
        }
        //public Usuarios(string nombre, string contrasena, string confirmar)
        //{
        //    this.Nombre = nombre;
        //    this.Contrasena = contrasena;
        //    this.ConfirmarContra = confirmar;
        //}

        //public override string ToString()
        //{
        //    return Nombre;
        //}
    }
}
