using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifer.Tests
{
    [TestClass]
    public class CheckIdentiferTests
    {
        [TestMethod]
        public void CheckIdentifer_OnlyNumsIdentifer_ReturnedFalse()
        {
            //Arrange
            string nonValidIdentifer = "123";
            bool answer;

            //Act
            answer = Program.CheckIdentifer(nonValidIdentifer);

            //Assert
            Assert.AreEqual(answer, false);
        }

        [TestMethod]
        public void CheckIdentifer_EmptyString_ReturnedFalse()
        {
            //Arrange
            string emptyString = "";
            bool answer;

            //Act
            answer = Program.CheckIdentifer(emptyString);

            //Assert
            Assert.AreEqual(answer, false);
        }

        [TestMethod]
        public void CheckIdentifer_NonValidIdentifer_ReturnedFalse()
        {
            //Arrange
            string nonValidIdentifer = "So12Me34";
            bool answer;

            //Act
            answer = Program.CheckIdentifer(nonValidIdentifer);

            //Assert
            Assert.AreEqual(answer, false);
        }

        [TestMethod]
        public void CheckIdentifer_ValidIdentifer_ReturnedFalse()
        {
            //Arrange
            string validIdentifer = "Begin";
            bool answer;

            //Act
            answer = Program.CheckIdentifer(validIdentifer);

            //Assert
            Assert.AreEqual(answer, true);
        }

        [TestMethod]
        public void CheckIdentifer_ValidIdentiferWithNums_ReturnedFalse()
        {
            //Arrange
            string validIdentiferWithNums = "Sort123";
            bool answer;

            //Act
            answer = Program.CheckIdentifer(validIdentiferWithNums);

            //Assert
            Assert.AreEqual(answer, true);
        }
    }
}
