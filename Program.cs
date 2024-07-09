internal class Program
{
    //Liskov Substitution Principle 
    //Lớp con có thể thay thế lớp cha nhưng không làm thay đổi tính đúng đắn của lớp cha 

    //VD kông áp dụng
    // public class Rectangle
    // {
    //     public double Width { get; set; }
    //     public double Height { get; set; }

    //     public double GetArea()
    //     {
    //         return Width * Height;
    //     }
    // }

    // public class Square : Rectangle
    // {
    //     //new : tức là Width ở đây là thuộc tính riêng biệt,  sẽ ko ghi đè lên Width ở class Rectangle
    //     public new double Width
    //     {
    //         //trả về thuộc tính Width từ class cha Rectangle
    //         get { return base.Width; }
    //         //nếu không dùng base.Width thì sẽ lỗi lặp vô hạn gọi lại setter vì Width=Height=value sẽ tự động gọi setter
    //         set { base.Width = base.Height = value; }
    //     }

    //     public new double Height
    //     {
    //         get { return base.Height; }
    //         set { base.Width = base.Height = value; }
    //     }
    // }

    //-------------------------------------------------------------------------------------
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

    public class Square : IShape
    {
        public double SideLength { get; set; }

        public double CalculateArea()
        {
            return SideLength * SideLength;
        }
    }

    private static void Main(string[] args)
    {
        //Ko áp dụng LRP
        // Rectangle r = new Rectangle();
        // Square s = new Square{Height=10,Width=20};
        // //r.Height=0 vì r và s chưa trỏ chung 1 bộ nhớ
        // System.Console.WriteLine(r.Height);
        // //Trỏ chung 1 bộ nhớ, con thay thế cha
        // Rectangle r1 = s;
        // //r1.Height=100
        // System.Console.WriteLine(r1.Height);
        // //r1.GetArea() = 400 sai
        // System.Console.WriteLine(r1.GetArea());

        //-----------------------------------------------------------------------------------
        //Áp dụng LRP
        IShape rectangle = new Rectangle { Width = 5, Height = 10 };
        Console.WriteLine($"Area of Rectangle: {rectangle.CalculateArea()}"); // Output: 50
        IShape square = new Square { SideLength = 7 };
        Console.WriteLine($"Area of Square: {square.CalculateArea()}"); // Output: 49

    }
}