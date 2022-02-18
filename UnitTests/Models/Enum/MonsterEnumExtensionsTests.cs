using Game.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    public class MonsterEnumExtensionsTests
    {
        [Test]
        public void MonsterJobEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterJobEnum.Unknown.ToMessage();
            // Reset

            // Assert
            Assert.AreEqual("Player", result);
        }

        [Test]
        public void MonsterJobEnumExtensionsTests_Brute_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterJobEnum.Brute.ToMessage();
            // Reset

            // Assert
            Assert.AreEqual("Brute", result);
        }

        [Test]
        public void MonsterJobEnumExtensionsTests_Swift_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = MonsterJobEnum.Swift.ToMessage();
            // Reset

            // Assert
            Assert.AreEqual("Swift", result);
        }

        //[Test]
        //public void MonsterJobEnumExtensionsTests_Clever_Default_Should_Pass()
        //{
        //    // Arrange

        //    // Act
        //    var result = MonsterJobEnum.Clever.ToMessage();
        //    // Reset

        //    // Assert
        //    Assert.AreEqual("Clever", result);
        //}
    }
}
