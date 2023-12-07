using MediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace MediatR.Infrastructure
{
    public class DBContext_App : DbContext
    {
      
        public DBContext_App(DbContextOptions<DBContext_App> options) : base(options) { }
        public DbSet<Product> Products { get; set; }





        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-RQ5G2OC;Database=MediatR_EX;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        //}
    }
}
