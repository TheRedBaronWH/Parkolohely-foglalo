using Parkolóhely_foglaló.Control;
using Parkolóhely_foglaló.DB;
using Parkolóhely_foglaló.Model;

bool running = true;

while (running)
{
    Console.WriteLine("What do you wanna do? \n(1) List Parking Spots \n(2) List Reservations \n(3) Add Reservation \n(4) Remove Reservation \n(5) Exit");
    string input = Console.ReadLine().ToLower();
        
    switch(input) {
        case "1":
            Console.WriteLine("Parking spots:");
            foreach(ParkingSpot spot in await DbApi.GetParkingSpots())
            {
                Console.WriteLine(spot);
            }
            break;
        case "2":
            Console.WriteLine("Reservations:");
            foreach (ParkingSpot spot in await DbApi.GetParkingSpots())
            {
                Console.WriteLine($"Reservations for {spot}:");
                foreach (ParkingSpotReservation reservation in await DbApi.GetReservationsForSpot(spot))
                {
                    Console.WriteLine(reservation);
                }
            }
            break;
        case "3":
            Console.WriteLine("Enter the starting date for your reservation (YYYY-MM-DD HH:MM):");
            bool validInput = false;
            DateTime startingDate = DateTime.Now;
            DateTime endingDate = DateTime.Now;
            while (!validInput)
            {
                string dateInput = Console.ReadLine().ToLower();

                if (dateInput == "now")
                {
                    startingDate = DateTime.Now;
                    validInput = true;
                }
                else
                {
                    if (DateTime.TryParse(dateInput, out DateTime dateTime))
                    {
                        startingDate = dateTime;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                    }
                }
            }
            Console.WriteLine("Enter the ending date for your reservation (YYYY-MM-DD HH:MM):");
            validInput = false;
            while (!validInput)
            {
                string dateInput = Console.ReadLine();

                if (DateTime.TryParse(dateInput, out DateTime dateTime))
                {
                    endingDate = dateTime;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                }
            }
            Console.WriteLine("Available parking spots at the requested time:");  
            foreach(var spot in await DbApi.GetFreeParkingSpots(startingDate, endingDate))
            {
                Console.WriteLine(spot);
            }
            Console.WriteLine("Enter the number of the parking spot you want to reserve:");
            int intInput = int.Parse(Console.ReadLine());
            ParkingSpot selectedSpot = await DbApi.GetParkingSpot(intInput);
            if(selectedSpot == null)
            {
                Console.WriteLine("No such parking spot found. Enter the number of the parking spot you want to reserve:");
                intInput = int.Parse(Console.ReadLine());
                selectedSpot = await DbApi.GetParkingSpot(intInput);
            }
            bool success = await ReservationHandler.TryAddReservation("Test", selectedSpot, startingDate, endingDate);
            Console.WriteLine(success ? "Reservation successful!" : "Reservation failed! The parking spot is already reserved at the requested time.");
            break;
        case "4":
            Console.WriteLine("Reservations:");
            foreach(var res in await DbApi.GetReservations())
            {
                Console.WriteLine(res);
            }
            Console.WriteLine("Enter the ID of the reservation you want to remove:");
            int reservationId = int.Parse(Console.ReadLine());
            ParkingSpotReservation reservationToRemove = await DbApi.GetReservation(reservationId);
            if (reservationToRemove != null)
            {
                await DbApi.RemoveReservation(reservationToRemove);
                Console.WriteLine("Reservation removed successfully.");
            }
            else
            {
                Console.WriteLine("No such reservation found.");
            }
            break;
        case "5":
            running = false;
            break;
    }
}
