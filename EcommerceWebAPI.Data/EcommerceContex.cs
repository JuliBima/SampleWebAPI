using EcommerceWebAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebAPI.Data
{
    public class EcommerceContex : DbContext
    {
        public EcommerceContex()
        {

        }

        public EcommerceContex(DbContextOptions<EcommerceContex> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Produk> Produks { get; set; }
        public DbSet<Katalog> Katalogs { get; set; }
        public DbSet<TypeProduk> TypeProduks { get; set; }
        public DbSet<Keranjang> Keranjangs { get; set; }
        public DbSet<Transaksi> Transaksis { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ecommerce")
                 .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
                 Microsoft.Extensions.Logging.LogLevel.Information).EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasMany(e => e.Produks).WithMany(s => s.Users)
               .UsingEntity<Keranjang>(es => es.HasOne<Produk>().WithMany(),
               bs => bs.HasOne<User>().WithMany());

            modelBuilder.Entity<Katalog>().HasMany(e => e.Produks).WithMany(s => s.Katalogs)
               .UsingEntity<KatalogProduk>(es => es.HasOne<Produk>().WithMany(),
               bs => bs.HasOne<Katalog>().WithMany());

        }
    }
}