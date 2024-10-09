namespace prague_parking_v1
{
    public class ParkingLot
    {
        private Vehicle[] parkingSpots;

        // constructor
        public ParkingLot()
        {
            parkingSpots = new Vehicle[100];
        }

        public bool ParkVehicle(string registrationNumber, string vehicleType, string inputSpotString)
        {

            int spotNumber;

            if (!int.TryParse(inputSpotString, out spotNumber) || spotNumber < 1 || spotNumber > 100)
            {
                throw new ArgumentException("Invalid spot number. Enter a number between 1 and 100:");
            }

            // Adjust for 0-based index in the array
            int index = spotNumber - 1;

            // Check if the spot is already taken
            if (parkingSpots[index] != null)
            {
                return false; // Spot is taken
            }

            Vehicle vehicle = new Vehicle(registrationNumber, vehicleType);

            // Park the vehicle
            parkingSpots[index] = vehicle;
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
