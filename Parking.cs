namespace prague_parking_v1
{
    public class ParkingLot
    {
        private string[] parkingSpots;

        // constructor
        public ParkingLot()
        {
            parkingSpots = new string[100];
        }

        public bool ParkVehicle(string registrationNumber, string vehicleType)
        {
            //validate registration and type of vehicle.
            if (registrationNumber.Length > 10 || registrationNumber.Length <= 0)
            {
                Console.Clear();
                throw new ArgumentException("Registration number can't be more than 10 characters or less than 1.\n");
            }
            if (vehicleType != "car" && vehicleType != "motorcycle")
            {
                Console.Clear();
                throw new ArgumentException("Invalid vehicle type, only car or motorcycle.\n");
            }

            // Loop through parking spots to find a valid one
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                // Check for car parking
                if (vehicleType == "car")
                {
                    if (parkingSpots[i] == null)
                    {
                        Console.WriteLine($"\nparked in spot {i + 1}");
                        parkingSpots[i] = $"{vehicleType}:{registrationNumber}"; // Park the car in an empty spot
                        return true;
                    }
                }
                else if (vehicleType == "motorcycle")
                {
                    // Check if spot is empty or already has one motorcycle
                    if (parkingSpots[i] == null)
                    {
                        Console.WriteLine($"parked in spot {i + 1}");
                        parkingSpots[i] = $"{vehicleType}:{registrationNumber}";
                        return true;
                    }
                    else if (!parkingSpots[i].Contains("&") && !parkingSpots[i].StartsWith("c"))
                    {
                        // Park second motorcycle if there's only one motorcycle already
                        Console.WriteLine($"parked in spot {i +1}");
                        parkingSpots[i] += $" & {vehicleType}:{registrationNumber}";
                        return true;
                    }
                }
            }
            return false; // No available spot
        }


        public bool MoveVehicle(string stringRegNr, string toStringSpot)
        {
            int toSpot;

            if (!int.TryParse(toStringSpot, out toSpot) || toSpot < 1 || toSpot > 100)
            {
                throw new ArgumentException("Invalid spot number. Enter a number between 1 and 100:");
            }

            // Adjust spot numbers to array indices
            int fromIndex = FindVehicle(stringRegNr) - 1;
            int toIndex = toSpot - 1;

            // Check if there is a vehicle with the return value
            if (fromIndex + 1 == -1)
            {
                throw new ArgumentException("Invalid reg. no.\n");
            }
            if (parkingSpots[toIndex] != null)
            {
                if (parkingSpots[toIndex].Contains("&"))
                {
                    throw new ArgumentException("Spot is not available.\n");
                }else if (parkingSpots[toIndex] != null)
                {
                    throw new ArgumentException("Spot is not available.\n");
                }
            }
           

            if (parkingSpots[fromIndex].Contains("&"))
            {
                // Split motorcycles
                string[] vehicles = parkingSpots[fromIndex].Split('&');
                // Move the specific motorcycle
                if (vehicles[0].Contains(stringRegNr))
                {
                    parkingSpots[toIndex] = vehicles[0].Trim(); // Move first motorcycle
                    parkingSpots[fromIndex] = vehicles[1].Trim(); // Keep the second motorcycle
                }
                else if (vehicles[1].Contains(stringRegNr))
                {
                    parkingSpots[toIndex] = vehicles[1].Trim(); // Move second motorcycle
                    parkingSpots[fromIndex] = vehicles[0].Trim(); // Keep the first motorcycle
                }
                Console.WriteLine($"\nMotorcycle with registration number {stringRegNr} successfully moved to spot {toSpot}.\n");
            }
            else
            {
                // Move the vehicle (car or single motorcycle)
                parkingSpots[toIndex] = parkingSpots[fromIndex];
                parkingSpots[fromIndex] = null;
                Console.WriteLine($"\nVehicle with registration number {stringRegNr} successfully moved from spot {fromIndex + 1} to spot {toSpot}.\n");
            }

            return true;
        }

        public bool RemoveVehicle(string specRegNumToRemove)
        {
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                if (parkingSpots[i] != null && parkingSpots[i].Contains(specRegNumToRemove))
                {
                    // Handle case when there are two motorcycles in the spot, check for &
                    if (parkingSpots[i].Contains("&"))
                    {
                        // Split it
                        string[] vehicles = parkingSpots[i].Split('&');

                        // Find and remove the motorcycle with the matching registration number
                        if (vehicles[0].Contains(specRegNumToRemove))
                        {
                            parkingSpots[i] = vehicles[1].Trim(); // Keep the second motorcycle
                            Console.WriteLine($"\nMotorcycle with registration number {specRegNumToRemove} removed. Another motorcycle remains in spot {i + 1}.\n");
                        }
                        else if (vehicles[1].Contains(specRegNumToRemove))
                        {
                            parkingSpots[i] = vehicles[0].Trim(); // Keep the first motorcycle
                            Console.WriteLine($"\nMotorcycle with registration number {specRegNumToRemove} removed. Another motorcycle remains in spot {i + 1}.\n");
                        }
                    }
                    else
                    {
                        // If it's a car or a single motorcycle, remove it
                        parkingSpots[i] = null;
                        Console.WriteLine($"\nVehicle with registration number {specRegNumToRemove} removed from spot {i + 1}.\n");
                    }
                    return true; // Vehicle found and removed
                }
            }
            Console.WriteLine($"\nNo vehicle found with registration number {specRegNumToRemove}.\n");
            return false; // Vehicle not found
        }

        public int FindVehicle(string searchWord)
        {
            // Loop through the parking spots
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                if (parkingSpots[i] != null)
                {
                    // Split the parked vehicle string to check registration number
                    string[] vehicles = parkingSpots[i].Split(new[] { ';', '&' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var vehicle in vehicles)
                    {
                        string registrationNumber = vehicle.Split(':')[1].Trim(); 

                        if (registrationNumber == searchWord.Trim())
                        {
                            // Return the spot number (adjust for user)
                            return i + 1;
                        }
                    }
                }
            }
            // Return -1 if not found
            return -1;
        }

        public void PrintParkingLot()
        {
            const int rows = 50; // Number of rows
            const int cols = 2;  // Number of columns
            const int spotWidth = 40; // Fixed width for each spot display
            Console.Clear();
            Console.WriteLine("\n--- Current Parking Lot ---\n");
            Console.WriteLine("Spot | Vehicle(s)         | Reg. No.");
            Console.WriteLine(new string('-', (spotWidth + 1) * cols)); // Line for header

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int index = row * cols + col;
                    if (index < parkingSpots.Length)
                    {
                        string spotInfo;

                        if (parkingSpots[index] == null)
                        {
                            spotInfo = "Empty"; // If spot is empty
                        }
                        else
                        {
                            string[] vehicles = parkingSpots[index].Split(';');
                            if (vehicles.Length == 1)
                            {
                                spotInfo = parkingSpots[index]; // Single vehicle (car or one motorcycle)
                            }
                            else
                            {
                                // Format two MC's
                                spotInfo = $"{vehicles[0]} & {vehicles[1]}";
                            }
                        }
                        Console.Write($"|nr:{index + 1:D3}: {spotInfo,-20} ");
                    }
                }
                Console.WriteLine("|"); 
                Console.WriteLine(new string('-', (spotWidth + 1) * cols));
            }
        }
    }
}
