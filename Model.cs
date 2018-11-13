using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
	public abstract class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual Product Product { get; set; }
	}

	public class Buyer : Person
	{
		public string ShipTo { get; set; }
	}

	public class Seller : Person
	{
		public int Rating { get; set; } = 0;
	}

	public class Product
	{
		public int Id { get; set; }

		public string Description { get; set; }
		public virtual Seller Seller { get; set; }
		public virtual IList<Buyer> Buyers { get; set; }
	}
}
