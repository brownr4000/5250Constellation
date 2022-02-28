using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Models;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// The BattleEngine class defines the Battle Engine for the Game
    /// </summary>
    public class BattleEngine : BattleEngineBase, IBattleEngineInterface
    {
        // The Round
        public new IRoundEngineInterface Round
        {
            get
            {
                if (base.Round == null)
                {
                    base.Round = new RoundEngine();
                }
                return base.Round;
            }
            set { base.Round = Round; }
        }

        // The BaseEngine
        public new EngineSettingsModel EngineSettings { get; set; } = EngineSettingsModel.Instance;

        /// <summary>
        /// The PopulateCharacterList method adds a Charcter to the Character list
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override bool PopulateCharacterList(CharacterModel data)
        {
            EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            return true;
        }

        /// <summary>
        /// The StartBattle method starts the battle
        /// 
        /// This method overrides the default IBattleEngineInterface StartBattle method
        /// </summary>
        /// <param name="isAutoBattle">The flag if the Battle is an AutoBattle</param>
        /// <returns></returns>
        public override bool StartBattle(bool isAutoBattle)
        {
            // Reset the Score so it is fresh
            EngineSettings.BattleScore = new ScoreModel
            {
                AutoBattle = isAutoBattle
            };

            BattleRunning = true;

            _ = Round.NewRound();

            return true;
        }

        /// <summary>
        /// The EndBattle method ends the Battle
        /// </summary>
        /// <returns></returns>
        public override bool EndBattle()
        {
            BattleRunning = false;

            _ = EngineSettings.BattleScore.CalculateScore();

            return true;
        }
    }
}