using System.ComponentModel.DataAnnotations;

namespace Parkolóhely_foglaló.Core.Model;

public class ParkingSpot
{
    [Key]
    public int Id { get; set; }
    public bool Electric { get; set; }
    public string Name => $"Spot {Id} {(Electric ? "- Electric" : "")}";
    public int Row { get; set; }
    public int Column { get; set; }
    public string Location => $"Row {Row}, Column {Column}";

    public override string ToString()
    {
        return $"{Name} at {Location}";
    }
}
