using System;

public enum AccountType { Current, Savings, Deposit }

public class BankAccount
{
    private static int idCounter = 1000;
    private int accountNumber;
    private double balance;
    private AccountType type;

    public static void IncrementCounter()
    {
        idCounter = idCounter + 1;
    }

    public void SetAccountData(double initialBalance, AccountType accountType)
    {
        IncrementCounter();
        accountNumber = idCounter;
        balance = initialBalance;
        type = accountType;
    }

    public void Deposit(double amount)
    {
        balance = balance + amount;
        Console.WriteLine("Счет " + accountNumber + " пополнен на " + amount + " руб.");
    }

    public bool Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance = balance - amount;
            Console.WriteLine("Со счета " + accountNumber + " успешно снято " + amount + " руб.");
            return true;
        }
        else
        {
            Console.WriteLine("Ошибка на счете " + accountNumber + ": Недостаточно средств для снятия " + amount + " руб.!");
            return false;
        }
    }

    // Метод: перевод денег с другого счета (fromAccount) на текущий (this)
    public void Transfer(BankAccount fromAccount, double amount)
    {
        Console.WriteLine("\n--- Попытка перевода " + amount + " руб. со счета " + fromAccount.GetAccountNumber() + " на счет " + this.accountNumber + " ---");

        // Пытаемся снять деньги со счета отправителя
        if (fromAccount.Withdraw(amount))
        {
            // Если снятие прошло успешно (вернулось true), зачисляем их на текущий счет
            this.Deposit(amount);
            Console.WriteLine("Перевод успешно выполнен!");
        }
        else
        {
            Console.WriteLine("Перевод отменен из-за нехватки средств.");
        }
    }

    public int GetAccountNumber() { return accountNumber; }
    public double GetBalance() { return balance; }
    public AccountType GetAccountType() { return type; }

    public void PrintInfo()
    {
        Console.WriteLine("Номер счета: " + accountNumber);
        Console.WriteLine("Тип счета: " + type);
        Console.WriteLine("Текущий баланс: " + balance + " руб.");
        Console.WriteLine("-----------------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем первый счет (отправитель)
        BankAccount ac1 = new BankAccount();
        ac1.SetAccountData(5000.00, AccountType.Current);

        // Создаем второй счет (получатель)
        BankAccount ac2 = new BankAccount();
        ac2.SetAccountData(1000.00, AccountType.Savings);

        Console.WriteLine("Состояние счетов до перевода:");
        ac1.PrintInfo();
        ac2.PrintInfo();

        // Успешный перевод: на acc2 переводим 2500 руб. со счета acc1
        ac2.Transfer(ac1, 2500.00);

        // Неуспешный перевод: пытаемся перевести с acc1 10000 руб. (больше остатка)
        ac2.Transfer(ac1, 10000.00);

        Console.WriteLine("\nСостояние счетов после всех операций:");
        ac1.PrintInfo();
        ac2.PrintInfo();

        Console.ReadLine();
    }
}

