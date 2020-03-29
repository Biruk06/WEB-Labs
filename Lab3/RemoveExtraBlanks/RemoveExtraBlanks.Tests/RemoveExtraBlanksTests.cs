using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveExtraBlanks.Tests
{
    [TestClass]
    public class RemoveExtraBlanksTests
    {
        [TestMethod]
        public void RemoveExtraBlanks_EmptyString_EmptyString()
        {
            //Arrange
            string emptyString = "";

            //Act
            emptyString = Program.RemoveExtraBlanks(emptyString);

            //Assert
            Assert.AreEqual(emptyString, "");
        }

        [TestMethod]
        public void RemoveExtraBlanks_StringWithExtraBlanks_StringWithoutExtraBlanks()
        {
            //Arrange
            string withExtraBlanks = "   1    2   3    4    ";
            string withoutExtraBlanks = "";

            //Act
            withoutExtraBlanks = Program.RemoveExtraBlanks(withExtraBlanks);

            //Assert
            Assert.AreEqual(withoutExtraBlanks, "1 2 3 4");
        }

        [TestMethod]
        public void RemoveExtraBlanks_StringWithoutExtraBlanks_StringWithoutExtraBlanks()
        {
            //Arrange
            string withoutExtraBlanks_1 = "1 2 3 4";
            string withoutExtraBlanks_2 = "";

            //Act
            withoutExtraBlanks_2 = Program.RemoveExtraBlanks(withoutExtraBlanks_1);

            //Assert
            Assert.AreEqual(withoutExtraBlanks_2, "1 2 3 4");
        }

        [TestMethod]
        public void RemoveExtraBlanks_StringWithOnlyBlanks_EmptyString()
        {
            //Arrange
            string withOnlyBlanks = "            ";
            string withoutExtraBlanks = "";

            //Act
            withoutExtraBlanks = Program.RemoveExtraBlanks(withOnlyBlanks);

            //Assert
            Assert.AreEqual(withoutExtraBlanks, "");
        }
    }
}
