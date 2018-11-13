using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
	public class Context : DbContext
	{
		public Context() : base() { Init(); }
		public Context(string nameOrConnectionString) : base(nameOrConnectionString) { Init(); }

		public void Init()
		{
			this.Database.Log = (s) => {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine(s);
				Console.ResetColor();
				};
			Database.SetInitializer < Context > (null);
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Configurations.Add(new ProductSchema());
			modelBuilder.Configurations.Add(new PersonSchema());
			modelBuilder.Configurations.Add(new SellerSchema());
			modelBuilder.Configurations.Add(new BuyerSchema());
		}
	}
}
