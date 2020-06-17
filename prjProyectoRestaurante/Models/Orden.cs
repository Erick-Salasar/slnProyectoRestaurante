using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
    

    [Table("Orden")]
    public partial class Orden
    {
        

        [Key]
        public int IDOrden { get; set; }

        
        public DateTime FechaOrden { get; set; }

        public int? IDMesa { get; set; }

        public virtual List<Factura> Factura { get; set; }

        public virtual Mesa Mesa { get; set; }

       public virtual List<ProductoIngrediente> ProductoIngrediente { get; set; }
    }
}
