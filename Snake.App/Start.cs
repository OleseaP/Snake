using Snake.App.Business;
using System;
using System.Linq;

namespace Snake.App
{
    public class Start
    {
        static void Main()
        {
            var sectiune = new Sectiune();
            sectiune.AdaugaSectiunileDeStartPentruPerimetru();
            sectiune.AdaugaSectiunileDeStartPentruSnake();
            sectiune.PozitiaDeStartPentruApple();

            var harta = new Harta();

            while (true)
            {
                harta.CreeazaHarta(sectiune.SectiunilePerimetrului, sectiune.SectiunilePentruSnake, sectiune.Apple);

                var directia = InteractiuneCuUtilizatorul.CitesteDirectiaDeMiscareIntrodusaDeUtilizator();

                #region Verific daca sarpele poate inainta.
                bool sarpelePoateInainta = true;

                if (directia == ConsoleKey.UpArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    var sectiuneaUnu = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 1);

                    if (head.Coloana == sectiuneaUnu.Coloana && (head.Rand - 1) == sectiuneaUnu.Rand)
                    {
                        sarpelePoateInainta = false;
                    }
                }
                if (directia == ConsoleKey.DownArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    var sectiuneaUnu = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 1);

                    if (head.Coloana == sectiuneaUnu.Coloana && (head.Rand + 1) == sectiuneaUnu.Rand)
                    {
                        sarpelePoateInainta = false;
                    }
                }
                if (directia == ConsoleKey.LeftArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    var sectiuneaUnu = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 1);

                    if ((head.Coloana - 1) == sectiuneaUnu.Coloana && head.Rand == sectiuneaUnu.Rand)
                    {
                        sarpelePoateInainta = false;
                    }
                }
                if (directia == ConsoleKey.RightArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    var sectiuneaUnu = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 1);

                    if ((head.Coloana + 1) == sectiuneaUnu.Coloana && head.Rand == sectiuneaUnu.Rand)
                    {
                        sarpelePoateInainta = false;
                    }
                }
                #endregion

                #region Verific daca sarpele va lovi perimetrul.
                bool sarpeleALovitPerimetru = false;

                if (directia == ConsoleKey.UpArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    sarpeleALovitPerimetru = sectiune.SectiunilePerimetrului.Any(x => x.Coloana == head.Coloana && x.Rand == (head.Rand - 1));
                }
                if (directia == ConsoleKey.DownArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    sarpeleALovitPerimetru = sectiune.SectiunilePerimetrului.Any(x => x.Coloana == head.Coloana && x.Rand == (head.Rand + 1));
                }
                if (directia == ConsoleKey.LeftArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    sarpeleALovitPerimetru = sectiune.SectiunilePerimetrului.Any(x => x.Coloana == (head.Coloana - 1) && x.Rand == head.Rand);
                }
                if (directia == ConsoleKey.RightArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    sarpeleALovitPerimetru = sectiune.SectiunilePerimetrului.Any(x => x.Coloana == (head.Coloana + 1) && x.Rand == head.Rand);
                }
                #endregion

                #region Verific daca sarpele va lovi coada sa.
                bool sarpeleALovitCoadaSa = false;

                if (directia == ConsoleKey.UpArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    sarpeleALovitCoadaSa = sectiune.SectiunilePentruSnake.Any(x => x.Coloana == head.Coloana && x.Rand == (head.Rand - 1));
                }
                if (directia == ConsoleKey.DownArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    sarpeleALovitCoadaSa = sectiune.SectiunilePentruSnake.Any(x => x.Coloana == head.Coloana && x.Rand == (head.Rand + 1));
                }
                if (directia == ConsoleKey.LeftArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    sarpeleALovitCoadaSa = sectiune.SectiunilePentruSnake.Any(x => x.Coloana == (head.Coloana - 1) && x.Rand == head.Rand);
                }
                if (directia == ConsoleKey.RightArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);
                    sarpeleALovitCoadaSa = sectiune.SectiunilePentruSnake.Any(x => x.Coloana == (head.Coloana + 1) && x.Rand == head.Rand);
                }
                #endregion

                #region Verific daca sarpele va manca marul
                bool sarpeleAMancatMarul = false;

                if (directia == ConsoleKey.UpArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);

                    if (head.Coloana == sectiune.Apple.Coloana && (head.Rand - 1) == sectiune.Apple.Rand)
                    {
                        sarpeleAMancatMarul = true;
                    }
                }
                if (directia == ConsoleKey.DownArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);

                    if (head.Coloana == sectiune.Apple.Coloana && (head.Rand + 1) == sectiune.Apple.Rand)
                    {
                        sarpeleAMancatMarul = true;
                    }
                }
                if (directia == ConsoleKey.LeftArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);

                    if ((head.Coloana - 1) == sectiune.Apple.Coloana && head.Rand == sectiune.Apple.Rand)
                    {
                        sarpeleAMancatMarul = true;
                    }
                }
                if (directia == ConsoleKey.RightArrow)
                {
                    var head = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == 0);

                    if ((head.Coloana + 1) == sectiune.Apple.Coloana && head.Rand == sectiune.Apple.Rand)
                    {
                        sarpeleAMancatMarul = true;
                    }
                }
                #endregion

                #region Misca sarpele o pozitie inainte

                if (directia == ConsoleKey.UpArrow)
                {
                    for (int i = 0; i < sectiune.SectiunilePentruSnake.Count; i++)
                    {
                        var sectiunea = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == i);
                        if (i == 0) // Sectiunea HEAD
                        {
                            sectiunea.Rand = sectiunea.Rand - 1;

                            continue;
                        }

                        sectiunea.Rand = sectiunea.Rand - 1;
                    }


                }
              
                #endregion
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
