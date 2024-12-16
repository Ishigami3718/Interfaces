using System;
using System.Numerics;

namespace Lab
{
    interface IMyNumber<T> where T : IMyNumber<T>
    {
        T Add(T b);
        T Subtract(T b);
        T Multiply(T b);
        T Divide(T b);
    }

    class MyFrac
    {
        private BigInteger num;
        private BigInteger den;
    }

    class MyComplex
    {
        private double real;
        private double imaginary;
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}