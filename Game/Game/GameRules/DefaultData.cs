using System.Collections.Generic;

using Game.Models;
using Game.ViewModels;

namespace Game.GameRules
{
    /// <summary>
    /// The DefaultData class defines the structre and attributes of the Default data in the Game
    /// </summary>
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel  {
                   Name = "Forged Boots",
                   Description = "Heavily armored boots",
                   Damage = 0,
                   Range = 0,
                   Location = ItemLocationEnum.Feet,
                   Attribute = AttributeEnum.Defense,
                   Value = 5,
                   ImageURI = "",},

                new ItemModel {
                    Name = "Moon Boots",
                    Description = "Bouncy boots that boost movement and agility",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed,
                    Value = 1,
                    ImageURI = "moon_boots.png",},

                new ItemModel {
                    Name = "Rocket Boots",
                    Description = "Technological boots that greatly improve speed",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed,
                    Value = 5,
                    ImageURI = "rocket_boots.png",},

                new ItemModel {
                    Name = "Power Ring",
                    Description = "A ring of alien design that provides the wearer unbelievable power",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack,
                    Value = 9,
                    ImageURI = "power_ring.png",},

                new ItemModel {
                    Name = "Battleglove",
                    Description = "Tactical gloves that provide protection to the knuckles",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Defense,
                    Value = 2,
                    ImageURI = "",},

                new ItemModel {
                    Name = "Cybernetic Arm",
                    Description = "A technological augmentation",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Defense,
                    Value = 8,
                    ImageURI = "",},

                new ItemModel {
                    Name = "Techno Kabuto",
                    Description = "A kabuto style helmet with a head-mounted display",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack,
                    Value = 5,
                    ImageURI = "",},

                new ItemModel {
                    Name = "Sunglasses",
                    Description = "A pair of shades that protect the wearer from getting things in their eye",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense,
                    Value = 1,
                    ImageURI = "sunglasses.png",},

                new ItemModel {
                    Name = "Fedora",
                    Description = "A standard issue hat for the men in black",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense,
                    Value = 3,
                    ImageURI = "fedora.png",},

                new ItemModel {
                    Name = "Ushanka",
                    Description = "A hat with earflaps",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense,
                    Value = 5,
                    ImageURI = "",},

                new ItemModel {
                    Name = "Amulet of Vigor",
                    Description = "An advanced amulet that boosts offensive capability",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Attack,
                    Value = 5,
                    ImageURI = "",},

                new ItemModel {
                    Name = "Amulet of Protection",
                    Description = "An advanced amulet that provides additional protection",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Defense,
                    Value = 5,
                    ImageURI = "",},

                new ItemModel {
                    Name = "Life Alert",
                    Description = "A pendant that boosts life force",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.MaxHealth,
                    Value = 5,
                    ImageURI = "",},

                new ItemModel {
                    Name = "Carbonizer",
                    Description = "A small device that gives some protection",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense,
                    Value = 1,
                    ImageURI = "",},

                new ItemModel {
                    Name = "Riot Shield",
                    Description = "A polycarbonate shield that protects from close attacks",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense,
                    Value = 3,
                    ImageURI = "shield_01.png",},

                new ItemModel {
                    Name = "Ballistic Shield",
                    Description = "A large shield made of Aramid fibers that protects from ballistic attacks",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense,
                    Value = 5,
                    ImageURI = "",},

                new ItemModel {
                    Name = "Stun Gun",
                    Description = "A handheld weapon that stuns a target",
                    Damage = 1,
                    Range = 1,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    Value = 1,
                    ImageURI = "stun_gun.png",},

                new ItemModel {
                    Name = "Baton",
                    Description = "A cylindrical club for bludgeoning",
                    Damage = 2,
                    Range = 1,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Speed,
                    Value = 1,
                    ImageURI = "",},

                new ItemModel {
                   Name = "Semi-auto Pistol",
                   Description = "A handheld gun, standard issue",
                   Damage = 4,
                   Range = 9,
                   Location = ItemLocationEnum.PrimaryHand,
                   Attribute = AttributeEnum.Attack,
                   Value = 2,
                   ImageURI = "pistol_01.png",},

                new ItemModel {
                    Name = "Crystal Sword",
                    Description = "A one-handed sword made of ultra-hard crystalline structures from space",
                    Damage = 6,
                    Range = 1,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    Value = 3,
                    ImageURI = "crystal_sword.png",},

                new ItemModel {
                    Name = "Laser Sword",
                    Description = "A one-handed sword made of light using technology",
                    Damage = 7,
                    Range = 2,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    Value = 4,
                    ImageURI = "laser_sword.png",},

                new ItemModel {
                    Name = "Parallax Laser Rifle",
                    Description = "A snub rifle that shoots a focused beam of light",
                    Damage = 8,
                    Range = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    Value = 5,
                    ImageURI = "laser_rifle.png",},

                new ItemModel {
                    Name = "Noisy Cricket",
                    Description = "A tiny weapon of extraterrestrial design",
                    Damage = 10,
                    Range = 2,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Speed,
                    Value = 5,
                    ImageURI = "noisy_cricket.png",},

                new ItemModel {
                    Name = "Tactical Shotgun",
                    Description = "A standard Earth shotgun",
                    Damage = 12,
                    Range = 2,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense,
                    Value = 3,
                    ImageURI = "shotgun.png",},

                new ItemModel {
                    Name = "Proton Cannon",
                    Description = "A two-handed portable cannon that launches proton-based projectiles",
                    Damage = 30,
                    Range = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    Value = 9,
                    ImageURI = "",},
            };

            return datalist;
        }

        /// <summary>
        /// Load Example Scores
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<ScoreModel> LoadData(ScoreModel temp)
        {
            var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

            return datalist;
        }

        /// <summary>
        /// Load Characters
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<CharacterModel> LoadData(CharacterModel temp)
        {
            var HeadString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Head);
            var NecklassString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Necklass);
            var PrimaryHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.PrimaryHand);
            var OffHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.OffHand);
            var FeetString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Feet);
            var RightFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);
            var LeftFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);

            var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "Agent-01",
                    Description = "Cybernetically enhanced with Alien technology",
                    Level = 1,
                    MaxHealth = 10,
                    Attack = 2,
                    Defense = 6,
                    Speed = 1,
                    ImageURI = "agent7.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                    Job = CharacterJobEnum.Defender
                },

                new CharacterModel {
                    Name = "Agent Smith",
                    Description = "A man in black",
                    Level = 1,
                    MaxHealth = 10,
                    Attack = 3,
                    Defense = 5,
                    Speed = 1,
                    ImageURI = "agent1.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                    Job = CharacterJobEnum.Defender
                },

                new CharacterModel {
                    Name = "Slim Jim",
                    Description = "He protecc, he attacc, he have bazooka on his bacc",
                    Level = 1,
                    MaxHealth = 8,
                    Attack = 3,
                    Defense = 2,
                    Speed = 4,
                    ImageURI = "agent2.png",
                    Head = HeadString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    Job = CharacterJobEnum.Striker
                },

                new CharacterModel {
                    Name = "Prof. Tompkins",
                    Description = "The Mirror Universe Mark Twain",
                    Level = 1,
                    MaxHealth = 7,
                    Attack = 1,
                    Defense = 3,
                    Speed = 2,
                    ImageURI = "agent3.png",
                    Job = CharacterJobEnum.Support
                },

                new CharacterModel {
                    Name = "Agent Braxton",
                    Description = "An actual baby",
                    Level = 1,
                    MaxHealth = 8,
                    Attack = 2,
                    Defense = 2,
                    Speed = 3,
                    ImageURI = "agent4.png",
                    Job = CharacterJobEnum.Striker
                },

                new CharacterModel {
                    Name = "Agent Amelix",
                    Description = "A deadly assasin from the near future",
                    Level = 1,
                    MaxHealth = 8,
                    Attack = 3,
                    Defense = 1,
                    Speed = 5,
                    ImageURI = "agent5.png",
                    Job = CharacterJobEnum.Striker
                },

                new CharacterModel {
                    Name = "Larry",
                    Description = "From the Accounting department",
                    Level = 1,
                    MaxHealth = 6,
                    Attack = 1,
                    Defense = 3,
                    Speed = 2,
                    ImageURI = "agent6.png",
                    Job = CharacterJobEnum.Support
                }
            };

            return datalist;
        }

        /// <summary>
        /// Load Characters
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static List<MonsterModel> LoadData(MonsterModel temp)
        {
            var datalist = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Serpens",
                    Description = "A constellation of a large snake",
                    ImageURI = "Serpens_Monster.png",
                    Difficulty = DifficultyEnum.Average,
                    Attack = 3,
                    Defense = 3,
                    Speed = 5,
                },

                new MonsterModel {
                    Name = "Cancer",
                    Description = "A medium size constellation of a crab",
                    ImageURI = "Cancer_Monster.png",
                    Difficulty = DifficultyEnum.Average,
                    Attack = 2,
                    Defense = 8,
                    Speed = 2,
                },

                new MonsterModel {
                    Name = "Pisces",
                    Description = "A constellation of two fish",
                    ImageURI = "Pisces_Monster.png",
                    Difficulty = DifficultyEnum.Average,
                    Attack = 4,
                    Defense = 2,
                    Speed = 5,
                },

                new MonsterModel {
                    Name = "Scorpio",
                    Description = "A constellation of a giant scorpion",
                    ImageURI = "Scorpio_Monster.png",
                    Attack = 6,
                    Defense = 7,
                    Speed = 4,
                    Difficulty = DifficultyEnum.Average
                },

                new MonsterModel {
                    Name = "Lepus",
                    Description = "A hare constellation being chased around the sky, or possibly the Moon Rabbit",
                    ImageURI = "Placeholder_Monster1.png",
                    Difficulty = DifficultyEnum.Easy,
                    Attack = 2,
                    Speed = 8,
                    Defense = 2
                },

                new MonsterModel {
                    Name = "Corvus",
                    Description = "A small crow or a raven constellation from the Southern sky",
                    ImageURI = "Placeholder_Monster2.png",
                    Attack = 3,
                    Speed = 3,
                    Defense = 2,
                    Difficulty = DifficultyEnum.Easy,
                },
            };

            return datalist;
        }
    }
}