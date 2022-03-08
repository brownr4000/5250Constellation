using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

using Game.Engine.EngineGame;
using Game.Helpers;
using Game.Models;
using Game.ViewModels;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class AutoBattleEngineGameTests
    {
        #region TestSetup
        AutoBattleEngine AutoBattleEngine;

        [SetUp]
        public void Setup()
        {
            AutoBattleEngine = new AutoBattleEngine();

            AutoBattleEngine.Battle.EngineSettings.CharacterList.Clear();
            AutoBattleEngine.Battle.EngineSettings.MonsterList.Clear();
            AutoBattleEngine.Battle.EngineSettings.CurrentDefender = null;
            AutoBattleEngine.Battle.EngineSettings.CurrentAttacker = null;

            AutoBattleEngine.Battle.Round = new RoundEngine();
            AutoBattleEngine.Battle.Round.Turn = new TurnEngine();

            _ = AutoBattleEngine.Battle.StartBattle(true);   // Clear the Engine
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void AutoBattleEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = AutoBattleEngine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AutoBattleEngine_Constructor_Valid_Battle_Round_Turn_Should_Pass()
        {
            // Arrange

            // Act
            var result = AutoBattleEngine;
            result.Battle = new BattleEngine();
            result.Battle.Round = new RoundEngine();
            result.Battle.Round.Turn = new TurnEngine();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region RunAutoBattle
        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_Default_Should_Pass()
        {
            //Arrange

            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_InValid_DetectInfinateLoop_Should_Return_False()
        {
            //Arrange

            // Trigger DetectInfinateLoop Loop
            var oldRoundCountMax = AutoBattleEngine.Battle.EngineSettings.MaxRoundCount;
            AutoBattleEngine.Battle.EngineSettings.MaxRoundCount = -1;

            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset
            AutoBattleEngine.Battle.EngineSettings.MaxRoundCount = oldRoundCountMax;

            //Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Unit Test for Checking if a New Round starts
        /// </summary>
        /// <returns></returns>
        [Test]
        public void AutoBattleEngine_RunAutoBattle_Valid_NewRound_Should_Return_True()
        {
            //Arrange

            _ = DiceHelper.EnableForcedRolls();

            var data = new CharacterModel { Level = 1, MaxHealth = 10 };

            AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));


            //Act
            var result = AutoBattleEngine.Battle.Round.NewRound();

            //Reset
            _ = DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(true, result);
        }
        #endregion RunAutoBattle

        #region CreateCharacterParty
        [Test]
        public async Task AutoBattleEngine_CreateCharacterParty_Valid_Characters_Should_Assign_6()
        {
            //Arrange
            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 6;

            CharacterIndexViewModel.Instance.Dataset.Clear();

            _ = await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "1" });
            _ = await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "2" });
            _ = await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "3" });
            _ = await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "4" });
            _ = await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "5" });
            _ = await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "6" });
            _ = await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "7" });

            //Act
            var result = AutoBattleEngine.CreateCharacterParty();

            //Reset

            //Assert
            Assert.AreEqual(6, AutoBattleEngine.Battle.EngineSettings.CharacterList.Count);
            Assert.AreEqual("6", AutoBattleEngine.Battle.EngineSettings.CharacterList.ElementAt(5).Name);
        }

        [Test]
        public void AutoBattleEngine_CreateCharacterParty_Valid_Characters_CharacterIndex_None_Should_Create_6()
        {
            //Arrange
            AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 6;

            CharacterIndexViewModel.Instance.Dataset.Clear();

            //Act
            var result = AutoBattleEngine.CreateCharacterParty();

            //Reset

            //Assert
            Assert.AreEqual(6, AutoBattleEngine.Battle.EngineSettings.CharacterList.Count);
        }
        #endregion CreateCharacterParty   

        #region DetectInfinateLoop
        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_InValid_RoundCount_More_Than_Max_Should_Return_True()
        {
            // Arrange
            AutoBattleEngine.Battle.EngineSettings.BattleScore.RoundCount = AutoBattleEngine.Battle.EngineSettings.MaxRoundCount + 1;

            // Act
            var result = AutoBattleEngine.DetectInfinateLoop();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_InValid_TurnCount_Count_More_Than_Max_Should_Return_True()
        {
            // Arrange
            AutoBattleEngine.Battle.EngineSettings.BattleScore.TurnCount = AutoBattleEngine.Battle.EngineSettings.MaxTurnCount + 1;

            // Act
            var result = AutoBattleEngine.DetectInfinateLoop();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_Valid_Counts_Less_Than_Max_Should_Return_false()
        {
            // Arrange
            AutoBattleEngine.Battle.EngineSettings.BattleScore.TurnCount = AutoBattleEngine.Battle.EngineSettings.MaxTurnCount - 1;
            AutoBattleEngine.Battle.EngineSettings.BattleScore.RoundCount = AutoBattleEngine.Battle.EngineSettings.MaxRoundCount - 1;

            // Act
            var result = AutoBattleEngine.DetectInfinateLoop();

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion DetectInfinateLoop
    }
}