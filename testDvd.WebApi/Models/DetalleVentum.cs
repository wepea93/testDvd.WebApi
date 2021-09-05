using System;
using System.Collections.Generic;

#nullable disable

namespace testDvd.WebApi.Models
{
    public partial class DetalleVentum
    {
        public int Id { get; set; }
        public int CodVenta { get; set; }
        public int CodProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public virtual Producto CodProductoNavigation { get; set; }
        public virtual Ventum CodVentaNavigation { get; set; }
    }
}
