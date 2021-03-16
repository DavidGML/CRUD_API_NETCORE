using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAItalika.Models
{
    public class AuthRequest
    {
        [Required]
        public string nombre_usuario { get; set; }

        [Required]
        public string contraseña { get; set; }
    }
}
