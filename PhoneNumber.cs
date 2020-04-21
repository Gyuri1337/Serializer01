using System;
using System.Collections.Generic;
using System.Text;

namespace Serializer
{
	class PhoneNumber
    {
        public Country Country { get; set; }
        public int Number { get; set; }

        static RootDescriptor<PhoneNumber> getPhoneNumberDescriptor()
        {
            return new RootDescriptor<PhoneNumber>(PersonModelTypes.PhoneNumber);
        }
    }
}
