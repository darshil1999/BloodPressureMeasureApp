using Microsoft.EntityFrameworkCore;
namespace BloodPressureMeasureApp.Entities
{
    public class BloodPressureDbContext : DbContext
    {
        public BloodPressureDbContext(DbContextOptions<BloodPressureDbContext> option) : base(option) { }

        public DbSet<BloodPressure> BloodPressures { get; set; }
        public DbSet<Position> Positions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodPressure>(entity =>
            {
                entity.Property(e => e.MeasurementDate).HasColumnType("date");
            });
            modelBuilder.Entity<Position>().ToTable("Position");

            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = "standing", PositionName = "Standing" },
                new Position { PositionId = "sitting", PositionName = "Sitting" },
                new Position { PositionId = "lying_down", PositionName = "Lying Down" }
            );

            modelBuilder.Entity<BloodPressure>().HasData(
                new BloodPressure() { BloodPressureId = 1, Systolic = 181, Diastolic = 121, MeasurementDate = new DateTime(2008, 7, 2), PositionId = "standing" },
                new BloodPressure() { BloodPressureId = 2, Systolic = 142, Diastolic = 91, MeasurementDate = new DateTime(2005, 5, 29), PositionId = "lying_down" },
                new BloodPressure() { BloodPressureId = 3, Systolic = 131, Diastolic = 85, MeasurementDate = new DateTime(2002, 11, 24), PositionId = "standing" },
                new BloodPressure() { BloodPressureId = 4, Systolic = 122, Diastolic = 79, MeasurementDate = new DateTime(1998, 5, 8), PositionId = "sitting" },
                new BloodPressure() { BloodPressureId = 5, Systolic = 118, Diastolic = 78, MeasurementDate = new DateTime(1996, 2, 9), PositionId = "sitting" },
                new BloodPressure() { BloodPressureId = 6, Systolic = 160, Diastolic = 100, MeasurementDate = new DateTime(1999, 11, 30), PositionId = "lying_down" }
                );

        }
    }
}
