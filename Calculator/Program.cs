using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Actions:");
            Console.WriteLine("1 - addition");
            Console.WriteLine("2 - subtraction");
            Console.WriteLine("3 - multiplication");
            Console.WriteLine("4 - division");
            Console.WriteLine("5 - Exit");
            string action = "5";
            do
            {
                Console.Write("Enter Value 1: ");
                string value1 = Console.ReadLine();
                Console.Write("Enter Value 2: ");
                string value2 = Console.ReadLine();
                Console.Write("Select action: ");
                action = Console.ReadLine();
                double result = new double();
                switch (action)
                {
                    case "1":
                        result = int.Parse(value1) + int.Parse(value2);
                        break;
                    case "2":
                        result = int.Parse(value1) - int.Parse(value2);
                        break;
                    case "3":
                        result = int.Parse(value1) * int.Parse(value2);
                        break;
                    case "4":
                        result = int.Parse(value1) / int.Parse(value2);
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("error wrong action");
                        break;
                }
                Console.WriteLine($"result - {result}");
            } while (action != "5");
            
           
        }
    }
}
