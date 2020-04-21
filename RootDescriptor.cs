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

        }
    }

}
