using System;

namespace CivicTransportSystem.Models
{
    public class CivicCard : Card
    {
        public override decimal ExitFee => 15;
        public override DateTime ValidUntil => LastUsedDate.AddYears(5);
    }
}
