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
            if (amount + penalty > balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
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

    public class SavingsAccount : BankAccount
    {
        private double higherRate = 0.075;

        public SavingsAccount(int accountNumber, double initialBalance, double interestRate)
            : base(accountNumber, initialBalance, interestRate)
        {
        }

        public new void CalculateInterest()
        {
            // Calculate interest based on the original balance before this calculation
            double interest = GetBalance() * higherRate;
            Deposit(interest);
        }
    }
}
