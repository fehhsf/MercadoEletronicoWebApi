using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Infra.Data.Context
{
    public class MsSqlContext: DbContext
    {
		public DbSet<Pedido> Pedido { get; set; }
		public DbSet<ItemPedido> ItemPedido { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{	
			optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\fehh_\Downloads\MercadoEletronico\MercadoEletronicoWebApi\Modelo.Infra.Data\Context\DataBase\DataBase.mdf; Integrated Security = True");
		}
	}
}
