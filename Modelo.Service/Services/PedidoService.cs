using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Service.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public Pedido GetPedidoByNumeroPedido(string numeroPedido)
        {
            return _pedidoRepository.SelectAll().Where(x => x.NumeroPedido == numeroPedido).FirstOrDefault();
        }
    }
}
