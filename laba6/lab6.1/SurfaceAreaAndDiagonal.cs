namespace lab6._1
{
    internal class SurfaceAreaAndDiagonal : Figure
    {
        public int length
        {
            get
            {
                return base.Length;
            }
            set
            {
                base.Length = value; 
            }
        }
        public int width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value; 
            }
        }
        public int height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value; 
            }
        }


        public SurfaceAreaAndDiagonal() : base() { }

        public SurfaceAreaAndDiagonal(int length, int width, int height) : base(length, width, height) { }

        public SurfaceAreaAndDiagonal(SurfaceAreaAndDiagonal other) : base(other) { }

        public int CalculateSurfaceArea()
        {
            return 2 * (length * width + length * height + width * height);
        }

        public double CalculateDiagonal()
        {
            return Math.Sqrt(length * length + width * width + height * height);
        }

        public override string ToString()
        {
            return $"Длина: {length}, Ширина: {width}, Высота: {height}";
        }
    }
}
