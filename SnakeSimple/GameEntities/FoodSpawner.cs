using SnakeSimple.GameConfigurations;

namespace SnakeSimple.GameEntities
{
    public class FoodSpawner
    {
        public Food SpawnFood(GameField field)
        {
            var position = new Position(0, 0);
            do
            {
                position = GetRandomPosition();
            }
            while (!field.CellIsEmpty(position));
            return new Food(position);
        }

        private Position GetRandomPosition()
        {
            var random = new Random();
            var randomX = random.Next(GameConfiguration.FieldWidth);
            var randomY = random.Next(GameConfiguration.FieldHeight);
            return new Position(randomX, randomY);
        }
    }
}
