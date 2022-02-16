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
    }
}
