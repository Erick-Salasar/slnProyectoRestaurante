using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;


namespace prjProyectoRestaurante.Models
{
   

    [Table("Genero")]
    public partial class Genero
    {
        
        [Key]
        public int IDGenero { get; set; }

        
        public char Sigla { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public virtual List<Persona> Persona { get; set; }
    }
}
