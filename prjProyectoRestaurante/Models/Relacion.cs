using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
    

    [Table("Relacion")]
    public partial class Relacion
    {
        

        [Key]
        public int IDRelacion { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public int? IDPersona { get; set; }

        public virtual Persona Persona { get; set; }

        public virtual List<Rol> Rol { get; set; }
    }
}
