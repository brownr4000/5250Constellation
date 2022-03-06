using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using Game.Engine.EngineBase;
using Game.Engine.EngineKoenig;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Views.Battle;
using Game.Models;
using Game.GameRules;
using Game.Engine.EngineModels;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public partial class BattleFieldPage : ContentPage
    {
        public List<MonsterModel> defaultMonsterData = DefaultData.LoadData(new MonsterModel());

        public List<CharacterModel> defaultCharacterData = DefaultData.LoadData(new CharacterModel());

        // HTML Formatting for message output box
        public HtmlWebViewSource htmlSource = new HtmlWebViewSource();

        // View Model for Current Character
        public PlayerInfoModel CurrentCharacterData;

        // Set flag when character is the attacker 
        public bool isCharacterTheAttacker;

        // View Model for Current Monster
        public PlayerInfoModel CurrentMonsterSelectedData;

        // Wait time before proceeding
        public int WaitTime = 1500;

        // Hold the Map Objects, for easy access to update them
        public Dictionary<string, object> MapLocationObject = new Dictionary<string, object>();

        // This uses the Instance so it can be shared with other Battle Pages as needed
        public BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        BattleEngine Engine = new BattleEngine();

        // Empty Constructor for UTs
        bool UnitTestSetting;
        public BattleFieldPage(bool UnitTest) { UnitTestSetting = UnitTest; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BattleFieldPage()
        {
            InitializeComponent();

            BattleSequenceFrame.IsVisible = false;
            NextMoveFrame.IsVisible = false;
            BreakBattleSequenceFrame.IsVisible = false;
            MonsterDefenderLabel.IsVisible = false;

            // Set initial State to Starting
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Starting;

            // Set up the UI to Defaults
            BindingContext = BattleEngineViewModel.Instance;

            // Create and Draw the Map
            _ = InitializeMapGrid();

            // Populate the UI Map
            DrawMapGridInitialState();

            // Ask the Game engine to select who goes first
            _ = BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(null);
        }

        /// <summary>
        /// Put the Player into a Display Box
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StackLayout PlayerInfoDisplayBox(PlayerInfoModel data)
        {
            if (data == null)
            {
                data = new PlayerInfoModel
                {
                    ImageURI = ""
                };
            }

            // Hookup the image
            var PlayerImage = new Image
            {
                Style = (Style)Application.Current.Resources["ImageButtonBattleFieldWithBackgroundStyle"],
                Source = data.ImageURI
            };

            // Put the Image Button and Text inside a layout
            var PlayerStack = new StackLayout
            {
                Style = (Style)Application.Current.Resources["PlayerBattleDisplayBox"],
                Children = {
                    PlayerImage,
                },
            };

            return PlayerStack;
        }

        /// <summary>
        /// Attack clicked method call
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackButton_Clicked(object sender, EventArgs e)
        {
            if(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.IsSelectedAsTarget == false)
            {
                MonsterDefenderLabel.IsVisible = true;
                return;
            }

            BattleSequenceFrame.IsVisible = true;
            NextMoveFrame.IsVisible = false;
            MonsterDefenderLabel.IsVisible = false;

            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = CurrentCharacterData;
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.Battling;

            // Call next action
            NextActionForCharacter();
        }

        /// <summary>
        /// Start Battle clicked method called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StartBattleButton_Clicked(object sender, EventArgs e)
        {
            NextAction();
            BattleSequenceFrame.IsVisible = true;
            NextMoveFrame.IsVisible = false;
            StartBattleButton.IsVisible = false;
        }

        /// <summary>
        /// Picks Attack as the first action 
        /// </summary>
        public void NextAction()
        {
            BattleSequenceFrame.IsVisible = true;
            isCharacterTheAttacker = false;
            // Get the turn, set the current player and attacker to match
            SetAttackerAndDefender();

            // Show the outcome on the Board
            DrawGameAttackerDefenderBoard();

            if (!isCharacterTheAttacker && BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PlayerType == PlayerTypeEnum.Character)
            {
                ForceCharcterToTakeAction();
                return;
            }
            CheckAction();
        }

        /// <summary>
        /// Draw the UI for
        ///
        /// Attacker vs Defender Mode
        /// 
        /// </summary>
        public void DrawGameAttackerDefenderBoard()
        {
            // Draw the Map
            _ = UpdateMapGrid();
        }

        /// <summary>
        /// Walk the current grid
        /// check each cell to see if it matches the engine map
        /// Update only those that need change
        /// </summary>
        /// <returns></returns>
        public bool UpdateMapGrid()
        {
            foreach (var data in BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapGridLocation)
            {
                // Use the ImageButton from the dictionary because that represents the player object
                var MapObject = GetMapGridObject(GetDictionaryImageButtonName(data));
                if (MapObject == null)
                {
                    return false;
                }

                var imageObject = (ImageButton)MapObject;

                // Check automation ID on the Image, That should match the Player, if not a match, the cell is now different need to update
                if (!imageObject.AutomationId.Equals(data.Player.Guid))
                {
                    // The Image is different, so need to re-create the Image Object and add it to the Stack
                    // That way the correct monster is in the box.
                    MapObject = GetMapGridObject(GetDictionaryStackName(data));

                    if (MapObject == null)
                    {
                        return false;
                    }

                    var stackObject = (StackLayout)MapObject;

                    // Remove the ImageButton
                    stackObject.Children.RemoveAt(0);

                    var PlayerImageButton = DetermineMapImageButton(data);

                    stackObject.Children.Add(PlayerImageButton);

                    // Update the Image in the Datastructure
                    _ = MapGridObjectAddImage(PlayerImageButton, data);

                    stackObject.BackgroundColor = DetermineMapBackgroundColor(data);
                }
            }
            return true;
        }
        
        /// <summary>
        /// Method to check for new round game over 
        /// </summary>
        /// <returns></returns>
        public async Task CheckAction()
        {
            // Hold the current state
            var RoundCondition = BattleEngineViewModel.Instance.Engine.Round.RoundNextTurn();

            // Set character and monster images
            SetImages();

            // Output the Message of what happened.
            GameMessage();

            if (RoundCondition == RoundEnum.NewRound)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.NewRound;

                // Pause
                _ = Task.Delay(WaitTime);

                Debug.WriteLine("New Round");

                // Show the Round Over, after that is cleared, it will show the New Round Dialog
                ShowModalRoundOverPage();
                return;
            }

            // Check for Game Over
            if (RoundCondition == RoundEnum.GameOver)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleStateEnum = BattleStateEnum.GameOver;

                // Wrap up
                _ = BattleEngineViewModel.Instance.Engine.EndBattle();

                // Pause
                _ = Task.Delay(WaitTime);

                Debug.WriteLine("Game Over");

                GameOver();
                return;
            }
            await Task.Delay(2000);
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.IsSelectedAsTarget = false;

            NextAction();
        }

        /// <summary>
        /// Set character and monster images
        /// </summary>
        public async void SetImages()
        {
            Player1Image.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker is null ?
             null : BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.ImageURI;

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PlayerType == PlayerTypeEnum.Character
                && BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker != null)
            {
                foreach (var character in defaultCharacterData)
                {
                    if (character.ImageURI == BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.ImageURI)
                    {
                        Player1Image.Source = character.ImageGIFURI;
                    }
                }
            }

            if (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender != null &&
                BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.PlayerType == PlayerTypeEnum.Monster &&
                !BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.Alive)
            {
               foreach(var monster in defaultMonsterData)
                {
                   if(monster.ImageURI == BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.ImageURI)
                    {
                        Player2Image.Source = monster.ImageGIFURI;
                       // Player2Image.BackgroundColor = Color.Black;
                        _ = Task.Delay(2000);

                        //foreach (var i in new[] { 1, 3, 5 })
                        //{
                        //    await Player2Image.RelScaleTo(0.5 / i, 350, Easing.SinIn);
                        //    await Player2Image.RelScaleTo(-0.5 / i, 0, Easing.SinOut);
                        //    await Player2Image.RelScaleTo(0.5 / i, 350, Easing.SinInOut);

                        //    // Pause
                        //    _ = Task.Delay(1900);                           
                        //}
                        return;
                    }
                }
                return;
            }

         //   Player2Image.BackgroundColor = Color.Transparent;
            Player2Image.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender is null ?
               null : BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.ImageURI;
        }

        /// <summary>
        /// Next action after character is picked
        /// </summary>
        public void NextActionForCharacter()
        {
            // Get the turn, set the current player and attacker to match
            SetDefender();

            CheckAction();
        }
        /// <summary>
        /// Game is over
        /// Show Buttons
        /// Clean up the Engine
        /// Show the Score
        /// Clear the Board
        /// </summary>
        public async void GameOver()
        {
            // Save the Score to the Score View Model, by sending a message to it.
            var Score = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore;
            MessagingCenter.Send(this, "AddData", Score);
            await Navigation.PushModalAsync(new GameOverPage());
        }     

        /// <summary>
        /// Show the Round Over page
        /// Round Over is where characters get items
        /// </summary>
        public async void ShowModalRoundOverPage()
        {
           // ShowBattleMode();
            await Navigation.PushModalAsync(new RoundOverPage());
        }      

        /// <summary>
        /// Break Action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RelaxButton_Clicked(object sender, EventArgs e)
        {
            RelaxExample();
            BreakBattleSequenceFrame.IsVisible = true;
            NextMoveFrame.IsVisible = false;
        }

        /// <summary>
        /// Take a break selected
        /// 
        /// </summary>
        public async Task RelaxExample()
        {
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Relax;           
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker = CurrentCharacterData;

            EngineViewModel.Engine.Round.Turn.TakeTurn(CurrentCharacterData);

            CurrentBreakCharacterImage.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.ImageURI;

            // Output the Message of what happened.
            GameMessage();

            await Task.Delay(2000);

            BreakBattleSequenceFrame.IsVisible = false;
            // Continues the game
            NextAction();
        }

        /// <summary>
        /// Decide The Turn and who to Attack
        /// </summary>
        public void SetAttackerAndDefender()
        {            
            _ = BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(BattleEngineViewModel.Instance.Engine.Round.GetNextPlayerTurn());

            switch (BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.PlayerType)
            {
                case PlayerTypeEnum.Character:                    
                    _ = BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(BattleEngineViewModel.Instance.Engine.Round.Turn.AttackChoice(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker));
                    break;

                case PlayerTypeEnum.Monster:
                default:
                    // Monsters turn, so auto pick a Character to Attack
                    _ = BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(BattleEngineViewModel.Instance.Engine.Round.Turn.AttackChoice(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker));
                    break;
            }
        }

        /// <summary>
        /// Decide The defender
        /// </summary>
        public void SetDefender()
        {
            _ = BattleEngineViewModel.Instance.Engine.Round.SetCurrentAttacker(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker);
            var player = BattleEngineViewModel.Instance.Engine.Round.GetNextPlayerTurn();

            switch (player.PlayerType)
            {
                case PlayerTypeEnum.Character:
                    _ = BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(BattleEngineViewModel.Instance.Engine.Round.Turn.AttackChoice(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker));
                    break;

                case PlayerTypeEnum.Monster:
                default:
                    _ = BattleEngineViewModel.Instance.Engine.Round.SetCurrentDefender(BattleEngineViewModel.Instance.Engine.Round.Turn.AttackChoice(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker));
                    break;
            }
        }

        /// <summary>
        /// Builds up the output message
        /// </summary>
        /// <param name="message"></param>
        public void GameMessage()
        {
            // Output The Message that happened.
            BattleGrammer.Text = string.Format("{0} \n{1}", BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.TurnMessage, BattleGrammer.Text);

            Debug.WriteLine(BattleGrammer.Text);

            if (!string.IsNullOrEmpty(BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.LevelUpMessage))
            {
                BattleGrammer.Text = string.Format("{0} \n{1}", BattleEngineViewModel.Instance.Engine.EngineSettings.BattleMessagesModel.LevelUpMessage, BattleGrammer.Text);
            }

            BreakBattleGrammer.Text = BattleGrammer.Text;
        }

        /// <summary>
        /// Move clicked method called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void MoveButton_Clicked(object sender, EventArgs e)
        {
            // Move button code
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAction = ActionEnum.Move;

            EngineViewModel.Engine.Round.Turn.TakeTurn(BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker);

            BreakBattleSequenceFrame.IsVisible = true;
            CurrentBreakCharacterImage.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker.ImageURI;

            // Output the Message of what happened.
            GameMessage();

            await Task.Delay(2000);

            BreakBattleSequenceFrame.IsVisible = false;

            // Continues the game
            NextAction();
        }

        /// <summary>
        /// Abilities clicked method called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AbilitiesButton_Clicked(object sender, EventArgs e)
        {
            // Show abilities                           
        }

        /// <summary>
        /// Create the Initial Map Grid
        /// 
        /// All lcoations are empty
        /// </summary>
        /// <returns></returns>
        public bool InitializeMapGrid()
        {
            _ = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.ClearMapGrid();

            return true;
        }

        /// <summary>
        /// Draw the Map Grid
        /// Add the Players to the Map
        /// 
        /// Need to have Players in the Engine first, to then put on the Map
        /// 
        /// The Map Objects are all created with the map background image first
        /// 
        /// Then the actual characters are added to the map
        /// </summary>
        public void DrawMapGridInitialState()
        {
            // Create the Map in the Game Engine
            _ = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.PopulateMapModel(BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList);

            _ = CreateMapGridObjects();

            _ = UpdateMapGrid();
        }

        /// <summary>
        /// Convert the Stack to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryFrameName(MapModelLocation data)
        {
            return string.Format("MapR{0}C{1}Frame", data.Row, data.Column);
        }

        /// <summary>
        /// Convert the Stack to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryStackName(MapModelLocation data)
        {
            return string.Format("MapR{0}C{1}Stack", data.Row, data.Column);
        }

        /// <summary>
        /// Covert the player map location to a name for the dictionary to lookup
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetDictionaryImageButtonName(MapModelLocation data)
        {
            // Look up the Frame in the Dictionary
            return string.Format("MapR{0}C{1}ImageButton", data.Row, data.Column);
        }

        /// <summary>
        /// Populate the Map
        /// 
        /// For each map position in the Engine
        /// Create a grid object to hold the Stack for that grid cell.
        /// </summary>
        /// <returns></returns>
        public bool CreateMapGridObjects()
        {
            foreach (var location in BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapGridLocation)
            {
                var data = MakeMapGridBox(location);

                // Add the Box to the UI

                MapGrid.Children.Add(data, location.Column, location.Row);
            }

            // Set the Height for the MapGrid based on the number of rows * the height of the BattleMapFrame

            var height = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.MapXAxiesCount * 60;

            BattleMapDisplay.MinimumHeightRequest = height;
            BattleMapDisplay.HeightRequest = height;

            return true;
        }

        /// <summary>
        /// Get the Frame from the Dictionary
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetMapGridObject(string name)
        {
            _ = MapLocationObject.TryGetValue(name, out var data);
            return data;
        }

        /// <summary>
        /// Make the Game Map Frame 
        /// Place the Character or Monster on the frame
        /// If empty, place Empty
        /// </summary>
        /// <param name="mapLocationModel"></param>
        /// <returns></returns>
        public Frame MakeMapGridBox(MapModelLocation mapLocationModel)
        {
            if (mapLocationModel.Player == null)
            {
                mapLocationModel.Player = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.EmptySquare;
            }

            var PlayerImageButton = DetermineMapImageButton(mapLocationModel);

            var PlayerStack = new StackLayout
            {
                Padding = 0,
                Style = (Style)Application.Current.Resources["BattleMapImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = DetermineMapBackgroundColor(mapLocationModel),
                Children = {
                    PlayerImageButton
                },
            };

            _ = MapGridObjectAddImage(PlayerImageButton, mapLocationModel);
            _ = MapGridObjectAddStack(PlayerStack, mapLocationModel);

            var MapFrame = new Frame
            {
                Style = (Style)Application.Current.Resources["BattleMapFrame"],
                Content = PlayerStack,
                AutomationId = GetDictionaryFrameName(mapLocationModel)
            };

            return MapFrame;
        }

        /// <summary>
        /// This add the ImageButton to the stack to kep track of
        /// </summary>
        /// <param name="data"></param>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public bool MapGridObjectAddImage(ImageButton data, MapModelLocation MapModel)
        {
            var name = GetDictionaryImageButtonName(MapModel);

            // First check to see if it has data, if so update rather than add
            if (MapLocationObject.ContainsKey(name))
            {
                // Update it
                MapLocationObject[name] = data;
                return true;
            }

            MapLocationObject.Add(name, data);

            return true;
        }

        /// <summary>
        /// This adds the Stack into the Dictionary to keep track of
        /// </summary>
        /// <param name="data"></param>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public bool MapGridObjectAddStack(StackLayout data, MapModelLocation MapModel)
        {
            var name = GetDictionaryStackName(MapModel);

            // First check to see if it has data, if so update rather than add
            if (MapLocationObject.ContainsKey(name))
            {
                // Update it
                MapLocationObject[name] = data;
                return true;
            }

            MapLocationObject.Add(name, data);
            return true;
        }

        /// <summary>
        /// Set the Image onto the map
        /// The Image represents the player
        /// 
        /// So a charcter is the character Image for that character
        /// 
        /// The Automation ID equals the guid for the player
        /// This makes it easier to identify when checking the map to update thigns
        /// 
        /// The button action is set per the type, so Characters events are differnt than monster events
        /// </summary>
        /// <param name="MapLocationModel"></param>
        /// <returns></returns>
        public ImageButton DetermineMapImageButton(MapModelLocation MapLocationModel)
        {
            var data = new ImageButton
            {
                Style = (Style)Application.Current.Resources["BattleMapPlayerSmallStyle"],
                Source = MapLocationModel.Player.ImageURI,

                // Store the guid to identify this button
                AutomationId = MapLocationModel.Player.Guid
            };

            switch (MapLocationModel.Player.PlayerType)
            {
                case PlayerTypeEnum.Character:
                    data.Clicked += (sender, args) => SetSelectedCharacter(MapLocationModel);
                    break;
                case PlayerTypeEnum.Monster:
                    data.Clicked += (sender, args) => SetSelectedMonster(MapLocationModel);
                    break;
                case PlayerTypeEnum.Unknown:
                default:
                    data.Clicked += (sender, args) => SetSelectedEmpty(MapLocationModel);

                    // Use the blank cell
                    data.Source = BattleEngineViewModel.Instance.Engine.EngineSettings.MapModel.EmptySquare.ImageURI;
                    break;
            }

            return data;
        }

        /// <summary>
        /// Set the Background color for the tile.
        /// Monsters and Characters have different colors
        /// Empty cells are transparent
        /// </summary>
        /// <param name="MapModel"></param>
        /// <returns></returns>
        public Color DetermineMapBackgroundColor(MapModelLocation MapModel)
        {
            string BattleMapBackgroundColor;
            switch (MapModel.Player.PlayerType)
            {
                case PlayerTypeEnum.Character:
                case PlayerTypeEnum.Monster:
                case PlayerTypeEnum.Unknown:
                default:
                    BattleMapBackgroundColor = "BattleMapTransparentColor";
                    break;
            }

            var result = (Color)Application.Current.Resources[BattleMapBackgroundColor];
            return result;
        }

        /// <summary>
        /// Event when an empty location is clicked on
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SetSelectedEmpty(MapModelLocation data)
        {
            // TODO: Info

            /*
             * This gets called when the characters is clicked on
             * Usefull if you want to select the location to move to etc.
             * 
             * For Mike's simple battle grammar there is no selection of action so I just return true
             */

            return true;
        }

        /// <summary>
        /// Event when a Monster is clicked on
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SetSelectedMonster(MapModelLocation data)
        {
            // Set selected Monster data
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender = data.Player;

            // Set selected monster as target 
            BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentDefender.IsSelectedAsTarget = true;

            return true;
        }

        /// <summary>
        /// Event when a Character is clicked on
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SetSelectedCharacter(MapModelLocation data)
        {
            return true;
        }

        /// <summary>
        /// Event when a Character is selected by battle engine
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ForceCharcterToTakeAction()
        {
            isCharacterTheAttacker = true;

            NextMoveFrame.IsVisible = true;
            BattleSequenceFrame.IsVisible = false;
            BreakBattleSequenceFrame.IsVisible = false;

            //Setting the ViewModel with current character details
            CurrentCharacterData = new PlayerInfoModel();
            CurrentCharacterData = BattleEngineViewModel.Instance.Engine.EngineSettings.CurrentAttacker;

            CharacterImage.Source = CurrentCharacterData.ImageURI;

            //CharacterName.Text = "Character: " + CurrentCharacterData.Name;
            CharacterName.Text = "Its " + CurrentCharacterData.Name + "'s turn. Pick an action";
            HealthValue.Text = CurrentCharacterData.CurrentHealth.ToString();
            RangeValue.Text = CurrentCharacterData.Range.ToString();

            //Setting progress bars
            HealthProgressBar.Progress = CurrentCharacterData.CurrentHealth / 9f;
            RangeProgressBar.Progress = CurrentCharacterData.Range / 9f;
            return true;
        }

        /// <summary>
        /// Battle Settings button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BattleSettings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BattleSettingsPage());
        }
    }
}