using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OticaCrista.Data.Mapping;
using OticaCrista.Models;
using OticaCrista.Models.Product;
using OticaCrista.Models.Sale;

namespace OticaCrista.Data
{
    public class OticaCristaContext : IdentityDbContext<ApplicationUser>
    {
        public OticaCristaContext(DbContextOptions<OticaCristaContext> options)
            : base(options)
        {
        }

        //Client
        public DbSet<ClientModel> Clients { get; set; }

        //Product and Service
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<BrandModel> Brands { get; set; }
        public DbSet<ServiceModel> Services { get; set; }

        //Sale
        public DbSet<SaleModel> Sales { get; set; }
        public DbSet<SaleProductItem> SalesProducts { get; set; }
        public DbSet<SaleServiceItem> SalesServices { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<Entry> Entries { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductMap(modelBuilder.Entity<ProductModel>());
            new SaleMap(modelBuilder.Entity<SaleModel>());

            modelBuilder.Entity<ClientModel>(client=>
            {
                client.Property(x => x.BornDate)
                    .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });
            modelBuilder.Entity<SaleModel>(sale =>
            {
                sale.Property(x => x.SaleDate)
                .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            });

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
                dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                dateTime=> DateOnly.FromDateTime(dateTime))
        {
        }
    }

    public class DateOnlyComparer : ValueComparer<DateOnly>
    {
        public DateOnlyComparer() : base(
            (d1, d2) => d1.DayNumber == d2.DayNumber,
            d => d.GetHashCode())
        {
        }
    }
}
