using Microsoft.EntityFrameworkCore;
using Parkolóhely_foglaló.Model;

namespace Parkolóhely_foglaló.DB;

public class DbApi
{
    public async Task<List<ParkingSpot>> GetParkingSpots()
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Spots
                .ToListAsync();
        }
    }

    public async Task<List<ParkingSpotReservation>> GetReservations(ParkingSpot Spot)
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Reservations
                .Where(r => r.Spot == Spot)
                .ToListAsync();
        }
    }

    public async Task AddParkingSpot(ParkingSpot spot)
    {
        using (var db = new ParkingDBContext())
        {
            db.Spots.Add(spot);
            await db.SaveChangesAsync();
        }
    }

    public async Task RemoveParkingSpot(ParkingSpot spot)
    {
        using (var db = new ParkingDBContext())
        {
            db.Spots.Remove(spot);
            await db.SaveChangesAsync();
        }
    }

    public async Task AddReservation(ParkingSpotReservation reservation)
    {
        using (var db = new ParkingDBContext())
        {
            db.Reservations.Add(reservation);
            await db.SaveChangesAsync();
        }
    }

    public async Task RemoveReservation(ParkingSpotReservation reservation)
    {
        using (var db = new ParkingDBContext())
        {
            db.Reservations.Remove(reservation);
            await db.SaveChangesAsync();
        }
    }
}
