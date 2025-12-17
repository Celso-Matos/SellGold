using SellGold.Customers.Domain.Common;

namespace SellGold.Customers.Domain.ValueObject
{
    public class StreetInfo : HitObject
    {
        public StreetInfo(string street, string number, string? complement)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new DomainException("Rua é obrigatória.");

            if (string.IsNullOrWhiteSpace(number))
                throw new DomainException("Número é obrigatório.");

            Street = street;
            Number = number;
            Complement = complement;
        }

        public string Street { get; }
        public string Number { get; }
        public string? Complement { get; }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Street;
            yield return Number;
            yield return Complement;
        }
    }
}
