namespace AreaPerimeter
{
    class Circle
    {
        private static float PI = 3.14f;
        public double radius { get; set; }

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public double calculateArea()
        {
            double area = (PI * (radius * radius));
            return area;
        }

        public double calculatePerimeter()
        {
            double perimeter = (2 * PI * radius);
            return perimeter;
        }

        }
}