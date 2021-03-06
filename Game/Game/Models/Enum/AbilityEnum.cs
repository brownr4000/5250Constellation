using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of s a Ability can have
    /// Used in Ability Crudi, and in Battles.
    /// </summary>
    public enum AbilityEnum
    {
        // Not specified
        Unknown = 0,

        // Not specified
        None = 1,

        // General Abilities 10 Range
        // Heal Self
        Bandage = 10,


        // Fighter Abilities > 20 Range
        // Buff Speed
        Nimble = 21,

        // Buff Defense
        Toughness = 22,

        // Buff Attack
        Focus = 23,


        // Cleric Abilities > 50 Range
        // Buff Speed
        Quick = 51,

        // Buff Defense
        Barrier = 52,

        // Block Attacks
        Block = 110,

        // Guard
        Guard = 111,

        // Buff Attack
        Curse = 53,

        // Heal Self
        Heal = 54,

        // Doge attack
        Dodge = 99,

        // Double strike
        DoubleStrike = 25,

        // Heal adjacent character
        HealTeammate = 100,

        // Buff +2 Attack for adjacent character
        BoostAttack = 40,

        // Buff +2 Defense for adjacent character
        BoostDefense = 41,

        // Buff +2 Speed for adjacent character
        BoostSpeed = 42,

        // Skip Turn
        Wait = 200,

    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class AbilityEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this AbilityEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case AbilityEnum.Bandage:
                    Message = "Apply Bandages";
                    break;

                case AbilityEnum.Nimble:
                    Message = "React Quickly";
                    break;

                case AbilityEnum.Toughness:
                    Message = "Toughen Up";
                    break;

                case AbilityEnum.Focus:
                    Message = "Focuses their Energy";
                    break;

                case AbilityEnum.Quick:
                    Message = "Anticipate";
                    break;

                case AbilityEnum.Barrier:
                    Message = "Barrier Defense";
                    break;

                case AbilityEnum.Block:
                    Message = "Block Attacks";
                    break;

                case AbilityEnum.Guard:
                    Message = "Guard Attacks";
                    break;

                case AbilityEnum.Curse:
                    Message = "Shout Curse";
                    break;

                case AbilityEnum.Heal:
                    Message = "Heal Self";
                    break;

                case AbilityEnum.Dodge:
                    Message = "Dodge Attack";
                    break;

                case AbilityEnum.DoubleStrike:
                    Message = "Double Strike";
                    break;

                case AbilityEnum.HealTeammate:
                    Message = "Heal adjacent character";
                    break;

                case AbilityEnum.BoostAttack:
                    Message = "Boost adjacent character attack";
                    break;

                case AbilityEnum.BoostDefense:
                    Message = "Boost adjacent character defense";
                    break;

                case AbilityEnum.BoostSpeed:
                    Message = "Boost adjacent character speed";
                    break;

                case AbilityEnum.Wait:
                    Message = "Waits for the next opportunity";
                    break;

                case AbilityEnum.None:
                case AbilityEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Ability Enum Class
    /// </summary>
    public static class AbilityEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for Ability
        /// Removes the Abilitys that are not changable by Items such as Unknown, MaxHealth
        /// </summary>
        public static List<string> GetFullList
        {
            get
            {
                var myList = Enum.GetNames(typeof(AbilityEnum)).ToList();
                return myList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Fighter
        /// </summary>
        public static List<string> GetListFighter
        {
            get
            {
                List<string> AbilityList = new List<string>{
                AbilityEnum.Nimble.ToString(),
                AbilityEnum.Toughness.ToString(),
                };

                AbilityList.AddRange(GetListOthers);
                return AbilityList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Cleric
        /// </summary>
        public static List<string> GetListCleric
        {
            get
            {

                List<string> AbilityList = new List<string>{
                AbilityEnum.Quick.ToString(),
                AbilityEnum.Barrier.ToString(),
                AbilityEnum.Curse.ToString(),
                AbilityEnum.Heal.ToString()
                };

                AbilityList.AddRange(GetListOthers);
                return AbilityList;
            }
        }


        /// <summary>
        /// Returns a list of strings of the enum for Striker
        /// </summary>
        public static List<string> GetListStriker
        {
            get
            {
                List<string> AbilityList = new List<string>{
                AbilityEnum.Dodge.ToString(),
                AbilityEnum.DoubleStrike.ToString(),
                };

                AbilityList.AddRange(GetListOthers);

                return AbilityList;
            }
        }


        /// <summary>
        /// Returns a list of strings of the enum for Defender
        /// </summary>
        public static List<string> GetListDefender
        {
            get
            {
                List<string> AbilityList = new List<string>{
                AbilityEnum.Guard.ToString(),
                AbilityEnum.Block.ToString(),
                };

                AbilityList.AddRange(GetListOthers);

                return AbilityList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum for Supporter
        /// </summary>
        public static List<string> GetListSupporter
        {
            get
            {
                List<string> AbilityList = new List<string>{
                AbilityEnum.BoostAttack.ToString(),
                AbilityEnum.BoostDefense.ToString(),
                AbilityEnum.BoostSpeed.ToString(),
                AbilityEnum.HealTeammate.ToString(),
                };

                return AbilityList;
            }
        }

        /// <summary>
        /// Returns a list of strings of the enum of not Cleric or Fighter
        /// </summary>
        public static List<string> GetListOthers
        {
            get
            {
                List<string> AbilityList = new List<string>{
                AbilityEnum.Focus.ToString(),
                AbilityEnum.Wait.ToString(),
                };

                return AbilityList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AbilityEnum ConvertStringToEnum(string value)
        {
            return (AbilityEnum)Enum.Parse(typeof(AbilityEnum), value);
        }
    }
}