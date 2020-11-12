using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Service.Services
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository _itemPedidoRepository;
        public ItemPedidoService(IItemPedidoRepository itemPedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
        }

        public IList<ItemPedido> GetItemByIdPedido(int idPedido)
        {
            return _itemPedidoRepository.SelectAll().Where(x => x.IdPedido == idPedido).ToList();
        }
    }
}
