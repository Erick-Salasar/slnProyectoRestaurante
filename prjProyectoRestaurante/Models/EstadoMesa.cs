using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
   
    [Table("EstadoMesa")]
    public partial class EstadoMesa
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDEstado { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        public virtual List<Mesa> Mesa { get; set; }
    }
}
