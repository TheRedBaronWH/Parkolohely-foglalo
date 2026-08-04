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
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath};Mode=ReadWriteCreate;Cache=Shared;");
    }
}
