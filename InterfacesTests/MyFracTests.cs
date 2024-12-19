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
        public void Test1()
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
        public void Test2()
        {
            var f1 = new MyFrac("1/4");
            var f2 = new MyFrac("1/6");

            var res = f1 + f2;
            Assert.AreEqual(new MyFrac("7/12"), res);

            var res1 = f1 - f2;
            Assert.AreEqual(new MyFrac("1/12"), res1);

            var res2 = f1 * f2;
            Assert.AreEqual(new MyFrac("1/24"), res2);

            var res3 = f1 / f2;
            Assert.AreEqual(new MyFrac("3/2"), res3);
        }

        public void Test3()
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

        public void Test4()
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

    }
}