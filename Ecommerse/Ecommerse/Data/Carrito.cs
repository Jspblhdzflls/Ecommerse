using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerse.Data
{
    public partial class Carrito
    {
        public int IdCarrito { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdArticulo { get; set; }
        public int? Cantidad { get; set; }
    }
}
