using Parkolóhely_foglaló.DB;
using Parkolóhely_foglaló.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parkolóhely_foglaló.Controller;

public static class ReservationHandler
{
    public static async Task TryAddReservation(string user, ParkingSpot spot, DateTime startingTime, DateTime endingTime)
    {
        if (startingTime >= endingTime) throw new Exception("Starting time must be before ending time.");
        if (startingTime < DateTime.Now.AddMinutes(-1)) throw new Exception("Starting time cannot be in the past.");

        ParkingSpotReservation reservation = new ParkingSpotReservation
        {
            ParkingSpotId = spot.Id,
            StartingTime = startingTime,
            EndingTime = endingTime,
            ReservedBy = user
        };
        await DbApi.AddReservation(reservation);
    }

    public static async Task TryRemoveReservation(string user, ParkingSpotReservation reservation)
    {
        if (reservation.ReservedBy == user || user == "admin")
        {
            await DbApi.RemoveReservation(reservation);
        }
        else
        {
            throw new Exception("You are not the owner of this reservation.");
        }
    }
}
