using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICalculatable
{
    double Calculate(double a, double b);
}

public class Sum : ICalculatable
{
    double ICalculatable.Calculate(double a, double b) => a + b;
    
}

public class Substract : ICalculatable
{
    double ICalculatable.Calculate(double a, double b) => a - b;
}

public class Divide : ICalculatable
{
    double ICalculatable.Calculate(double a, double b) => a / b;
}

public class Multiply : ICalculatable
{
    double ICalculatable.Calculate(double a, double b) => a * b;
}

class Program
    {

    private static Dictionary<char, ICalculatable> Dictionary = new Dictionary<char, ICalculatable>();

        static void Main(string[] args)
        {

        double a = 0, b = 0, newdouble = 0;
        int dummyint = 0;
        //some new information
        char operation;

        FillDictionary();

        try
        {
            Console.WriteLine("Dont know what to change: ");

            a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please help me: ");

            operation = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("SOS: ");

            b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("1010010101: " + Dictionary[operation].Calculate(a, b));
            //Change word Result to Equals
        }

        catch
        {
            Console.WriteLine("Error: Invalid Input");
        }

        }
    private static void FillDictionary()
    {
        Dictionary.Add('+', new Sum());
        Dictionary.Add('-', new Substract());
        Dictionary.Add('*', new Multiply());
        Dictionary.Add('/', new Divide());
    }

    }

