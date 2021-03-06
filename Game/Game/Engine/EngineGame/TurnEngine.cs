using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System;

using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.GameRules;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Engine.EngineBase;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// Engine controls the turns
    /// 
    /// A turn is when a Character takes an action or a Monster takes an action
    /// 
    /// </summary>
    public class TurnEngine : TurnEngineBase, ITurnEngineInterface
    {
        #region Algrorithm
        /* 
            Need to decide who takes the next turn
            Target to Attack
            Should Move, or Stay put (can hit with weapon range?)
            Death
            Manage Round...
          
            Attack or Move
            Roll To Hit
            Decide Hit or Miss
            Decide Damage
            Death
            Drop Items
            Turn Over
        */
        #endregion Algrorithm

        // Hold the BaseEngine
        public new EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        /// <summary>
        /// CharacterModel Attacks...
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override bool TakeTurn(PlayerInfoModel Attacker)
        {
            // Choose Action.  Such as Move, Attack etc.

            // INFO: Teams, if you have other actions they would go here.

            var result = false;

            // If the action is not set, then try to set it or use Attact
            if (EngineSettings.CurrentAction == ActionEnum.Unknown)
            {
                // Set the action if one is not set
                EngineSettings.CurrentAction = DetermineActionChoice(Attacker);

                // When in doubt, attack...
                if (EngineSettings.CurrentAction == ActionEnum.Unknown)
                {
                    EngineSettings.CurrentAction = ActionEnum.Attack;
                }
            }

            switch (EngineSettings.CurrentAction)
            {
                case ActionEnum.Attack:
                    result = Attack(Attacker);
                    break;

                case ActionEnum.Ability:
                    result = UseAbility(Attacker);
                    break;

                case ActionEnum.Relax:
                    result = UseRelax(Attacker);
                    break;

                case ActionEnum.Move:
                    result = MoveAsTurn(Attacker);
                    break;
            }

            // Increment Turn Count so you know what turn number
            EngineSettings.BattleScore.TurnCount++;

            // Save the Previous Action off
            EngineSettings.PreviousAction = EngineSettings.CurrentAction;

            // Reset the Action to unknown for next time
            EngineSettings.CurrentAction = ActionEnum.Unknown;

            return result;
        }

        #region Action
        /// <summary>
        /// Determine what Actions to do
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override ActionEnum DetermineActionChoice(PlayerInfoModel Attacker)
        {
            // If it is the characters turn, and NOT auto battle, use what was sent into the engine

            /*
             * The following is Used for Monsters, and Auto Battle Characters
             * 
             * Order of Priority
             * If can attack Then Attack
             * Next use Ability or Move
             */

            // Assume Move if nothing else happens

            // Check to see if ability is avaiable

            // See if Desired Target is within Range, and if so attack away
            return base.DetermineActionChoice(Attacker);
        }

        /// <summary>
        /// Find a Desired Target
        /// Move close to them
        /// Get to move the number of Speed
        /// </summary>
        public override bool MoveAsTurn(PlayerInfoModel Attacker)
        {

            /*
             * TODO: TEAMS Work out your own move logic if you are implementing move
             * 
             * Mike's Logic
             * The monster or charcter will move to a different square if one is open
             * Find the Desired Target
             * Jump to the closest space near the target that is open
             * 
             * If no open spaces, return false
             * 
             */

            /* 
             * DONE: Changed the logic while moving characters. System now checks if the target monster is selected
             * by user.
             * If yes, then character moves to a square near that monster.
             */

            // If the Monster the calculate the options
            if (Attacker.PlayerType == PlayerTypeEnum.Monster)
            {
                // For Attack, Choose Who
                EngineSettings.CurrentDefender = AttackChoice(Attacker);

                if (EngineSettings.CurrentDefender == null)
                {
                    return false;
                }

                // Get X, Y for Defender
                var locationDefender = EngineSettings.MapModel.GetLocationForPlayer(EngineSettings.CurrentDefender);
                if (locationDefender == null)
                {
                    return false;
                }

                // Get X, Y for the Attacker
                var locationAttacker = EngineSettings.MapModel.GetLocationForPlayer(Attacker);
                if (locationAttacker == null)
                {
                    return false;
                }

                // Find Location Nearest to Defender that is Open.
                var openSquare = EngineSettings.MapModel.ReverseDistance(locationAttacker, Attacker.Speed);

                // Get the Open Locations
                if (EngineSettings.MapModel.IsTargetInSpeed(Attacker, EngineSettings.CurrentDefender))
                {
                    openSquare = EngineSettings.MapModel.ReturnClosestEmptyLocation(locationDefender);
                }

                // Format a message to show
                if(openSquare != null)
                {
                    Debug.WriteLine(string.Format("{0} moves from {1},{2} to {3},{4}", locationAttacker.Player.Name, locationAttacker.Column, locationAttacker.Row, openSquare.Column, openSquare.Row));

                    EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + " moves closer to " + EngineSettings.CurrentDefender.Name;
                }                

                return EngineSettings.MapModel.MovePlayerOnMap(locationAttacker, openSquare);
            }

            if (Attacker.PlayerType == PlayerTypeEnum.Character)
            {
                // If defender is not already chosen by user, then engine will choose 
                if (!EngineSettings.CurrentDefender.IsSelectedAsTarget)
                {
                    EngineSettings.CurrentDefender = AttackChoice(Attacker);
                }                

                if (EngineSettings.CurrentDefender == null)
                {
                    return false;
                }

                // Get X, Y for Defender
                var locationDefender = EngineSettings.MapModel.GetLocationForPlayer(EngineSettings.CurrentDefender);
                if (locationDefender == null)
                {
                    return false;
                }

                var locationAttacker = EngineSettings.MapModel.GetLocationForPlayer(Attacker);
                if (locationAttacker == null)
                {
                    return false;
                }

                // Find Location Nearest to Defender that is Open.

                // Get the Open Locations
                var openSquare = EngineSettings.MapModel.ReturnClosestEmptyLocation(locationDefender);

                Debug.WriteLine(string.Format("{0} moves from {1},{2} to {3},{4}", locationAttacker.Player.Name, locationAttacker.Column, locationAttacker.Row, openSquare.Column, openSquare.Row));

                EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + " moves closer to " + EngineSettings.CurrentDefender.Name;

                return EngineSettings.MapModel.MovePlayerOnMap(locationAttacker, openSquare);
            }

            return true;
        }

        /// <summary>
        /// Decide to use an Ability or not
        /// 
        /// Set the Ability
        /// </summary>
        public override bool ChooseToUseAbility(PlayerInfoModel Attacker)
        {
            // See if healing is needed.
            EngineSettings.CurrentActionAbility = Attacker.SelectHealingAbility();
            if (EngineSettings.CurrentActionAbility != AbilityEnum.Unknown)
            {
                EngineSettings.CurrentAction = ActionEnum.Ability;
                return true;
            }

            // If not needed, then role dice to see if other ability should be used
            // Choose the % chance - 15% Chance on a d20 roll
            // Select the ability
            if (DiceHelper.RollDice(1, 20) < 3)
            {
                EngineSettings.CurrentActionAbility = Attacker.SelectAbilityToUse();

                if (EngineSettings.CurrentActionAbility != AbilityEnum.Unknown)
                {
                    // Ability can , switch to unknown to exit
                    EngineSettings.CurrentAction = ActionEnum.Ability;
                    return true;
                }

                // No ability available
                return false;
            }
            
            // Don't try
            return false;
        }

        /// <summary>
        /// Use the Ability
        /// </summary>
        public override bool UseAbility(PlayerInfoModel Attacker)
        {
            if (Attacker.PlayerType == PlayerTypeEnum.Monster)
            {
                return false;
            }

            if (Attacker.Job == CharacterJobEnum.Defender)
            {
                switch (EngineSettings.CurrentActionAbility)
                {
                    case AbilityEnum.Barrier:
                        EngineSettings.CurrentActionAbility = AbilityEnum.Barrier;

                        UseBarrier(Attacker);

                        break;

                    case AbilityEnum.Block:
                        EngineSettings.CurrentActionAbility = AbilityEnum.Block;

                        UseBlock(Attacker);

                        break;
                }
            }

            if (Attacker.Job == CharacterJobEnum.Striker)
            {
                switch (EngineSettings.CurrentActionAbility)
                {
                    case AbilityEnum.Dodge:
                        EngineSettings.CurrentActionAbility = AbilityEnum.Dodge;

                        UseDodge(Attacker);

                        break;

                    case AbilityEnum.DoubleStrike:
                        EngineSettings.CurrentActionAbility = AbilityEnum.DoubleStrike;

                        UseDoubleStrike(Attacker);

                        break;
                }
            }

            if (Attacker.Job == CharacterJobEnum.Support)
            {
                switch (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentActionAbility)
                {
                    case AbilityEnum.HealTeammate:
                        EngineSettings.CurrentActionAbility = AbilityEnum.HealTeammate;

                        HealTeam(Attacker);

                        break;

                    case AbilityEnum.BoostAttack:
                        EngineSettings.CurrentActionAbility = AbilityEnum.BoostAttack;

                        BoostAttack(Attacker);

                        break;

                    case AbilityEnum.BoostDefense:
                        EngineSettings.CurrentActionAbility = AbilityEnum.BoostDefense;

                        BoostDefense(Attacker);

                        break;

                    case AbilityEnum.BoostSpeed:
                        EngineSettings.CurrentActionAbility = AbilityEnum.BoostSpeed;

                        BoostSpeed(Attacker);

                        break;
                }
            }

            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + " Uses Ability " + EngineSettings.CurrentActionAbility.ToMessage();
            return (Attacker.UseAbility(EngineSettings.CurrentActionAbility));
        }

        /// <summary>
        /// Take a break
        /// </summary>
        public override bool UseRelax(PlayerInfoModel Attacker)
        {
            return base.UseRelax(Attacker);
        }

        #endregion Action

        #region Attack
        /// <summary>
        /// Attack as a Turn
        /// 
        /// Pick who to go after
        /// 
        /// Determine Attack Score
        /// Determine DefenseScore
        /// 
        /// Do the Attack
        /// 
        /// </summary>
        public override bool Attack(PlayerInfoModel Attacker)
        {
            // INFO: Teams, AttackChoice will auto pick the target, good for auto battle

            // Manage autobattle

            // Do Attack

            return base.Attack(Attacker);
        }

        /// <summary>
        /// Decide which to attack
        /// </summary>
        public override PlayerInfoModel AttackChoice(PlayerInfoModel data)
        {
            switch (data.PlayerType)
            {
                case PlayerTypeEnum.Monster:
                    return SelectCharacterToAttack();

                case PlayerTypeEnum.Character:
                default:
                    return SelectMonsterToAttack();
            }
        }

        /// <summary>
        /// Pick the Character to Attack
        /// </summary>
        public override PlayerInfoModel SelectCharacterToAttack()
        {
            // Check if there is less than one or no Players in the PlayerList
            if (EngineSettings.PlayerList == null)
            {
                return null;
            }

            if (EngineSettings.PlayerList.Count < 1)
            {
                return null;
            }

            // Select first in the list:

            // TODO: Teams, You need to implement your own Logic can not use mine.
            // DONE - Our Logic:
            // Sort list for Alive Characters,
            // then order by Current Health,
            // then by CharacterJob,
            // then by Defense descending
            var Defender = EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Character)
                .OrderBy(m => m.CurrentHealth)
                .ThenBy(m => m.Job.Equals(CharacterJobEnum.Support))
                .ThenBy(m => m.Job.Equals(CharacterJobEnum.Striker))
                .ThenBy(m => m.Job.Equals(CharacterJobEnum.Defender))
                .ThenByDescending(m => m.Defense)
                .FirstOrDefault();

            return Defender;
        }

        /// <summary>
        /// Pick the Monster to Attack
        /// </summary>
        public override PlayerInfoModel SelectMonsterToAttack()
        {
            // Check if there is less than one or no Players in the PlayerList
            if (EngineSettings.PlayerList == null)
            {
                return null;
            }

            if (EngineSettings.PlayerList.Count < 1)
            {
                return null;
            }

            var Defender = new PlayerInfoModel();

            // TODO: Teams, You need to implement your own Logic can not use mine.
            // DONE - Our Logic:
            // If defender is not already selected by user
            // Sort list for Alive Monsters,
            // then order by Monster Job
            // then by Attack
            // theb by Current Health
            if (EngineSettings.BattleScore.AutoBattle || !EngineSettings.CurrentDefender.IsSelectedAsTarget)
            {
              Defender = EngineSettings.PlayerList
              .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster)
              .OrderBy(m => m.Job.Equals(MonsterJobEnum.Brute))
              .ThenBy(m => m.Job.Equals(MonsterJobEnum.Swift))
              .ThenBy(m => m.Attack)
              .ThenBy(m => m.CurrentHealth)
              .FirstOrDefault();
            }
            else
            {
                Defender = EngineSettings.CurrentDefender;
            } 

            return Defender;
        }

        /// <summary>
        /// // MonsterModel Attacks CharacterModel
        /// </summary>
        public override bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            // Check if Attacker or Target are null
            if (Attacker == null)
            {
                return false;
            }

            if (Target == null)
            {
                return false;
            }

            // Set Messages to empty
            _ = EngineSettings.BattleMessagesModel.ClearMessages();

            // Do the Attack
            _ = CalculateAttackStatus(Attacker, Target);

            // See if the Battle Settings Overrides the Roll
            EngineSettings.BattleMessagesModel.HitStatus = BattleSettingsOverride(Attacker);

            if (Attacker.Name == "Doug") 
            {
                EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.CriticalMiss;
            }

            // Based on the Hit Status, what to do...
            switch (EngineSettings.BattleMessagesModel.HitStatus)
            {
                case HitStatusEnum.Miss:
                    // It's a Miss

                    break;

                case HitStatusEnum.CriticalMiss:
                    // It's a Critical Miss, so Bad things may happen
                    _ = DetermineCriticalMissProblem(Attacker);

                    break;

                case HitStatusEnum.CriticalHit:
                case HitStatusEnum.Hit:
                    // It's a Hit

                    //Calculate Damage
                    EngineSettings.BattleMessagesModel.DamageAmount = Attacker.GetDamageRollValue();

                    // If critical Hit, double the damage
                    if (EngineSettings.BattleMessagesModel.HitStatus == HitStatusEnum.CriticalHit)
                    {
                        EngineSettings.BattleMessagesModel.DamageAmount *= 2;
                    }

                    // Apply the Damage
                    _ = ApplyDamage(Target);


                    // Assigning current health to the right character on the CharacterList
                    if (Attacker.PlayerType == PlayerTypeEnum.Character)
                    {
                        foreach (var character in EngineSettings.CharacterList)
                        {
                            if (character.Guid == Attacker.Guid)
                            {
                                character.CurrentHealth = Attacker.CurrentHealth;
                            }
                        }
                    }

                    EngineSettings.BattleMessagesModel.TurnMessageSpecial = EngineSettings.BattleMessagesModel.GetCurrentHealthMessage();

                    // Check if Dead and Remove
                    _ = RemoveIfDead(Target);

                    // If it is a character apply the experience earned
                    _ = CalculateExperience(Attacker, Target);

                    break;
            }

            // Battle Message
            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + EngineSettings.BattleMessagesModel.AttackStatus + Target.Name + EngineSettings.BattleMessagesModel.TurnMessageSpecial + EngineSettings.BattleMessagesModel.ExperienceEarned;
            Debug.WriteLine(EngineSettings.BattleMessagesModel.TurnMessage);

            return true;
        }
        #endregion Attack

        /// <summary>
        /// See if the Battle Settings will Override the Hit
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverride(PlayerInfoModel Attacker)
        {
            return base.BattleSettingsOverride(Attacker);
        }

        /// <summary>
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverrideHitStatusEnum(HitStatusEnum myEnum)
        {
            // Based on the Hit Status, establish a message
            return base.BattleSettingsOverrideHitStatusEnum(myEnum);
        }

        /// <summary>
        /// Apply the Damage to the Target
        /// </summary>
        public override bool ApplyDamage(PlayerInfoModel Target)
        {
            return base.ApplyDamage(Target);
        }

        /// <summary>
        /// Calculate the Attack, return if it hit or missed.
        /// </summary>
        public override HitStatusEnum CalculateAttackStatus(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.CalculateAttackStatus(Attacker, Target);
        }

        /// <summary>
        /// Calculate Experience
        /// Level up if needed
        /// </summary>
        public override bool CalculateExperience(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.CalculateExperience(Attacker, Target);
        }

        /// <summary>
        /// If Dead process Target Died
        /// </summary>
        public override bool RemoveIfDead(PlayerInfoModel Target)
        {
            return base.RemoveIfDead(Target);
        }

        /// <summary>
        /// Target Died
        /// 
        /// Process for death...
        /// 
        /// Returns the count of items dropped at death
        /// </summary>
        public override bool TargetDied(PlayerInfoModel Target)
        {
            bool found;

            // Mark Status in output
            EngineSettings.BattleMessagesModel.TurnMessageSpecial = " and causes death. ";

            // Removing the 
            _ = EngineSettings.MapModel.RemovePlayerFromMap(Target);

            // INFO: Teams, Hookup your Boss if you have one...

            // Using a switch so in the future additional PlayerTypes can be added (Boss...)
            switch (Target.PlayerType)
            {
                case PlayerTypeEnum.Character:
                    // Add the Character to the killed list
                    EngineSettings.BattleScore.CharacterAtDeathList += Target.FormatOutput() + "\n";

                    EngineSettings.BattleScore.CharacterModelDeathList.Add(Target);

                    _ = DropItems(Target);

                    found = EngineSettings.CharacterList.Remove(EngineSettings.CharacterList.Find(m => m.Guid.Equals(Target.Guid)));
                    found = EngineSettings.PlayerList.Remove(EngineSettings.PlayerList.Find(m => m.Guid.Equals(Target.Guid)));

                    return true;

                case PlayerTypeEnum.Monster:
                default:
                    // Add one to the monsters killed count...
                    EngineSettings.BattleScore.MonsterSlainNumber++;

                    // Add the MonsterModel to the killed list
                    EngineSettings.BattleScore.MonstersKilledList += Target.FormatOutput() + "\n";

                    EngineSettings.BattleScore.MonsterModelDeathList.Add(Target);

                    _ = DropItems(Target);

                    found = EngineSettings.MonsterList.Remove(EngineSettings.MonsterList.Find(m => m.Guid.Equals(Target.Guid)));
                    found = EngineSettings.PlayerList.Remove(EngineSettings.PlayerList.Find(m => m.Guid.Equals(Target.Guid)));

                    return true;
            }
        }

        /// <summary>
        /// Drop Items
        /// </summary>
        public override int DropItems(PlayerInfoModel Target)
        {
            var DroppedMessage = "\nItems Dropped : \n";

            // Drop Items to ItemModel Pool
            var myItemList = Target.DropAllItems();

            // I feel generous, even when characters die, random drops happen :-)
            // If Random drops are enabled, then add some....
            myItemList.AddRange(GetRandomMonsterItemDrops(EngineSettings.BattleScore.RoundCount));

            // Add to ScoreModel
            foreach (var ItemModel in myItemList)
            {
                EngineSettings.BattleScore.ItemsDroppedList += ItemModel.FormatOutput() + "\n";
                DroppedMessage += ItemModel.Name + "\n";
            }

            EngineSettings.ItemPool.AddRange(myItemList);

            if (myItemList.Count == 0)
            {
                DroppedMessage = " Nothing dropped. ";
            }

            EngineSettings.BattleMessagesModel.DroppedMessage = DroppedMessage;

            EngineSettings.BattleScore.ItemModelDropList.AddRange(myItemList);

            return myItemList.Count();
        }

        /// <summary>
        /// Roll To Hit
        /// </summary>
        /// <param name="AttackScore"></param>
        /// <param name="DefenseScore"></param>
        public override HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore)
        {
            var d20 = DiceHelper.RollDice(1, 20);

            if (d20 == 1)
            {
                EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.Miss;
                EngineSettings.BattleMessagesModel.AttackStatus = " rolls 1 to miss ";

                if (EngineSettings.BattleSettingsModel.AllowCriticalMiss)
                {
                    EngineSettings.BattleMessagesModel.AttackStatus = " rolls 1 to completly miss ";
                    EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.CriticalMiss;
                }

                return EngineSettings.BattleMessagesModel.HitStatus;
            }

            if (d20 == 20)
            {
                EngineSettings.BattleMessagesModel.AttackStatus = " rolls 20 for hit ";
                EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.Hit;

                if (EngineSettings.BattleSettingsModel.AllowCriticalHit)
                {
                    EngineSettings.BattleMessagesModel.AttackStatus = " rolls 20 for lucky hit ";
                    EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.CriticalHit;
                }
                return EngineSettings.BattleMessagesModel.HitStatus;
            }

            var ToHitScore = d20 + AttackScore;
            if (ToHitScore < DefenseScore)
            {
                EngineSettings.BattleMessagesModel.AttackStatus = " rolls " + d20 + " and misses ";

                // Miss
                EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.Miss;
                EngineSettings.BattleMessagesModel.DamageAmount = 0;
                return EngineSettings.BattleMessagesModel.HitStatus;
            }

            EngineSettings.BattleMessagesModel.AttackStatus = " rolls " + d20 + " and hits ";

            // Hit
            EngineSettings.BattleMessagesModel.HitStatus = HitStatusEnum.Hit;
            return EngineSettings.BattleMessagesModel.HitStatus;
        }

        /// <summary>
        /// Will drop between 1 and 4 items from the ItemModel set...
        /// </summary>
        public override List<ItemModel> GetRandomMonsterItemDrops(int round)
        {
            // TODO: Teams, You need to implement your own modification to the Logic cannot use mine as is.

            // You decide how to drop monster items, level, etc.

            // The Number drop can be Up to the Round Count, but may be less.  

            // DONE: No of items dropped will be equal to the round number

            // Negative results in nothing dropped
            var NumberToDrop = DiceHelper.RollDice(1, round - 2) + 1;

            var result = new List<ItemModel>();
            for (var i = 0; i < NumberToDrop; i++)
            {
                // Get a random Unique Item
                var data = ItemIndexViewModel.Instance.GetItem(RandomPlayerHelper.GetMonsterUniqueItem());
                result.Add(data);
            }
            return result;
        }

        /// <summary>
        /// Critical Miss Problem
        /// </summary>
        public override bool DetermineCriticalMissProblem(PlayerInfoModel attacker)
        {
            return base.DetermineCriticalMissProblem(attacker);
        }

        /// <summary>
        /// UserBarrier method gives the Player the ability to boost their defense
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns>True</returns>
        public bool UseBarrier(PlayerInfoModel Attacker)
        {
            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + " boots up a force sheild";

            Attacker.BuffDefense();

            return true;
        }

        /// <summary>
        /// UserBlock method gives the Player the ability to boost their defense
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns>True</returns>
        public bool UseBlock(PlayerInfoModel Attacker)
        {
            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + " takes a denfensive stance";

            Attacker.BuffDefense();

            return true;
        }

        /// <summary>
        /// UserDodge method gives the Player the a boost to defense as a way to avoid attacks
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns>True</returns>
        public bool UseDodge(PlayerInfoModel Attacker)
        {
            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + " nimbly avoids incoming attacks";

            Attacker.BuffDefense();

            return true;
        }

        /// <summary>
        /// UserDoubleStrike method lets the Player attack twice on the current turn
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns>True</returns>
        public bool UseDoubleStrike(PlayerInfoModel Attacker)
        {
            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + " uses Double Strike";

            if (EngineSettings.BattleScore.AutoBattle != true)
            {
                EngineSettings.BattleScore.AutoBattle = true;

                for (int i = 0; i < 2; i++)
                {
                    SelectMonsterToAttack();
                }

                EngineSettings.BattleScore.AutoBattle = false;

                return true;
            }

            return false;
        }

        /// <summary>
        /// The HealTeam method heals all Characters that are Alive in the current Round
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns>True</returns>
        public bool HealTeam(PlayerInfoModel Attacker)
        {
            foreach (var character in EngineSettings.CharacterList)
            {
                if (character.Alive == true)
                {
                    if (character.CurrentHealth != character.MaxHealth)
                    {
                        character.ApplyHeal();

                        EngineSettings.BattleMessagesModel.TurnMessage = character.Name + " restores 5 health";
                        Debug.WriteLine(character.Name + " current health is " + character.CurrentHealth);
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool BoostAttack(PlayerInfoModel Attacker)
        {
            foreach (var character in EngineSettings.CharacterList)
            {
                if (character.Alive == true)
                {
                    if (character != Attacker)
                    {
                        character.BuffAttack();

                        EngineSettings.BattleMessagesModel.TurnMessage = character.Name + " has Attack boosted";
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool BoostDefense(PlayerInfoModel Attacker)
        {
            foreach (var character in EngineSettings.CharacterList)
            {
                if (character.Alive == true)
                {
                    if (character != Attacker)
                    {
                        character.BuffDefense();

                        EngineSettings.BattleMessagesModel.TurnMessage = character.Name + " has Defense boosted";
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public bool BoostSpeed(PlayerInfoModel Attacker)
        {
            foreach (var character in EngineSettings.CharacterList)
            {
                if (character.Alive == true)
                {
                    if (character != Attacker)
                    {
                        character.BuffSpeed();

                        EngineSettings.BattleMessagesModel.TurnMessage = character.Name + " has Speed boosted";
                    }
                }
            }

            return true;
        }
    }
}