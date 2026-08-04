using System;
using System.Collections.Generic;
using System.Text;

namespace Parkolóhely_foglaló.Model;

public class ParkingSpotReservation
{
    public ParkingSpot Spot { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public string ReservedBy { get; set; }

    public override string ToString()
    {
        return $"{Spot} reserved from {StartingTime} to {EndingTime} by {ReservedBy}";
    }
}
