using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
    

    [Table("Mesa")]
    public partial class Mesa
    {
       

        [Key]
        public int IDMesa { get; set; }

        
        public int NumeroMesa { get; set; }

        public int? IDEstado { get; set; }

        public int? IDReservaMesa { get; set; }

        public virtual EstadoMesa EstadoMesa { get; set; }

        public virtual ReservaMesa ReservaMesa { get; set; }

        public virtual List<Orden> Orden { get; set; }
    }
}
