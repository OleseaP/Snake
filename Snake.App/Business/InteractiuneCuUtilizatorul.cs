using System;

namespace Snake.App.Business
{
    class InteractiuneCuUtilizatorul
    {
        public static ConsoleKey anterioara = ConsoleKey.DownArrow;

        public static ConsoleKey CitesteDirectiaDeMiscareIntrodusaDeUtilizator() 
        {
            //while (true)
            //{
            if (Console.KeyAvailable)
            {
                //Console.WriteLine("Alege directia pentru sarpe.");
                ConsoleKeyInfo directia = Console.ReadKey();
                //Console.WriteLine();

            async: if (directia.Key != ConsoleKey.DownArrow &&
                 directia.Key != ConsoleKey.UpArrow &&
                 directia.Key != ConsoleKey.LeftArrow &&
                 directia.Key != ConsoleKey.RightArrow)
                {
                    goto async;
                    //Console.WriteLine("Ai introdus o tasta gresita. Mai incearca.");
                }
                else
                {
                    //Console.Clear();
                    anterioara = directia.Key;
                    return directia.Key;
                }
            }
            return anterioara;
            //}
        }
    }
}
