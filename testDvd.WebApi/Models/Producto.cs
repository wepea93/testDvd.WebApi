using System;
using System.Collections.Generic;

#nullable disable

namespace testDvd.WebApi.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public int CodProveedor { get; set; }
        public string Estado { get; set; }

        public virtual Proveedor CodProveedorNavigation { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
