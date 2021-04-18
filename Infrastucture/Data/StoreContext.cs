using Microsoft.EntityFrameworkCore;
using System.Reflection;

using Core.Entities;

namespace Infrastucture.Data
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options):base(options){

        }
        public DbSet<Product> Products{get;set;}
        public DbSet<ProductBrand> ProductBrand{get;set;}
        public DbSet<ProductType> ProductType{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            ModelBuilder modelBuilder1 = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}