using System;
using System.Collections.Generic;

#nullable disable

namespace testDvd.WebApi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
        }

        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string NombreCompleto { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
