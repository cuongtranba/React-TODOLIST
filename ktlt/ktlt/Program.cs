using System;

namespace ktlt
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO khi nhập n=4 thì tính 1+2+3+4 = 10
            
            var n = Console.ReadLine();
            int i = 0;
            int s = 0;
            while (i <= int.Parse(n))
            {
                s = s + i;
                i++;
            }
            Console.WriteLine("Tong la:"+s);
        }
    }
}