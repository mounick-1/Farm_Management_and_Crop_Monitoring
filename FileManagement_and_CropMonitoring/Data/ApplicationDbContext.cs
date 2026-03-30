using Microsoft.EntityFrameworkCore;
using FarmManagement_and_CropMonitoring.Models;

namespace FarmManagement_and_CropMonitoring.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Register your tables here
        public DbSet<Field> Fields { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceUsage> ResourceUsages { get; set; }
        public DbSet<PlantSchedule> PlantSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // This tells SQL: "QuantityInStock is a decimal, not an int!"
            modelBuilder.Entity<Resource>()
                .Property(r => r.QuantityInStock)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ResourceUsage>()
                .Property(u => u.QuantityUsed)
                .HasColumnType("decimal(18,2)");
            // This is the FIX: Tell SQL not to "Cascade" delete for PlantSchedules
            modelBuilder.Entity<PlantSchedule>()
                .HasOne(p => p.Field)
                .WithMany(f => f.PlantSchedules)
                .HasForeignKey(p => p.FieldId)
                .OnDelete(DeleteBehavior.Restrict); 
            // This prevents the "Multiple Cascade Paths" error
        }
    }
}