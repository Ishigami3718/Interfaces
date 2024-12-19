using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void FTest1()
        {
            var f1 = new MyFrac("1/30");
            var f2 = new MyFrac("3/25");

            var res = f1+f2;
            Assert.AreEqual(new MyFrac("23/150"), res);

            var res1 = f1 - f2;
            Assert.AreEqual(new MyFrac("-13/150"), res1);

            var res2 = f1 * f2;
            Assert.AreEqual(new MyFrac("1/250"), res2);

            var res3 = f1 / f2;
            Assert.AreEqual(new MyFrac("5/18"), res3);
        }

        [TestMethod]
        public void FTest2()
        {
            var f1 = new MyFrac("1/4");
            var f2 = new MyFrac("1/6");

            var res = f1 + f2;
            Assert.AreEqual(new MyFrac("5/12"), res);

            var res1 = f1 - f2;
            Assert.AreEqual(new MyFrac("1/12"), res1);

            var res2 = f1 * f2;
            Assert.AreEqual(new MyFrac("1/24"), res2);

            var res3 = f1 / f2;
            Assert.AreEqual(new MyFrac("3/2"), res3);
        }

        [TestMethod]
        public void FTest3()
        {
            var f1 = new MyFrac("-3/17");
            var f2 = new MyFrac("-6/-13");

            var res = f1 + f2;
            Assert.AreEqual(new MyFrac("63/221"), res);

            var res1 = f1 - f2;
            Assert.AreEqual(new MyFrac("-141/221"), res1);

            var res2 = f1 * f2;
            Assert.AreEqual(new MyFrac("-18/221"), res2);

            var res3 = f1 / f2;
            Assert.AreEqual(new MyFrac("-13/34"), res3);
        }

        [TestMethod]
        public void FTest4()
        {
            var f1 = new MyFrac("-3/17");
            var f2 = new MyFrac("6/-13");

            var res = f1 + f2;
            Assert.AreEqual(new MyFrac("-141/221"), res);

            var res1 = f1 - f2;
            Assert.AreEqual(new MyFrac("63/221"), res1);

            var res2 = f1 * f2;
            Assert.AreEqual(new MyFrac("18/221"), res2);

            var res3 = f1 / f2;
            Assert.AreEqual(new MyFrac("13/34"), res3);
        }

        [TestMethod]
        public void CTest1()
        {
            var f1 = new MyComplex("1 + 10i");
            var f2 = new MyComplex("0 + -7i");

            var res = f1 + f2;
            Assert.AreEqual(new MyComplex("1+3i"), res);

            var res1 = f1 - f2;
            Assert.AreEqual(new MyComplex("1+17i"), res1);

            var res2 = f1 * f2;
            Assert.AreEqual(new MyComplex("70+-7i"), res2);

            var res3 = f1 / f2;
            Assert.AreEqual(new MyComplex($"{-10.0/7}+{1.0/7}i"), res3);
        }

        [TestMethod]
        public void CTest2()
        {
            var f1 = new MyComplex("13+1,5i");
            var f2 = new MyComplex("-3+-7i");

            var res = f1 + f2;
            Assert.AreEqual(new MyComplex("10+-5,5i"), res);

            var res1 = f1 - f2;
            Assert.AreEqual(new MyComplex("16+8,5i"), res1);

            var res2 = f1 * f2;
            Assert.AreEqual(new MyComplex("-28,5+-95,5i"), res2);

            var res3 = f1 / f2;
            Assert.AreEqual(new MyComplex($"{-99.0/116}+{173.0/116}i"), res3);
        }

        [TestMethod]
        public void CTest3()
        {
            var f1 = new MyComplex("0+31i");
            var f2 = new MyComplex("0+12i");

            var res = f1 + f2;
            Assert.AreEqual(new MyComplex("0+43i"), res);

            var res1 = f1 - f2;
            Assert.AreEqual(new MyComplex("0+19i"), res1);

            var res2 = f1 * f2;
            Assert.AreEqual(new MyComplex("-372+0i"), res2);

            var res3 = f1 / f2;
            Assert.AreEqual(new MyComplex($"{31/12.0}+{0}i"), res3);
        }
    }
}