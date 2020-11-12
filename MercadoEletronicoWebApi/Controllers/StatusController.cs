using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entities;
using Modelo.Service.DTO_s;
using Modelo.Service.Interfaces;
using Modelo.Service.Validators;


namespace MercadoEletronicoWebApi.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] StatusDTO item)
        {
            try
            {
                string status = _statusService.GetPedidoStatus(item);
                
                return new ObjectResult(status);
              
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
    }
}
