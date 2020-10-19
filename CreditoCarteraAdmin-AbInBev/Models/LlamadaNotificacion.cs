using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditoCarteraAdmin_AbInBev.Models
{
    public class LlamadaNotificacion
    {
        public int Id { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        [DisplayName("URL")]
        public string BlobStorageURL { get; set; }
        [Required]
        [DisplayName("Días previos de llamada")]
        public int DiasPrevios { get; set; }
    }
}
