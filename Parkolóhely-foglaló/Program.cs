using Parkolóhely_foglaló.DB;
using Parkolóhely_foglaló.Model;

foreach (ParkingSpot spot in await DbApi.GetParkingSpots())
{
    Console.WriteLine(spot);
}
