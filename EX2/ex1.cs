using System;
using System.Collections.Generic;

// Interfaces
public interface IAdmin
{
    void CreateAccount(string name, double initialAmount, string accountType);
}

public interface IAccountHolder
{
    void Withdraw(double amount);
    void Deposit(double amount);
    void ApplyForLoan(double amount);
}

public interface IAccount
{
    string AccountNumber { get; }
    string Name { get; set; }
    double Balance { get; set; }
    string AccountType { get; }
    void Transaction(double amount);
}

// Account Abstract Class
public abstract class Account : IAccount
{
    public string AccountNumber { get; private set; }
    public string Name { get; set; }
    public double Balance { get; set; }
    public abstract string AccountType { get; }

    protected Account(string name, double initialAmount)
    {
        AccountNumber = Guid.NewGuid().ToString();
        Name = name;
        Balance = initialAmount;
    }

    public abstract void Transaction(double amount);
}

// Specific Account Types
public class SavingsAccount : Account
{
    public override string AccountType => "Savings";

    public SavingsAccount(string name, double initialAmount) : base(name, initialAmount) {}

    public override void Transaction(double amount)
    {
        Balance += amount;
    }
}

public class CurrentAccount : Account
{
    public override string AccountType => "Current";

    public CurrentAccount(string name, double initialAmount) : base(name, initialAmount) {}

    public override void Transaction(double amount)
    {
        Balance += amount;
    }
}

// Admin Class
public class Admin : IAdmin
{
    private List<Account> accounts = new List<Account>();

    public void CreateAccount(string name, double initialAmount, string accountType)
    {
        if (accountType == "Savings")
            accounts.Add(new SavingsAccount(name, initialAmount));
        else if (accountType == "Current")
            accounts.Add(new CurrentAccount(name, initialAmount));
    }
}

// Account Holder Class
public class AccountHolder : IAccountHolder
{
    private Account account;

    public AccountHolder(Account account)
    {
        this.account = account;
    }

    public void Withdraw(double amount)
    {
        if (account.Balance >= amount && amount > 0)
            account.Transaction(-amount);
        else
            throw new Exception("Invalid transaction.");
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
            account.Transaction(amount);
        else
            throw new Exception("Invalid deposit amount.");
    }

    public void ApplyForLoan(double amount)
    {
        if (account.AccountType == "Current")
            throw new Exception("Loan not available for current accounts.");
        else
            Console.WriteLine($"Loan applied for: {amount}");  // Further implementation needed.
    }

    public double Balance
    {
        get { return account.Balance; }
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to the Banking Application!");
        Console.WriteLine("Are you an Admin or an Account Holder? (Enter 'Admin' or 'Holder'):");
        string userType = Console.ReadLine().Trim();

        Admin admin = new Admin();
        AccountHolder holder = null;

        if (userType.Equals("Admin", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Admin selected. Create a new account.");
            Console.WriteLine("Enter name for new account:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter initial amount:");
            double initialAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter account type (Savings or Current):");
            string accountType = Console.ReadLine();

            admin.CreateAccount(name, initialAmount, accountType);
            Console.WriteLine("Account created successfully!");
        }
        else if (userType.Equals("Holder", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Account Holder selected. Please enter the account name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the initial balance:");
            double initialBalance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please specify the type of account (Savings or Current):");
            string accountType = Console.ReadLine();

            if (accountType.Equals("Savings", StringComparison.OrdinalIgnoreCase))
            {
                holder = new AccountHolder(new SavingsAccount(name, initialBalance));
            }
            else if (accountType.Equals("Current", StringComparison.OrdinalIgnoreCase))
            {
                holder = new AccountHolder(new CurrentAccount(name, initialBalance));
            }
            
            Console.WriteLine("Select operation: Withdraw, Deposit, Apply for Loan");
            string operation = Console.ReadLine();

            switch (operation.ToLower())
            {
                case "withdraw":
                    Console.WriteLine("Enter amount to withdraw:");
                    double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                    holder.Withdraw(withdrawAmount);
                    Console.WriteLine($"Withdrawn {withdrawAmount}. New balance: {holder.Balance}");
                    break;
                case "deposit":
                    Console.WriteLine("Enter amount to deposit:");
                    double depositAmount = Convert.ToDouble(Console.ReadLine());
                    holder.Deposit(depositAmount);
                    Console.WriteLine($"Deposited {depositAmount}. New balance: {holder.Balance}");
                    break;
                case "apply for loan":
                    Console.WriteLine("Enter loan amount:");
                    double loanAmount = Convert.ToDouble(Console.ReadLine());
                    holder.ApplyForLoan(loanAmount);
                    break;
                default:
                    Console.WriteLine("Invalid operation selected.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid user type entered.");
        }
    }
}

