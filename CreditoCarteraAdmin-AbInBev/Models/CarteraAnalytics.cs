using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CreditoCarteraAdmin_AbInBev.Models
{
    public partial class CarteraAnalytics
    {
        public CarteraAnalytics()
        {
            SmsEnviados = 0;
            LlamadasHechas = 0;
        }

        public int Id { get; set; }
        [DisplayName ("Nombre de cliente")]
        public string NombreCliente { get; set; }
        [DisplayName("País")]
        public string Pais { get; set; }
        [DisplayName("Celular")]
        public string NumeroCelular { get; set; }
        [DisplayName("Adeudo")]
        public string ValorCartera { get; set; }
        [DisplayName("Fecha de vencimiento")]
        public DateTime FechaVencimiento { get; set; }
        public bool Habilitado { get; set; }
        [DisplayName("SMS Enviados")]
        public int SmsEnviados { get; set; }
        [DisplayName("Llamadas realizadas")]
        public int LlamadasHechas { get; set; }
    }
}
