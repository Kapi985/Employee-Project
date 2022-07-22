// See https://aka.ms/new-console-template for more information
public class Statistics
{
    public double High;

    public double Low;

    public double Sum;

    public int Count;
    
    public Statistics()
    {
        High = double.MinValue;
        Low = double.MaxValue;
        Sum = 0.0;
        Count = 0;
    }
    public double Average
    {
        get
        {
            return Sum/Count;
        }
    }
    public char Letter
    {
        get
        {
            switch(Average)
            {
            case var d when d >= 80:
                return 'A';

            case var d when d >= 60:
                return 'B';

            case var d when d >= 40:
                return 'C';

            case var d when d >= 20:
                return 'D';

            default:
                return 'E';
            }
            
        }
    }

    public void Add(double number)
    {
        Sum += number;
        Count ++;
        Low = Math.Min(number, Low);
        High = Math.Max(number, High);
    }
}