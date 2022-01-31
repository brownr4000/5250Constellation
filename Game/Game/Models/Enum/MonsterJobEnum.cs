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

        // Fighters hit hard and have fight abilities
        Fighter = 11,

        // Clerics defend well and have buff abilities
        Cleric = 15,

        // Clerics support well and have healing abilities
        Support = 25
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
                    Message = "Tank";
                    break;

                case MonsterJobEnum.Cleric:
                    Message = "Damage";
                    break;

                case MonsterJobEnum.Support:
                    Message = "Support";
                    break;

                case MonsterJobEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }
}