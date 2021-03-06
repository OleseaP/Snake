using Snake.App.Business;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Snake.App
{
    public class Start
    {
        static async Task Main()
        {
            var sectiune = new Sectiune();
            sectiune.AdaugaSectiunileDeStartPentruPerimetru();
            sectiune.AdaugaSectiunileDeStartPentruSnake();
            sectiune.PozitiaDeStartPentruApple();

            var harta = new Harta();

            ConsoleKey directia = ConsoleKey.RightArrow;
            var task = new Thread(() =>
            {
                while (true)
                {
                    //Thread.Sleep(50);
                    directia = InteractiuneCuUtilizatorul.CitesteDirectiaDeMiscareIntrodusaDeUtilizator();
                }

            });

            var task2 = new Thread(() =>
            {
                while (true)
                {

                    Thread.Sleep(100);
                    Console.Clear();
                    harta.CreeazaHarta(sectiune.SectiunilePerimetrului, sectiune.SectiunilePentruSnake, sectiune.Apple);

                    //var directia = InteractiuneCuUtilizatorul.CitesteDirectiaDeMiscareIntrodusaDeUtilizator();

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

                    #region Misca sarpele cu o pozitie inainte

                    for (int i = 0; i < sectiune.SectiunilePentruSnake.Count; i++)
                    {
                        var sectiunea = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == i);

                        if (i == 0) // Sectiunea HEAD
                        {
                            if (directia == ConsoleKey.UpArrow)
                            {
                                sectiunea.Rand = sectiunea.Rand - 1;
                            }
                            if (directia == ConsoleKey.DownArrow)
                            {
                                sectiunea.Rand = sectiunea.Rand + 1;
                            }
                            if (directia == ConsoleKey.LeftArrow)
                            {
                                sectiunea.Coloana = sectiunea.Coloana - 1;
                            }
                            if (directia == ConsoleKey.RightArrow)
                            {
                                sectiunea.Coloana = sectiunea.Coloana + 1;
                            }
                        }
                        else
                        {
                            var sectiuneaDinFata = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == (i - 1));
                            sectiunea.Rand = sectiuneaDinFata.PozitiaAnterioara[0];
                            sectiunea.Coloana = sectiuneaDinFata.PozitiaAnterioara[1];
                        }
                    }

                    #region Reseteaza proprietatea PozitiaAnterioara
                    for (int i = 0; i < sectiune.SectiunilePentruSnake.Count; i++)
                    {
                        var sectiunea = sectiune.SectiunilePentruSnake.FirstOrDefault(x => x.NumarulSectiunei == i);

                        sectiunea.PozitiaAnterioara[0] = sectiunea.Rand;
                        sectiunea.PozitiaAnterioara[1] = sectiunea.Coloana;
                    }
                    #endregion

                    #endregion
                }
            });

            task2.Start();
            task.Start();
        }
    }
    
    //"internal" + "cuvantul cheie CLASS" + "Denumirea clasei"
    //{
    //}
    //"private" + "tipul proprietatii" + "Denumirea proprietatii"
    //{
    //}
}
