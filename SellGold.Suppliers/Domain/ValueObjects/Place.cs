using SellGold.Suppliers.Domain.Exceptions;

namespace SellGold.Suppliers.Domain.ValueObjects
{
    public class Place : HitObject
    {
        public Place(string district, string city, string state, string country)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new DomainException("Cidade é obrigatória.");

            if (string.IsNullOrWhiteSpace(state))
                throw new DomainException("Estado é obrigatório.");

            if (string.IsNullOrWhiteSpace(country))
                throw new DomainException("País é obrigatório.");

            District = district;
            City = city;
            State = state;
            Country = country;
        }

        public string District { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return District;
            yield return City;
            yield return State;
            yield return Country;
        }
    }
}
