using Parkolóhely_foglaló.DB;
using Parkolóhely_foglaló.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parkolóhely_foglaló.Control;

public static class ReservationHandler
{
    public static async Task<bool> TryAddReservation(string user, ParkingSpot spot, DateTime startingTime, DateTime endingTime)
    {
        if (startingTime >= endingTime || startingTime < DateTime.Now) return false;

        ParkingSpotReservation reservation = new ParkingSpotReservation
        {
            ParkingSpotId = spot.Id,
            StartingTime = startingTime,
            EndingTime = endingTime,
            ReservedBy = user
        };
        await DbApi.AddReservation(reservation);
        return true;
    }

    public static async Task<bool> TryRemoveReservation(string user, ParkingSpotReservation reservation)
    {
        if(reservation.ReservedBy != user || user != "admin")
        {
            return false;
        }
        
        await DbApi.RemoveReservation(reservation);
        return true;
    }
}
