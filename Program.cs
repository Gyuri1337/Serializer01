using System;

namespace Serializer
{
    class Program
    {
        static void Main(string[] args)
        {
            RootDescriptor<Person> rootDesc = GetPersonDescriptor();

            var czechRepublic = new Country {Name = "Czech Republic", AreaCode = 420};
            var person = new Person
            {
                FirstName = "Pavel",
                LastName = "Jezek",
                HomeAddress = new Address {Street = "Patkova", City = "Prague"},
                WorkAddress = new Address {Street = "Malostranske namesti", City = "Prague"},
                CitizenOf = czechRepublic,
                MobilePhone = new PhoneNumber {Country = czechRepublic, Number = 123456789}
            };
        }

        static RootDescriptor<Person> GetPersonDescriptor()
        {
            var rootDesc = new RootDescriptor<Person>(PersonModelTypes.Person);
            return rootDesc;
        }

    }
}
