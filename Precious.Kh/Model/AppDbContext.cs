using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Precious.Kh.Model
{
	public class AppDbContext : DbContext
	{
		public AppDbContext()
		{

		}

		public AppDbContext(DbContextOptions options) : base(options)
		{
		}
		//public DbSet<T> GetDbSet<T>() where T : class
		//{
		//	return Set<T>();
		//} 

		public DbSet<Account> Account { get; set; }
		public DbSet<AddressCustomer> AddressCustomer { get; set; }
		public DbSet<Bill> Bill { get; set; }
		public DbSet<BillDetail> BillDetail { get; set; }
		public DbSet<Brand> Brand { get; set; }
		public DbSet<Cart> Cart { get; set; }
		public DbSet<CartDetail> CartDetail { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Color> Color { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<FavoriteProducts> FavoriteProducts { get; set; }
		public DbSet<ImageProductDetail> ImageProductDetail { get; set; }
		public DbSet<Product> Product { get; set; }
		public DbSet<ProductDetail> ProductDetail { get; set; }
		public DbSet<Sale> Sale { get; set; }
		public DbSet<Size> Size { get; set; }
		public DbSet<Staff> Staff { get; set; }
		public DbSet<TagetCustomers> TagetCustomers { get; set; }
		public DbSet<Voucher> Voucher { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=NIHONGGOO\\SQLEXPRESS;Database=Precious;Trusted_Connection=True;TrustServerCertificate=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
