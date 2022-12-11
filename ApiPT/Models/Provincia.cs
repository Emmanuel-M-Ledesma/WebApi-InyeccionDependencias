using System;
using System.Collections.Generic;

namespace ApiPT.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Sucursals = new HashSet<Sucursal>();
        }

        public int IdProvincia { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Sucursal> Sucursals { get; set; }
    }
}
