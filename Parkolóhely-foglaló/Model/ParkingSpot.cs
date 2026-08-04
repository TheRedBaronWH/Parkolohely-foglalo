using System;
using System.Collections.Generic;
using System.Text;

namespace Parkolóhely_foglaló.Model;

public class ParkingSpot
{
    public int Row { get; set; }
    public int Column { get; set; }

    public override string ToString()
    {
        return $"Parking spot at Row {Row} Column {Column}";
    }
}
