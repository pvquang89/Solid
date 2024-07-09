internal class Program
{
    // // Không áp dụng ISP
    // public interface IUser
    // {
    //     void Login(string username, string password);
    //     void Logout();
    //     void ChangePassword(string newPassword);
    //     void ViewProfile();
    //     void AssignRole(string role);
    //     void ResetPassword();
    // }
    // Áp dụng ISP
    public interface IUser
    {
        void Login(string username, string password);
        void Logout();
        void ChangePassword(string newPassword);
        void ViewProfile();
    }

    public interface IAdminUser : IUser
    {
        void AssignRole(string role);
    }

    public interface IPasswordResettableUser : IUser
    {
        void ResetPassword();
    }
    private static void Main(string[] args)
    {
    }
}