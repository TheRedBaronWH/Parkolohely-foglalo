using System.ComponentModel.DataAnnotations;

namespace Parkolóhely_foglaló.Model;

public class ParkingSpot
{
    [Key]
    public int SpotId { get; set; }
    public string Name => $"Spot {SpotId}";
    public int Row { get; set; }
    public int Column { get; set; }

    public override string ToString()
    {
        return $"{Name} at Row {Row} Column {Column}";
    }
}
