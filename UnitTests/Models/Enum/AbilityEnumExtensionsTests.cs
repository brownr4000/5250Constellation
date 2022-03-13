using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class AbilityEnumExtensionsTests
    {
        [Test]
        public void AbilityEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("None", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Bandage_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Bandage.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Apply Bandages", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Block_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Block.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Block Attacks", result);
        }
        
        [Test]
        public void AbilityEnumExtensionsTests_Dodge_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Dodge.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Dodge Attack", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_DoubleStrike_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.DoubleStrike.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Double Strike", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_BoostAttack_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.BoostAttack.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Boost adjacent character attack", result);
        }


        [Test]
        public void AbilityEnumExtensionsTests_Barrier_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Barrier.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Barrier Defense", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Curse_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Curse.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Shout Curse", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Focus_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Focus.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Focuses their Energy", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Heal_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Heal.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Heal Self", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Nimble_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Nimble.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("React Quickly", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Quick_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Quick.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Anticipate", result);
        }

        [Test]
        public void AbilityEnumExtensionsTests_Toughness_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnum.Toughness.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Toughen Up", result);
        }
    }
}
