
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
/**
 * Project      : Lights - Game2
 * Description  : A game of Simon with 9 lights, each light is played once and has different colors
 * File         : MainForm.cs
 * Author       : Weber Jamie
 * Date         : 02 October 2023
**/
namespace Game3
{
    /// <summary>
    /// The main Form of the program
    /// </summary>
    public partial class MainForm : Form
    {


        // #############################
        // The global variables of the class
        // #############################


        /// <summary>
        /// The class for the management of the game
        /// </summary>
        private Game game;

        /// <summary>
        /// The shape of the tiles
        /// </summary>
        private string shape = "Ronds";

        /// <summary>
        /// The brush for the tiles
        /// </summary>
        private SolidBrush[,] offColors;

        /// <summary>
        /// The brush for the lit tiles
        /// </summary>
        private SolidBrush[,] litColors;

        /// <summary>
        /// The size of the tile
        /// </summary>
        private const int size = 80;

        /// <summary>
        /// The current frame for the bot
        /// </summary>
        private int botTimerFrame = 0;


        // #############################
        // The functions for the start of the form
        // #############################


        /// <summary>
        /// The constructor of the class, instanciate a new game object
        /// </summary>
        public MainForm()
        {
            offColors = new SolidBrush[,] 
            { 
                { new SolidBrush(Color.FromArgb(255, 127, 0, 0)),  new SolidBrush(Color.FromArgb(255, 0, 127, 0)),  new SolidBrush(Color.FromArgb(255, 0, 0, 127))},
                { new SolidBrush(Color.FromArgb(255, 127, 0, 127)),  new SolidBrush(Color.FromArgb(255, 127, 127, 0)),  new SolidBrush(Color.FromArgb(255, 0, 127, 127))},
                { new SolidBrush(Color.FromArgb(255, 127, 63, 0)),  new SolidBrush(Color.FromArgb(255, 0, 127, 79)),  new SolidBrush(Color.FromArgb(255, 95, 0, 127))}
            };
            litColors = new SolidBrush[,]
            {
                { new SolidBrush(Color.FromArgb(255, 255, 0, 0)),  new SolidBrush(Color.FromArgb(255, 0, 255, 0)),  new SolidBrush(Color.FromArgb(255, 0, 0, 255))},
                { new SolidBrush(Color.FromArgb(255, 255, 0, 255)),  new SolidBrush(Color.FromArgb(255, 255, 255, 0)),  new SolidBrush(Color.FromArgb(255, 0, 255, 255))},
                { new SolidBrush(Color.FromArgb(255, 255, 127, 0)),  new SolidBrush(Color.FromArgb(255, 0, 255, 159)),  new SolidBrush(Color.FromArgb(255, 191, 0, 255))}
            };
            InitializeComponent();
            game = new Game();
        }

        /// <summary>
        /// When loading the form
        /// Checks the base radio buttons and show the game in the picturebox
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SimpleRbt.Checked = true;
            CircleRbt.Checked = true;
            GamePbx.Image = DrawGame();
            BotTimer.Interval = 300;
        }


        // #############################
        // The functions when changing the radio buttons for the options of the app
        // #############################


        /// <summary>
        /// When Clicking one the difficulty radio button
        /// Change the interval for the bot speed
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event</param>
        private void Difficulty_Checked(object sender, EventArgs e)
        {
            string text = ((RadioButton)sender).Text;
            switch (text)
            {
                case "Simple":
                    BotTimer.Interval = 300;
                    break;
                case "Rapide":
                    BotTimer.Interval = 200;
                    break;
                case "Très Rapide":
                    BotTimer.Interval = 100;
                    break;
            }
        }

        /// <summary>
        /// When clicking one of the style radio button
        /// Change the shape of the tile and redraw the game
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event</param>
        private void Style_Checked(object sender, EventArgs e)
        {
            shape = ((RadioButton)sender).Text;
            GamePbx.Image = DrawGame();
        }


        // #############################
        // The function when clicking in the game
        // #############################


        /// <summary>
        /// When clicking on the picture box
        /// Check if it is the player's turn and that the last input has finished and verify if the player is right
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event</param>
        private void GamePbx_Click(object sender, EventArgs e)
        {
            if (PlayerTimer.Enabled)
            {
                return;
            }
            MouseEventArgs me = (MouseEventArgs)e;
            int x = me.X / 84;
            int y = me.Y / 84;
            if (game.CheckPlayer(x, y))
            {
                GamePbx.Image = DrawGameWithSelectedTile(x, y);
                PlayerTimer.Start();
            }
        }


        // #############################
        // The function when one of the timer ticks
        // #############################


        /// <summary>
        /// When the timer is ticking
        /// Draw the correspondant frame
        /// If arrived at the last input, start the player phase
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event</param>
        private void BotTimer_Tick(object sender, EventArgs e)
        {
            if (botTimerFrame == 1)
            {
                GamePbx.Image = DrawGame();

                if (!game.Iterate)
                {
                    game.StartPlayer();
                    BotTimer.Stop();
                }
            }
            else if (botTimerFrame == 4)
            {
                int[] tile = game.GetComputerSequence();
                GamePbx.Image = DrawGameWithSelectedTile(tile[0], tile[1]);
            }
            botTimerFrame++;
            if (botTimerFrame == 5)
            {
                botTimerFrame = 0;
            }
        }

        /// <summary>
        /// When the timer is ticking
        /// Show the empty game and verify if we finished and if we won
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event</param>
        private void PlayerTimer_Tick(object sender, EventArgs e)
        {
            GamePbx.Image = DrawGame();
            PlayerTimer.Stop();
            if (!game.Iterate)
            {
                (string, bool) result = game.PlayerTurn();
                if (result.Item2)
                {
                    game.AddToSequence();
                    BotTimer.Start();
                }
                else
                {
                    MessageBox.Show(result.Item1);
                    StartBtn.Enabled = true;
                    DifficultyGbx.Enabled = true;
                    StyleGbx.Enabled = true;
                    game.AddScore(NamePlayerTextbox.Text);
                }
            }
        }


        // #############################
        // The function when clicking on the start or quit buttons
        // #############################


        /// <summary>
        /// When clicking the start button
        /// Start a new game of lights
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event</param>
        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (NamePlayerTextbox.Text == "")
            {
                MessageBox.Show("Veuillez donner un nom");
                return;
            }
            game.CreateSequence();
            BotTimer.Start();
            StartBtn.Enabled = false;
            DifficultyGbx.Enabled = false;
            StyleGbx.Enabled = false;
        }

        /// <summary>
        /// When clicking the quit button
        /// Closes the game
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event</param>
        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// When clicking the score button
        /// Open a second form to show the 10 best scores
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event</param>
        private void ScoreBtn_Click(object sender, EventArgs e)
        {
            new ScoreForm(game.Get10BestScores()).Show();
        }


        // #############################
        // The function for drawing the game
        // #############################


        /// <summary>
        /// Draw the game
        /// </summary>
        /// <returns>A bitmap with the drawing of the game</returns>
        private Bitmap DrawGame()
        {
            Bitmap bmp = new Bitmap(252, 252);
            Graphics g = Graphics.FromImage(bmp);
            for(int i = 0; i < 3; i++)
            {
                for(int ii = 0; ii < 3; ii++)
                {
                    switch(shape)
                    {
                        case "Ronds":
                            g.FillEllipse(offColors[i, ii], new Rectangle(i * (size + 4), ii * (size + 4), size, size));
                            break;
                        case "Rectangles":
                            g.FillRectangle(offColors[i, ii], new Rectangle(i * (size + 4), ii * (size + 4), size, size));
                            break;
                        case "Arrondi":
                            g.FillPath(offColors[i, ii], RoundRect(new Rectangle(i * (size + 4), ii * (size + 4), size, size)));
                            break;
                    }
                }
            }
            g.Dispose();
            return bmp;
        }

        /// <summary>
        /// Draw the game with the last clicked tile lit up
        /// </summary>
        /// <param name="x">The x of the tile</param>
        /// <param name="y">The y of the tile</param>
        /// <returns>A bitmap with the drawing of the game</returns>
        private Bitmap DrawGameWithSelectedTile(int x, int y)
        {
            Bitmap bmp = DrawGame();
            Graphics g = Graphics.FromImage(bmp);
            switch (shape)
            {
                case "Ronds":
                    g.FillEllipse(litColors[x, y], new Rectangle(x * (size + 4) + 2, y * (size + 4) + 2, size - 4, size - 4));
                    break;
                case "Rectangles":
                    g.FillRectangle(litColors[x, y], new Rectangle(x * (size + 4) + 2, y * (size + 4) + 2, size - 4, size - 4));
                    break;
                case "Arrondi":
                    g.FillPath(litColors[x, y], RoundRect(new Rectangle(x * (size + 4) + 2, y * (size + 4) + 2, size - 4, size - 4)));
                    break;
            }
            g.Dispose();
            return bmp;
        }

        /// <summary>
        /// Draw a rectangle with rounded angles
        /// I wrote this code with the help of György Kőszeg with his code from this source:
        /// https://stackoverflow.com/a/33853557
        /// To show that I understand what this code do, I will put comments in the code explaining what each lines do
        /// </summary>
        /// <param name="boundaries">The boundaries of the rounded rectangle</param>
        /// <returns>The path to take to draw a rounded rectangle</returns>
        private GraphicsPath RoundRect(Rectangle boundaries)
        {
            // This is the size of the arcs for each corners, it has a radius of 15 px and so it's size is of 30 (the diameter).
            // I put it at the location of the rectangle we want to draw, which is the top left corner.
            Rectangle arc = new Rectangle(boundaries.Location, new Size(30, 30));

            // Here I instanciate the path, here it is empty but I am gonna give it some directions to take.
            GraphicsPath rect = new GraphicsPath();

            // Here are the direction, I draw an arc with AddArc, which add an arc from a hypothetical circle the size of the rectangle "arc".
            // In the parameters I give it the rectangle so that it knows the size and position of it,
            // the second parameter is the starting angle of the arc, here 180,
            // the third one is the angle of the arc, 90 degree.
            // Like in math, 0 degree is the most right position of the circle, unlike in math, however, the angles go in reverse (90 degree in math is "┗", 90 degree here is "┎").
            rect.AddArc(arc, 180, 90);

            // Here I change the position of the arc for the second angle since if I wouldn't, I would get a small circle instead of a rounded rectangle
            // Sincce we set the position from the top left, I have to reduce 30 pixels of the size of the rectangle or my rectangle would be 30 pixels to big
            arc.X = boundaries.Right - 30;

            // Same as the first angle but for the top right one.
            rect.AddArc(arc, 270, 90);

            // Same as the second angle but for the bottom right one.
            arc.Y = boundaries.Bottom - 30;

            // Same as the first angle but for the bottom right one.
            rect.AddArc(arc, 0, 90);

            // Same as the second angle but for the bottom left one.
            // Here I don't remove 30 pixels since we uses the left side to move the arc location.
            arc.X = boundaries.Left;

            // Same as the first angle but for the bottom left one.
            rect.AddArc(arc, 90, 90);

            // Here I only have 4 arcs from each corners of the rectangles but nothing in between, this adds a line between each arcs to complete the rectangle.
            rect.CloseFigure();

            // Here I return the path I made so that we can draw it on the bitmap of the game
            return rect;
        }
    }
}