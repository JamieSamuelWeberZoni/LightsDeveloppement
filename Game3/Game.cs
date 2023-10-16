using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/**
* Project      : Lights - Game3
* Description  : A game of Simon with 9 lights, each light has different colors, the game start with 1 light and continue  until the player do a mistake or get at max value
* File         : Game.cs
* Author       : Weber Jamie
* Date         : 02 October 2023
**/
namespace Game3
{
    /// <summary>
    /// The class that manages the game mechanics
    /// </summary>
    internal class Game
    {
        /// <summary>
        /// The sequence to play
        /// </summary>
        private int[]? sequence;

        /// <summary>
        /// The number of the current light
        /// </summary>
        private int iterate = 0;

        /// <summary>
        /// The score of the player
        /// </summary>
        private int score = 0;

        /// <summary>
        /// The max score possible
        /// </summary>
        private int max = 1024;

        /// <summary>
        /// Whether the player has done a flawless job or not
        /// </summary>
        private bool isPlayerRight = true;

        private List<Score> scores;

        /// <summary>
        /// If it's the player phase
        /// </summary>
        private bool playGame = false;

        /// <summary>
        /// Verify if the iterator has reached the score or not
        /// </summary>
        public bool Iterate { get { return iterate < score; } }

        /// <summary>
        /// Getter of the score
        /// </summary>
        public int Score { get { return score; } }

        /// <summary>
        /// Getter of the max score
        /// </summary>
        public int Max { get { return max; } }

        /// <summary>
        /// The constructor of the class
        /// Verify if an xml file exist at a certain place and get the scores of it if it does
        /// </summary>
        public Game()
        {
            string currDir = Path.GetDirectoryName(Application.ExecutablePath)!;
            if (!Directory.Exists(currDir + "\\lightsSave"))
            {
                Directory.CreateDirectory(currDir + "\\lightsSave");
            }
            string save = $"{currDir}\\lightsSave\\score.xml";
            if (File.Exists(save))
            {
                XmlSerializer serialize = new XmlSerializer(typeof(List<Score>));
                FileStream file = new FileStream(save, FileMode.Open);
                byte[] buffer = new byte[file.Length];
                file.Read(buffer, 0, (int)file.Length);
                MemoryStream stream = new MemoryStream(buffer);
                scores = (List<Score>)serialize.Deserialize(stream)!;
                file.Close();
            }
            else
            {
                scores = new List<Score>();
            }
        }

        /// <summary>
        /// Save the list of scores to an xml document
        /// </summary>
        public void Save()
        {
            string currDir = Path.GetDirectoryName(Application.ExecutablePath)!;
            string save = $"{currDir}\\lightsSave\\score.xml";
            FileStream file = File.Exists(save) ? File.OpenWrite(save) : File.Create(save);
            XmlSerializer serialize = new XmlSerializer(typeof(List<Score>));
            serialize.Serialize(file, scores);
            file.Close();
        }

        /// <summary>
        /// Create a sequence for the computer
        /// </summary>
        public void CreateSequence()
        {
            score = 0;
            sequence = new int[0];
            isPlayerRight = true;
            AddToSequence();
        }

        /// <summary>
        /// Add to the sequence one more action
        /// </summary>
        public void AddToSequence()
        {
            score++;
            int[] oldSeq = sequence!;
            sequence = new int[score];
            for (int i = 0; i < oldSeq.Length; i++)
            {
                sequence[i] = oldSeq[i];
            }
            sequence[sequence.Length - 1] = new Random().Next(0, 9);
            iterate = 0;
        }

        /// <summary>
        /// Get the current tile of the computer
        /// </summary>
        /// <returns>The tile in a int array of 2</returns>
        public int[] GetComputerSequence()
        {
            int x = (int)Math.Floor(sequence![iterate] / 3.0);
            int y = sequence![iterate] - x * 3;
            iterate++;
            return new int[] { x, y };
        }

        /// <summary>
        /// Check if player is right and returns if the game is on
        /// </summary>
        /// <param name="x">The x position of the player</param>
        /// <param name="y">The y posîtion of the player</param>
        /// <returns>True if you can play the game, False if not</returns>
        public bool CheckPlayer(int x, int y)
        {
            if (!playGame)
            {
                return false;
            }
            int playerNbr = x * 3 + y;
            bool response = playerNbr == sequence![iterate];
            isPlayerRight = response ? isPlayerRight : false;
            iterate++;
            return true;
        }

        /// <summary>
        /// Start of the player phase
        /// </summary>
        public void StartPlayer()
        {
            iterate = 0;
            playGame = true;
        }

        /// <summary>
        /// End of the player phase
        /// </summary>
        /// <returns>If the player has won</returns>
        public bool EndGame()
        {
            playGame = false;
            return isPlayerRight;
        }

        /// <summary>
        /// Verify if the game is finished and if the player won or lost
        /// </summary>
        /// <returns>A string of the message if the game is finished and a bool whether the game is finished or not</returns>
        public (string, bool) PlayerTurn()
        {
            if (EndGame())
            {
                if (score >= max)
                {
                    return ($"Gagné! Vous avez atteint le maximum de {max} points", false);
                }
                return ("", true);
            }
            else
            {
                return ($"Perdu! Vous avez atteint un score de {score} point{(score > 1 ? "s" : "")}", false);
            }
        }

        /// <summary>
        /// Add a score to the list of scores and save this list
        /// </summary>
        /// <param name="name"></param>
        public void AddScore(string name)
        {
            scores.Add(new Score(name, score, null));
            Save();
        }

        /// <summary>
        /// Get a list of string representing the 10 best scores or less if there aren't enough scores
        /// </summary>
        /// <returns>A list of string representing scores</returns>
        public string[] Get10BestScores()
        {
            if (scores.Count >= 10)
            {
                string[] scoreTxt = new string[10];
                List<Score> tenBest = scores.OrderBy((Score item) => item).Take(10).ToList();
                for(int i = 0; i < 10; i++)
                {
                    scoreTxt[i] = tenBest[i].Get;
                }
                return scoreTxt;
            }
            else
            {
                int count = scores.Count;
                string[] scoreTxt = new string[count];
                List<Score> tenBest = scores.OrderBy((Score item) => item).Take(count).ToList();
                for (int i = 0; i < count; i++)
                {
                    scoreTxt[i] = tenBest[i].Get;
                }
                return scoreTxt;
            }

        }
    }
}
