using SnakeSimple.GameConfigurations;
using SnakeSimple.GameEntities;

namespace SnakeSimple.GameLogic
{
    public class CollisionLogic
    {
        public CollisionEvent HandleCollision(Snake snake, GameField field)
        {
            var nextHeadPosition = snake.GetNextHeadPosition();
            if (CheckWallCollision(nextHeadPosition))
            {
                return CollisionEvent.GameBorder;
            }
            if (snake.CollidesWithBody(nextHeadPosition))
            {
                return CollisionEvent.Self;
            }
            if (field.SpriteAt(nextHeadPosition) == Sprites.Food)
            {
                return CollisionEvent.Food;
            }
            return CollisionEvent.None;
        }

        private bool CheckWallCollision(Position target)
        {
            return target.X < 0
                || target.Y < 0
                || target.X >= GameConfiguration.FieldWidth
                || target.Y >= GameConfiguration.FieldHeight;
        }
    }
}
