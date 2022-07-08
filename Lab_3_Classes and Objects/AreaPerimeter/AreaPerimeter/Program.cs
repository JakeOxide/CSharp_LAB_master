using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            while (again)
            {
                var control = new MyConsole();
                int action = control.getActionValue();
                if (action == 1)
                {
                    int radius = control.promptValue(0, 100, "\n Enter the Radius of the Circle (max 100) : ");
                    var myCircle = new Circle(radius);
                    Console.WriteLine("\n \t The area is : " + Math.Round(myCircle.calculateArea(), 2));
                    Console.WriteLine("\n \t The perimeter is : " + Math.Round(myCircle.calculatePerimeter(), 2));
                }
                else
                {
                    int length = control.promptValue(0, 100, "\n Enter the Length of the Rectangle (max 100) : ");
                    int width = control.promptValue(0, 100, "\n Enter the Width of the Rectangle (max 100) : ");
                    var myRectangle = new Rectangle(length, width);
                    Console.WriteLine("\n \t The area is : " + myRectangle.calculateArea());
                    Console.WriteLine("\n \t The perimeter is : " + myRectangle.calculatePerimeter());
                }

                do
                {
                    int choice = control.promptValue(0, 1, "\n Do you want to clear the screen and continue (Y=1/N=0) : ");
                    if (choice == 1)
                    {
                        again = true;
                        Console.Clear();
                    }
                    else
                        again = false;
                    break;
                } while (again);
            }
        }
    }

    class MyConsole
    {
        private int actionValue;

        public MyConsole()
        {
            promptInput();
            actionValue = identify(acceptAndVerify(1, 2, "\n Input action choice Here: "));
        }

        public void promptInput()
        {
            Console.WriteLine("\n Choose an action you want to perform");
            Console.WriteLine("\n \t 1. Find the area and perimeter of a circle");
            Console.WriteLine("\n \t 2. Find the area and perimeter of a rectangle");
        }

        private int identify(int input)
        {
            int number = -1;
            switch (input)
            {
                case 1:
                    {
                        number = 1;
                        break;
                    }
                case 2:
                    {
                        number = 2;
                        break;
                    }
            }
            return number;
        }

        public int promptValue(int min, int max, string text)
        {
            Console.WriteLine();
            int value = acceptAndVerify(min, max, text);
            return value;
        }

        public int acceptAndVerify(int min, int max, string text)
        {
            int res;
            do
            {
                Console.Write(text);
                res = Convert.ToInt32(Console.ReadLine());
                if (res >= min && res <= max)
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("\n Wrong Input, Try again");
                }
            } while (res < min || res > max);
            return res;
        }

        public int getActionValue()
        {
            return actionValue;
        }

    }
}