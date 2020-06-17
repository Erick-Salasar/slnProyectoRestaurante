using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace prjProyectoRestaurante.Models
{
    
    [Table("Categoria")]
    public partial class Categoria
    {
        

        [Key]
        public int IDCategoria { get; set; }

        [StringLength(18)]
        public string Descripcion { get; set; }

        public virtual List<Producto> Producto { get; set; }
    }
}
