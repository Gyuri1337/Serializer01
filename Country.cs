using System;
using System.Collections.Generic;
using System.Text;

namespace Serializer
{
	class Country
    {
        public string Name { get; set; }
        public int AreaCode { get; set; }
        static RootDescriptor<PhoneNumber> getCountryDescriptor()
        {
            return new RootDescriptor<PhoneNumber>(PersonModelTypes.Country);
        }
    }
}
