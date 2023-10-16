using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**
* Project      : Lights - Game3
* Description  : A game of Simon with 9 lights, each light has different colors, the game start with 1 light and continue  until the player do a mistake or get at max value
* File         : ScoreForm.cs
* Author       : Weber Jamie
* Date         : 16 October 2023
**/
namespace Game3
{
    /// <summary>
    /// The form to show the best scores
    /// </summary>
    public partial class ScoreForm : Form
    {
        /// <summary>
        /// The list of scores
        /// </summary>
        private string[] scores;

        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="scores">The list of scores</param>
        public ScoreForm(string[] scores)
        {
            InitializeComponent();
            this.scores = scores;
        }

        /// <summary>
        /// When loading the form
        /// Show the scores
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event</param>
        private void ScoreForm_Load(object sender, EventArgs e)
        {
            bool multipleScores = scores.Length > 1;
            TitleLbl.Text = $"Le{(multipleScores ? $"s {scores.Length}" : "")} meilleur{(multipleScores ? "s" : "")} score{(multipleScores ? "s" : "")}!";
            ScoresLbl.Text = "";
            foreach (string score in scores)
            {
                ScoresLbl.Text += $"{score}\r\n";
            }
        }
    }
}
