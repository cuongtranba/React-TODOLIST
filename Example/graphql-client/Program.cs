using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using QLHH.DAL;

namespace graphql_client
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HongLienContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=ForTest;Trusted_Connection=True;MultipleActiveResultSets=true");
            using (var db =new HongLienContext(optionsBuilder.Options))
            {
                Stopwatch stopwatch = new Stopwatch();

                // Begin timing.
                stopwatch.Start();

                // Do something.
                var a = db.AttributeTypes.FirstOrDefault(c => c.AttributeTypeName.Contains("123aaa"));
                // Stop timing.
                stopwatch.Stop();

                // Write result.
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
                Console.ReadLine();
            }
        }
    }
}