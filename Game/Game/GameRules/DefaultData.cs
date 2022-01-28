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
                    Name = "Stun Gun",
                    Description = "A handheld weapon that stuns a target",
                    ImageURI = "sword1.png",
                    Range = 1,
                    Damage = 1,
                    Value = 1,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Pistol",
                    Description = "A handheld gun, standard issue",
                    ImageURI = "sword2.png",
                    Range = 9,
                    Damage = 2,
                    Value = 2,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Crystal Sword",
                    Description = "A one-handed sword made of crystals from space",
                    ImageURI = "sword3.png",
                    Range = 1,
                    Damage = 2,
                    Value = 3,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Laser Gun",
                    Description = "A space-age rifle that shoots lasers",
                    ImageURI = "sword4.png",
                    Range = 9,
                    Damage = 3,
                    Value = 5,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Laser Sword",
                    Description = "A one-handed sword made of light using technology",
                    ImageURI = "sword5.png",
                    Range = 1,
                    Damage = 3,
                    Value = 4,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Shotgun",
                    Description = "A standard Earth shotgun",
                    ImageURI = "sword6.png",
                    Range = 3,
                    Damage = 7,
                    Value = 3,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Nosiy Cricket",
                    Description = "A tiny weapon of extraterrestrial design",
                    ImageURI = "sword7.png",
                    Range = 4,
                    Damage = 9,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Carbonizer",
                    Description = "A device that slows down a Monster",
                    ImageURI = "sword8.png",
                    Range = 1,
                    Damage = 2,
                    Value = 0,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Defense Shield",
                    Description = "A device that protects the user from harm",
                    ImageURI = "shield2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Sunglasses",
                    Description = "A pair of shades that protect the wearer from getting things in their eye",
                    ImageURI = "hat1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Moon Boots",
                    Description = "Bouncy boots that boost the speed of the wearer",
                    ImageURI = "feet2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Fedora",
                    Description = "A standard issue hat for the men in black",
                    ImageURI = "shield1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Power Ring",
                    Description = "A ring of alien design that provides the wearer unbelievable power",
                    ImageURI = "ring2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 10,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Health Shield",
                    Description = "Enough to hide behind",
                    ImageURI = "shield3.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.MaxHealth},

                new ItemModel {
                    Name = "Lucky Shield",
                    Description = "Do you feel lucky punk?",
                    ImageURI = "shield4.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Bunny Hat",
                    Description = "Pink hat with fluffy ears",
                    ImageURI = "hat1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Horned Hat",
                    Description = "Where's the Rabbit?",
                    ImageURI = "hat2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Fast Necklass",
                    Description = "And Tasty",
                    ImageURI = "neck1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Feel the Power",
                    Description = "Love this one",
                    ImageURI = "neck2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Horned Hat",
                    Description = "Where's the Rabbit?",
                    ImageURI = "hat2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Ring of Power",
                    Description = "The wearer has all the power",
                    ImageURI = "ring1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Strong Ring",
                    Description = "Watch out",
                    ImageURI = "ring2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Warm Shoes",
                    Description = "Strong Shoes",
                    ImageURI = "feet1.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Cute Shoes",
                    Description = "really fast",
                    ImageURI = "feet2.png",
                    Range = 0,
                    Damage = 0,
                    Value = 9,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed},
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
                    Name = "Mike",
                    Description = "Archer Wannabe",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "elf1.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Tim",
                    Description = "Hawk eye",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "elf2.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Doug",
                    Description = "Warrior in training",
                    Level = 1,
                    MaxHealth = 8,
                    ImageURI = "elf4.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Sue",
                    Description = "A strong Warrior",
                    Level = 4,
                    MaxHealth = 38,
                    ImageURI = "elf3.png"
                },

                new CharacterModel {
                    Name = "Jea",
                    Description = "Come and get me",
                    Level = 5,
                    MaxHealth = 43,
                    ImageURI = "elf5.png"
                },

                new CharacterModel {
                    Name = "Darren",
                    Description = "The Wiz",
                    Level = 5,
                    MaxHealth = 43,
                    ImageURI = "elf6.png"
                },

                new CharacterModel {
                    Name = "Dani",
                    Description = "A powerfull Cleric",
                    Level = 5,
                    MaxHealth = 43,
                    ImageURI = "elf7.png"
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
                    Name = "Green Troll",
                    Description = "Big and Ugly",
                    ImageURI = "troll1.png",
                },

                new MonsterModel {
                    Name = "Old Troll",
                    Description = "Old and Powerfull",
                    ImageURI = "troll2.png",
                },

                new MonsterModel {
                    Name = "Dainty Troll",
                    Description = "and fast",
                    ImageURI = "troll3.png",
                },

                new MonsterModel {
                    Name = "Troll's Troll",
                    Description = "wozer",
                    ImageURI = "troll4.png",
                },

                new MonsterModel {
                    Name = "Warrior Troll",
                    Description = "with sword",
                    ImageURI = "troll5.png",
                },

                new MonsterModel {
                    Name = "Ax Troll",
                    Description = "with Hat and Ax",
                    ImageURI = "troll6.png",
                },
            };

            return datalist;
        }
    }
}