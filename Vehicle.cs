namespace prague_parking_v1
{
    public class Vehicle
    {
        public string RegistrationNumber { get; private set; }
        public string Type { get; private set; }

        public Vehicle(string registrationNumber, string type)
        {
            if (registrationNumber.Length > 10 || registrationNumber.Length <= 0)
            {
                Console.Clear();
                throw new ArgumentException("Registration number can't be more than 10 characters or less than 1.\n");

            }
            if (type != "car" && type != "motorcycle")
            {
                Console.Clear();
                throw new ArgumentException("Invalid vehicle type, only car or motorcycle.\n");
            }
            RegistrationNumber = registrationNumber;
            Type = type;
        }
    }
}
