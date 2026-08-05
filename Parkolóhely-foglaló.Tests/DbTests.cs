using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Parkolóhely_foglaló.Core.DB;
using Parkolóhely_foglaló.Core.Model;
using Parkolóhely_foglaló.Core.Controller;
using TUnit.Core;

namespace Parkolóhely_foglaló.Tests;

public class DbTests
{
    private SqliteConnection connection = null;
    private ParkingDBContext context = null;

    [Before(Test)]
    public async Task SetupDb()
    {
        connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<ParkingDBContext>()
            .UseSqlite(connection)
            .Options;
        context = new ParkingDBContext(options);
        await context.Database.EnsureCreatedAsync();
    }

    [Test]
    public async Task AddSpot()
    {
        int count = context.Spots.Count();

        ParkingSpot spot = new ParkingSpot { Electric = true, Row = 6, Column = 6 };
        await ParkingDbApi.AddParkingSpot(spot);
        await context.SaveChangesAsync();

        await Assert.That(count).IsEqualTo(context.Spots.Count() - 1);
        await Assert.That(context.Spots.Contains(spot)).IsTrue();
    }

    [Test]
    public async Task RemoveSpot()
    {
        int count = context.Spots.Count();

        ParkingSpot spot = new ParkingSpot { Electric = true, Row = 6, Column = 6 };
        await ParkingDbApi.AddParkingSpot(spot);
        await context.SaveChangesAsync();

        await ParkingDbApi.RemoveParkingSpot(spot);
        await context.SaveChangesAsync();

        await Assert.That(count).IsEqualTo(context.Spots.Count());
        await Assert.That(context.Spots.Contains(spot)).IsFalse();
    }

    [Test]
    public async Task AddReservation()
    {
        int count = context.Reservations.Count();

        ParkingSpot spot = context.Spots.First();
        ParkingSpotReservation reservation = await ReservationHandler.TryAddReservation("admin", spot, DateTime.Now, DateTime.Now.AddHours(1));
        await context.SaveChangesAsync();

        await Assert.That(count).IsEqualTo(context.Reservations.Count() - 1);
        await Assert.That(context.Reservations.Contains(reservation)).IsTrue();
    }

    [Test]
    public async Task RemoveReservation()
    {
        int count = context.Reservations.Count();

        ParkingSpot spot = context.Spots.First();
        ParkingSpotReservation reservation = await ReservationHandler.TryAddReservation("admin", spot, DateTime.Now, DateTime.Now.AddHours(1));
        await context.SaveChangesAsync();

        await ReservationHandler.TryRemoveReservation("admin", reservation);
        await context.SaveChangesAsync();

        await Assert.That(count).IsEqualTo(context.Reservations.Count());
        await Assert.That(context.Reservations.Contains(reservation)).IsFalse();
    }

    [After(Test)]
    public async Task DestroyDb()
    {
        await context.DisposeAsync();
        await connection.DisposeAsync();
    }
}
