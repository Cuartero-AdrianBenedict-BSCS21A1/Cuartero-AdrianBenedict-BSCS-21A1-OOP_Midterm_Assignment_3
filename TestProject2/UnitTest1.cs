using ClassLibrary1;

namespace TestProject2
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }
    }

    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book SearchBook(string title)
        {
            return books.FirstOrDefault(b => b.Title == title);
        }
    }

    public class Customer
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetOrders()
        {
            return orders;
        }
    }

    public class Order
    {
    }

    public class EmailSender
    {
        public string SendEmail()
        {
            return "Email sent";
        }
    }

    public class OrderProcessor
    {
        private EmailSender _emailSender;

        public OrderProcessor(EmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public string ProcessOrder(Order order)
        {
            return _emailSender.SendEmail();
        }
    }
}

namespace TestProject1
{
    public class BankAccount
    {
        private int accountNumber;
        private double balance;
        private double interestRate;

        public BankAccount(int accountNumber, double initialBalance, double interestRate = 0.0)
        {
            this.accountNumber = accountNumber;
            this.balance = initialBalance;
            this.interestRate = interestRate;
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void Withdraw(double amount, bool isOtherBank = false)
        {
            double penalty = isOtherBank ? 20 : 0;
            balance -= (amount + penalty);
        }

        public void CalculateInterest()
        {
            balance += balance * interestRate;
        }

        public double GetBalance()
        {
            return balance;
        }
    }
}

namespace TestProject1
{
    public class SavingsAccount : BankAccount
    {
        private double higherRate = 0.075;

        public SavingsAccount(int accountNumber, double initialBalance, double interestRate)
            : base(accountNumber, initialBalance, interestRate)
        {
        }

        public new void CalculateInterest()
        {
            double balance = GetBalance();
            balance += balance * higherRate;
            Deposit(balance - GetBalance());
        }
    }
}
