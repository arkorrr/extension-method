using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DailyTemperature
{
    public decimal High { get; }
    public decimal Low { get; }

    public DailyTemperature(decimal high, decimal low)
    {
        High = high;
        Low = low;
    }

    public decimal GetTemperatureDifference()
    {
        return High - Low;
    }
}