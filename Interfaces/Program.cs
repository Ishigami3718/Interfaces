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

    class MyFrac:IMyNumber<MyFrac>
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

        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(nom*that.den+that.nom*den,den*that.den);
        }

        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(nom * that.den - that.nom * den, den * that.den);
        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(nom * that.nom, den * that.den);
        }

        public MyFrac Divide(MyFrac that)
        {
            return new MyFrac(nom * that.den, den * that.nom);
        }

        public static MyFrac operator +(MyFrac f1,MyFrac f2)
        {
            return f1.Add(f2);
        }

        public static MyFrac operator -(MyFrac f1, MyFrac f2)
        {
            return f1.Substract(f2);
        }

        public static MyFrac operator *(MyFrac f1, MyFrac f2)
        {
            return f1.Multiply(f2);
        }

        public static MyFrac operator /(MyFrac f1, MyFrac f2)
        {
            return f1.Divide(f2);
        }
    }

    class MyComplex:IMyNumber<MyComplex>
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

        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(real+that.real,imaginary+that.imaginary);
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(real - that.real, imaginary - that.imaginary);
        }

        public MyComplex Multiply(MyComplex that)
        {
            return new MyComplex(real*that.real-imaginary*that.imaginary,
                real*that.imaginary+imaginary*that.real);
        }

        public MyComplex Divide(MyComplex that)
        {
            return new MyComplex((real*that.real+imaginary*that.imaginary)/
                (that.real*that.real+that.imaginary*that.imaginary),
                (imaginary*that.real-real*that.imaginary)/
                (that.real * that.real + that.imaginary * that.imaginary));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}