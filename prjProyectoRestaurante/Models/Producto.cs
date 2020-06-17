using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
   
    [Table("Producto")]
    public partial class Producto
    {
        

        [Key]
        public int IDProducto { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

      
        public decimal Costo { get; set; }

        public decimal Precio { get; set; }

        public int? IDCategoria { get; set; }

        public int? IDIventaarioProdu { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual InventarioProdu InventarioProdu { get; set; }

        public virtual List<ProductoIngrediente> ProductoIngrediente { get; set; }
    }
}
