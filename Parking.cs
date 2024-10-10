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

        public bool ParkVehicle(string registrationNumber, string vehicleType, string inputSpotString)
        {
            int spotNumber;
            //validate spot number
            if (!int.TryParse(inputSpotString, out spotNumber) || spotNumber < 1 || spotNumber > 100)
            {
                throw new ArgumentException("Invalid spot number. Enter a number between 1 and 100:");
            }

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

            // Adjust for 0-based index in the array
            int index = spotNumber - 1;

            // Check if the spot is already taken
            if (parkingSpots[index] != null)
            {
                return false; // Spot is taken
            }

            // Park the vehicle
            parkingSpots[index] = registrationNumber;
            Console.WriteLine(parkingSpots);
            return true; // Successfully parked
        }

        public bool MoveVehicle(string fromStringSpot, string toStringSpot)
        {
            int fromSpot;
            int toSpot;
            //convert to int and validate
            if (!int.TryParse(fromStringSpot, out fromSpot) || fromSpot < 1 || fromSpot > 100)
            {
                throw new ArgumentException("Invalid spot number. Enter a number between 1 and 100:");
            }
            if (!int.TryParse(toStringSpot, out toSpot) || toSpot < 1 || toSpot > 100)
            {
                throw new ArgumentException("Invalid spot number. Enter a number between 1 and 100:");
            }
            // Adjust spot numbers to array indices
            int fromIndex = fromSpot - 1;
            int toIndex = toSpot - 1;
            // Check if there is a vehicle in the 'from' spot
            if (parkingSpots[fromIndex] == null)
            {
                Console.WriteLine($"\nNo vehicle found in spot {fromSpot} to move.\n");
                return false;
            }
            // Check if the spot is empty
            if (parkingSpots[toIndex] != null)
            {
                Console.WriteLine($"\nSpot {toSpot} is already taken. Cannot move the vehicle.\n");
                return false;
            }
            // Move the vehicle
            parkingSpots[toIndex] = parkingSpots[fromIndex];
            parkingSpots[fromIndex] = null; 

            Console.WriteLine($"\nVehicle successfully moved from spot {fromSpot} to spot {toSpot}.\n");
            return true;


        }

        public bool RemoveVehicle(string spotStringNumber)
        {
            int indexNum;
            //validate input
            if (!int.TryParse(spotStringNumber, out indexNum) || indexNum < 1 || indexNum > 100)
            {
                throw new ArgumentException("Invalid spot number. Enter a number between 1 and 100:");
            }

            int adjustedIndex = indexNum - 1;
            // Check if there is a vehicle in the spot
            if (parkingSpots[adjustedIndex] == null)
            {
                Console.WriteLine($"\nNo vehicle found in spot {adjustedIndex} to remove.\n");
                return false;
            }
            // Remove the vehicle by setting the spot to null
            parkingSpots[adjustedIndex] = null;
            return true;

        }

        public int FindVehicle(string searchWord)
        {
            // Loop through the parking spots to find the vehicle
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                if (parkingSpots[i] != null && parkingSpots[i].Equals(searchWord))
                {
                    // Return the spot number (adjust for user)
                    return i + 1;
                }
            }
            // Return -1 if the vehicle is not found
            return -1;

        }
    }
}
