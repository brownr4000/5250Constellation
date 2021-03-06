using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

using Game.Engine.EngineGame;
using Game.Models;
using Game.ViewModels;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class RoundEngineGameTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new();

            Engine.Round = new RoundEngine
            {
                Turn = new TurnEngine()
            };
            _ = Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            //Engine.StartBattle(true);   
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void RoundEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region OrderPlayListByTurnOrder
        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Speed_Higher_Should_Be_Z()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Level_Higher_Should_Be_Z()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_Experience_Higher_Should_Be_Z()
        {
            // Arrange

            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 100,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10,
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_ListOrder_Should_Be_1()
        {
            // Arrange
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "A",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "A",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual(1, result[0].ListOrder);
        }

        [Test]
        public void RoundEngine_OrderPlayerListByTurnOrder_Valid_CurrentHealth_Should_Be_ZZ()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Both need to be character to fall through to the Name Test
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "ZZ",
                ListOrder = 10
            };

            CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Sort the list by Name, so it has to be resorted.
            Engine.EngineSettings.PlayerList = Engine.EngineSettings.PlayerList.OrderBy(m => m.Name).ToList();

            // Act
            var result = Engine.Round.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("ZZ", result[0].Name);
        }
        #endregion OrderPlayListByTurnOrder

        #region GetItemFromPoolIfBetter

        //[Test]
        //public async Task RoundEngine_GetItemFromPoolIfBetter_InValid_Pool_Empty_Should_Fail()
        //{
        //    Engine.EngineSettings.MonsterList.Clear();

        //    // Both need to be character to fall through to the Name Test
        //    // Arrange
        //    var Character = new CharacterModel
        //    {
        //        Speed = 20,
        //        Level = 1,
        //        CurrentHealth = 1,
        //        ExperienceTotal = 1,
        //        Name = "Z",
        //        ListOrder = 1,
        //        Guid = "me"
        //    };

        //    // Add each model here to warm up and load it.
        //    _ = Game.Helpers.DataSetsHelper.WarmUp();

        //    var item1 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 1, Location = ItemLocationEnum.Head };
        //    var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Value = 20, Location = ItemLocationEnum.Head };

        //    _ = await ItemIndexViewModel.Instance.CreateAsync(item1);
        //    _ = await ItemIndexViewModel.Instance.CreateAsync(item2);

        //    //Engine.EngineSettings.ItemPool.Add(item1);
        //    //Engine.EngineSettings.ItemPool.Add(item2);

        //    // Put the Item on the Character
        //    _ = Character.AddItem(ItemLocationEnum.Head, item2.Id);

        //    var CharacterPlayer = new PlayerInfoModel(Character);
        //    Engine.EngineSettings.CharacterList.Clear();
        //    Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

        //    // Make the List
        //    Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

        //    // Act
        //    var result = Engine.Round.GetItemFromPoolIfBetter(CharacterPlayer, ItemLocationEnum.Head);

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result);
        //}

        #endregion GetItemFromPoolIfBetter

        #region PickupItemsFromPool
        [Test]
        public void RoundEngine_PickupItemsFromPool_Valid_Default_Should_Pass()
        {
            // Arrange
            var Character = new CharacterModel
            {
                Speed = 20,
                Level = 1,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
                ListOrder = 1,
                Guid = "me"
            };

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(Character));

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.PickupItemsFromPool(CharacterPlayer);

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion PickupItemsFromPool

        #region EndRound
        [Test]
        public void RoundEngine_EndRound_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine.Round.EndRound();

            // Reset

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion EndRound

        #region RoundNextTurn
        /// <summary>
        /// Unit Test to check that no Valid Characters results in GameOver 
        /// </summary>
        [Test]
        public void RoundEngine_RoundNextTurn_Valid_No_Characters_Should_Return_GameOver()
        {
            // Arrange
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.CharacterList.Clear();

            // Act
            var result = Engine.Round.RoundNextTurn();

            // Reset

            // Assert
            Assert.AreEqual(RoundEnum.GameOver, result);
        }

        [Test]
        public void RoundEngine_RoundNextTurn_Valid_No_Monsters_Should_Return_NewRound()
        {
            // Arrange
            Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Attack = 100,
                                Defense = 100,
                                Level = 1,
                                CurrentHealth = 111,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Act
            var result = Engine.Round.RoundNextTurn();

            // Reset

            // Assert
            Assert.AreEqual(RoundEnum.NewRound, result);
        }

        [Test]
        public void RoundEngine_RoundNextTurn_Valid_Characters_Monsters_Should_Return_NextTurn()
        {
            // Arrange
            Engine.EngineSettings.MaxNumberPartyCharacters = 1;
            Engine.EngineSettings.MaxNumberPartyMonsters = 1;

            var characterPlayer = new PlayerInfoModel(
                    new CharacterModel 
                    {
                        Speed = 100,
                        Attack = 100,
                        Defense = 100,
                        Level = 1,
                        CurrentHealth = 111,
                        ExperienceTotal = 1,
                        ExperienceRemaining = 1,
                        Name = "Mike",
                        ListOrder = 1,
                    });

            Engine.EngineSettings.CharacterList.Add(characterPlayer);

            var characterMonster = new PlayerInfoModel(
                    new MonsterModel {
                        Speed = 1,
                        Attack = 1,
                        Defense = 1,
                        Level = 1,
                        CurrentHealth = 1,
                        ExperienceTotal = 1,
                        ExperienceRemaining = 1,
                        Name = "Sue",
                        ListOrder = 2,
                    });

            Engine.EngineSettings.MonsterList.Add(characterMonster);

            // Act
            var result = Engine.Round.RoundNextTurn();

            // Reset

            // Assert
            Assert.AreEqual(RoundEnum.NextTurn, result);
        }
        #endregion RoundNextTurn

        #region GetNextPlayerInList

        [Test]
        public void RoundEngine_GetNextPlayerInList_Valid_Sue_Should_Return_Monster()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var CharacterPlayerMike = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 200,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Mike",
                                            ListOrder = 1,
                                        });

            var CharacterPlayerDoug = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 20,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Doug",
                                            ListOrder = 2,
                                        });

            var CharacterPlayerSue = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 2,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Sue",
                                            ListOrder = 3,
                                        });

            var MonsterPlayer = new PlayerInfoModel(
                                    new MonsterModel
                                    {
                                        Speed = 1,
                                        Level = 1,
                                        CurrentHealth = 1,
                                        ExperienceTotal = 1,
                                        Name = "Monster",
                                        ListOrder = 4,
                                    });

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerDoug);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerSue);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Set Sue as the Player
            Engine.EngineSettings.CurrentAttacker = CharacterPlayerSue;

            // Arrange

            // Act
            var result = Engine.Round.GetNextPlayerInList();

            // Reset

            // Assert
            Assert.AreEqual("Monster", result.Name);
        }

        [Test]
        public void RoundEngine_GetNextPlayerInList_Valid_Monster_Should_Return_Mike()
        {
            Engine.EngineSettings.MonsterList.Clear();

            // Arrange
            var CharacterPlayerMike = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 200,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Mike",
                                            ListOrder = 1,
                                        });

            var CharacterPlayerDoug = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 20,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Doug",
                                            ListOrder = 2,
                                        });

            var CharacterPlayerSue = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 2,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Sue",
                                            ListOrder = 3,
                                        });

            var MonsterPlayer = new PlayerInfoModel(
                                    new MonsterModel
                                    {
                                        Speed = 1,
                                        Level = 1,
                                        CurrentHealth = 1,
                                        ExperienceTotal = 1,
                                        Name = "Monster",
                                        ListOrder = 4,
                                    });

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();

            Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerDoug);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerSue);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.GetNextPlayerInList();

            // Reset


            // Assert
            Assert.AreEqual("Mike", result.Name);
        }

        #endregion GetNextPlayerInList

        #region PlayerList
        //[Test]
        //public void RoundEngine_PlayerList_Valid_Default_Should_Pass()
        //{
        //    // Act
        //    var result = Engine.Round.PlayerList();

        //    // Reset

        //    // Assert
        //    Assert.AreEqual(false, result.Any());
        //}
        #endregion PlayerList

        #region SwapCharacterItem
        /// <summary>
        /// This Unit Tests checks the SwapCharacterItem method
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task RoundEngine_SwapCharacterItem_Valid_Default_Should_Pass()
        {
            // Arrange
            // Clear Monster and Character Lists
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.CharacterList.Clear();

            // Create new Character
            var Character = new CharacterModel
            {
                Level = 5,
                Attack = 2,
                Speed = 2,
                CurrentHealth = 1,
                ExperienceTotal = 1,
                Name = "Z",
            };

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            // Create Items
            var item1 = new ItemModel { Attribute = AttributeEnum.Defense, Damage = 4, Value = 1, Location = ItemLocationEnum.PrimaryHand };
            var item2 = new ItemModel { Attribute = AttributeEnum.Attack, Damage = 8, Value = 5, Location = ItemLocationEnum.PrimaryHand };

            _ = await ItemIndexViewModel.Instance.CreateAsync(item1);
            _ = await ItemIndexViewModel.Instance.CreateAsync(item2);

            // Equip one Item to Character
            _ = Character.AddItem(ItemLocationEnum.PrimaryHand, item1.Id);

            // Add Character to CharacterList
            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Act
            var result = Engine.Round.SwapCharacterItem(CharacterPlayer, ItemLocationEnum.PrimaryHand, item2);

            // Reset

            // Assert
            Assert.AreEqual(item1, result);                         // Verify item1 was dropped
            Assert.AreEqual(item2.Id, CharacterPlayer.PrimaryHand); // Verify that Character has Item2
        }
        #endregion SwapCharacterItem

        #region GetItemFromPoolIfBetter
        [Test]
        public void RoundEngine_GetItemFromPoolIfBetter_Valid_Default_Should_Pass()
        {
            // Arrange 

            // Act
            var result = Engine.Round.GetItemFromPoolIfBetter(null, ItemLocationEnum.Head);

            // Reset

            // Assert
            Assert.AreEqual(false, result);
        }
        #endregion GetItemFromPoolIfBetter

        #region RemoveDeadPlayersFromList
        [Test]
        public void RoundEngine_RemoveDeadPlayersFromList_Valid_Default_Should_Pass()
        {
            // Arrange
            // Create Monster
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
            };

            // Add Monster to MonsterList
            var MonsterPlayer = new PlayerInfoModel(Monster);
            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Create Characters & Add to CharacterList
            var Character = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 0,
                ExperienceTotal = 1,
                Name = "C",
                Alive = false, // Set flag for Alive to false
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            Character = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 3,
                ExperienceTotal = 1,
                Name = "D",
            };

            CharacterPlayer = new PlayerInfoModel(Character);
            Engine.EngineSettings.CharacterList.Add(CharacterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.RemoveDeadPlayersFromList();

            // Reset

            // Assert
            Assert.AreEqual(2, result.Count);
        }
        #endregion RemoveDeadPlayersFromList

        #region GetNextPlayerTurn
        [Test]
        public void RoundEngine_GetNextPlayerTurn_Valid_Default_Should_Pass()
        {
            // Arrange
            var CharacterPlayerSue = new PlayerInfoModel(
                                        new CharacterModel
                                        {
                                            Speed = 2,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Sue",
                                            ListOrder = 3,
                                        });

            var MonsterPlayer = new PlayerInfoModel(
                                        new MonsterModel
                                        {
                                            Speed = 1,
                                            Level = 1,
                                            CurrentHealth = 1,
                                            ExperienceTotal = 1,
                                            Name = "Monster",
                                            ListOrder = 4,
                                        });

            // Add each model here to warm up and load it.
            _ = Game.Helpers.DataSetsHelper.WarmUp();

            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CharacterList.Add(CharacterPlayerSue);

            Engine.EngineSettings.MonsterList.Clear();
            Engine.EngineSettings.MonsterList.Add(MonsterPlayer);

            // Make the List
            Engine.EngineSettings.PlayerList = Engine.Round.MakePlayerList();

            // Act
            var result = Engine.Round.GetNextPlayerTurn();

            // Reset

            // Assert
            Assert.AreEqual("Sue", result.Name);
        }
        #endregion GetNextPlayerTurn
    }
}