using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/**
* Project      : Lights - Game3
* Description  : A game of Simon with 9 lights, each light has different colors, the game start with 1 light and continue  until the player do a mistake or get at max value
* File         : Score.cs
* Author       : Weber Jamie
* Date         : 02 October 2023
**/
namespace Game3
{
    /// <summary>
    /// The class for the score of a player
    /// </summary>
    public class Score : IComparable<Score>
    {
        /// <summary>
        /// The scroe obtained
        /// </summary>
        public int score;

        /// <summary>
        /// The name of the player
        /// </summary>
        public string name;

        /// <summary>
        /// The date and time of when the score was saved
        /// </summary>
        public DateTime date;

        /// <summary>
        /// Get the score as a string
        /// </summary>
        public string Get { get { return $"{name} : {score} | {date.Day}/{date.Month}/{date.Year} - {date.Hour}:{date.Minute}"; } }

        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="score">The score of the player</param>
        /// <param name="date">The date of saving if old score</param>
        public Score(string name, int score, DateTime? date)
        {
            this.name = name;
            this.score = score;
            if (date == null)
            {
                date = DateTime.Now;
            }
            this.date = (DateTime)date!;
        }

        /// <summary>
        /// Empty score for serialization
        /// </summary>
        public Score()
        {
        }

        /// <summary>
        /// Compare to another score to see which is bigger
        /// </summary>
        /// <param name="other">The other score to compare to</param>
        /// <returns>negative if bigger, positive if smaller, 0 if the same size</returns>
        public int CompareTo(Score? other)
        {
            return other!.score - this.score;
        }
    }
}
