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

        public void ParkVehicle(Vehicle vehicle, int spotNumber)
        {
            // Implement logic to park the vehicle
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
