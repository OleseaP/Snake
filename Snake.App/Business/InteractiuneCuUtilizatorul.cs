using System;

namespace Snake.App.Business
{
    class InteractiuneCuUtilizatorul
    {
        public static ConsoleKey CitesteDirectiaDeMiscareIntrodusaDeUtilizator() 
        {
            while (true)
            {
                Console.WriteLine("Alege directia pentru sarpe.");
                ConsoleKeyInfo directia = Console.ReadKey();
                Console.WriteLine();

                if (directia.Key != ConsoleKey.DownArrow &&
                    directia.Key != ConsoleKey.UpArrow &&
                    directia.Key != ConsoleKey.LeftArrow &&
                    directia.Key != ConsoleKey.RightArrow)
                {
                    Console.WriteLine("Ai introdus o tasta gresita. Mai incearca.");
                }
                else
                {
                    Console.Clear();

                    return directia.Key;
                }
            }
        }
    }
}
