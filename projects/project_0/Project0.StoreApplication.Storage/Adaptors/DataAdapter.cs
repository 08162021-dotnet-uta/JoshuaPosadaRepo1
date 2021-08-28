// using Microsoft.EntityFrameworkCore;

// namespace Project0.StoreAPplication.Storage.Adaptors
// {
//   public class DataAdapter : DbContext
//   {
//     public DbSet<Customer> Customers {get; set;}
//     public DbSet<Order> Orders {get; set;}
//     public DbSet<Product> Products {get; set;}
//     public DbSet<Store> Stores {get; set;}

//     protected override void OnConfiguring(DbContextOptionBuilder builder)
//     {
//       builder.UseSqlServer(@"Server=(localdb)\cmssqllocaldb;Database=Blogging;Trusted_Connection=True");
//     }
//   }

// }