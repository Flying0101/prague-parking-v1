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

        public void MoveVehicle(int fromSpot, int toSpot)
        {
            // change to bool return type // add logic
        }

        public void RemoveVehicle(int spotNumber)
        {
            // change to bool return type // add logic
        }

        public void FindVehicle(string registrationNumber)
        {
            // change to bool return type // add logic
        }
    }
}
