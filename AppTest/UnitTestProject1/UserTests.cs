using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void IsAdaltTest()
        {
            //arrange
            int age = 18;
            bool expected = true;

            //act
            User user = new User();
            bool act = user.IsAdalt(age);

            //assert
            Assert.AreEqual(expected, act);
        }
    }
}