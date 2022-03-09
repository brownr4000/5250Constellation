using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.Engine.EngineGame;
using Game.Engine.EngineModels;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class TurnEngineGameTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.Round = new RoundEngine();
            Engine.Round.Turn = new TurnEngine();
            Engine.StartBattle(true);   // Start engine in auto battle mode
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void TurnEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region MoveAsTurn
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TurnEngine_MoveAsTurn_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_MoveAsTurn_Valid_Monster_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(new PlayerInfoModel(new MonsterModel()));

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion MoveAsTurn

        #region ApplyDamage
        [Test]
        public void TurnEngine_ApplyDamage_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.ApplyDamage(new PlayerInfoModel(new MonsterModel()));

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion ApplyDamage

        #region Attack
        /// <summary>
        /// Unit test for the Attack method
        /// </summary>
        [Test]
        public void TurnEngine_Attack_Valid_Default_Should_Pass()
        {
            // Arrange
            var character = new PlayerInfoModel(new CharacterModel());
            var monster  = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Attack = 1,
                    Defense = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    MonsterJob = MonsterJobEnum.Brute,
                });

            Engine.EngineSettings.PlayerList.Add(character);
            Engine.EngineSettings.PlayerList.Add(monster);

            _ = Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            // Act
            var result = Engine.Round.Turn.Attack(character);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion Attack

        #region AttackChoice
        /// <summary>
        /// Unit test for the AttackChoice method
        /// </summary>
        [Test]
        public void TurnEngine_AttackChoice_Valid_Default_Should_Pass()
        {
            // Arrange
            Engine.EngineSettings.PlayerList.Clear();

            var character = new PlayerInfoModel(new CharacterModel());
            var monster = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Attack = 1,
                    Defense = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    MonsterJob = MonsterJobEnum.Brute,
                });

            Engine.EngineSettings.PlayerList.Add(character);
            Engine.EngineSettings.PlayerList.Add(monster);

            _ = Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);
            Engine.EngineSettings.CurrentAttacker = character;

            // Act
            var result = Engine.Round.Turn.AttackChoice(character);

            // Reset
            Engine.EngineSettings.PlayerList.Clear();

            // Assert
            Assert.AreEqual(monster, result);
        }
        #endregion AttackChoice

        #region SelectCharacterToAttack
        /// <summary>
        /// Unit test for SelectCharacterToAttack
        /// </summary>
        [Test]
        public void TurnEngine_SelectCharacterToAttack_Valid_Default_Should_Pass()
        {
            // Arrange
            Engine.EngineSettings.PlayerList.Clear();

            var character = new PlayerInfoModel(
                new CharacterModel
                {
                    CurrentHealth = 2,
                    Job = CharacterJobEnum.Support,
                });

            var monster = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Attack = 1,
                    Defense = 1,
                    Level = 1,
                    CurrentHealth = 10,
                    MonsterJob = MonsterJobEnum.Brute,
                });

            Engine.EngineSettings.PlayerList.Add(character);
            Engine.EngineSettings.PlayerList.Add(monster);

            _ = Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            Engine.EngineSettings.CurrentAttacker = monster;

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset
            Engine.EngineSettings.PlayerList.Clear();

            // Assert
            Assert.AreEqual(character, result);
        }
        #endregion SelectCharacterToAttack

        #region UseAbility
        [Test]
        public void TurnEngine_UseAbility_Valid_Default_Should_Pass()
        {
            // Arrange 
            var player = new PlayerInfoModel(
                new CharacterModel 
                { 
                    Speed = 1,
                    CurrentHealth = 2,
                    Job = CharacterJobEnum.Fighter,
                });

            // Act
            var result = Engine.Round.Turn.UseAbility(player);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion UseAbility

        #region BattleSettingsOverrideHitStatusEnum
        [Test]
        public void TurnEngine_BattleSettingsOverrideHitStatusEnum_Valid_Default_Should_Pass()
        {
            // Arrange 
            Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Hit;

            // Act
            var result = Engine.Round.Turn.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.Miss);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }
        #endregion BattleSettingsOverrideHitStatusEnum

        #region BattleSettingsOverride
        [Test]
        public void TurnEngine_BattleSettingsOverride_Valid_Default_Should_Pass()
        {
            // Arrange 
            Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Miss;

            // Act
            var result = Engine.Round.Turn.BattleSettingsOverride(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }
        #endregion BattleSettingsOverride

        #region CalculateExperience
        [Test]
        public void TurnEngine_CalculateExperience_Valid_Default_Should_Pass()
        {
            // Arrange
            var character = new PlayerInfoModel(
                new CharacterModel
                {
                    CurrentHealth = 2,
                    Job = CharacterJobEnum.Support,
                });

            var monster = new PlayerInfoModel(
                new MonsterModel
                {
                    CurrentHealth = 100,
                    MonsterJob = MonsterJobEnum.Brute,
                    Alive = false,
                });
            
            Engine.EngineSettings.BattleMessagesModel.DamageAmount = 0;

            // Act
            var result = Engine.Round.Turn.CalculateExperience(character, monster);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, character.ExperienceTotal);
        }
        #endregion CalculateExperience

        #region CalculateAttackStatus
        [Test]
        public void TurnEngine_CalculateAttackStatus_Valid_Default_Should_Pass()
        {
            // Arrange 
            // Force roll so the result will be constant
            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(20);

            // Act
            var result = Engine.Round.Turn.CalculateAttackStatus(new PlayerInfoModel(), new PlayerInfoModel());

            // Reset
            _ = DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }
        #endregion CalculateAttackStatus

        #region RemoveIfDead
        [Test]
        public void TurnEngine_RemoveIfDead_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.RemoveIfDead(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion RemoveIfDead

        #region ChooseToUseAbility
        [Test]
        public void TurnEngine_ChooseToUseAbility_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.ChooseToUseAbility(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion ChooseToUseAbility

        #region SelectMonsterToAttack
        [Test]
        public void TurnEngine_SelectMonsterToAttack_Valid_Default_Should_Pass()
        {
            // Arrange 
            Engine.EngineSettings.PlayerList.Clear();

            // Act
            var result = Engine.Round.Turn.SelectMonsterToAttack();

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion SelectMonsterToAttack

        #region DetermineActionChoice
        /// <summary>
        /// Tests the DetermineActionChoice method for a Character Player
        /// </summary>
        [Test]
        public void TurnEngine_DetermineActionChoice_Valid_Default_Should_Pass()
        {
            // Arrange
            Engine.EngineSettings.BattleScore.AutoBattle = false;

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Alive = false,
                }) ;

            Engine.EngineSettings.PlayerList.Add(CharacterPlayer);

            _ = BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(CharacterPlayer);
            _ = BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(MonsterPlayer);
            
            // Act
            var result = Engine.Round.Turn.DetermineActionChoice(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Move, result);
        }
        #endregion DetermineActionChoice

        #region TurnAsAttack
        [Test]
        public void TurnEngine_TurnAsAttack_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(new PlayerInfoModel(new CharacterModel()), new PlayerInfoModel(new MonsterModel()));

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion TurnAsAttack

        #region TargetDied
        [Test]
        public void TurnEngine_TargetDied_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.TargetDied(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion TargetDied

        #region TakeTurn
        [Test]
        public void TurnEngine_TakeTurn_Valid_Default_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new CharacterModel());
            var monster = new PlayerInfoModel(new MonsterModel());
            Engine.EngineSettings.CurrentAttacker = PlayerInfo;
            Engine.EngineSettings.CurrentDefender = monster;

            // Act
            var action = Engine.EngineSettings.CurrentAction;
            var result = Engine.Round.Turn.TakeTurn(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Unknown, action);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_TakeTurn_Ability_Should_Pass()
        {
            // Arrange

            Engine.EngineSettings.CurrentAction = ActionEnum.Ability;
            Engine.EngineSettings.CurrentActionAbility = AbilityEnum.Bandage;

            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.Round.Turn.TakeTurn(PlayerInfo);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TakeTurn_Move_Should_Pass()
        {
            // Arrange

            Engine.EngineSettings.CurrentAction = ActionEnum.Move;

            var character = new PlayerInfoModel(new CharacterModel());
            var monster = new PlayerInfoModel(new CharacterModel());

            Engine.EngineSettings.PlayerList.Add(character);
            Engine.EngineSettings.PlayerList.Add(monster);

            _ = Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            // Act
            var result = Engine.Round.Turn.TakeTurn(character);

            // Reset
            Engine.EngineSettings.PlayerList.Clear();

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_TakeTurn_InValid_ActionEnum_Unknown_Should_Set_Action_To_Attack()
        {
            // Arrange

            Engine.EngineSettings.CurrentAction = ActionEnum.Move;

            var character = new PlayerInfoModel(new CharacterModel());
            var monster = new PlayerInfoModel(new CharacterModel());

            Engine.EngineSettings.PlayerList.Add(character);
            Engine.EngineSettings.PlayerList.Add(monster);

            _ = Engine.EngineSettings.MapModel.PopulateMapModel(Engine.EngineSettings.PlayerList);

            // Set current action to unknonw
            EngineSettingsModel.Instance.CurrentAction = ActionEnum.Unknown;

            // Set Autobattle to false
            EngineSettingsModel.Instance.BattleScore.AutoBattle = false;


            // Act
            var result = Engine.Round.Turn.TakeTurn(character);

            // Reset
            Engine.EngineSettings.PlayerList.Clear();

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion TakeTurn

        #region RollToHitTarget
        [Test]
        public void TurnEngine_RollToHitTarget_Valid_Default_Should_Pass()
        {
            // Arrange 
            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(1);

            // Act
            var result = Engine.Round.Turn.RollToHitTarget(1,1);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Miss, result);
        }
        #endregion RollToHitTarget

        #region GetRandomMonsterItemDrops
        [Test]
        public void TurnEngine_GetRandomMonsterItemDrops_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.GetRandomMonsterItemDrops(1).Count();

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }
        #endregion GetRandomMonsterItemDrops

        #region DetermineCriticalMissProblem
        [Test]
        public void TurnEngine_DetermineCriticalMissProblem_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.DetermineCriticalMissProblem(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion DetermineCriticalMissProblem

        #region DropItems
        [Test]
        public void TurnEngine_DropItems_Valid_Default_Should_Pass()
        {
            // Arrange
            var player = new CharacterModel();

            var PlayerInfo = new PlayerInfoModel(player);

            _ = DiceHelper.EnableForcedRolls();
            _ = DiceHelper.SetForcedRollValue(1);

            // Act
            var result = Engine.Round.Turn.DropItems(PlayerInfo);

            // Reset
            _ = DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(2, result);
        }
        #endregion DropItems
    }
}