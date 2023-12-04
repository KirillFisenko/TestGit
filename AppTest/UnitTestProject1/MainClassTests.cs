using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class MainClassTests
    {
        [TestMethod()]
        public void CharCountTest()
        {
            //arrange
            string s = "string";
            int expected = 6;

            //act
            MainClass test = new MainClass();
            int act = test.CharCount(s);

            //assert
            Assert.AreEqual(expected, act);
        }

        [TestMethod()]
        public void CharCountTest1()
        {
            //arrange
            string s = "s";
            int expected = 1;

            //act
            MainClass test = new MainClass();
            int act = test.CharCount(s);

            //assert
            Assert.AreEqual(expected, act);
        }
    }
}