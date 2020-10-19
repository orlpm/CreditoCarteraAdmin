using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CreditoCarteraAdmin_AbInBev.Models
{
    public class FrecuenciaNotificaciones
    {
        public FrecuenciaNotificaciones()
        {
            RondasEnviadas = 0;
        }
        public int Id { get; set; }
        [Required]
        [DisplayName("Nombre de campaña")]
        public string NombreCampaña { get; set; }
        [Required]
        [DisplayName("Días de previos de campaña")]
        public int DiasPrevios { get; set; }
        [Required]
        [DisplayName("Mensajes Maximos")]
        public int NumeroEnvios  { get; set; }
        [DisplayName("Hora de envío")]
        public string HoraEnvio { get; set; }
        [DisplayName("Cada minuto")]
        [Required]
        public int CadaMinuto { get; set; }
        [DisplayName("Cada hora")]
        public int CadaHora { get; set; }
        public int RondasEnviadas { get; set; }
    }
}
