using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Service.Interfaces
{
    public interface IItemPedidoService
    {

        IList<ItemPedido> GetItemByIdPedido(int idPedido);
    }
}
