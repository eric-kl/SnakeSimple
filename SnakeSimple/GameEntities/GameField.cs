using SnakeSimple.GameConfigurations;

namespace SnakeSimple.GameEntities
{
    public class GameField
    {
        private static int FieldWidthWithBorders = GameConfiguration.FieldWidth + 2;
        private static int FieldHeightWithBorders = GameConfiguration.FieldHeight + 2;

        private char[,] field;

        public GameField()
        {
            field = new char[GameConfiguration.FieldWidth + 2, GameConfiguration.FieldHeight + 2];
            DrawBorders();
            Clear();
        }

        public void Clear()
        {
            for (int x = 0; x < GameConfiguration.FieldWidth; x++)
            {
                for (int y = 0; y < GameConfiguration.FieldHeight; y++)
                {
                    DrawToCell(x, y, Sprites.Empty);
                }
            }
        }

        private void DrawBorders()
        {
            for (int i = 0; i < FieldWidthWithBorders; i++)
            {
                DrawToField(i, 0, Sprites.Border);
                DrawToField(i, FieldHeightWithBorders - 1, Sprites.Border);
            }
            for (int i = 0; i < FieldHeightWithBorders; i++)
            {
                DrawToField(0, i, Sprites.Border);
                DrawToField(FieldWidthWithBorders - 1, i, Sprites.Border);
            }
        }

        public char SpriteAt(Position position)
        {
            return field[position.X + 1, position.Y + 1];
        }

        public bool CellIsEmpty(Position position)
        {
            return SpriteAt(position) == ' ';
        }

        public void DrawToCell(Position position, char symbol)
        {
            DrawToCell(position.X, position.Y, symbol);
        }

        public void DrawToCell(int x, int y, char symbol)
        {
            DrawToField(x + 1, y + 1, symbol);
        }

        private void DrawToField(int x, int y, char symbol)
        {
            field[x, y] = symbol;
        }

        public void PrintToConsole()
        {
            for (int y = 0; y < FieldHeightWithBorders; y++)
            {
                string s = "";
                for (int x = 0; x < FieldWidthWithBorders; x++)
                {
                    s += field[x, y];
                }
                Console.WriteLine(s);
            }
        }
    }
}
