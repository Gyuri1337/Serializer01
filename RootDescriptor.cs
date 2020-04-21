using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Serializer
{
	public class RootDescriptor<T>
    {
        
        public RootDescriptor(PersonModelTypes Type)
        {
            myType = Type;
        }
        private PersonModelTypes myType;
        public void Serialize(TextWriter writer, T instance)
        {
            switch (myType)
            {
                case PersonModelTypes.Person: 
                    WritePerson(writer, instance);
                    break;
                case PersonModelTypes.Country:
                    WriteCountry(writer, instance);
                    break;
                case PersonModelTypes.Citizen:
                    WriteCizitzen(writer, instance);
                    break;
                case PersonModelTypes.Address:
                    WriteAddress(writer, instance);
                    break;
                case PersonModelTypes.PhoneNumber:
                    WritePhoneNumber(writer, instance);
                    break;
            }
            
        }
        static RootDescriptor<Address> getAddressDescriptor()
        {
            return new RootDescriptor<Address>(PersonModelTypes.Address);
        }
        public void WritePhoneNumber(TextWriter writer, T instance)
        {
            writer.WriteLine("<MobilePhone>");
            RootDescriptor<Country> countryDescriptor = getCountryDescriptor();
            countryDescriptor.Serialize(writer, Get<Country, PhoneNumber>(number => number.Country, instance));
            writer.WriteLine("<City>{0}</City>", Get<int, PhoneNumber>(number => number.Number, instance));
            writer.WriteLine("</MobilePhone>");
        }
        public void WriteAddress(TextWriter writer, T instance)
        {
            writer.WriteLine("<Street>{0}</Street>", Get<String, Address>(address => address.Street, instance));
            writer.WriteLine("<City>{0}</City>", Get<String, Address>(address => address.City, instance));
        }
        public void WriteCountry(TextWriter writer, T instance)
        {
            writer.WriteLine("<{0}>", instance.GetType().Name);
            writer.WriteLine("<City>{0}</City>", Get<String, Country>(country => country.Name, instance));
            writer.WriteLine("<AreaCode>{0}</AreaCode>", Get<int, Country>(country => country.AreaCode, instance));
            writer.WriteLine("</{0}>", instance.GetType().Name);
        }
        public void WriteCizitzen(TextWriter writer, T instance)
        {
            writer.WriteLine("<CiztizenOf>", instance.GetType().Name);
            writer.WriteLine("<Name>{0}</Name>", Get<String, Country>(country => country.Name, instance));
            writer.WriteLine("<AreaCode>{0}</AreaCode>", Get<int, Country>(country => country.AreaCode, instance));
            writer.WriteLine("</CitizenOf>");
        }
        public void WritePerson(TextWriter writer, T instance)
        {
            writer.WriteLine("<{0}>", instance.GetType().Name);
            writer.WriteLine("<FirstName>{0}</FirstName>", Get<String, Person>(person => person.FirstName, instance));
            writer.WriteLine("<LastName>{0}</LastName>", Get<String, Person>(person => person.LastName, instance));
            RootDescriptor<Address> adressDescriptor = getAddressDescriptor();
            RootDescriptor<Country> countryDescriptor = getCitizenDescriptor();
            writer.WriteLine("<HomeAddress>");
            adressDescriptor.Serialize(writer, Get<Address, Person>(person => person.HomeAddress, instance));
            writer.WriteLine("</HomeAddress>");
            writer.WriteLine("<WorkAddress>");
            adressDescriptor.Serialize(writer, Get<Address, Person>(person => person.WorkAddress, instance));
            writer.WriteLine("</WorkAddress>");
            countryDescriptor.Serialize(writer, Get<Country, Person>(person => person.CitizenOf, instance));
            RootDescriptor<PhoneNumber> phoneDescriptor = getPhoneNumberDescriptor();
            phoneDescriptor.Serialize(writer, Get<PhoneNumber, Person>(person => person.MobilePhone, instance));
            writer.WriteLine("</{0}>", instance.GetType().Name);
        }
        static RootDescriptor<Country> getCountryDescriptor()
        {
            return new RootDescriptor<Country>(PersonModelTypes.Country);
        }
        static RootDescriptor<PhoneNumber> getPhoneNumberDescriptor()
        {
            return new RootDescriptor<PhoneNumber>(PersonModelTypes.PhoneNumber);
        }

        static RootDescriptor<Country> getCitizenDescriptor()
        {
            return new RootDescriptor<Country>(PersonModelTypes.Citizen);
        }
        static I Get<I,O>(Func<O,I> getter, object i)
        {
            return getter((O)i);
        }
    }

}
