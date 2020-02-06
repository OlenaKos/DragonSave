using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Reflection;


namespace DragonSave
{
    [TestFixture]
    class GragonSaveTest
    {
        [Test]
        public void Length_8_returned5()
        {
            //arrange
            string password = "P2sc0*isp";
            int expected = 5; //all options

            //act            
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Length_5_returned3()
        {
            //arrange
            string password = "P2sc0";
            int expected = 3; //1-uppercase, 2-number, 3-lowercase

            //act            
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Length_6_returned1()
        {
            //arrange
            string password = "258456";
            int expected = 1; //1-number

            //act            
            int actual = PasswordStrengthCheker.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
