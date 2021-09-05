using System;
using System.Collections.Generic;

#nullable disable

namespace testDvd.WebApi.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string RazonSocial { get; set; }
        public string Rut { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Url { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
