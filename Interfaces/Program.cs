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
        private BigInteger nom;
        private BigInteger den;

        private BigInteger Evklid(BigInteger f, BigInteger s)
        {
            while (s != 0)
            {
                BigInteger temp = s;
                s = f % s;
                f = temp;
            }
            return f;
        }
        public MyFrac(BigInteger nom, BigInteger den)
        {
            if (den == 0) throw new Exception("denom is zero");
            BigInteger nsd = Evklid(nom, den);
            this.nom = nom/nsd;
            this.den = den/nsd;
        }

        public MyFrac(string inp) : this(long.Parse(inp.Split('/')[0]), BigInteger.Parse(inp.Split('/')[1]))
        {
        }

        public override string ToString()
        {
            if (nom == 0) return "0";
            else if (nom < 0 && den < 0)
                return $"{BigInteger.Abs(nom)}/{BigInteger.Abs(den)}";
            else if (nom < 0 || den < 0)
                return $"-({BigInteger.Abs(nom)}/{BigInteger.Abs(den)})";
            else
                return $"{nom}/{den}";
        }
    }

    class MyComplex
    {
        private double real;
        private double imaginary;

        public MyComplex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        public MyComplex(string inp):this(double.Parse(inp.Split(new char[] {'+','i'},
            StringSplitOptions.RemoveEmptyEntries)[0]), double.Parse(inp.Split(new char[] { '+', 'i' },
            StringSplitOptions.RemoveEmptyEntries)[1])){ }

        public override string ToString()
        {
            return real + "+" + imaginary+"i";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}