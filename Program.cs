using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static System.Console;

namespace EFTest
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Context c = new Context("Server=(local);Database=EFTest;Integrated Security=SSPI");

				var everything = c.Set<Product>()
									.Include(p => p.Buyers)
									.Include(p => p.Seller);

				WriteLine("{0} products", everything.Count());


				foreach (var item in everything)
				{
					WriteLine("******************");
					WriteLine("{0}.  Seller: {1} ({2})", item.Description, item.Seller.Name, item.Seller.Rating);
					WriteLine("Buyers:");
					foreach (var buyer in item.Buyers)
					{
						WriteLine("{0}: {1}", buyer.Name, buyer.ShipTo);
					}
				}
			}
			catch(Exception ex)
			{
				WriteLine(ex.ToString());
			}

			WriteLine("Done");
			ReadLine();
		}
	}
}
