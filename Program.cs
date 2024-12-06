using System;
using CivicTransportSystem.Services;

namespace CivicTransportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Civic Transport System");
            var cardService = new CardService();

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Register Civic Card");
                Console.WriteLine("2. Register Discounted Card");
                Console.WriteLine("3. Reload Card");
                Console.WriteLine("4. Simulate Trip");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        cardService.RegisterCard(false);
                        break;
                    case "2":
                        cardService.RegisterCard(true);
                        break;
                    case "3":
                        cardService.ReloadCard();
                        break;
                    case "4":
                        cardService.SimulateTrip();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
