using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace prjProyectoRestaurante.Models
{
    
    [Table("Persona")]
    public partial class Persona
    {
        
        [Key]
        public int IDPersona { get; set; }

        [StringLength(11)]
        public string Cedula { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string ApellidoPa { get; set; }

        [StringLength(50)]
        public string ApellidoMa { get; set; }

        
        public DateTime FechaNacimiento { get; set; }

       
        public DateTime FechaRegistro { get; set; }

        [StringLength(50)]
        public string Direccion { get; set; }

        [StringLength(11)]
        public string TelefonoCel { get; set; }

        [StringLength(11)]
        public string TelefonoDom { get; set; }

        [StringLength(11)]
        public string Usuario { get; set; }

        [StringLength(11)]
        public string Contraseña { get; set; }

        public int? IDGenero { get; set; }

        public virtual List<Factura> Factura { get; set; }

        public virtual Genero Genero { get; set; }

        public virtual List<Relacion> Relacion { get; set; }
    }
}
