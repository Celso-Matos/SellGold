using SellGold.Customers.Domain.Exceptions;

namespace SellGold.Customers.Domain.ValueObjects
{
    public class Address : HitObject
    {
        protected Address() {

            // EF Core only
            StreetInfo = null!;
            Place = null!;
            ZipCode = null!;
            AddressType = null!;

        }

        public Address(
            StreetInfo streetInfo,
            Place place,
            string zipCode,
            string addressType)
        {
            if (streetInfo is null)
                throw new DomainException("Logradouro é obrigatório.");

            if (place is null)
                throw new DomainException("Localização é obrigatória.");

            if (string.IsNullOrWhiteSpace(zipCode))
                throw new DomainException("CEP é obrigatório.");

            StreetInfo = streetInfo;
            Place = place;
            ZipCode = zipCode;
            AddressType = addressType;
        }

        public StreetInfo StreetInfo { get; }
        public Place Place { get; }
        public string ZipCode { get; }
        public string AddressType { get; }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return StreetInfo;
            yield return Place;
            yield return ZipCode;
            yield return AddressType;
        }

    }
}
