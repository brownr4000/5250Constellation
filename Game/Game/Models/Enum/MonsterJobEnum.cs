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

        Fighter = 9,

        // Brute Monsters hit hard and are tough to beat
        Brute = 10,

        Cleric = 19,
        
        // Swift Monsters attack quickly
        Swift = 20,


        Support = 29,

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
                case MonsterJobEnum.Fighter:
                    Message = "Brute";
                    break;

                case MonsterJobEnum.Cleric:
                    Message = "Swift";
                    break;

                case MonsterJobEnum.Support:
                    Message = "Clever";
                    break;

                case MonsterJobEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }
}