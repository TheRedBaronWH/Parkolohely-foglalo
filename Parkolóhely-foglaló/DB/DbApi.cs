using Microsoft.EntityFrameworkCore;
using Parkolóhely_foglaló.Model;

namespace Parkolóhely_foglaló.DB;

public static class DbApi
{
    public static async Task<List<ParkingSpot>> GetParkingSpots()
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Spots
                .ToListAsync();
        }
    }

    public static async Task<List<ParkingSpotReservation>> GetReservations(ParkingSpot Spot)
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Reservations
                .Where(r => r.ParkingSpot == Spot)
                .ToListAsync();
        }
    }

    public static async Task AddParkingSpot(ParkingSpot spot)
    {
        using (var db = new ParkingDBContext())
        {
            db.Spots.Add(spot);
            await db.SaveChangesAsync();
        }
    }

    public static async Task RemoveParkingSpot(ParkingSpot spot)
    {
        using (var db = new ParkingDBContext())
        {
            db.Spots.Remove(spot);
            await db.SaveChangesAsync();
        }
    }

    public static async Task AddReservation(ParkingSpotReservation reservation)
    {
        using (var db = new ParkingDBContext())
        {
            db.Reservations.Add(reservation);
            await db.SaveChangesAsync();
        }
    }

    public static async Task RemoveReservation(ParkingSpotReservation reservation)
    {
        using (var db = new ParkingDBContext())
        {
            db.Reservations.Remove(reservation);
            await db.SaveChangesAsync();
        }
    }
}
