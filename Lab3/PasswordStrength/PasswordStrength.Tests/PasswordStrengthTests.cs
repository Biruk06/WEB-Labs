using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordStrength.Tests
{
    [TestClass]
    public class PasswordPartsTests
    {
        [TestMethod]
        public void CalcPasswordParts_EmptyString__0InAllCounters()
        {
            //Arrange
            string emptyStr = "";
            PasswordParts passwordParts = new PasswordParts();

            //Act
            passwordParts = Program.CalcPasswordParts(emptyStr);

            //Assert
            Assert.AreEqual(passwordParts.passwordLength, 0);
            Assert.AreEqual(passwordParts.lettersCount, 0);
            Assert.AreEqual(passwordParts.upperLettersCount, 0);
            Assert.AreEqual(passwordParts.lowerLettersCount, 0);
            Assert.AreEqual(passwordParts.numsCount, 0);
            Assert.AreEqual(passwordParts.duplicatesCount, 0);
        }

        [TestMethod]
        public void CalcPasswordParts_OnlyDuplicatesLettersString_CorrectCountAllParts()
        {
            //Arrange
            string duplicatesString = "aaa";
            PasswordParts passwordParts = new PasswordParts();

            //Act
            passwordParts = Program.CalcPasswordParts(duplicatesString);

            //Assert
            Assert.AreEqual(passwordParts.passwordLength, 3);
            Assert.AreEqual(passwordParts.lettersCount, 3);
            Assert.AreEqual(passwordParts.upperLettersCount, 0);
            Assert.AreEqual(passwordParts.lowerLettersCount, 3);
            Assert.AreEqual(passwordParts.numsCount, 0);
            Assert.AreEqual(passwordParts.duplicatesCount, 3);
        }

        [TestMethod]
        public void CalcPasswordParts_NormalString_CorrectCountAllParts()
        {
            //Arrange
            string NormalString = "Sort23456";
            PasswordParts passwordParts = new PasswordParts();

            //Act
            passwordParts = Program.CalcPasswordParts(NormalString);

            //Assert
            Assert.AreEqual(passwordParts.passwordLength, 9);
            Assert.AreEqual(passwordParts.lettersCount, 4);
            Assert.AreEqual(passwordParts.upperLettersCount, 1);
            Assert.AreEqual(passwordParts.lowerLettersCount, 3);
            Assert.AreEqual(passwordParts.numsCount, 5);
            Assert.AreEqual(passwordParts.duplicatesCount, 0);
        }


        [TestMethod]
        public void CalcPasswordParts_OnlyNumsString_CorrectCountAllParts()
        {
            //Arrange
            string numsString = "23456";
            PasswordParts passwordParts = new PasswordParts();

            //Act
            passwordParts = Program.CalcPasswordParts(numsString);

            //Assert
            Assert.AreEqual(passwordParts.passwordLength, 5);
            Assert.AreEqual(passwordParts.lettersCount, 0);
            Assert.AreEqual(passwordParts.upperLettersCount, 0);
            Assert.AreEqual(passwordParts.lowerLettersCount, 0);
            Assert.AreEqual(passwordParts.numsCount, 5);
            Assert.AreEqual(passwordParts.duplicatesCount, 0);
        }

        [TestMethod]
        public void CalcPasswordParts_StringWithDuplicates_CorrectCountAllParts()
        {
            //Arrange
            string stringWithDuplicates = "SSSorttt233455677";
            PasswordParts passwordParts = new PasswordParts();

            //Act
            passwordParts = Program.CalcPasswordParts(stringWithDuplicates);

            //Assert
            Assert.AreEqual(passwordParts.passwordLength, 17);
            Assert.AreEqual(passwordParts.lettersCount, 8);
            Assert.AreEqual(passwordParts.upperLettersCount, 3);
            Assert.AreEqual(passwordParts.lowerLettersCount, 5);
            Assert.AreEqual(passwordParts.numsCount, 9);
            Assert.AreEqual(passwordParts.duplicatesCount, 12);
        }
    }

    [TestClass]
    public class CalcPasswordStrengthTests
    {
        [TestMethod]
        public void CalcPasswordStrength_0InAllParts_0()
        {
            //Arrange
            PasswordParts passwordParts = new PasswordParts()
            {
                passwordLength = 0,
                lettersCount = 0,
                upperLettersCount = 0, 
                lowerLettersCount = 0,
                numsCount = 0,
                duplicatesCount = 0
            };
            int passwordStrength;

            //Act
            passwordStrength = Program.CalcPasswordStrength(passwordParts);

            //Assert
            Assert.AreEqual(passwordStrength, 0);
        }

        [TestMethod]
        public void CalcPasswordStrength_OnlyDuplicates_3()
        {
            //Arrange
            PasswordParts passwordParts = new PasswordParts()
            {
                passwordLength = 3,
                lettersCount = 3,
                upperLettersCount = 0,
                lowerLettersCount = 0,
                numsCount = 0,
                duplicatesCount = 3
            };
            int passwordStrength;

            //Act
            passwordStrength = Program.CalcPasswordStrength(passwordParts);

            //Assert
            Assert.AreEqual(passwordStrength, 6);
        }

        [TestMethod]
        public void CalcPasswordStrength_OnlyNums_35()
        {
            //Arrange
            PasswordParts passwordParts = new PasswordParts()
            {
                passwordLength = 5,
                lettersCount = 0,
                upperLettersCount = 0,
                lowerLettersCount = 0,
                numsCount = 5,
                duplicatesCount = 0
            };
            int passwordStrength;

            //Act
            passwordStrength = Program.CalcPasswordStrength(passwordParts);

            //Assert
            Assert.AreEqual(passwordStrength, 35);
        }

        [TestMethod]
        public void CalcPasswordStrength_WithoutDuplicates_84()
        {
            //Arrange
            PasswordParts passwordParts = new PasswordParts()
            {
                passwordLength = 9,
                lettersCount = 4,
                upperLettersCount = 1,
                lowerLettersCount = 3,
                numsCount = 5,
                duplicatesCount = 0
            };
            int passwordStrength;

            //Act
            passwordStrength = Program.CalcPasswordStrength(passwordParts);

            //Assert
            Assert.AreEqual(passwordStrength, 84);
        }

        [TestMethod]
        public void CalcPasswordStrength_Not0AllParts_144()
        {
            //Arrange
            PasswordParts passwordParts = new PasswordParts()
            {
                passwordLength = 17,
                lettersCount = 8,
                upperLettersCount = 3,
                lowerLettersCount = 5,
                numsCount = 9,
                duplicatesCount = 12
            };
            int passwordStrength;

            //Act
            passwordStrength = Program.CalcPasswordStrength(passwordParts);

            //Assert
            Assert.AreEqual(passwordStrength, 144);
        }
    }
}
