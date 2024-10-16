using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Task2
{
    static public int[] Filter(this int[] arr, Predicate<int> predicate)
    {
        return Array.FindAll(arr, predicate);
    }
    public static void Task()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] evenNumbers = numbers.Filter(x => x % 2 == 0);
        Console.WriteLine("Четные числа: " + string.Join(", ", evenNumbers));
    }
}