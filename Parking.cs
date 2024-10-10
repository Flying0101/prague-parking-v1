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

            if (!int.TryParse(fromStringSpot, out fromSpot) || fromSpot < 1 || fromSpot > 100)
            {
                throw new ArgumentException("Invalid spot number. Enter a number between 1 and 100:");
            }
            if (!int.TryParse(toStringSpot, out toSpot) || toSpot < 1 || toSpot > 100)
            {
                throw new ArgumentException("Invalid spot number. Enter a number between 1 and 100:");
            }

            int fromIndex = fromSpot - 1;
            int toIndex = toSpot - 1;

            if (parkingSpots[fromIndex] == null)
            {
                Console.WriteLine($"\nNo vehicle found in spot {fromSpot} to move.\n");
                return false;
            }

            if (parkingSpots[toIndex] != null)
            {
                Console.WriteLine($"\nSpot {toSpot} is already taken. Cannot move the vehicle.\n");
                return false;
            }

            parkingSpots[toIndex] = parkingSpots[fromIndex];
            parkingSpots[fromIndex] = null; 

            Console.WriteLine($"\nVehicle successfully moved from spot {fromSpot} to spot {toSpot}.\n");
            return true;


        }

        public bool RemoveVehicle(string spotStringNumber)
        {
            int indexNum;

            if (!int.TryParse(spotStringNumber, out indexNum) || indexNum < 1 || indexNum > 100)
            {
                throw new ArgumentException("Invalid spot number. Enter a number between 1 and 100:");
            }

            int adjustedIndex = indexNum - 1;

            if (parkingSpots[adjustedIndex] == null)
            {
                Console.WriteLine($"\nNo vehicle found in spot {adjustedIndex} to remove.\n");
                return false;
            }

            parkingSpots[adjustedIndex] = null;
            return true;

        }

        public int FindVehicle(string searchWord)
        {
            for (int i = 0; i < parkingSpots.Length; i++)
            {
                if (parkingSpots[i] != null && parkingSpots[i].Equals(searchWord))
                {
                    return i + 1;
                }
            }

            return -1;

        }
    }
}
