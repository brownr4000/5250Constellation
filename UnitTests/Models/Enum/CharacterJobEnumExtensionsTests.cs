using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// The CharacterJobEnumExtensionsTests class is the unit test framework for the CharacterJobEnum class
    /// </summary>
    [TestFixture]
    public class CharacterJobEnumExtensionsTests
    {
        /// <summary>
        /// Tests the Unknown Player Job
        /// </summary>
        [Test]
        public void CharacterJobEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Player", result);
        }

        /// <summary>
        /// Tests the Fighter Player Job
        /// </summary>
        [Test]
        public void CharacterJobEnumExtensionsTests_Fighter_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Fighter.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Fighter", result);
        }

        /// <summary>
        /// Tests the Cleric Player Job 
        /// </summary>
        [Test]
        public void CharacterJobEnumExtensionsTests_Cleric_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Cleric.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Cleric", result);
        }

        /// <summary>
        /// Tests the Defender Player Job 
        /// </summary>
        [Test]
        public void CharacterJobEnumExtensionsTests_Defender_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Defender.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Defender", result);
        }

        /// <summary>
        /// Tests the Striker Player Job 
        /// </summary>
        [Test]
        public void CharacterJobEnumExtensionsTests_Striker_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Striker.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Striker", result);
        }

        /// <summary>
        /// Tests the Support Player Job 
        /// </summary>
        [Test]
        public void CharacterJobEnumExtensionsTests_Support_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Support.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Support", result);
        }
    }
}
