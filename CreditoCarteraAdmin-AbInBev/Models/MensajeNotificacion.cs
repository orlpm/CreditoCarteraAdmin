using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditoCarteraAdmin_AbInBev.Models
{
    public class MensajeNotificacion
    {
        public int Id { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Mensaje { get; set; }
        [DisplayName("Días previos de mensaje")]
        [Required]
        public int DiasPrevios { get; set; }
    }
}
