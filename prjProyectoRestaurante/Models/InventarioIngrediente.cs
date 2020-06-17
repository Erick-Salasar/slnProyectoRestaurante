using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
    

    [Table("InventarioIngrediente")]
    public partial class InventarioIngrediente
    {
        

        [Key]
        public int IDInventarioIngre { get; set; }

        
        public decimal Cantidad { get; set; }

        
        public decimal CantidadMinima { get; set; }

        public virtual List<Ingrediente> Ingrediente { get; set; }
    }
}
