using MediatR.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


    namespace MediatR.Infrastructure
    {
        public class DBContext_App : DbContext
        {
        public DBContext_App() { }
            public DBContext_App(DbContextOptions<DBContext_App> options) : base(options) { }
            public DbSet<Product> Products { get; set; }
           
            public DbSet<User> Users { get; set; }

            public DbSet<Role> Roles { get; set; }
            public DbSet<UserRoles> UserRoles { get; set; }





            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-RQ5G2OC;Database=MediatR_Database_3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<UserRoles>().HasKey(sc => new { sc.UserId, sc.RoleId});
 
                base.OnModelCreating(modelBuilder);
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            }
        }
    }

