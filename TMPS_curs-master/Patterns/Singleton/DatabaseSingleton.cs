using Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Singleton
{
    public class DatabaseSingleton
    {
        private static ProductContext productContext = null;
        private static readonly object lockObj = new object();

        private DatabaseSingleton() { }

        // свойство 
        //public static ProductContext ProductContext
        //{
        //    get
        //    {
        //        lock (lockObj)
        //        {
        //            if (productContext == null)
        //            {
        //                productContext = new ProductContext();
        //            }
        //            return productContext;
        //        }
        //    }
        //}
    }
}
