
using System;
using NUnit.Framework;

namespace unit
{
    public class Program
    {
        static void Main(string[] args)
        {
            isTriangle(Double.MaxValue, Double.MaxValue, Double.MaxValue);
        }

        public static bool isTriangle(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
                return false;
            if (a == 0 || b == 0 || c == 0)
                return false;

            double check12 = checked(a + b);
            double check13 = checked(a + c);
            double check23 = checked(b + c);

            if (Double.IsPositiveInfinity(check12) || Double.IsPositiveInfinity(check13) || Double.IsPositiveInfinity(check23))
                return false;

            bool istriangle = a + b >= c;
            istriangle = istriangle && (a + c >= b);
            istriangle = istriangle && (b + c >= a);

            if (istriangle == false)
                return false;

            return true;
        }
    }
}