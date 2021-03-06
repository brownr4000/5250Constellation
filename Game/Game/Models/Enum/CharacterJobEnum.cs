using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Jobs a character can have
    /// Used in Character Crudi, and in Battles.
    /// </summary>
    public enum CharacterJobEnum
    {
        // Not specified
        Unknown = 0,

        // Fighters hit hard and have fight abilities
        Fighter = 10,

        // Clerics defend well and have buff abilities
        Cleric = 12,

        // Defender Class has high defense abilities, aka Tank
        Defender = 20,

        // Striker Class has high attack and speed abilities, aka Damage
        Striker = 30,

        // Support Class can heal and have buff abilities
        Support = 40
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class CharacterJobEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this CharacterJobEnum value)
        {
            // Default String
            var Message = "Player";

            switch (value)
            {
                case CharacterJobEnum.Fighter:
                    Message = "Fighter";
                    break;

                case CharacterJobEnum.Cleric:
                    Message = "Cleric";
                    break;

                case CharacterJobEnum.Defender:
                    Message = "Defender";
                    break;

                case CharacterJobEnum.Striker:
                    Message = "Striker";
                    break;

                case CharacterJobEnum.Support:
                    Message = "Support";
                    break;

                case CharacterJobEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for Charcter Jobs
    /// </summary>
    public static class CharacterJobEnumHelper
    {
        /// <summary>
        /// Gets the list of locations that an Item can have.
        /// Does not include the Left and Right Finger 
        /// </summary>
        public static List<string> GetJobList
        {
            get
            {
                var myList = Enum.GetNames(typeof(CharacterJobEnum)).ToList();
                var result = myList.Where(a => a.ToString() != CharacterJobEnum.Unknown.ToString())
                                           .OrderBy(a => a)
                                           .ToList();
                return result;
            }
        }
    }
}