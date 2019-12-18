using System;

namespace Hometask
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] countries = { "Andorra", "Liechtenstein", "Madagascar", "Japan", "Switzerland", "Togo", "Greece" };

            string temp;
            for (int i = 0; i < countries.Length - 1; i++)
            {
                for (int j = i + 1; j < countries.Length; j++)
                {
                    if (countries[i].Length > countries[j].Length)
                    {
                        temp = countries[i];
                        countries[i] = countries[j];
                        countries[j] = temp;
                    }
                }
            }

            foreach (string str in countries)
            {
                Console.WriteLine(str + " ");
            }

            Console.ReadLine();
        }
    }
}
