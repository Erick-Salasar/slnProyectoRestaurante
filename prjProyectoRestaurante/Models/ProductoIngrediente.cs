using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
    

    [Table("ProductoIngrediente")]
    public partial class ProductoIngrediente
    {
        [Key]
        
        public int IDProduIng { get; set; }

        public int? IDProducto { get; set; }

        public int? IDIngrediente { get; set; }

        public int? IDOrden { get; set; }

        public virtual Ingrediente Ingrediente { get; set; }

        public virtual Orden Orden { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
