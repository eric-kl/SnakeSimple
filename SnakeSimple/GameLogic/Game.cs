using SnakeSimple.GameConfigurations;
using SnakeSimple.GameEntities;

namespace SnakeSimple.GameLogic
{
    public class Game
    {
        private GameField field;
        private Snake snake;
        private CollisionLogic collisionLogic;
        private Food food;
        private FoodSpawner spawner;

        private bool gameRunning = true;

        public void Start()
        {
            PrintWelcome();
            WaitForAnyKey();
            Restart();
        }

        public void Restart()
        {
            Setup();
            Run();
            ShowGameOver();
        }

        private void Setup()
        {
            collisionLogic = new CollisionLogic();
            spawner = new FoodSpawner();
            field = new GameField();

            var startPosition = new Position(GameConfiguration.FieldWidth / 2, GameConfiguration.FieldHeight / 2);
            snake = new Snake(startPosition);
           
            var foodPosition = Position.Add(startPosition, Position.FromDirection(Direction.Left));
            food = new Food(foodPosition);
        }

        private void Run()
        {
            gameRunning = true;
            while (gameRunning)
            {
                HandleInput();
                UpdateGame();
                Draw();
                Thread.Sleep(GameConfiguration.TickLength);
            }
        }

        private void HandleInput()
        {
            if (!Console.KeyAvailable)
            {
                return;
            }
            var key = Console.ReadKey(true).Key;
            if (ControlMapper.IsQuitKey(key))
            {
                gameRunning = false;
            }
            snake.HandleInput(key);
        }

        private void UpdateGame()
        {
            var collision = collisionLogic.HandleCollision(snake, field);
            if (collision == CollisionEvent.GameBorder)
            {
                gameRunning = false;
            }
            if (collision == CollisionEvent.Self)
            {
                gameRunning = false;
            }
            if (collision == CollisionEvent.Food)
            {
                snake.Grow();
                snake.Move();
                SpawnFood();
            }
            if (collision == CollisionEvent.None)
            {
                snake.Move();
            }
        }

        private void SpawnFood()
        {
            food = spawner.SpawnFood(field);
        }

        private void Draw()
        {
            Console.SetCursorPosition(0, 0);
            field.Clear();
            food.DrawToField(field);
            snake.DrawToField(field);
            field.PrintToConsole();
        }

        private void PrintWelcome()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Welcome to Start press any Key");
        }

        private void WaitForAnyKey()
        {
            Console.ReadKey();
            Console.Clear();
        }

        private void ShowGameOver()
        {
            Console.WriteLine("GAME OVER! Press R to restart or any other key to quit");
            if (WaitForRestart())
            {
                Console.Clear();
                Restart();
            }
        }

        private bool WaitForRestart()
        {
            var key = Console.ReadKey().Key;
            return ControlMapper.IsRestartKey(key);
        }
    }
}
