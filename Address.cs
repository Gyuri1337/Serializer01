using System;
using System.Collections.Generic;
using System.Text;

namespace Serializer
{
	class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        static RootDescriptor<PhoneNumber> getAddressDescriptor()
        {
            return new RootDescriptor<PhoneNumber>(PersonModelTypes.Address);
        }
    }
}
