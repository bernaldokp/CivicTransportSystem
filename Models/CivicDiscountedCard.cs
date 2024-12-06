using System;

namespace CivicTransportSystem.Models
{
    public class CivicDiscountedCard : Card
    {
        public string DiscountType { get; set; } // "Senior Citizen" or "PWD"
        public override decimal ExitFee => 10;
        public override DateTime ValidUntil => LastUsedDate.AddYears(3);
        public int DailyTrips { get; set; } = 0;

        public override void UseCard()
        {
            if (!IsValid)
                throw new InvalidOperationException("Card is no longer valid.");

            decimal discount = DailyTrips switch
            {
                0 => 0.20m,
                <= 4 => 0.23m,
                _ => 0.20m
            };

            decimal discountedFee = ExitFee * (1 - discount);

            if (Balance < discountedFee)
                throw new InvalidOperationException("Insufficient balance.");

            Balance -= discountedFee;
            LastUsedDate = DateTime.Now;

            // Reset trip count if it's a new day
            if (DailyTrips > 0 && LastUsedDate.Date != DateTime.Now.Date)
                DailyTrips = 0;

            DailyTrips++;
        }
    }
}
