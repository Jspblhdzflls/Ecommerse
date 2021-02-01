using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerse.Data
{
    public partial class Review
    {
        public int IdReview { get; set; }
        public int? IdProducto { get; set; }
        public DateTime? FechaReview { get; set; }
        public int? IdUsuario { get; set; }
    }
}
