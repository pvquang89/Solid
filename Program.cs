internal class Program
{
    //Single Responsibility Principle
    //Mỗi class chỉ đảm nhiệm 1 trách nhiệm duy nhất, tức chỉ có lí do để thay đổi nó

    //Trước khi áp dụng
    //Class User có quá nhiểu phương thức không liên quan như SaveToDatabase, SendEmail
    // public class User
    // {
    //     public string Name { get; set; }
    //     public string Email { get; set; }
    //     public void SaveToDatabase(){}
    //     public void SendEmail(){}
    // }

    //Sau khi áp dụng
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UserRepository
    {
        public void SaveToDatabase(User user) { }
    }

    public class EmailService
    {
        public void SendEmail(User user) { }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}