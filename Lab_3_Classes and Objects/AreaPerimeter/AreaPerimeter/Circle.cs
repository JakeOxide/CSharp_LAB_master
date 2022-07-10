namespace AreaPerimeter
{
    class Circle : Shape
    {
        private static float PI = 3.14f;
        public double radius { get; set; }

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public override double calculateArea()
        {
            double area = (PI * (radius * radius));
            return area;
        }

        public override double calculatePerimeter()
        {
            double perimeter = (2 * PI * radius);
            return perimeter;
        }

        }
}