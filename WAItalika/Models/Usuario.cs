using System;
using System.Collections.Generic;

#nullable disable

namespace WAItalika.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
    }
}
