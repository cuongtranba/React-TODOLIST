using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var db = new TestContext())
            {
                var blogs = db.EntityTypes.Find(4);
                
            }
        }
    }

    public class TestContext:DbContext
    {
        public DbSet<EntityType> EntityTypes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ForTest;Trusted_Connection=True;");
        }
    }

    public class EntityType
    {
        public int EntityTypeId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EntityTypeName { get; set; }
        public bool IsDeleted { get; set; }
        public int UpdatedByUserId { get; set; }
    }
}