using NUnit.Framework;
using Game.Engine.EngineKoenig;
using Game.Models;
using System.Threading.Tasks;
using Game.ViewModels;
using Game.Helpers;
using Game.Engine.EngineModels;
using Game.Engine.EngineGame;

namespace Scenario
{
    [TestFixture]
    public class HackathonScenarioTests
    {
        #region TestSetup
        readonly BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;
        Game.Engine.EngineKoenig.BattleEngine Engine = new Game.Engine.EngineKoenig.BattleEngine();

        [SetUp]
        public void Setup()
        {
            // Put seed data into the system for all tests
            _ = BattleEngineViewModel.Instance.Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            _ = BattleEngineViewModel.Instance.Engine.StartBattle(false);

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = false;
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Scenario0
        [Test]
        public void HakathonScenario_Scenario_0_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      #
            *      
            * Description: 
            *      <Describe the scenario>
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      <List Files Changed>
            *      <List Classes Changed>
            *      <List Methods Changed>
            * 
            * Test Algrorithm:
            *      <Step by step how to validate this change>
            * 
            * Test Conditions:
            *      <List the different test conditions to make>
            * 
            * Validation:
            *      <List how to validate this change>
            *  
            */

            // Arrange

            // Act

            // Assert


            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Scenario0

        #region Scenario1
        [Test]
        public async Task HackathonScenario_Scenario_1_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      Make a Character called Mike, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Set speed to -1 so he is really slow
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Mike is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.CriticalHit;

            //Act
            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, EngineViewModel.Engine.EngineSettings.PlayerList.Find(m => m.Name.Equals("Mike")));
            Assert.AreEqual(1, EngineViewModel.Engine.EngineSettings.BattleScore.RoundCount);
        }
        #endregion Scenario1

        #region Scenario2
        [Test]
        public void HakathonScenario_Scenario_2_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      2
            *      
            * Description: 
            *      Make a character called Doug, Doug always misses
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *       Changes in TurnEngine.cs method TurnAsAtack()
            * 
            * Test Algrorithm:
            *      Create a character called Doug
            *      Set speed to 5
            *      Set current health to 10
            *      
            *      Create a monster called Lisa
            *      set speed to 5
            *      set current health to 10
            *      
            *      set Doug to always miss
            *      set Monster to always hit
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Doug's attack was a CriticalMiss
            *      Verify Round Count is 1
            *  
            */

            // Arrange
            Game.Engine.EngineGame.BattleEngine Train = new Game.Engine.EngineGame.BattleEngine();
            
            Train.EngineSettings.MaxNumberPartyCharacters = 1;

            var Doug = new PlayerInfoModel(
                    new CharacterModel 
                    {
                        Speed = 5,
                        Level = 1,
                        CurrentHealth = 10,
                        ExperienceTotal = 5,
                        ExperienceRemaining = 1,
                        Name = "Doug",
                    });

            Train.EngineSettings.CharacterList.Add(Doug);

            var Lisa = new PlayerInfoModel(
                    new MonsterModel
                    {
                        Speed = 5,
                        Level = 1,
                        CurrentHealth = 10,
                        ExperienceTotal = 5,
                        ExperienceRemaining = 1,
                        Name = "Lisa",
                    });

            Train.EngineSettings.MonsterList.Add(Lisa);

            // Monsters always hit
            Train.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.CriticalHit;

            // Act
            var status = Train.Round.Turn.TurnAsAttack(Doug, Lisa);

            var result = Train.EngineSettings.BattleSettingsModel.CharacterHitEnum;

            // Reset

            // Assert
            Assert.AreEqual(true, status);
            Assert.AreEqual(HitStatusEnum.CriticalMiss, result);
            Assert.AreEqual(1, Train.EngineSettings.BattleScore.RoundCount);
        }
        #endregion Scenario2


        #region Scenario4
        [Test]
        public void HakathonScenario_Scenario_4_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      4
            *      
            * Description: 
            *      The attacker will automatically hit and the window will return the message to that a critical hit happened
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No code change required
            * 
            * Test Algrorithm:
            *      set the AttackScore to 1
            *      set the DefenseScore to 100
            *      EnableForecedRolls and set the forced roll value to 20
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify the HitStatusEnum is CriticalHit
            *      Verify the HitStatusEnum message is " hits really hard "
            *  
            */

            // Arrange

            var AttackScore = 1;
            var DefenseScore = 100;

            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(20);

            var oldSeting = EngineSettingsModel.Instance.BattleSettingsModel.AllowCriticalHit;
            EngineSettingsModel.Instance.BattleSettingsModel.AllowCriticalHit = true;

            // Act
            var status = EngineViewModel.Engine.Round.Turn.RollToHitTarget(AttackScore, DefenseScore);

            // Reset
            _ = DiceHelper.DisableForcedRolls();
            EngineSettingsModel.Instance.BattleSettingsModel.AllowCriticalHit = oldSeting;

            // Assert
            Assert.AreEqual(HitStatusEnum.CriticalHit, status);
            Assert.AreEqual(HitStatusEnum.CriticalHit.ToMessage(),status.ToMessage());
        }
        #endregion Scenario4

        #region Scenario33
        [Test]
        public void HackathonScenario_Scenario_33_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      33
            *      
            * Description: 
            *      Allow characters to choose to do nothing for their turn. Resting restores 2 health per rest.
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Enum: ActionEnum
            *      Class: TurnEngineBase.cs, ITurnEngineInterface.cs, TurnEngine.cs
            *      Methods: UseRelax, TakeTurn
            * 
            * Test Algrorithm:
            *      Create a character Doug
            *      Set the current Action to Relax
            *      Call Turn Engine to Take Turn
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify the result is true
            *      Verify the character's current health increase by 2
            */

            // Arrange
            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var Doug = new PlayerInfoModel(
                    new CharacterModel
                    {
                        Speed = 5,
                        Level = 1,
                        CurrentHealth = 5,
                        ExperienceTotal = 5,
                        ExperienceRemaining = 1,
                        Name = "Doug",
                    });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(Doug);
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Relax;

            // Act
            var result = Engine.Round.Turn.TakeTurn(Doug);

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(7, EngineViewModel.Engine.EngineSettings.CharacterList.Find(m => m.Name.Equals("Doug")).CurrentHealth);
        }
        #endregion Scenario33

        #region Scenario34
        [Test]
        public void HakathonScenario_Scenario_34_Valid_Default_Should_Pass()
        {
            /*
            * Scenario Number:
            *      # 34
            *
            * Description:
            *      Move based on speed
            *      Limit the distance a player can move to their speed attribute.
            *      If a player has speed of 3, then they can move 3 squares, a speed of 6 can move 6 etc.
            *
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes:
            *      Added ReverseDistance, IsTargetInSpeed and SpeedClosestEmptyLocation methods to MapModel
            *      Modified MoveAsAction in EngineGame.TurnEngine
            *
            * Test Algrorithm:
            *      Create an new Character with Speed = 1
            *      Create a new Monster with Speed = 2
            *      Monster takes first action by calling MoveAsAction
            *
            * Test Conditions:
            *      The starting location of the Monster
            *      The ending location of the Monster
            *      The calculated distance between the two locations
            *
            * Validation:
            *      Verify that the starting and ending locations are different
            *      Verify that the calculated distance is the same as the Monster's Speed Attribute
            *
            */

            // Arrange
            Game.Engine.EngineGame.BattleEngine Train = new Game.Engine.EngineGame.BattleEngine();

            Train.EngineSettings.MaxNumberPartyCharacters = 1;
            Train.EngineSettings.MaxNumberPartyMonsters = 1;

            Train.EngineSettings.CurrentAction = ActionEnum.Move;

            var slowpoke = new PlayerInfoModel(
                new CharacterModel
                {
                    Speed = 1,
                    Level = 1,
                    CurrentHealth = 10,
                    Name = "slowpoke",
                });

            var fastMonster = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 2,
                    Level = 1,
                    CurrentHealth = 10,
                });

            Train.EngineSettings.CharacterList.Add(slowpoke);
            Train.EngineSettings.MonsterList.Add(fastMonster);

            _ = Train.EngineSettings.MapModel.PopulateMapModel(Train.Round.MakePlayerList());

            var StartLoc = Train.EngineSettings.MapModel.GetLocationForPlayer(fastMonster);

            // Act
            Train.Round.Turn.TakeTurn(fastMonster);

            var result = Train.EngineSettings.MapModel.GetLocationForPlayer(fastMonster);

            var distance = Train.EngineSettings.MapModel.CalculateDistance(StartLoc, result);

            // Reset
            Train.EngineSettings.PlayerList.Clear();

            // Assert
            Assert.AreNotEqual(StartLoc, result);
            Assert.AreEqual(distance, fastMonster.Speed);
        }
        #endregion Scenario34
    }
}