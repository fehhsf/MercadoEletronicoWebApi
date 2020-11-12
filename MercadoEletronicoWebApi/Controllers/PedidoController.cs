using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoEletronicoWebApi.Data.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entities;
using Modelo.Service.Interfaces;
using Modelo.Service.Validators;

namespace MercadoEletronicoWebApi.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly IItemPedidoService _itemPedidoService;
        private readonly IService<Pedido> _restServicePedido;
        private readonly IService<ItemPedido> _restServiceItemPedido;

        public PedidoController(IPedidoService pedidoService, IService<Pedido> restServicePedido, IService<ItemPedido> restServiceItemPedido, IItemPedidoService itemPedidoService)
        {
            _pedidoService = pedidoService;
            _restServicePedido = restServicePedido;
            _restServiceItemPedido = restServiceItemPedido;
            _itemPedidoService = itemPedidoService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PedidoDTO item)
        {
            try
            {
                Pedido pedido = new Pedido
                {
                    NumeroPedido = item.NumeroPedido
                };

                _restServicePedido.Post<PedidoValidator>(pedido);

                IList<ItemPedido> itensPedido = item.itensPedido;

                foreach (ItemPedido itemPedido in itensPedido)
                {
                    itemPedido.IdPedido = pedido.Id;
                    _restServiceItemPedido.Post<ItemPedidoValidator>(itemPedido);
                }

                return Ok(pedido.Id);

            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        public IActionResult Get()
        {
            try
            {
                return Ok(_restServicePedido.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] PedidoDTO item)
        {
            try
            {
                Pedido pedido = _pedidoService.GetPedidoByNumeroPedido(item.NumeroPedido);
                IList<ItemPedido> itensPedido = _itemPedidoService.GetItemByIdPedido(pedido.Id); 

                _restServicePedido.Put<PedidoValidator>(pedido);

                foreach(ItemPedido itemPedido in itensPedido)
                {
                    itemPedido.Descricao = item.itensPedido.Where(x => x.Id == itemPedido.Id).Select(x => x.Descricao).FirstOrDefault();
                    itemPedido.PrecoUnitario = item.itensPedido.Where(x => x.Id == itemPedido.Id).Select(x => x.PrecoUnitario).FirstOrDefault();
                    itemPedido.Quantidade = item.itensPedido.Where(x => x.Id == itemPedido.Id).Select(x => x.Quantidade).FirstOrDefault();
                    _restServiceItemPedido.Put<ItemPedidoValidator>(itemPedido);
                }

                return Ok(item);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                IList<ItemPedido> itensPedido = _itemPedidoService.GetItemByIdPedido(id);

                foreach(ItemPedido itemPedido in itensPedido)
                {
                    _restServiceItemPedido.Delete(itemPedido.Id);
                }
                
                _restServicePedido.Delete(id);
                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}