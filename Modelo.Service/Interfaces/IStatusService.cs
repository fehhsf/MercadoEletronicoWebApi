using Modelo.Domain.Entities;
using Modelo.Service.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Service.Interfaces
{
    public interface IStatusService
    {
        string GetPedidoStatus(StatusDTO status);
    }
}
