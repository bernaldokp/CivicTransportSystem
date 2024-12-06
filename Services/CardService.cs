using System;
using CivicTransportSystem.Models;
using CivicTransportSystem.Data;
using System.Linq;

namespace CivicTransportSystem.Services
{
    public class CardService
    {
        private readonly AppDbContext _context;

        public CardService()
        {
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
        }

        public void RegisterCard(bool isDiscounted)
        {
            Console.WriteLine("Enter Cardholder Number:");
            string cardholderNumber = Console.ReadLine();

            if (isDiscounted)
            {
                Console.WriteLine("Enter Discount Type (Senior Citizen / PWD):");
                string discountType = Console.ReadLine();

                var discountedCard = new CivicDiscountedCard
                {
                    CardholderNumber = cardholderNumber,
                    Balance = 500,
                    DiscountType = discountType,
                    LastUsedDate = DateTime.Now
                };
                _context.CivicDiscountedCards.Add(discountedCard);
            }
            else
            {
                var card = new CivicCard
                {
                    CardholderNumber = cardholderNumber,
                    Balance = 300,
                    LastUsedDate = DateTime.Now
                };
                _context.CivicCards.Add(card);
            }

            _context.SaveChanges();
            Console.WriteLine("Card registered successfully!");
        }

        public void ReloadCard()
        {
            Console.WriteLine("Enter Cardholder Number:");
            string cardholderNumber = Console.ReadLine();

            Console.WriteLine("Enter Amount to Reload:");
            decimal amount = decimal.Parse(Console.ReadLine());

            var card = _context.Cards.FirstOrDefault(c => c.CardholderNumber == cardholderNumber);
            if (card == null)
            {
                Console.WriteLine("Card not found.");
                return;
            }

            try
            {
                card.Reload(amount);
                _context.SaveChanges();
                Console.WriteLine("Reload successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void SimulateTrip()
        {
            Console.WriteLine("Enter Cardholder Number:");
            string cardholderNumber = Console.ReadLine();

            var card = _context.Cards.FirstOrDefault(c => c.CardholderNumber == cardholderNumber);
            if (card == null)
            {
                Console.WriteLine("Card not found.");
                return;
            }

            try
            {
                card.UseCard();
                _context.SaveChanges();
                Console.WriteLine("Trip successful! Remaining Balance: " + card.Balance);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
