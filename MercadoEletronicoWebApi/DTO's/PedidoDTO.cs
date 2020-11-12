using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoEletronicoWebApi.Data.DTO_s
{
    public class PedidoDTO
    {
        public string NumeroPedido;
        public IList<ItemPedido> itensPedido; 
    }
}
