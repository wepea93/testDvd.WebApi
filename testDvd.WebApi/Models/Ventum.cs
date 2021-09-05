using System;
using System.Collections.Generic;

#nullable disable

namespace testDvd.WebApi.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int CodCliente { get; set; }
        public decimal Descuento { get; set; }
        public decimal ValorNeto { get; set; }
        public decimal ValorTotal { get; set; }
        public string Estado { get; set; }

        public virtual Cliente CodClienteNavigation { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
