using Snake.App.Models;
using System.Collections.Generic;
using System;

namespace Snake.App.Business
{
    class Harta
    {
        public void CreeazaHarta(List<SectiunePerimetru> sectiunilePerimetrului, List<SectiuneSnake> sectiunilePentruSnake, Apple apple)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    SectiunePerimetru sectiunePerimetru = sectiunilePerimetrului.Find(x => x.Rand == i && x.Coloana == j);
                    if (sectiunePerimetru != null)
                    {
                        Console.Write(sectiunePerimetru.Fundal);

                        continue;
                    }

                    SectiuneSnake sectiuneSnake = sectiunilePentruSnake.Find(x => x.Rand == i && x.Coloana == j);
                    if (sectiuneSnake != null)
                    {
                        Console.Write(sectiuneSnake.Fundal);

                        continue;
                    }

                    if (i == apple.Rand && j == apple.Coloana)
                    {
                        Console.Write(apple.Fundal);

                        continue;
                    }

                    Console.Write(".");

                }
                Console.WriteLine();
            }
        }
    }
}
