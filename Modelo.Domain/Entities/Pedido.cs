using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Modelo.Domain.Entities
{
    [Table("Pedido")]
    public class Pedido : BaseEntity
    {
        [Column("NumeroPedido")]
        public string NumeroPedido { get; set; }       
    }
}
