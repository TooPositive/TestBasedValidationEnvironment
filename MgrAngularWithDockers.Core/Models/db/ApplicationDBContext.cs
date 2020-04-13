using MgrAngularWithDockers.Core.Models.db.Interfaces;
using MgrAngularWithDockers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MgrAngularWithDockers.Core.Models.db
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    //var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        //    IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
        //         .AddJsonFile("appsettings.json", optional: false)
        //         //.AddJsonFile($"appsettings.{envName}.json", optional: true)
        //         .Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TestResult>()
        //        .Property(x=> x.Id).IsRequired()
        //        .Property(x=> x.).IsRequired()
        //}

        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
    }
}
