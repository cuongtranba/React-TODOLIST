using System;

namespace Object_Proxy_By_Refector_ReflectionEMIT
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyGenerator.GetInterfaceProxy<Student>();
            Console.ReadLine();
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }



}