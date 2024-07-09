using System.Data.Common;

//Dependence inversion
//1. Các module cấp cao không lên phụ thuộc vào các module cấp thấp, cả 2 nên phụ thuộc vào abstracition 
//2. Abstraction không nên phụ thuộc vào chi tiết mà ngược lại
//(các class nên giao tiếp với nhau thông qua interface, ko phải thông qua implementation)
//-----------------------------------------------------------------------------------------------------------
//Áp dụng ta được
//1. OrderProcessor (module cấp cao) không trực tiếp sử dụng các lớp cụ thể như CreditCardPaymentService, CashPaymentService, EmailNotiService, hay SMSNotiService.
//Thay vào đó, nó sử dụng abstraction IPaymentService và INotiService.
//2. Các module cấp thấp đều implement interface tương ứng, các phương thức ko làm thay đổi chữ ký của interface
internal class Program
{
    //Định nghĩa các abstraction
    public interface IPaymentService
    {
        void ProcessPayment(Order order);
    }
    public interface INotiService
    {
        void SendNoti(string message);
    }

    //Định nghĩa các implementation(concrete class/module cấp thấp)
    public class CreditCardPaymentService : IPaymentService
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Processing credit card payment for order: " + order.Id);
        }
    }

    public class CashPaymentService : IPaymentService
    {
        public void ProcessPayment(Order order)
        {
            Console.WriteLine("Processing cash payment for order: " + order.Id);
        }
    }
    public class EmailNotiService : INotiService
    {
        public void SendNoti(string message)
        {
            System.Console.WriteLine("Sending email notification: " + message);
        }
    }
    //Ví dụ bây giờ thêm chức năng gửi thông báo qua sms
    public class SMSNotiService : INotiService
    {
        public void SendNoti(string message)
        {
            System.Console.WriteLine("Sending SMS notification: " + message);
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Amount { get; set; }
    }

    //Định nghĩa module cấp cao
    public class OrderProcessor
    {
        //module sử dụng abstraction thay vì implemention(module cấp thấp) 
        public readonly IPaymentService _paymentService;
        public readonly INotiService _notiService;

        //xử lý inject
        public OrderProcessor(IPaymentService paymentService, INotiService notiService)
        {
            _paymentService = paymentService;
            _notiService = notiService;
        }
        public void ProcessOrder(Order order)
        {
            _paymentService.ProcessPayment(order);
            _notiService.SendNoti("Order " + order.Id + " has been processed");
        }
    }

    private static void Main(string[] args)
    {
        // Tạo các đối tượng cụ thể
        IPaymentService creditCardPaymentService = new CreditCardPaymentService();
        IPaymentService cashPaymentService = new CashPaymentService();
        INotiService emailNotificationService = new EmailNotiService();
        INotiService smsNotificationService = new SMSNotiService();

        // Tạo OrderProcessor với các dịch vụ đã inject (thanh toán bằng credit card và gửi qua Email)
        OrderProcessor creditCardOrderProcessor = new OrderProcessor(creditCardPaymentService, emailNotificationService);

        // Tạo OrderProcessor với các dịch vụ đã inject (thanh toán bằng tiền mặt và gửi qua SMS)
        OrderProcessor cashOrderProcessor = new OrderProcessor(cashPaymentService, smsNotificationService);

        // Tạo một đơn đặt hàng
        Order order1 = new Order { Id = 1, ProductName = "Laptop", Amount = 1000.00 };
        // Xử lý đơn đặt hàng và thanh toán bằng credit card, gửi thông báo qua Email
        creditCardOrderProcessor.ProcessOrder(order1);
        System.Console.WriteLine("------------------------------------------------");
        Order order2 = new Order { Id = 1, ProductName = "Laptop", Amount = 1000.00 };
        // Xử lý đơn đặt hàng và thanh toán bằng tiền mặt, gửi thông báo qua SMS
        cashOrderProcessor.ProcessOrder(order2);
    }
}