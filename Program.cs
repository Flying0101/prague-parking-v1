namespace prague_parking_v1
{
    internal class Program
    {
        private static ParkingLot parkingLot = new ParkingLot();
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Stephano and Ömers parking assignment.");

            bool running = true;

            while (running)
            {
                Console.WriteLine("---Prague Parking System V1---\n");
                Console.WriteLine("1. Park a vehicle");
                Console.WriteLine("2. Move a vehicle");
                Console.WriteLine("3. Remove a vehicle");
                Console.WriteLine("4. Search for a vehicle");
                Console.WriteLine("5. Print the parking lot");
                Console.WriteLine("6. Exit\n");

                string userInput = Console.ReadLine()!;

                switch (userInput)
                {
                    case "1":
                        try
                        {
                            // Get vehicle registration number from the user
                            Console.Write("Enter registration number, max 10 characters: ");
                            string registrationNumber = Console.ReadLine()!;

                            // Get vehicle type from the user
                            Console.Write("Enter vehicle type, Car / Motorcycle: ");
                            string vehicleType = Console.ReadLine()!;

                            // Park the vehicle using the ParkVehicle method
                            if (parkingLot.ParkVehicle(registrationNumber, vehicleType.ToLower()))
                            {
                                Console.WriteLine($"Vehicle {registrationNumber} parked successfully.\n");
                            }
                            else
                            {
                                Console.WriteLine($"\nNo available spot for {vehicleType}. Please try another vehicle.\n");
                            }

                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "2":
                        try
                        {
                            // Get the source spot from the user
                            Console.Write("Enter the registration number of the vehicle to move: ");
                            string stringRegNr = Console.ReadLine()!;

                            // Get the destination spot from the user
                            Console.Write("Enter the destination spot number: ");
                            string toStringSpot = Console.ReadLine()!;

                            // Move the vehicle using the MoveVehicle method
                            parkingLot.MoveVehicle(stringRegNr, toStringSpot);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;
                    case "3":
                        try
                        {
                            Console.Write("\nEnter the register number of the vehicle to remove: ");
                            string specRegNumToRemove = Console.ReadLine()!;

                            // Remove the vehicle using the RemoveVehicle method
                            if (parkingLot.RemoveVehicle(specRegNumToRemove))
                            {
                                Console.WriteLine($"Deletion successfully.\n");
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }


                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine("\nLets start searching!");
                            Console.WriteLine("Enter the registration number of the vehicle: ");
                            string searchWord = Console.ReadLine()!;

                            // Search for the vehicle using the FindVehicle method
                            int foundSpot = parkingLot.FindVehicle(searchWord);

                            if (foundSpot != -1)
                            {
                                Console.WriteLine($"\nVehicle {searchWord} found at spot {foundSpot}.\n");
                            }
                            else
                            {
                                Console.WriteLine($"\nVehicle {searchWord} not found in the parking lot.\n");
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;
                    case "5":
                        parkingLot.PrintParkingLot();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("\nShutting down program...");
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid, please enter a number between 1-5...\n");
                        break;
                }
            }

        }
    }
}
