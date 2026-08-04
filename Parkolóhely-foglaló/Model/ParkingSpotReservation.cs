using System.ComponentModel.DataAnnotations;

namespace Parkolóhely_foglaló.Model;

public class ParkingSpotReservation
{
    [Key]
    public int ReservationId { get; set; }
    public ParkingSpot ParkingSpot { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public string ReservedBy { get; set; }

    public override string ToString()
    {
        return $"{ParkingSpot} reserved from {StartingTime} to {EndingTime} by {ReservedBy}";
    }
}
