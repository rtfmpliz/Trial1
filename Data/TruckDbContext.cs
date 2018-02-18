using trial1.Models;
using Microsoft.EntityFrameworkCore;

namespace trial1.Data
{
    public class TruckDbContext : DbContext
    {
        public TruckDbContext(DbContextOptions<TruckDbContext> options) : base(options)
        {
        }

        public DbSet<Karyawan> Karyawans { get; set; }
        public DbSet<Truck> Trucks { get; set; }
public DbSet<Kirim> Kirims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Karyawan>().ToTable("Karyawan");
            modelBuilder.Entity<Truck>().ToTable("Truck");
            modelBuilder.Entity<Kirim>().ToTable("Kirim");



        }
    }
}