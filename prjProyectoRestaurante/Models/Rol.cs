using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
    

    [Table("Rol")]
    public partial class Rol
    {
        [Key]
        public int IDRol { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public int IDRelacion { get; set; }

        public virtual Relacion Relacion { get; set; }
    }
}
