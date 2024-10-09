namespace prague_parking_v1
{
    public class Vehicle
    {
        public string RegistrationNumber { get; private set; }
        public string Type { get; private set; } // "type of vehicle"

        public Vehicle(string registrationNumber, string type)
        {
            if (registrationNumber.Length > 10)
                throw new ArgumentException("Registration number can't be more than 10 characters.");

            RegistrationNumber = registrationNumber;
            Type = type;
        }
    }
}
