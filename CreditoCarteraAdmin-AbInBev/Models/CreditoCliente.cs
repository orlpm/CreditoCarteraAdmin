using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CreditoCarteraAdmin_AbInBev.Models
{
    public partial class CreditoCliente
    {
        public CreditoCliente()
        {
            NumeroEnvios = 0;
        }
        public int Id { get; set; }
        [DisplayName("Nombre de cliente")]
        public string NombreCliente { get; set; }
        [DisplayName("Crédito anterior")]
        public int CreditoAnterior { get; set; }
        [DisplayName("Crédito nuevo")]
        public int CreditoNuevo { get; set; }
        [DisplayName("Fecha de registro")]
        public DateTime FechaRegistro { get; set; }
        [DisplayName("Cliente nuevo")]
        public bool ClienteNuevo { get; set; }
        [DisplayName("Crédito nuevo")]
        public bool StatusCreditoNuevo { get; set; }
        [DisplayName("Celular")]
        public string NumeroCelular { get; set; }
        [DisplayName("SMS Enviados")]
        public int NumeroEnvios { get; set; }
    }
}
