
using System;
using NUnit.Framework;

namespace unit
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static bool isTriangle(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
                return false;
            if (a == 0 || b == 0 || c == 0)
                return false;

            return true;
        }
    }
}