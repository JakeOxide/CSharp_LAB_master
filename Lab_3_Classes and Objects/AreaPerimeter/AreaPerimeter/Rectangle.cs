namespace AreaPerimeter
{
    class Rectangle : Shape
    {
        public double length { get; set; }

        public double width { get; set; }

        public Rectangle(int length, int width)
        {
            this.length = length;
            this.width = width;
        }

        public override double calculateArea()
        {
            double area = length * width;
            return area;
        }

        public override double calculatePerimeter()
        {
            double perimeter = 2 * (length + width);
            return perimeter;
        }

    }
}