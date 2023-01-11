namespace SnakeSimple.GameConfigurations
{
    public static class ControlMapper
    {
        public static Direction DirectionFromKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W: return Direction.Up;
                case ConsoleKey.A: return Direction.Left;
                case ConsoleKey.S: return Direction.Down;
                case ConsoleKey.D: return Direction.Right;
                default: return Direction.None;
            }
        }

        public static bool IsQuitKey(ConsoleKey key)
        {
            return key == ConsoleKey.Q;
        }

        public static bool IsRestartKey(ConsoleKey key)
        {
            return key == ConsoleKey.R;
        }
    }
}
