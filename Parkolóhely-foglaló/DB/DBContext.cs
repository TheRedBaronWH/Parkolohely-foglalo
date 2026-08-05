using Microsoft.EntityFrameworkCore;
using Parkolóhely_foglaló.Model;

namespace Parkolóhely_foglaló.DB;

public class ParkingDBContext: DbContext
{
    public DbSet<ParkingSpot> Spots { get; set; }
    public DbSet<ParkingSpotReservation> Reservations { get; set; }

    public string DbPath { get; }

    public ParkingDBContext()
    {
        //DbPath = @"..\..\..\parking.db";
        string appDataPath = FileSystem.AppDataDirectory;
        DbPath = Path.Combine(appDataPath, "parking.db");

        Database.EnsureCreated();

        if(!Spots.Any())
        {
            Spots.AddRange(
                new ParkingSpot { Row = 1, Column = 1, Electric = false },
                new ParkingSpot { Row = 1, Column = 2, Electric = false },
                new ParkingSpot { Row = 1, Column = 3, Electric = false },
                new ParkingSpot { Row = 2, Column = 1, Electric = false },
                new ParkingSpot { Row = 2, Column = 2, Electric = false },
                new ParkingSpot { Row = 2, Column = 3, Electric = false },
                new ParkingSpot { Row = 3, Column = 1, Electric = true },
                new ParkingSpot { Row = 3, Column = 2, Electric = true },
                new ParkingSpot { Row = 3, Column = 3, Electric = true }
            );
            SaveChanges();
        }
        if (!Reservations.Any())
        {
            Reservations.AddRange(
                new ParkingSpotReservation { ParkingSpotId = 1, StartingTime = DateTime.Now, EndingTime = DateTime.Now.AddDays(1), ReservedBy = "Anita" },
                new ParkingSpotReservation { ParkingSpotId = 2, StartingTime = new DateTime(2026, 12, 20, 12, 00, 00), EndingTime = new DateTime(2026, 12, 21, 21, 00, 00), ReservedBy = "Johnny" },
                new ParkingSpotReservation { ParkingSpotId = 3, StartingTime = DateTime.Now, EndingTime = DateTime.Now.AddMonths(1), ReservedBy = "admin" },
                new ParkingSpotReservation { ParkingSpotId = 1, StartingTime = DateTime.Now.AddDays(1).AddHours(-5), EndingTime = DateTime.Now.AddDays(1).AddHours(-3), ReservedBy = "Melinda" },
                new ParkingSpotReservation { ParkingSpotId = 7, StartingTime = DateTime.Now, EndingTime = DateTime.Now.AddDays(1), ReservedBy = "Scott" }
            );
            SaveChanges();
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath};Mode=ReadWriteCreate;Cache=Shared;");
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
