using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
    

    [Table("Factura")]
    public partial class Factura
    {
        [Key]
        public int IDFactura { get; set; }

       
        public DateTime FechaFactura { get; set; }

        public int? IDPersona { get; set; }

        [StringLength(50)]
        public string EstadoDeFactura { get; set; }

        [StringLength(50)]
        public string Observacion { get; set; }

        public int? IDOrden { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual Orden Orden { get; set; }
    }
}
