using Microsoft.EntityFrameworkCore;
using Parkolóhely_foglaló.Core.Model;

namespace Parkolóhely_foglaló.Core.DB;

public static class ParkingDbApi
{
    public static async Task<List<ParkingSpot>> GetParkingSpots()
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Spots
                .ToListAsync();
        }
    }

    public static async Task<ParkingSpot> GetParkingSpot(int spotId)
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Spots
                .Where(spot => spot.Id == spotId)
                .FirstOrDefaultAsync();
        }
    }

    public static async Task<List<ParkingSpot>> GetFreeParkingSpots(DateTime startingTime, DateTime endingTime)
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Spots
                .Where(spot => !db.Reservations.Any(reservation => reservation.ParkingSpotId == spot.Id &&
                                        reservation.StartingTime < endingTime &&
                                        reservation.EndingTime > startingTime))
                .ToListAsync();
        }
    }

    public static async Task<List<ParkingSpot>> GetFreeElectricParkingSpots(DateTime startingTime, DateTime endingTime)
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Spots
                .Where(spot => spot.Electric && !db.Reservations.Any(reservation => reservation.ParkingSpotId == spot.Id &&
                                        reservation.StartingTime < endingTime &&
                                        reservation.EndingTime > startingTime))
                .ToListAsync();
        }
    }

    public static async Task<List<ParkingSpot>> GetFreeNormalParkingSpots(DateTime startingTime, DateTime endingTime)
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Spots
                .Where(spot => !spot.Electric && !db.Reservations.Any(reservation => reservation.ParkingSpotId == spot.Id &&
                                        reservation.StartingTime < endingTime &&
                                        reservation.EndingTime > startingTime))
                .ToListAsync();
        }
    }

    public static async Task<List<ParkingSpotReservation>> GetReservations()
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Reservations
                .ToListAsync();
        }
    }

    public static async Task<ParkingSpotReservation> GetReservation(int reservationId)
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Reservations
                .Where(r => r.Id == reservationId)
                .FirstOrDefaultAsync();
        }
    }

    public static async Task<List<ParkingSpotReservation>> GetReservationsForSpot(ParkingSpot Spot)
    {
        using (var db = new ParkingDBContext())
        {
            return await db.Reservations
                .Where(r => r.ParkingSpotId == Spot.Id)
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
