using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore.Core
{
    public class ObjectFactory
    {

        public static IApplicationContext GetApplicationContext()
        {
            return ContextRegistry.GetContext();
        }

        public static object GetObject(string objectName)
        {
            return GetApplicationContext()[objectName];
        }

    }
}
