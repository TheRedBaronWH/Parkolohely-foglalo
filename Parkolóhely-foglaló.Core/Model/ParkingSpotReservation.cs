using System.ComponentModel.DataAnnotations;

namespace Parkolóhely_foglaló.Core.Model;

public class ParkingSpotReservation
{
    [Key]
    public int Id { get; set; }
    public int ParkingSpotId { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndingTime { get; set; }
    public string ReservedBy { get; set; }

    public override string ToString()
    {
        return $"Spot {ParkingSpotId} reserved from {StartingTime} to {EndingTime} by {ReservedBy} - Reservation ID: {Id}";
    }
}
