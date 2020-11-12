using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Service.DTO_s;
using Modelo.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Service.Services
{
    public class StatusService : IStatusService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public StatusService(IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _itemPedidoRepository = itemPedidoRepository;
        }

        public string GetPedidoStatus(StatusDTO status)
        {

            Pedido pedido = _pedidoRepository.SelectAll().Where(x => x.NumeroPedido == status.pedido).FirstOrDefault();

            StatusReturnDto retorno = new StatusReturnDto();      


            if (pedido == null)
                return JsonConvert.SerializeObject(new { status = "CODIGO_PEDIDO_INVALIDO" });
            else
            {   
                retorno.pedido = pedido.NumeroPedido;
                retorno.status = new List<string>();
                IList<ItemPedido> itensPedido = _itemPedidoRepository.SelectAll().Where(x => x.IdPedido == pedido.Id).ToList();
                

                if (status.status.ToUpper() == "REPROVADO")
                    retorno.status.Add("REPROVADO");
                if (status.itensAprovados == itensPedido.Sum(x => x.Quantidade)
                      && status.valorAprovado == itensPedido.Sum(x => x.PrecoUnitario * x.Quantidade) && status.status.ToUpper() == "APROVADO")
                    retorno.status.Add("APROVADO");
                if (status.valorAprovado < itensPedido.Sum(x => x.PrecoUnitario * x.Quantidade) && status.status.ToUpper() == "APROVADO")
                    retorno.status.Add("APROVADO_VALOR_A_MENOR");
                if (status.itensAprovados < itensPedido.Sum(x => x.Quantidade) && status.status.ToUpper() == "APROVADO")
                    retorno.status.Add("APROVADO_QTD_A_MENOR");
                if (status.valorAprovado > itensPedido.Sum(x => x.PrecoUnitario * x.Quantidade) && status.status.ToUpper() == "APROVADO")
                    retorno.status.Add("APROVADO_VALOR_A_MAIOR");
                if (status.itensAprovados > itensPedido.Sum(x => x.Quantidade) && status.status.ToUpper() == "APROVADO")
                    retorno.status.Add("APROVADO_QTD_A_MAIOR");
            }

            return JsonConvert.SerializeObject(retorno);
        }
    }
}
