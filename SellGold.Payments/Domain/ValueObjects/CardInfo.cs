namespace SellGold.Payments.Domain.ValueObjects
{
    public class CardInfo
    {
        public string Last4Digits { get; }
        public string Brand { get; }

        public CardInfo(string last4Digits, string brand)
        {
            Last4Digits = last4Digits;
            Brand = brand;
        }
    }
}
