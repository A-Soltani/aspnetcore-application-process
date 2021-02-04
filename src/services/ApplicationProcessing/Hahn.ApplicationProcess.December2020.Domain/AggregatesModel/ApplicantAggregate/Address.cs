using System;
using System.Collections.Generic;
using Hahn.ApplicationProcess.December2020.Domain.SeedWork;

namespace Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate
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
