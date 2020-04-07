using NUnit.Framework;

namespace CheckIdentifer.Tests
{
    [TestFixture]
    public class CheckIdentiferTests
    {
        [TestCase("123", false)]
        [TestCase("", false)]
        [TestCase("So12Me34", true)]
        [TestCase("Begin", true)]
        [TestCase("Sort1324", true)]
        public void CheckIdentifer_ShouldReturnTrueOrFalse(string identifer, bool answer)
        {
            //Assert
            Assert.AreEqual(Program.CheckIdentifer(identifer), answer);
        }
    }
}
