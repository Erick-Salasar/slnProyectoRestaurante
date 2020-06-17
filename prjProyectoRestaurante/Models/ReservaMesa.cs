using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
    
    [Table("ReservaMesa")]
    public partial class ReservaMesa
    {
        

        [Key]
        public int IDReservaMesa { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(11)]
        public string Telefono { get; set; }

        
        public DateTime HoraReserva { get; set; }

        public virtual List<Mesa> Mesa { get; set; }
    }
}
