using System;
using System.Collections.Generic;

#nullable disable

namespace WAItalika.Models
{
    public partial class InventarioMoto
    {
        public string Sku { get; set; }
        public string Fert { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime Fecha { get; set; }
    }
}
