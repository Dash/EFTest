using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
	public class ProductSchema : EntityTypeConfiguration<Product>
	{
		public ProductSchema()
		{
			HasKey(p => p.Id)
				.Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(p => p.Description)
				.HasMaxLength(256);

			HasOptional(p => p.Seller)
				.WithRequired(i => i.Product)
				.Map(m => m.MapKey("ProductId"));

			HasMany(p => p.Buyers)
				.WithRequired(i => i.Product)
				.Map(m => m.MapKey("ProductId"));
		}
	}

	public class PersonSchema : EntityTypeConfiguration<Person>
	{
		public PersonSchema()
		{
			ToTable("Persons");

			HasKey(p => p.Id)
				.Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(p => p.Name)
				.HasMaxLength(128);
		}
	}

	public class SellerSchema : EntityTypeConfiguration<Seller>
	{
		public SellerSchema()
		{
			ToTable("Sellers");

			HasKey(s => s.Id)
				.Property(s => s.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(s => s.Rating);
		}
	}

	public class BuyerSchema : EntityTypeConfiguration<Buyer>
	{
		public BuyerSchema()
		{
			ToTable("Buyers");

			HasKey(b => b.Id)
				.Property(b => b.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(b => b.ShipTo)
				.HasMaxLength(256);
		}
	}
}
