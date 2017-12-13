using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNoCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ForTestEntities1())
            {
                EntityType a = db.EntityTypes.Find(4);
                Console.WriteLine(a.GetType().FullName);

            }

        }
    }
}
