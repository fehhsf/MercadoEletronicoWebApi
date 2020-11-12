using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Service.Interfaces
{
    public interface IPedidoService 
    {
        Pedido GetPedidoByNumeroPedido(string numeroPedido);
    }
}
