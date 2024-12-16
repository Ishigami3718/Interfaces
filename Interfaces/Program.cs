﻿using System;
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

        public MyFrac(string inp) : this(BigInteger.Parse(inp.Split('/')[0]), BigInteger.Parse(inp.Split('/')[1]))
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
            return f1.Subtract(f2);
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

        public static MyComplex operator +(MyComplex f1, MyComplex f2)
        {
            return f1.Add(f2);
        }

        public static MyComplex operator -(MyComplex f1, MyComplex f2)
        {
            return f1.Subtract(f2);
        }

        public static MyComplex operator *(MyComplex f1, MyComplex f2)
        {
            return f1.Multiply(f2);
        }

        public static MyComplex operator /(MyComplex f1, MyComplex f2)
        {
            return f1.Divide(f2);
        }
    }
    class Program
    {
        static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab

// I'm not sure how to create constant factor "2" in more elegant way,
// without knowing how IMyNumber is implemented
Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        }
        static void Main(string[] args)
        {
            TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
            Console.ReadKey();
        }
    }
}