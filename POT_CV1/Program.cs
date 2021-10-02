using System;

namespace POT_CV1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            if (args.Length == 0 )
            {
                Console.Write("Zadajte meno:");
                name = Console.ReadLine();
            }
            else
            {
                name = args[0];                
            }
            Console.WriteLine($"{"Hello"}.{name}");
        }
    }
}
