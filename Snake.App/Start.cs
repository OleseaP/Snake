using Snake.App.Business;
using System;

namespace Snake.App
{
    public class Start
    {
        static void Main()
        {
            while (true)
            {
                var sectiune = new Sectiune();
                sectiune.AdaugaSectiunileDeStartPentruPerimetru();
                sectiune.AdaugaSectiunileDeStartPentruSnake();
                sectiune.PozitiaDeStartPentruApple();

                var harta = new Harta();
                harta.CreeazaHarta(sectiune.SectiunilePerimetrului, sectiune.SectiunilePentruSnake, sectiune.Apple);

                var directia = InteractiuneCuUtilizatorul.CitesteDirectiaDeMiscareIntrodusaDeUtilizator();

                if (directia == ConsoleKey.UpArrow)
                {

                }
            }
        }
    }
    
    //"internal" + "cuvantul cheie CLASS" + "Denumirea clasei"
    //{
    //}
    //"private" + "tipul proprietatii" + "Denumirea proprietatii"
    //{
    //}
}
