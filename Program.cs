namespace prague_parking_v1
{
    internal class Program
    {
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
                Console.WriteLine("5. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        running = false;
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
