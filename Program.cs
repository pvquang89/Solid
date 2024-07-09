internal class Program
{
    // Trước khi áp dụng OCP
    // public class AreaCalculator
    // {
    //     public double CalculateArea(object shape)
    //     {
    //         if (shape is Rectangle)
    //         {
    //             Rectangle rectangle = (Rectangle)shape;
    //             return rectangle.Width * rectangle.Height;
    //         }
    //         else if (shape is Circle)
    //         {
    //             Circle circle = (Circle)shape;
    //             return Math.PI * circle.Radius * circle.Radius;
    //         }
    //         // Các hình khác...
    //         return 0;
    //     }
    // }

    // Sau khi áp dụng OCP
    public interface IShape
    {
        double CalculateArea();
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    //???? Tách biệt logic
    public class AreaCalculator
    {
        public double CalculateArea(IShape shape)
        {
            return shape.CalculateArea();
        }
    }

    //Ví dụ thêm tam giác
    public class Triangle : IShape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public double CalculateArea()
        {
            return 0.5 * Base * Height;
        }


        private static void Main(string[] args)
        {
            Rectangle r = new Rectangle { Width = 10, Height = 20 };
            Circle c = new Circle { Radius = 15 };
            System.Console.WriteLine("Rectangle area : " + r.CalculateArea());
            System.Console.WriteLine("Circle area : " + Math.Round(c.CalculateArea(), 2));
            //
            Triangle t = new Triangle { Base = 6, Height = 4 };
            AreaCalculator a = new AreaCalculator();
            System.Console.WriteLine("Triagle area : "+ a.CalculateArea(t));


        }
    }
}