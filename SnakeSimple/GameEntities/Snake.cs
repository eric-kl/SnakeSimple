using SnakeSimple.GameConfigurations;

namespace SnakeSimple.GameEntities
{
    public class Snake
    {
        private Position headPosition;
        private List<Position> bodyParts = new List<Position>();

        public Direction direction = Direction.Down;

        private int length;

        private int BodyLength()
        {
            return length - 1;
        }

        public Snake(Position startPosition)
        {
            headPosition = startPosition;
            length = GameConfiguration.InitialSnakeLength;
        }

        public void HandleInput(ConsoleKey key)
        {
            direction = ControlMapper.DirectionFromKey(key);
        }

        public void Grow()
        {
            length += 1;
        }

        public void Move()
        {
            bodyParts.Add(headPosition);
            headPosition = GetNextHeadPosition();
            ShrinkBodyToLength();
        }

        public Position GetNextHeadPosition()
        {
            var moveVector = Position.FromDirection(direction);
            return Position.Add(headPosition, moveVector);
        }

        public bool CollidesWithBody(Position position)
        {
            //Compare with all body parts except the last one because it will move out the way
            for (int i = 0; i < bodyParts.Count - 1; i++)
            {
                if (Position.Equals(bodyParts[i], position))
                {
                    return true;
                }
            }
            return false;
        }

        private void ShrinkBodyToLength()
        {
            while (bodyParts.Count > BodyLength())
            {
                bodyParts.RemoveAt(0);
            }
        }

        public void DrawToField(GameField field)
        {
            field.DrawToCell(headPosition, Sprites.SnakeHead);
            DrawBodyToField(field);
        }

        private void DrawBodyToField(GameField field)
        {
            foreach (var bodyPart in bodyParts)
            {
                field.DrawToCell(bodyPart, Sprites.SnakeBody);
            }
        }
    }
}
