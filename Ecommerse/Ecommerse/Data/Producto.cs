using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerse.Data
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public int? IdCategoria { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal? PrecioProducto { get; set; }
        public int? Cantidad { get; set; }
    }
}
