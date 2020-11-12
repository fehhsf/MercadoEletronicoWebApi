using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Domain.Entities
{
    [Table("ItemPedido")]
    public class ItemPedido : BaseEntity
    {
        [Column("IdPedido")]
        public int IdPedido { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("PrecoUnitario")]
        public double PrecoUnitario { get; set; }

        [Column("Quantidade")]
        public int Quantidade { get; set; }
    }
}
