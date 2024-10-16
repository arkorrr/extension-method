using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

public class NotificationService
{
    public void OnAddMoney(decimal amount)
    {
        Console.WriteLine($"Счет пополнен на {amount}.");
    }
    public void OnExpenses(decimal amount) 
    {
        Console.WriteLine($"Со счёта снято {amount}.");
    }
    public void OnCreditUsed(decimal amount)
    {
        Console.WriteLine($"Использован кредит на сумму {amount}.");
    }

    public void OnLimitReached(decimal limit)
    {
        Console.WriteLine($"Вы достигли кредитного лимита в {limit}.");
    }
    public void ChangePIN(int PIN)
    {
        Console.WriteLine($"Пинкод был сменен на {PIN}.");
    }
}
public class Task3
{
    public decimal cardNumber { get; private set; }
    public string FIO { get; private set; }
    public DateTime validityPeriod { get; private set; }
    private int PIN;
    public decimal creditLimit { get; private set; }
    public decimal Balance { get; private set; }

    public event Action<decimal> OnDeposit;
    public event Action<decimal> OnWithdraw;
    public event Action<decimal> UsingCredit;
    public event Action<decimal> Limit;
    public event Action<int> PINChanged;
    public Task3(decimal cardNumber, string fIO, DateTime validityPeriod, int pIN, decimal creditLimit, decimal money)
    {
        this.cardNumber = cardNumber;
        FIO = fIO;
        this.validityPeriod = validityPeriod;
        PIN = pIN;
        this.creditLimit = creditLimit;
        Balance = money;
    }

    public Task3() { }

    public void AddMoney(int amount)
    {
        Balance += amount;
        OnDeposit?.Invoke(Balance);
    }
    public void Expenses(int expense)
    {
        if (expense > Balance)
        {
            Console.WriteLine("Недостаточно денег");
            return;
        }
        Balance -= expense;
        OnWithdraw?.Invoke(Balance);
    }
    public void CreditMoney(decimal amount)
    {
        if (Balance + amount > creditLimit)
        {
            Console.WriteLine("Достигли кредитного лимита.");
            Limit?.Invoke(creditLimit);
            return;
        }

        if (amount > Balance)
        {
            UsingCredit?.Invoke(amount);
        }

        Balance -= amount;
    }
    public void ChangePIN(int oldPin, int newPin)
    {
        if (PIN == oldPin)
        {
            PIN = newPin;
            PINChanged?.Invoke(newPin);
        }
        else
        {
            Console.WriteLine("Пинкод не верный, попробуйте позже.");
            return;
        }
    }

}

