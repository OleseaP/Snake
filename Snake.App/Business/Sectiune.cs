using Snake.App.Models;
using System.Collections.Generic;

namespace Snake.App.Business
{
    public class Sectiune
    {
        public List<SectiunePerimetru> SectiunilePerimetrului { get; set; } = new List<SectiunePerimetru>();
        public List<SectiuneSnake> SectiunilePentruSnake { get; set; } = new List<SectiuneSnake>();
        public Apple Apple { get; set; }

        public void AdaugaSectiunileDeStartPentruPerimetru()
        {
            // Am adaugat sectiunile pentru latura de sus.
            for (int i = 0; i < 20; i++)
            {
                var sectiunea = new SectiunePerimetru();
                sectiunea.Fundal = '#';
                sectiunea.Rand = 0;
                sectiunea.Coloana = i;

                SectiunilePerimetrului.Add(sectiunea);
            }

            // Am adaugat sectiunile pentru latura din stanga.
            for (int i = 1; i < 20; i++)
            {
                var sectiunea = new SectiunePerimetru();
                sectiunea.Fundal = '#';
                sectiunea.Rand = i;
                sectiunea.Coloana = 0;

                SectiunilePerimetrului.Add(sectiunea);
            }

            // Am adaugat sectiunile pentru latura din dreapta.
            for (int i = 1; i < 20; i++)
            {
                var sectiunea = new SectiunePerimetru();
                sectiunea.Fundal = '#';
                sectiunea.Rand = i;
                sectiunea.Coloana = 19;

                SectiunilePerimetrului.Add(sectiunea);
            }

            // Am adaugat sectiunile pentru latura de jos.
            for (int i = 1; i < 20; i++)
            {
                var sectiunea = new SectiunePerimetru();
                sectiunea.Fundal = '#';
                sectiunea.Rand = 19;
                sectiunea.Coloana = i;

                SectiunilePerimetrului.Add(sectiunea);
            }
        }

        public void AdaugaSectiunileDeStartPentruSnake()
        {
            for (int i = 4; i >= 0; i--)
            {
                if (i == 0)
                {
                    var sectiuneaHead = new SectiuneSnake();
                    sectiuneaHead.Fundal = '*';
                    sectiuneaHead.Head = true;
                    sectiuneaHead.Rand = 5;
                    sectiuneaHead.Coloana = 5;

                    SectiunilePentruSnake.Add(sectiuneaHead);
                }
                else
                {
                    var sectiunea = new SectiuneSnake();
                    sectiunea.Fundal = '&';
                    sectiunea.Head = false;
                    sectiunea.Rand = 5;
                    sectiunea.Coloana = i;

                    SectiunilePentruSnake.Add(sectiunea);
                }
            }
        }

        public void PozitiaDeStartPentruApple()
        {
            Apple = new Apple();
            Apple.Fundal = 'O';
            Apple.Rand = 5;
            Apple.Coloana = 7;
        }
    }
}
