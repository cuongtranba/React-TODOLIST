using shit.Model;
using System;
using System.Linq;
using Thrift.Protocol;
using Thrift.Transport;

namespace shit
{
    class Program
    {
        public static IntegrationDb integrationDb = new IntegrationDb();
        static void Main(string[] args)
        {
            InsertTown();
            InsertCountry();
            //InsertCompanyAffiliation();
        }

        private static void InsertCompanyAffiliation()
        {
            throw new NotImplementedException();
        }

        private static void InsertCountry()
        {
            var query = from a in integrationDb.countries1
                        join b in integrationDb.Countries on a.countryName equals b.Label into ab
                        from p in ab.DefaultIfEmpty()
                        where (a.countryName != null && a.countryName != string.Empty) && p.Label != a.countryName
                        select new { a.countryName };
            var countryNew = query.ToList().Select(c => new Country() { Label = c.countryName });
            integrationDb.Countries.AddRange(countryNew);
            integrationDb.SaveChanges();
        }

        private static void InsertTown()
        {
            var query = from a in integrationDb.towns1.Select(c=>c.town_name).Distinct()
                        join b in integrationDb.Towns on a equals b.Label into ab
                        from p in ab.DefaultIfEmpty()
                        where (a != null && a != string.Empty) && p.Label != a
                        select new { a };
            var townNew = query.ToList().Select(c => new Town() { Label = c.a});
            integrationDb.Towns.AddRange(townNew);
            integrationDb.SaveChanges();
        }
    }
}
