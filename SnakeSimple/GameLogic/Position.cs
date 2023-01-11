using System.ComponentModel;

namespace SnakeSimple
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y) { X = x; Y = y; }

        public static Position Add(Position position, Position other)
        {
            var x = position.X + other.X;
            var y = position.Y + other.Y;
            return new Position(x, y);
        }

        public static bool Equals(Position position1, Position position2)
        {
            return position1.X == position2.X && position1.Y == position2.Y;
        }

        public static Position FromDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left: return new Position(-1, 0);
                case Direction.Down: return new Position(0, 1);
                case Direction.Right: return new Position(1, 0);
                case Direction.Up: return new Position(0, -1);
                default: return new Position(0, 0);
            }
           
        }
    }
}
