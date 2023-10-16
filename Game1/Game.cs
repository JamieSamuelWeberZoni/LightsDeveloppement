using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Project      : Lights - Game1
 * Description  : A game of Simon with 9 lights, each light is played once
 * File         : Game.cs
 * Author       : Weber Jamie
 * Date         : 02 October 2023
**/
namespace Game1
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
        /// Whether the player has done a flawless job or not
        /// </summary>
        private bool isPlayerRight = true;

        /// <summary>
        /// If it's the player phase
        /// </summary>
        private bool playGame = false;

        public bool Iterate { get { return iterate < 9; } }

        /// <summary>
        /// Create a sequence for the computer
        /// </summary>
        public void CreateSequence()
        {
            List<int> numbers = Enumerable.Range(0, 9).ToList();
            sequence = new int[numbers.Count];
            for (int i = 0; i < sequence.Length; i++)
            {
                int index = new Random().Next(0, numbers.Count);
                sequence[i] = numbers[index];
                numbers.RemoveAt(index);
            }
            iterate = 0;
            isPlayerRight = true;
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
            return new int[] {x, y};
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
    }
}
