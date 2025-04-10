using System.Security.AccessControl;

namespace lab6._1
{
    internal  class Figure
    {
        protected int Length;
        protected int Width;
        protected int Height;

        public Figure() { }

        public Figure(int length, int width, int height)
        {
            try
            {
                if (length <= 0 || width <= 0 || height <= 0)
                {
                    throw new ArgumentOutOfRangeException("Значения длины, ширины и высоты должны быть больше нуля.");
                }

                this.Length = length;
                this.Width = width;
                this.Height = height;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Environment.Exit(1); 
            }
        }

        public Figure(Figure other)
        {
            this.Length = other.Length;
            this.Width = other.Width;
            this.Height = other.Height;
        }

        public int CalculateVolume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            return $"Длина: {Length}, Ширина: {Width}, Высота: {Height}";
        }
    }

}
