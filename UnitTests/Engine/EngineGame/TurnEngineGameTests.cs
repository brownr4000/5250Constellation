﻿using System.Linq;
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
            //Engine.StartBattle(true);   // Start engine in auto battle mode
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
        [Test]
        public void RoundEngine_MoveAsTurn_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.MoveAsTurn(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoundEngine_MoveAsTurn_Valid_Monster_Default_Should_Pass()
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
        public void RoundEngine_ApplyDamage_Valid_Default_Should_Pass()
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
        [Test]
        public void RoundEngine_Attack_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.Attack(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion Attack

        #region AttackChoice
        [Test]
        public void RoundEngine_AttackChoice_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.AttackChoice(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion AttackChoice

        #region SelectCharacterToAttack
        [Test]
        public void RoundEngine_SelectCharacterToAttack_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.SelectCharacterToAttack();

            // Reset

            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion SelectCharacterToAttack

        #region UseAbility
        [Test]
        public void RoundEngine_UseAbility_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.UseAbility(null);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion UseAbility

        #region BattleSettingsOverrideHitStatusEnum
        [Test]
        public void RoundEngine_BattleSettingsOverrideHitStatusEnum_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.BattleSettingsOverrideHitStatusEnum(HitStatusEnum.Unknown);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Unknown, result);
        }
        #endregion BattleSettingsOverrideHitStatusEnum

        #region BattleSettingsOverride
        [Test]
        public void RoundEngine_BattleSettingsOverride_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.BattleSettingsOverride(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Unknown, result);
        }
        #endregion BattleSettingsOverride

        #region CalculateExperience
        [Test]
        public void RoundEngine_CalculateExperience_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.CalculateExperience(new PlayerInfoModel(), new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion CalculateExperience

        #region CalculateAttackStatus
        [Test]
        public void RoundEngine_CalculateAttackStatus_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.CalculateAttackStatus(new PlayerInfoModel(), new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }
        #endregion CalculateAttackStatus

        #region RemoveIfDead
        [Test]
        public void RoundEngine_RemoveIfDead_Valid_Default_Should_Pass()
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
        public void RoundEngine_ChooseToUseAbility_Valid_Default_Should_Pass()
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
        public void RoundEngine_SelectMonsterToAttack_Valid_Default_Should_Pass()
        {
            // Arrange 

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
        public void RoundEngine_DetermineActionChoice_Valid_Default_Should_Pass()
        {
            // Arrange
            Engine.EngineSettings.BattleScore.AutoBattle = false;

            var CharacterPlayer = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.Round.Turn.DetermineActionChoice(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(ActionEnum.Unknown, result);
        }
        #endregion DetermineActionChoice

        #region TurnAsAttack
        [Test]
        public void RoundEngine_TurnAsAttack_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.TurnAsAttack(new PlayerInfoModel(), new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion TurnAsAttack

        #region TargetDied
        [Test]
        public void RoundEngine_TargetDied_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.TargetDied(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion TargetDied

        #region TakeTurn
        [Test]
        public void RoundEngine_TakeTurn_Valid_Default_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.Round.Turn.TakeTurn(PlayerInfo);

            // Reset

            // Assert
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

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion TakeTurn

        #region RollToHitTarget
        [Test]
        public void RoundEngine_RollToHitTarget_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.RollToHitTarget(1,1);

            // Reset

            // Assert
            Assert.AreEqual(HitStatusEnum.Hit, result);
        }
        #endregion RollToHitTarget

        #region GetRandomMonsterItemDrops
        [Test]
        public void RoundEngine_GetRandomMonsterItemDrops_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.GetRandomMonsterItemDrops(1).Count();

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }
        #endregion GetRandomMonsterItemDrops

        #region DetermineCriticalMissProblem
        [Test]
        public void RoundEngine_DetermineCriticalMissProblem_Valid_Default_Should_Pass()
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
        public void RoundEngine_DropItems_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.Turn.DropItems(new PlayerInfoModel());

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }
        #endregion DropItems
    }
}