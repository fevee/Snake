using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// Represents coordinates within the game play grid
    /// </summary>
    internal class Coordinates
    {
        private int x;
        private int y;

        public int X { get { return x; }}

        public int Y { get { return y; }}

        /// <summary>
        /// Initializes a new instance of the Coordinates class
        /// </summary>
        /// <param name="x">The x-coordinate of the position</param>
        /// <param name="y">The y-coordinate of the position</param>
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current Coordinate instance.
        /// Two coordinates are equal if they x and y values match.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>True if the specified object is equal to the current instance, otherwise false</returns>
        public override bool Equals(object? obj)
        {
            if ((obj == null || !GetType().Equals(obj.GetType())))
                return false;

            Coordinates other = (Coordinates)obj;
            return x == other.x && y == other.y;
        }

        /// <summary>
        /// Updates the coordinates based on the specified movvement direction.
        /// </summary>
        /// <param name="direction">The direction of movement (Up, Down, Left, Right)</param>
        public void ApplyMovementDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
                case Direction.Up:
                    y--;
                    break;
                case Direction.Down:
                    y++;
                    break;
            }
        }

    }
}
