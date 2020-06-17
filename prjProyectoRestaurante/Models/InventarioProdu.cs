using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
   
    [Table("InventarioProdu")]
    public partial class InventarioProdu
    {
        
        [Key]
        public int IDIventaarioProdu { get; set; }

        
        public decimal Cantidad { get; set; }

       
        public decimal CantidadMinima { get; set; }

        public virtual List<Producto> Producto { get; set; }
    }
}
