using System.Collections.Generic;
using ApplicationProcess.Domain.SeedWork;

namespace ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate
{
    public class Address : ValueObject
    {
        public string City { get; private set; }
        public string Country { get; private set; }
        public string FullAddress { get; private set; }

        public Address() { }

        public Address(string city, string country, string fullAddress)
        {
            City = city;
            Country = country;
            FullAddress = fullAddress;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return City;
            yield return Country;
        }
    }
}
