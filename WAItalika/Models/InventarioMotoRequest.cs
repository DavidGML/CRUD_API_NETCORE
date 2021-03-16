using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAItalika.Models
{
    public class InventarioMotoRequest
    {
        public string? Sku { get; set; }
        public string Fert { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string NumeroSerie { get; set; }
    }
}
