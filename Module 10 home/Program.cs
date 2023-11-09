using System;
using System.IO;

public interface ICalculatable
{
    double Add(double a, double b);
    double Subtract(double a, double b);
    double Multiply(double a, double b);
    double Divide(double a, double b);
}

public interface IStorable
{
    void SaveToFile(string filename);
    void LoadFromFile(string filename);
}

public class SimpleCalculator : ICalculatable
{
    public double Add(double a, double b)
    {
        double result = a + b;
        Console.WriteLine($"Addition Result: {result}");
        return result;
    }

    public double Subtract(double a, double b)
    {
        double result = a - b;
        Console.WriteLine($"Subtraction Result: {result}");
        return result;
    }

    public double Multiply(double a, double b)
    {
        double result = a * b;
        Console.WriteLine($"Multiplication Result: {result}");
        return result;
    }

    public double Divide(double a, double b)
    {
        if (b != 0)
        {
            double result = a / b;
            Console.WriteLine($"Division Result: {result}");
            return result;
        }
        else
        {
            Console.WriteLine("Cannot divide by zero!");
            return double.NaN;
        }
    }
}

public class AdvancedCalculator : SimpleCalculator, IStorable
{
    public double Power(double a, double b)
    {
        double result = Math.Pow(a, b);
        Console.WriteLine($"Power Result: {result}");
        return result;
    }

    public double SquareRoot(double a)
    {
        double result = Math.Sqrt(a);
        Console.WriteLine($"Square Root Result: {result}");
        return result;
    }

    public void SaveToFile(string filename)
    {
        File.WriteAllText(filename, "Saved data from AdvancedCalculator");
        Console.WriteLine($"Data saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        string data = File.ReadAllText(filename);
        Console.WriteLine($"Data loaded from {filename}: {data}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        SimpleCalculator simpleCalculator = new SimpleCalculator();
        AdvancedCalculator advancedCalculator = new AdvancedCalculator();

        simpleCalculator.Add(5, 3);
        simpleCalculator.Subtract(7, 2);
        simpleCalculator.Multiply(4, 6);
        simpleCalculator.Divide(8, 2);

        advancedCalculator.Power(2, 3);
        advancedCalculator.SquareRoot(16);

        advancedCalculator.SaveToFile("data.txt");
        advancedCalculator.LoadFromFile("data.txt");

        Console.ReadLine();
    }
}
