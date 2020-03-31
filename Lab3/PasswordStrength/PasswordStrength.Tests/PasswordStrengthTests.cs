using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordStrength.Tests
{
    [TestClass]
    public class PasswordStrengthTests
    {
        [TestMethod]
        public void CalcPasswordStrength_EmptyString_0()
        {
            //Arrange
            string emptyStr = "";
            int passwordStrength;

            //Act
            passwordStrength = Program.CalcPasswordStrength(emptyStr);

            //Assert
            Assert.AreEqual(passwordStrength, 0);
        }

        [TestMethod]
        public void CalcPasswordStrength_OnlyDuplicatesLettersString_6()
        {
            //Arrange
            string duplicatesString = "aaa";
            int passwordStrength;

            //Act
            passwordStrength = Program.CalcPasswordStrength(duplicatesString);

            //Assert
            Assert.AreEqual(passwordStrength, 6);
        }

        [TestMethod]
        public void CalcPasswordStrength_NormalString_84()
        {
            //Arrange
            string NormalString = "Sort23456";
            int passwordStrength;

            //Act
            passwordStrength = Program.CalcPasswordStrength(NormalString);

            //Assert
            Assert.AreEqual(passwordStrength, 84);
        }


        [TestMethod]
        public void CalcPasswordStrength_OnlyNumsString_35()
        {
            //Arrange
            string numsString = "23456";
            int passwordStrength;

            //Act
            passwordStrength = Program.CalcPasswordStrength(numsString);

            //Assert
            Assert.AreEqual(passwordStrength, 35);
        }

        [TestMethod]
        public void CalcPasswordStrength_StringWithDuplicates_144()
        {
            //Arrange
            string stringWithDuplicates = "SSSorttt233455677";
            int passwordStrength;

            //Act
            passwordStrength = Program.CalcPasswordStrength(stringWithDuplicates);

            //Assert
            Assert.AreEqual(passwordStrength, 144);
        }
    }
}
