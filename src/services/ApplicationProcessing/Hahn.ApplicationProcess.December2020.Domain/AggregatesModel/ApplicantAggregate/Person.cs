using Hahn.ApplicationProcess.December2020.Domain.SeedWork;

namespace Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate
{
    public class Person : Entity
    {
        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public string CountryOfOrigin { get; private set; }
        public int Age { get; private set; }

        public Person(string name, string familyName, string countryOfOrigin, int age)
        {
            Name = name;
            FamilyName = familyName;
            CountryOfOrigin = countryOfOrigin;
            Age = age;
        }
    }
}