using System;

namespace CivicTransportSystem.Models
{
    public abstract class Card
    {
        public int Id { get; set; }
        public string CardholderNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastUsedDate { get; set; }
        public abstract decimal ExitFee { get; }
        public abstract DateTime ValidUntil { get; }
        public virtual bool IsValid => DateTime.Now <= ValidUntil;

        public void Reload(decimal amount)
        {
            if (amount < 100 || amount > 5000)
                throw new ArgumentException("Amount must be between 100 and 5000.");

            if (Balance + amount > 20000)
                throw new InvalidOperationException("Maximum balance is 20000.");

            Balance += amount;
        }

        public virtual void UseCard()
        {
            if (!IsValid)
                throw new InvalidOperationException("Card is no longer valid.");

            if (Balance < ExitFee)
                throw new InvalidOperationException("Insufficient balance.");

            Balance -= ExitFee;
            LastUsedDate = DateTime.Now;
        }
    }
}
