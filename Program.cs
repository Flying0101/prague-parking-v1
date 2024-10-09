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
                Console.WriteLine("5. Exit\n");

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

                            // Get the parking spot number from the user
                            Console.Write("Enter parking spot number, 1-100: ");
                            string inputSpotString = Console.ReadLine()!;

                            // Park the vehicle using the ParkVehicle method
                            if (parkingLot.ParkVehicle(registrationNumber, vehicleType.ToLower(), inputSpotString))
                            {
                                Console.WriteLine($"\nVehicle {registrationNumber} parked successfully in spot {inputSpotString}.\n");
                            }
                            else
                            {
                                Console.WriteLine($"\nSpot {inputSpotString} is already taken. Please try another spot.\n");
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
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
