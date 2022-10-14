using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SISTEMADENOTAS.Models
{
    public partial class NotasEst
    {
        public int IdNotasE { get; set; }
        [DisplayName("Nombre")]
        [Required]
        public string? Nombre { get; set; }
        [DisplayName("Apellido")]
        [Required]
        public string? Apellido { get; set; }
        [DisplayName("Primer parcial")]
        [Range(0, 35)]
        public short? Ipn { get; set; }
        [DisplayName("Segundo parcial")]
        [Range(0, 35)]
        public short? Iipn { get; set; }
        [DisplayName("Sistematico")]
        [Range(0, 30)]
        public short? Siste { get; set; }
        [DisplayName("Proyecto")]
        [Range(0, 35)]
        public short? Proyect { get; set; }
        [DisplayName("Nota Final")]
        public short? Nf { get; set; }
    }
}
