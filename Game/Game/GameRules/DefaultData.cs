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
                new ItemModel {
                    Name = "Moon Boots",
                    Description = "Bouncy boots that boost movement and agility",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed,
                    Value = 1,
                    ImageURI = "moonboots.png",},

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
                    ImageURI = "ring.png",},

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
                    ImageURI = "ushanka.png",},

                new ItemModel {
                    Name = "Amulet of Vigor",
                    Description = "An advanced amulet that boosts offensive capability",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Attack,
                    Value = 5,
                    ImageURI = "amulet_of_vigor.png",},

                new ItemModel {
                    Name = "Amulet of Protection",
                    Description = "An advanced amulet that provides additional protection",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Defense,
                    Value = 5,
                    ImageURI = "amulet_of_vigor.png",},

                new ItemModel {
                    Name = "Carbonizer",
                    Description = "A small device that gives some protection",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense,
                    Value = 1,
                    ImageURI = "carbonizer.png",},

                new ItemModel {
                    Name = "Riot Shield",
                    Description = "A polycarbonate shield that protects from close attacks",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense,
                    Value = 3,
                    ImageURI = "defense_shield.png",},

                new ItemModel {
                    Name = "Ballistic Shield",
                    Description = "A large shield made of Aramid fibers that protects from ballistic attacks",
                    Damage = 0,
                    Range = 0,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense,
                    Value = 5,
                    ImageURI = "defense_shield.png",},

                new ItemModel {
                    Name = "Stun Gun",
                    Description = "A handheld weapon that stuns a target",
                    Damage = 1,
                    Range = 1,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    Value = 1,
                    ImageURI = "stungun_icon.png",},

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
                    ImageURI = "pistol_icon.png",},

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
                    ImageURI = "noisey_cricket.png",},

                new ItemModel {
                    Name = "Tactical Shotgun",
                    Description = "A standard Earth shotgun",
                    Damage = 12,
                    Range = 2,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense,
                    Value = 3,
                    ImageURI = "shot_gun.png",},

                new ItemModel {
                    Name = "Proton Cannon",
                    Description = "A two-handed portable cannon that launches proton-based projectiles",
                    Damage = 30,
                    Range = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    Value = 9,
                    ImageURI = "laser_rifle.png",},
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
                    Range = 4,
                    ImageURI = "agent_robot.png",
                    ImageGIFURI = "agent_robot_gif.gif",
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
                    Range = 7,
                    ImageURI = "agent_smith.png",
                    ImageGIFURI = "agent_smith_gif.gif",
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
                    Name = "Agent Twins",
                    Description = "Twins in black",
                    Level = 1,
                    MaxHealth = 10,
                    Attack = 3,
                    Defense = 5,
                    Speed = 1,
                    Range = 2,
                    ImageURI = "agent_twins.png",
                    ImageGIFURI = "agent_twins_gif.gif",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                    Job = CharacterJobEnum.Fighter
                },

                new CharacterModel {
                    Name = "Slim Jim",
                    Description = "He protecc, he attacc, he have bazooka on his bacc",
                    Level = 1,
                    MaxHealth = 8,
                    Attack = 3,
                    Defense = 2,
                    Speed = 4,
                    Range = 5,
                    ImageURI = "agent_dog.png",
                    ImageGIFURI = "agent_dog_gif.gif",
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
                    Range = 3,
                    ImageURI = "agent_prof_tompkins.png",
                    ImageGIFURI = "agent_prof_tompkins_gif.gif",
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
                    Range = 7,
                    ImageURI = "agent_baby.png",
                    ImageGIFURI = "agent_baby_gif.gif",
                    Job = CharacterJobEnum.Fighter
                },

                new CharacterModel {
                    Name = "Agent Amelix",
                    Description = "A deadly assasin from the near future",
                    Level = 1,
                    MaxHealth = 8,
                    Attack = 3,
                    Defense = 1,
                    Speed = 5,
                    Range = 2,
                    ImageURI = "agent_amelix.png",
                    ImageGIFURI = "agent_amelix_gif.gif",
                    Job = CharacterJobEnum.Striker
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
                    Difficulty = DifficultyEnum.Difficult,
                    ImageGIFURI = "serpens_monster_gif.gif",
                    MonsterJob = MonsterJobEnum.Swift,
                    Attack = 3,
                    Defense = 3,
                    Speed = 5,
                },

                new MonsterModel {
                    Name = "Cancer",
                    Description = "A medium size constellation of a crab",
                    ImageURI = "Cancer_Monster.png",
                     MonsterJob = MonsterJobEnum.Brute,
                    Difficulty = DifficultyEnum.Average,
                    ImageGIFURI = "cancer_monster_gif.gif",
                    Attack = 2,
                    Defense = 8,
                    Speed = 2,
                },

                new MonsterModel {
                    Name = "Pisces",
                    Description = "A constellation of two fish",
                    ImageURI = "Pisces_Monster.png",
                    MonsterJob = MonsterJobEnum.Brute,
                    Difficulty = DifficultyEnum.Hard,
                    ImageGIFURI = "pisces_monster_gif.gif",
                    Attack = 4,
                    Defense = 2,
                    Speed = 5,
                },

                new MonsterModel {
                    Name = "Scorpio",
                    Description = "A constellation of a giant scorpion",
                    ImageURI = "Scorpio_Monster.png",
                    Attack = 6,
                     MonsterJob = MonsterJobEnum.Swift,
                    ImageGIFURI = "scorpio_monster_gif.gif",
                    Defense = 7,
                    Speed = 4,
                    Difficulty = DifficultyEnum.Average
                },

                new MonsterModel {
                    Name = "Musca",
                    Description = "A hare constellation being chased around the sky, or possibly the Moon Rabbit",
                    ImageURI = "Musca_Monster.png",
                    Difficulty = DifficultyEnum.Impossible,
                    Attack = 2,
                    MonsterJob = MonsterJobEnum.Brute,
                    ImageGIFURI = "musca_monster_gif.gif",
                    Speed = 8,
                    Defense = 2
                },

                new MonsterModel {
                    Name = "Lacerta",
                    Description = "A small crow or a raven constellation from the Southern sky",
                    ImageURI = "Lacerta_Monster.png",
                    Attack = 3,
                    ImageGIFURI = "lacerta_monster_gif.gif",
                    Speed = 3,
                     MonsterJob = MonsterJobEnum.Clever,
                    Defense = 2,
                    Difficulty = DifficultyEnum.Easy,
                },
            };

            return datalist;
        }
    }
}