using System;
using System.Collections.Generic;
using System.Linq;

using Game.Helpers;
using Game.Models;
using Game.ViewModels;


namespace Game.GameRules
{
    public static class RandomPlayerHelper
    {
        public static List<string> CharacterImageList = new List<string> { "agent_amelix.png", "agent_baby.png", "agent_dog.png", "agent_prof_tompkins.png", "agent_robot.png", "agent_smith.png" };
        public static List<string> MonsterImageList = new List<string> { "Cancer_Monster.png", "Musca_Monster.png", "Lacerta_Monster.png", "Pisces_Monster.png", "Scorpio_Monster.png", "Serpens_Monster.png" };

        /// <summary>
        /// Get Health
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static int GetHealth(int level)
        {
            // Roll the Dice and reset the Health
            return DiceHelper.RollDice(level, 10);
        }

        /// <summary>
        /// Get A Random Difficulty
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterUniqueItem()
        {
            var result = ItemIndexViewModel.Instance.Dataset.ElementAt(DiceHelper.RollDice(1, ItemIndexViewModel.Instance.Dataset.Count()) - 1).Id;

            return result;
        }

        /// <summary>
        /// Get A Random Difficulty
        /// </summary>
        /// <returns></returns>
        public static DifficultyEnum GetMonsterDifficultyValue()
        {
            var DifficultyList = DifficultyEnumHelper.GetListMonster;

            var RandomDifficulty = DifficultyList.ElementAt(DiceHelper.RollDice(1, DifficultyList.Count()) - 1);

            var result = DifficultyEnumHelper.ConvertStringToEnum(RandomDifficulty);

            return result;
        }

        /// <summary>
        /// Get A Random Difficulty
        /// </summary>
        /// <returns></returns>
        public static MonsterJobEnum GetMonsterJobValue()
        {
            var MonsterJobList = MonsterJobEnumHelper.GetListMonster;

            var RandomJob = MonsterJobList.ElementAt(DiceHelper.RollDice(1, MonsterJobList.Count()) - 1);

            var result = MonsterJobEnumHelper.ConvertStringToEnum(RandomJob);

            return result;
        }

        /// <summary>
        /// Get Random Image
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterImage()
        {
            var result = MonsterImageList.ElementAt(DiceHelper.RollDice(1, MonsterImageList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Get Random Image
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterImage()
        {
            var result = CharacterImageList.ElementAt(DiceHelper.RollDice(1, CharacterImageList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Get Name
        /// 
        /// Return a Random Name
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterName()
        {

            List<string> FirstNameList = new List<string> { "Cancer", "Musca", "Lacerta", "Pisces", "Scorpio", "Serpens" };

            var result = FirstNameList.ElementAt(DiceHelper.RollDice(1, FirstNameList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Get Description
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetMonsterDescription()
        {
            List<string> StringList = new List<string> { "the destroyer", "the terrible", "the hunter", "the killer", "Can't we all get along?" };

            var result = StringList.ElementAt(DiceHelper.RollDice(1, StringList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Get Name
        /// 
        /// Return a Random Name
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterName()
        {

            List<string> FirstNameList = new List<string> { "Agent Kay", "Agent Jay", "Agent Mercury", "Agent Lady Bug", "Agent Buck"};

            var result = FirstNameList.ElementAt(DiceHelper.RollDice(1, FirstNameList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Get Description
        /// 
        /// Return a random description
        /// </summary>
        /// <returns></returns>
        public static string GetCharacterDescription()
        {
            List<string> StringList = new List<string> { "the courageous", "the awesome", "the younger", "the quiet", "the clever" };

            var result = StringList.ElementAt(DiceHelper.RollDice(1, StringList.Count()) - 1);

            return result;
        }

        /// <summary>
        /// Get Random Ability Number
        /// </summary>
        /// <returns></returns>
        public static int GetAbilityValue()
        {
            // 0 to 9, not 1-10
            return DiceHelper.RollDice(1, 10) - 1;
        }

        /// <summary>
        /// Get a Random Level
        /// </summary>
        /// <returns></returns>
        public static int GetLevel()
        {
            // 1-20
            return DiceHelper.RollDice(1, 20);
        }

        /// <summary>
        /// Get a Random Item for the Location
        /// 
        /// Return the String for the ID
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static string GetItem(ItemLocationEnum location)
        {
            var ItemList = ItemIndexViewModel.Instance.GetLocationItems(location);
            if (ItemList.Count == 0)
            {
                return null;
            }

            // Add None to the list
            ItemList.Add(new ItemModel { Id = null, Name = "None" });

            var result = ItemList.ElementAt(DiceHelper.RollDice(1, ItemList.Count()) - 1).Id;
            return result;
        }

        /// <summary>
        /// Create Random Character for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static CharacterModel GetRandomCharacter(int MaxLevel)
        {
            // If there are no characters in the system, return a default one
            if (CharacterIndexViewModel.Instance.Dataset.Count == 0)
            {
                return new CharacterModel();
            }

            var rnd = DiceHelper.RollDice(1, CharacterIndexViewModel.Instance.Dataset.Count);

            var result = new CharacterModel(CharacterIndexViewModel.Instance.Dataset.ElementAt(rnd - 1))
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetCharacterName(),
                Description = GetCharacterDescription(),

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                // Randomize an Item for Location
                Head = GetItem(ItemLocationEnum.Head),
                Necklass = GetItem(ItemLocationEnum.Necklass),
                PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand),
                OffHand = GetItem(ItemLocationEnum.OffHand),
                RightFinger = GetItem(ItemLocationEnum.Finger),
                LeftFinger = GetItem(ItemLocationEnum.Finger),
                Feet = GetItem(ItemLocationEnum.Feet),

                ImageURI = GetCharacterImage()
            };

            result.MaxHealth = DiceHelper.RollDice(MaxLevel, 10);

            // Level up to the new level
            _ = result.LevelUpToValue(result.Level);

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            return result;
        }

        /// <summary>
        /// Create Random Character for the battle
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static MonsterModel GetRandomMonster(int MaxLevel, bool Items = false)
        {
            // If there are no Monsters in the system, return a default one
            if (MonsterIndexViewModel.Instance.Dataset.Count == 0)
            {
                return new MonsterModel();
            }

            var rnd = DiceHelper.RollDice(1, MonsterIndexViewModel.Instance.Dataset.Count);

            var result = new MonsterModel(MonsterIndexViewModel.Instance.Dataset.ElementAt(rnd - 1))
            {
                Level = DiceHelper.RollDice(1, MaxLevel),

                // Randomize Name
                Name = GetMonsterName(),
                Description = GetMonsterDescription(),

                // Randomize the Attributes
                Attack = GetAbilityValue(),
                Speed = GetAbilityValue(),
                Defense = GetAbilityValue(),

                ImageURI = GetMonsterImage(),

                Difficulty = GetMonsterDifficultyValue()
                //MonsterJob = GetMonsterJobValue()
            };

            // Adjust values based on Difficulty
            result.Attack = result.Difficulty.ToModifier(result.Attack);
            result.Defense = result.Difficulty.ToModifier(result.Defense);
            result.Speed = result.Difficulty.ToModifier(result.Speed);
            result.Level = result.Difficulty.ToModifier(result.Level);

            // Get the new Max Health
            result.MaxHealth = DiceHelper.RollDice(result.Level, 10);

            // Adjust the health, If the new Max Health is above the rule for the level, use the original
            var MaxHealthAdjusted = result.Difficulty.ToModifier(result.MaxHealth);
            if (MaxHealthAdjusted < result.Level * 10)
            {
                result.MaxHealth = MaxHealthAdjusted;
            }

            // Level up to the new level
            _ = result.LevelUpToValue(result.Level);

            // Set ExperienceRemaining so Monsters can both use this method
            result.ExperienceRemaining = LevelTableHelper.LevelDetailsList[result.Level + 1].Experience;

            // Enter Battle at full health
            result.CurrentHealth = result.MaxHealth;

            // Monsters can have weapons too....
            if (Items)
            {
                result.Head = GetItem(ItemLocationEnum.Head);
                result.Necklass = GetItem(ItemLocationEnum.Necklass);
                result.PrimaryHand = GetItem(ItemLocationEnum.PrimaryHand);
                result.OffHand = GetItem(ItemLocationEnum.OffHand);
                result.RightFinger = GetItem(ItemLocationEnum.Finger);
                result.LeftFinger = GetItem(ItemLocationEnum.Finger);
                result.Feet = GetItem(ItemLocationEnum.Feet);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MaxLevel"></param>
        /// <returns></returns>
        public static MonsterModel GetMonsterFromDatastore(int MaxLevel)
        {
            // Count of all Monsters in the Dataset
            var MonsterCount = MonsterIndexViewModel.Instance.Dataset.Count();

            // Random number to pick Monster
            var MonsterNum = DiceHelper.RollDice(1, MonsterCount) - 1;

            //var data = RandomPlayerHelper.GetRandomMonster(TargetLevel, EngineSettings.BattleSettingsModel.AllowMonsterItems);
            var result = new MonsterModel(MonsterIndexViewModel.Instance.Dataset[MonsterNum]);

            // Flip a Coin
            var Coin = DiceHelper.RollDice(1, 2);

            // Roll a d4 to get a Bonus
            var Bonus = DiceHelper.RollDice(1, 4);

            // Set Level based on Max Level of Characters
            result.Level = DiceHelper.RollDice(1, MaxLevel);

            // Set Difficulty
            result.Difficulty = GetMonsterDifficultyValue();

            // Adjust values based on Difficulty
            result.Attack = result.Difficulty.ToModifier(result.Attack);
            result.Defense = result.Difficulty.ToModifier(result.Defense);
            result.Speed = result.Difficulty.ToModifier(result.Speed);

            // Randomly give Bonuses to Monster based on Coin Flip
            if (Coin == 1)
            {
                result.Attack += Bonus;

                if (result.MonsterJob == MonsterJobEnum.Brute)
                {
                    result.MonsterJob = MonsterJobEnum.Swift;
                }
            }

            if (Coin == 2)
            {
                result.Defense += Bonus;

                if (result.MonsterJob == MonsterJobEnum.Swift)
                {
                    result.MonsterJob = MonsterJobEnum.Brute;
                }
            }

            // Set inital MaxHealth
            result.MaxHealth = DiceHelper.RollDice(result.Level, 10);

            // Adjust the health, If the new Max Health is above the rule for the level, use the original
            var MaxHealthAdjusted = result.Difficulty.ToModifier(result.MaxHealth);
            if (MaxHealthAdjusted < result.Level * 10)
            {
                result.MaxHealth = MaxHealthAdjusted;
            }

            // Level up to new level
            _ = result.LevelUpToValue(result.Level);

            // Set ExperienceRemaining so Monsters can both use this method
            result.ExperienceRemaining = LevelTableHelper.LevelDetailsList[result.Level + 1].Experience;

            // Start Battle at Full Health
            result.CurrentHealth = result.MaxHealth;

            return result;
        }
    }
}