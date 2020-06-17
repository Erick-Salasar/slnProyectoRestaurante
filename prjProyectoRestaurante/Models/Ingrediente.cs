using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
    

    [Table("Ingrediente")]
    public partial class Ingrediente
    {
        

        [Key]
        public int IDIngrediente { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public int? IDInventarioIngre { get; set; }

       public virtual List<ProductoIngrediente> ProductoIngrediente { get; set; }

        public virtual InventarioIngrediente InventarioIngrediente { get; set; }
    }
}
