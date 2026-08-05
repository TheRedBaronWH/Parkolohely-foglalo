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
                new ParkingSpot { Row = 1, Column = 1 },
                new ParkingSpot { Row = 1, Column = 2 },
                new ParkingSpot { Row = 1, Column = 3 },
                new ParkingSpot { Row = 2, Column = 1 },
                new ParkingSpot { Row = 2, Column = 2 },
                new ParkingSpot { Row = 2, Column = 3 }
            );
            SaveChanges();
        }
        if (!Reservations.Any())
        {
            Reservations.AddRange(
                new ParkingSpotReservation { ParkingSpotId = 1, StartingTime = new DateTime(2026, 08, 05, 18, 00, 00), EndingTime = new DateTime(2026, 08, 06, 18, 00, 00), ReservedBy = "User" },
                new ParkingSpotReservation { ParkingSpotId = 2, StartingTime = new DateTime(2026, 12, 20, 12, 00, 00), EndingTime = new DateTime(2026, 12, 21, 21, 00, 00), ReservedBy = "User" },
                new ParkingSpotReservation { ParkingSpotId = 3, StartingTime = new DateTime(2026, 08, 05, 18, 30, 00), EndingTime = new DateTime(2026, 08, 08, 09, 00, 00), ReservedBy = "User" },
                new ParkingSpotReservation { ParkingSpotId = 1, StartingTime = new DateTime(2026, 08, 06, 18, 05, 00), EndingTime = new DateTime(2026, 08, 06, 18, 50, 00), ReservedBy = "User" }
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
