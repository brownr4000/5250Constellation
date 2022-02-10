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
                    ImageURI = "Item_Placeholder.png",
                    Range = 1,
                    Damage = 1,
                    Value = 1,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Pistol",
                    Description = "A handheld gun, standard issue",
                    ImageURI = "Item_Placeholder.png",
                    Range = 9,
                    Damage = 2,
                    Value = 2,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Crystal Sword",
                    Description = "A one-handed sword made of crystals from space",
                    ImageURI = "Item_Placeholder.png",
                    Range = 1,
                    Damage = 2,
                    Value = 3,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Laser Gun",
                    Description = "A space-age rifle that shoots lasers",
                    ImageURI = "Item_Placeholder.png",
                    Range = 9,
                    Damage = 3,
                    Value = 5,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Laser Sword",
                    Description = "A one-handed sword made of light using technology",
                    ImageURI = "Item_Placeholder.png",
                    Range = 1,
                    Damage = 3,
                    Value = 4,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Shotgun",
                    Description = "A standard Earth shotgun",
                    ImageURI = "Item_Placeholder.png",
                    Range = 3,
                    Damage = 7,
                    Value = 3,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Nosiy Cricket",
                    Description = "A tiny weapon of extraterrestrial design",
                    ImageURI = "Item_Placeholder.png",
                    Range = 4,
                    Damage = 9,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Carbonizer",
                    Description = "A device that slows down a Monster",
                    ImageURI = "Item_Placeholder.png",
                    Range = 1,
                    Damage = 2,
                    Value = 0,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Defense Shield",
                    Description = "A device that protects the user from harm",
                    ImageURI = "Item_Placeholder.png",
                    Range = 0,
                    Damage = 0,
                    Value = 3,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Sunglasses",
                    Description = "A pair of shades that protect the wearer from getting things in their eye",
                    ImageURI = "Item_Placeholder.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Moon Boots",
                    Description = "Bouncy boots that boost the speed of the wearer",
                    ImageURI = "Item_Placeholder.png",
                    Range = 0,
                    Damage = 0,
                    Value = 5,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Fedora",
                    Description = "A standard issue hat for the men in black",
                    ImageURI = "Item_Placeholder.png",
                    Range = 0,
                    Damage = 0,
                    Value = 1,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Power Ring",
                    Description = "A ring of alien design that provides the wearer unbelievable power",
                    ImageURI = "Item_Placeholder.png",
                    Range = 0,
                    Damage = 0,
                    Value = 10,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack},

                //new ItemModel {
                //    Name = "Health Shield",
                //    Description = "Enough to hide behind",
                //    ImageURI = "Item_Placeholder.png",
                //    Range = 0,
                //    Damage = 0,
                //    Value = 9,
                //    Location = ItemLocationEnum.OffHand,
                //    Attribute = AttributeEnum.MaxHealth},

                //new ItemModel {
                //    Name = "Lucky Shield",
                //    Description = "Do you feel lucky punk?",
                //    ImageURI = "Item_Placeholder.png",
                //    Range = 0,
                //    Damage = 0,
                //    Value = 9,
                //    Location = ItemLocationEnum.OffHand,
                //    Attribute = AttributeEnum.Attack},

                //new ItemModel {
                //    Name = "Bunny Hat",
                //    Description = "Pink hat with fluffy ears",
                //    ImageURI = "Item_Placeholder.png",
                //    Range = 0,
                //    Damage = 0,
                //    Value = 9,
                //    Location = ItemLocationEnum.Head,
                //    Attribute = AttributeEnum.Speed},

                //new ItemModel {
                //    Name = "Horned Hat",
                //    Description = "Where's the Rabbit?",
                //    ImageURI = "Item_Placeholder.png",
                //    Range = 0,
                //    Damage = 0,
                //    Value = 9,
                //    Location = ItemLocationEnum.Head,
                //    Attribute = AttributeEnum.Defense},

                //new ItemModel {
                //    Name = "Fast Necklass",
                //    Description = "And Tasty",
                //    ImageURI = "Item_Placeholder.png",
                //    Range = 0,
                //    Damage = 0,
                //    Value = 9,
                //    Location = ItemLocationEnum.Necklass,
                //    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Feel the Power",
                    Description = "Love this one",
                    ImageURI = "Item_Placeholder.png",
                    Range = 1,
                    Damage = 1,
                    Value = 1,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Horned Hat",
                    Description = "Where's the Rabbit?",
                    ImageURI = "Item_Placeholder.png",
                    Range = 1,
                    Damage = 1,
                    Value = 1,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense},

                new ItemModel {
                    Name = "Ring of Power",
                    Description = "The wearer has all the power",
                    ImageURI = "Item_Placeholder.png",
                    Range = 1,
                    Damage = 1,
                    Value = 1,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Speed},

                new ItemModel {
                    Name = "Strong Ring",
                    Description = "Watch out",
                    ImageURI = "Item_Placeholder.png",
                    Range = 1,
                    Damage = 1,
                    Value = 1,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Warm Shoes",
                    Description = "Strong Shoes",
                    ImageURI = "Item_Placeholder.png",
                    Range = 1,
                    Damage = 1,
                    Value = 1,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack},

                new ItemModel {
                    Name = "Cute Shoes",
                    Description = "really fast",
                    ImageURI = "Item_Placeholder.png",
                    Range = 1,
                    Damage = 1,
                    Value = 1,
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
                    Name = "Agent 1",
                    Description = "The oldest Agent",
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
                    Job = CharacterJobEnum.Fighter
                },

                new CharacterModel {
                    Name = "Agent Alpha",
                    Description = "The first Agent",
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
                    Job = CharacterJobEnum.Cleric
                },

                new CharacterModel {
                    Name = "Agent Omega",
                    Description = "The final defense",
                    Level = 1,
                    MaxHealth = 8,
                    Defense = 9,
                    ImageURI = "elf4.png",
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
                    Name = "Agent Dave",
                    Description = "A normal guy",
                    Level = 4,
                    MaxHealth = 38,
                    ImageURI = "elf3.png",
                    Job = CharacterJobEnum.Cleric
                },

                new CharacterModel {
                    Name = "Agent K",
                    Description = "Not Tommy Lee Jones",
                    Level = 5,
                    MaxHealth = 43,
                    Attack = 2,
                    ImageURI = "elf5.png",
                    Job = CharacterJobEnum.Cleric
                },

                new CharacterModel {
                    Name = "Agent Pug",
                    Description = "Someone recruited a dog to become an Agent",
                    Level = 5,
                    MaxHealth = 21,
                    ImageURI = "elf6.png",
                    Job = CharacterJobEnum.Support
                },

                new CharacterModel {
                    Name = "Larry",
                    Description = "No one understands how Larry got here",
                    Level = 1,
                    MaxHealth = 3,
                    ImageURI = "elf7.png",
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
                    Description = "A ram constellation",
                    ImageURI = "Serpens_Monster.png",
                    Attack = 3,
                    Defense = 3,
                    Speed = 3,
                },

                new MonsterModel {
                    Name = "Cancer",
                    Description = "A crab constellation",
                    ImageURI = "Cancer_Monster.png",
                    Attack = 2,
                    Defense = 8,
                    Speed = 2,
                },

                new MonsterModel {
                    Name = "Pisces",
                    Description = "A fish constellation",
                    ImageURI = "Pisces_Monster.png",
                    Attack = 4,
                    Defense = 2,
                    Speed = 5,
                },

                new MonsterModel {
                    Name = "Scorpio",
                    Description = "A scorpion constellation",
                    ImageURI = "Scorpio_Monster.png",
                    Attack = 8,
                    Defense = 7,
                    Speed = 4,
                    Difficulty = DifficultyEnum.Average,
                    MaxHealth = 80,
                },

                new MonsterModel {
                    Name = "Lepus",
                    Description = "A hare constellation",
                    ImageURI = "Placeholder_Monster1.png",
                    Attack = 1,
                    Speed = 8,
                    Defense = 2,
                    MaxHealth = 12,
                },

                new MonsterModel {
                    Name = "Corvus",
                    Description = "A crow constellation",
                    ImageURI = "Placeholder_Monster2.png",
                    Attack = 2,
                    Speed = 2,
                    Defense = 3,
                    MaxHealth = 15,
                    Difficulty = DifficultyEnum.Easy,
                },
            };

            return datalist;
        }
    }
}