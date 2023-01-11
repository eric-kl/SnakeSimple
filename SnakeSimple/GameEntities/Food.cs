
using SnakeSimple.GameConfigurations;

namespace SnakeSimple.GameEntities
{
    public class Food
    {
        private Position position;

        public Food(Position startPosition)
        {
            position = startPosition;
        }

        public void DrawToField(GameField field)
        {
            field.DrawToCell(position, Sprites.Food);
        }
    }
}
