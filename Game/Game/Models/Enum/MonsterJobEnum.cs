using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Jobs a monsters can have
    /// Used in Monster Crudi, and in Battles.
    /// </summary>
    public enum MonsterJobEnum
    {
        // Not specified
        Unknown = 0,

        // Brute Monsters hit hard and are tough to beat
        Brute = 10,
                
        // Swift Monsters attack quickly
        Swift = 20,

        // Clever Monsters have access to buffs
        Clever = 30
    }
  
    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class MonsterJobEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this MonsterJobEnum value)
        {
            // Default String
            var Message = "Player";

            switch (value)
            {
                case MonsterJobEnum.Brute:
                    Message = "Brute";
                    break;

                case MonsterJobEnum.Swift:
                    Message = "Swift";
                    break;

                case MonsterJobEnum.Clever:
                    Message = "Clever";
                    break;

                case MonsterJobEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }

    }

    /// <summary>
    /// Helper for the Monster Job
    /// </summary>
    public static class MonsterJobEnumHelper
    {

        /// <summary>
        /// Returns a list of strings of the enum for MonsterJob
        /// Removes the unknown
        /// </summary>
        public static List<string> GetListMonster
        {
            get
            {
                var myList = Enum.GetNames(typeof(MonsterJobEnum)).ToList();
                var result = myList.Where(a => a.ToString() != MonsterJobEnum.Unknown.ToString())
                                           .OrderBy(a => a)
                                           .ToList();
                return myList;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value. 
        /// That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MonsterJobEnum ConvertStringToEnum(string value)
        {
            return (MonsterJobEnum)Enum.Parse(typeof(MonsterJobEnum), value);
        }
    }
}