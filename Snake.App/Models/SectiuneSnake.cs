namespace Snake.App.Models
{
    public class SectiuneSnake
    {
        public char Fundal { get; set; }
        public int Rand { get; set; }
        public int Coloana { get; set; }
        public int NumarulSectiunei { get; set; }
        public int[] PozitiaAnterioara { get; set; } = new int[2];
    }
}
