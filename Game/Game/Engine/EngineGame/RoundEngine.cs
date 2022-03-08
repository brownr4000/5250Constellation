using System;
using System.Collections.Generic;
using System.Linq;

using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.GameRules;
using Game.Helpers;
using Game.Models;
using Game.ViewModels;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// The Round class manages the Rounds for each Battle
    /// </summary>
    public class RoundEngine : RoundEngineBase, IRoundEngineInterface
    {
        // Hold the BaseEngine
        public new EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        // The Turn Engine
        public new ITurnEngineInterface Turn
        {
            get
            {
                if (base.Turn == null)
                {
                    base.Turn = new TurnEngine();
                }
                return base.Turn;
            }
            set { base.Turn = Turn; }
        }

        /// <summary>
        /// The ClearLists method clears the List between Rounds
        /// </summary>
        public override bool ClearLists()
        {
            EngineSettings.ItemPool.Clear();
            EngineSettings.MonsterList.Clear();
            return true;
        }

        /// <summary>
        /// The NewRound method controls and resets the status of the Battle at the start of each Round
        /// 
        /// It is called to make a new set of monsters, and reset Character buffs
        /// </summary>
        public override bool NewRound()
        {
            // End the existing round
            _ = EndRound();

            // Remove Character Buffs
            _ = RemoveCharacterBuffs();

            // Populate New Monsters..
            _ = AddMonstersToRound();

            // Make the BaseEngine.PlayerList
            _ = MakePlayerList();

            // Set Order for the Round
            _ = OrderPlayerListByTurnOrder();

            // Populate BaseEngine.MapModel with Characters and Monsters
            _ = EngineSettings.MapModel.PopulateMapModel(EngineSettings.PlayerList);

            // Update Score for the RoundCount
            EngineSettings.BattleScore.RoundCount++;

            return true;
        }

        /// <summary>
        /// Add Monsters to the Round
        /// 
        /// Chooses a Monster from the existing Dataset at random
        /// Creates the Maximum number of Monsters using the base Monster
        /// Adjusts the name based on the number in the party
        /// Applies a random Bonus based on a Coin Flip and a d4
        /// Adds modified Monster to the Monster List
        /// </summary>
        /// <returns>The number of Monsters in the MonsterList</returns>
        public override int AddMonstersToRound()
        {
            var TargetLevel = 1;    // Value to hold Level

            // Update Level based on Minimum Character Level
            if (EngineSettings.CharacterList.Count() > 0)
            {
                // Get the Min Character Level (linq is soo cool....)
                TargetLevel = Convert.ToInt32(EngineSettings.CharacterList.Min(m => m.Level));
            }

            // Loop for number of Monsters in the Party
            for (var i = 0; i < EngineSettings.MaxNumberPartyMonsters; i++)
            {
                //var data = RandomPlayerHelper.GetRandomMonster(TargetLevel, EngineSettings.BattleSettingsModel.AllowMonsterItems);
                var data = RandomPlayerHelper.GetMonsterFromDatastore(TargetLevel);

                // Help identify which Monster it is
                data.Name += " " + Convert.ToString(i + 1);

                // Add monster to MonsterList
                EngineSettings.MonsterList.Add(new PlayerInfoModel(data));
            }

            return EngineSettings.MonsterList.Count();
        }

        /// <summary>
        /// At the end of the round
        /// Clear the ItemModel List
        /// Clear the MonsterModel List
        /// </summary>
        public override bool EndRound()
        {
            // In Auto Battle this happens and the characters get their items, In manual mode need to do it manualy
            if (EngineSettings.BattleScore.AutoBattle)
            {
                _ = PickupItemsForAllCharacters();
            }

            // Reset Monster and Item Lists
            _ = ClearLists();

            return true;
        }

        /// <summary>
        /// For each character pickup the items
        /// </summary>
        public override bool PickupItemsForAllCharacters()
        {
            // In Auto Battle this happens and the characters get their items
            // When called manualy, make sure to do the character pickup before calling EndRound

            // Have each character pickup items...
            foreach (var character in EngineSettings.CharacterList)
            {
                _ = PickupItemsFromPool(character);
            }

            return true;
        }

        /// <summary>
        /// The RoundNextTurn method manges the next turn
        /// 
        /// Decides Who's Turn
        /// Remembers Current Player
        /// 
        /// Starts the Turn
        /// 
        /// </summary>
        /// <returns></returns>
        public override RoundEnum RoundNextTurn()
        {
            // No characters, game is over..
            if (EngineSettings.CharacterList.Count < 1)
            {
                // Game Over
                EngineSettings.RoundStateEnum = RoundEnum.GameOver;
                return EngineSettings.RoundStateEnum;
            }

            // Check if round is over
            if (EngineSettings.MonsterList.Count < 1)
            {
                // If over, New Round
                EngineSettings.RoundStateEnum = RoundEnum.NewRound;
                return RoundEnum.NewRound;
            }

            // If in Auto Battle pick the next attacker
            if (EngineSettings.BattleScore.AutoBattle)
            {
                // Decide Who gets next turn
                // Remember who just went...
                EngineSettings.CurrentAttacker = GetNextPlayerTurn();

                // Only Attack for now
                EngineSettings.CurrentAction = ActionEnum.Attack;
            }

            // Do the turn..
            _ = Turn.TakeTurn(EngineSettings.CurrentAttacker);

            // No characters, game is over..
            if (EngineSettings.CharacterList.Count < 1)
            {
                // Game Over
                EngineSettings.RoundStateEnum = RoundEnum.GameOver;
                return EngineSettings.RoundStateEnum;
            }

            // Check if round is over
            if (EngineSettings.MonsterList.Count < 1)
            {
                // If over, New Round
                EngineSettings.RoundStateEnum = RoundEnum.NewRound;
                return RoundEnum.NewRound;
            }

            EngineSettings.RoundStateEnum = RoundEnum.NextTurn;

            return EngineSettings.RoundStateEnum;
        }

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        public override PlayerInfoModel GetNextPlayerTurn()
        {
            // Remove the Dead
            _ = RemoveDeadPlayersFromList();

            // Get Next Player
            var PlayerCurrent = GetNextPlayerInList();

            return PlayerCurrent;
        }

        /// <summary>
        /// Remove Dead Players from the List
        /// </summary>
        public override List<PlayerInfoModel> RemoveDeadPlayersFromList()
        {
            EngineSettings.PlayerList = EngineSettings.PlayerList.Where(m => m.Alive == true).ToList();
            return EngineSettings.PlayerList;
        }

        /// <summary>
        /// The OrderPlayerListByTurnOrder orders the Players in Turn Sequence
        /// </summary>
        public override List<PlayerInfoModel> OrderPlayerListByTurnOrder()
        {
            // Order by Speed (Descending)
            // Then by CharacterJobEnum.Striker
            // Then by MonsterJobEnum.Swift
            // Then by CharacterJobEnum.Defender
            // Then by MonsterJobEnum.Brute
            // Then by CharacterJobEnum.Support 
            // Then by Highest level (Descending)
            // Then by CurrentHealth (Desending)
            // Then by First in list order (Ascending)

            EngineSettings.PlayerList = EngineSettings.PlayerList.OrderByDescending(a => a.GetSpeed())
                .ThenBy(a => a.Job.Equals(CharacterJobEnum.Striker))
                .ThenBy(a => a.Job.Equals(MonsterJobEnum.Swift))
                .ThenBy(a => a.Job.Equals(CharacterJobEnum.Defender))
                .ThenBy(a => a.Job.Equals(MonsterJobEnum.Brute))
                .ThenBy(a => a.Job.Equals(CharacterJobEnum.Support))
                .ThenByDescending(a => a.Level)
                .ThenByDescending(a => a.CurrentHealth)
                .ThenBy(a => a.ListOrder)
                .ToList();

            return EngineSettings.PlayerList;
        }

        /// <summary>
        /// The MakePlayerList method creates the list of Players for the Round
        /// </summary>
        public override List<PlayerInfoModel> MakePlayerList()
        {
            // Start from a clean list of players
            EngineSettings.PlayerList.Clear();

            // Remember the Insert order, used for Sorting
            var ListOrder = 0;

            // Add the Characters
            foreach (var data in EngineSettings.CharacterList)
            {
                if (data.Alive)
                {
                    EngineSettings.PlayerList.Add(
                        new PlayerInfoModel(data)
                        {
                            // Remember the order
                            ListOrder = ListOrder
                        });

                    ListOrder++;
                }
            }

            // Add the Monsters
            foreach (var data in EngineSettings.MonsterList)
            {
                if (data.Alive)
                {
                    EngineSettings.PlayerList.Add(
                        new PlayerInfoModel(data)
                        {
                            // Remember the order
                            ListOrder = ListOrder
                        });

                    ListOrder++;
                }
            }

            return EngineSettings.PlayerList;
        }

        /// <summary>
        /// Get the Information about the Player
        /// </summary>
        public override PlayerInfoModel GetNextPlayerInList()
        {
            // Walk the list from top to bottom
            // If Player is found, then see if next player exist, if so return that.
            // If not, return first player (looped)

            // If List is empty, return null
            if (EngineSettings.PlayerList.Count == 0)
            {
                return null;
            }

            // No current player, so set the first one
            if (EngineSettings.CurrentAttacker == null)
            {
                return EngineSettings.PlayerList.FirstOrDefault();
            }

            // Find current player in the list
            var index = EngineSettings.PlayerList.FindIndex(m => m.Guid.Equals(EngineSettings.CurrentAttacker.Guid));

            // If at the end of the list, return the first element
            if (index == EngineSettings.PlayerList.Count() - 1)
            {
                return EngineSettings.PlayerList.FirstOrDefault();
            }

            // Return the next element
            return EngineSettings.PlayerList[index + 1];
        }

        /// <summary>
        /// Pickup Items Dropped
        /// </summary>
        public override bool PickupItemsFromPool(PlayerInfoModel character)
        {

            // TODO: Teams, You need to implement your own Logic if not using auto apply

            // I use the same logic for Auto Battle as I do for Manual Battle

            _ = GetItemFromPoolIfBetter(character, ItemLocationEnum.Head);
            _ = GetItemFromPoolIfBetter(character, ItemLocationEnum.Necklass);
            _ = GetItemFromPoolIfBetter(character, ItemLocationEnum.PrimaryHand);
            _ = GetItemFromPoolIfBetter(character, ItemLocationEnum.OffHand);
            _ = GetItemFromPoolIfBetter(character, ItemLocationEnum.RightFinger);
            _ = GetItemFromPoolIfBetter(character, ItemLocationEnum.LeftFinger);
            _ = GetItemFromPoolIfBetter(character, ItemLocationEnum.Feet);

            return true;
        }

        /// <summary>
        /// The GetItemFromPoolIfBetter method swaps out the item if it is better
        /// 
        /// This method uses Attribute, Damage then Value to determine if an item is better
        /// </summary>
        public override bool GetItemFromPoolIfBetter(PlayerInfoModel character, ItemLocationEnum setLocation)
        {
            var thisLocation = setLocation;
            if (setLocation == ItemLocationEnum.RightFinger)
            {
                thisLocation = ItemLocationEnum.Finger;
            }

            if (setLocation == ItemLocationEnum.LeftFinger)
            {
                thisLocation = ItemLocationEnum.Finger;
            }

            // Sort by Location
            // Then by Attribute
            // Then by Damage
            // Then by Value
            var myList = EngineSettings.ItemPool.Where(a => a.Location == thisLocation)
                .OrderByDescending(a => a.Attribute)
                .ThenBy(a => a.Damage)
                .ThenBy(a => a.Value)
                .ToList();

            // Check if no items in the list
            if (!myList.Any())
            {
                return false;
            }

            var CharacterItem = character.GetItemByLocation(setLocation);
            if (CharacterItem == null)
            {
                _ = SwapCharacterItem(character, setLocation, myList.FirstOrDefault());
                return true;
            }

            foreach (var PoolItem in myList)
            {
                if (PoolItem.Value > CharacterItem.Value)
                {
                    _ = SwapCharacterItem(character, setLocation, PoolItem);
                    return true;
                }
            }

            return true;
        }

        /// <summary>
        /// The SwapCharacterItem swaps the Item the Character has for one from the pool
        /// 
        /// It drops the current item back into the Pool
        /// </summary>
        public override ItemModel SwapCharacterItem(PlayerInfoModel character, ItemLocationEnum setLocation, ItemModel PoolItem)
        {
            // Put on the new ItemModel, which drops the one back to the pool
            var droppedItem = character.AddItem(setLocation, PoolItem.Id);

            // Add the PoolItem to the list of selected items
            EngineSettings.BattleScore.ItemModelSelectList.Add(PoolItem);

            // Remove the ItemModel just put on from the pool
            _ = EngineSettings.ItemPool.Remove(PoolItem);

            if (droppedItem != null)
            {
                // Add the dropped ItemModel to the pool
                EngineSettings.ItemPool.Add(droppedItem);
            }

            return droppedItem;
        }

        /// <summary>
        /// The RemoveCharacterBuffs removes buffs for all characters in player list
        /// </summary>
        public override bool RemoveCharacterBuffs()
        {
            foreach (var data in EngineSettings.PlayerList)
            {
                _ = data.ClearBuffs();
            }

            foreach (var data in EngineSettings.PlayerList)
            {
                _ = data.ClearBuffs();
            }

            return true;
        }
    }
}