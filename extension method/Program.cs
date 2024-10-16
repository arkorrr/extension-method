using static Task3;
using System.Security.Principal;

class Program
{
    static void Main(string[] args)
    {
        //Task1
        Task1.Task();
        //Task2
        Task2.Task();
        //Task3
        
        var notificationService = new NotificationService();
        var CreditCard = new Task3(1234567890, "Иван Иванов", DateTime.Now.AddYears(3), 1234, 5000, 1000);
        CreditCard.OnDeposit += notificationService.OnAddMoney;
        CreditCard.OnWithdraw += notificationService.OnExpenses;
        CreditCard.UsingCredit += notificationService.OnCreditUsed;
        CreditCard.Limit += notificationService.OnLimitReached;
        CreditCard.PINChanged += notificationService.ChangePIN;
        CreditCard.AddMoney(200);
        CreditCard.Expenses(100);
        CreditCard.CreditMoney(5000);
        CreditCard.ChangePIN(1214,1234);
        //Task4
        DailyTemperature[] temperature = new DailyTemperature[]
        {
                new DailyTemperature(12, 10),
                new DailyTemperature(15, 9),
                new DailyTemperature(14, 11),
                new DailyTemperature(18, 8),
                new DailyTemperature(20, 12),
        };
        int maxDifferenceDayIndex = 0;
        decimal maxDifference = temperature[0].GetTemperatureDifference();
        for (int i = 1; i < temperature.Length; i++)
        {
            decimal difference = temperature[i].GetTemperatureDifference();
            if (difference > maxDifference)
            {
                maxDifference = difference;
                maxDifferenceDayIndex = i;
            }
        }
        Console.WriteLine($"The day with the maximum temperature difference: Day {maxDifferenceDayIndex + 1}");
        Console.WriteLine($"Max difference: {maxDifference}°C");
    }
}

