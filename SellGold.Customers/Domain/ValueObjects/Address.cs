using SellGold.Customers.Domain.Exceptions;

namespace SellGold.Customers.Domain.ValueObjects
{
    public class Address : HitObject
    {
        protected Address() {

            // EF Core only
            StreetInfo = null!;
            Location = null!;
            ZipCode = null!;
            Type = null!;

        }

        public Address(
            StreetInfo streetInfo,
            Place location,
            string zipCode,
            string type)
        {
            if (streetInfo is null)
                throw new DomainException("Logradouro é obrigatório.");

            if (location is null)
                throw new DomainException("Localização é obrigatória.");

            if (string.IsNullOrWhiteSpace(zipCode))
                throw new DomainException("CEP é obrigatório.");

            StreetInfo = streetInfo;
            Location = location;
            ZipCode = zipCode;
            Type = type;
        }

        public StreetInfo StreetInfo { get; }
        public Place Location { get; }
        public string ZipCode { get; }
        public string Type { get; }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return StreetInfo;
            yield return Location;
            yield return ZipCode;
            yield return Type;
        }

    }
}
