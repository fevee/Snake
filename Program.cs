using Snake;

Coordinates gridDimensions = new Coordinates(50, 20);
Coordinates snakePosition = new Coordinates(10, 1);
Random rand = new Random();
Coordinates applePosition = new Coordinates(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y -1));
int frameDelay = 100; //Renders at 100ms per frame
Direction movementDirection = Direction.Down;
int score = 0;

List<Coordinates> snakePositionHistory = new List<Coordinates>();
int snakeLength = 1;

// Set the console window size and buffer size, leaving extra space for system messages
Console.SetWindowSize(gridDimensions.X + 1, gridDimensions.Y + 5); 
Console.SetBufferSize(gridDimensions.X + 1, gridDimensions.Y + 5);  

// Print the grid
while(true)
{
    Console.Clear();
    Console.WriteLine("Score: " + score);
    snakePosition.ApplyMovementDirection(movementDirection);

    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coordinates currentCoordinate = new Coordinates(x, y);

            if (snakePosition.Equals(currentCoordinate) || snakePositionHistory.Contains(currentCoordinate))
                Console.Write("■");
            else if (applePosition.Equals(currentCoordinate))
                Console.Write("a");
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                Console.Write("#");
            else
                Console.Write(" ");
        }
        Console.WriteLine();  // Move to the next line after drawing each row
    }

    if (snakePosition.Equals(applePosition))
    {
        snakeLength++;
        score++;
        applePosition = new Coordinates(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
    }
    else if (snakePosition.X == 0 || snakePosition.Y == 0 || snakePosition.X == gridDimensions.X - 1 || snakePosition.Y == gridDimensions.Y - 1 || snakePositionHistory.Contains(snakePosition))
    {
        score = 0;
        snakeLength = 1;
        snakePosition = new Coordinates(10, 1);
        snakePositionHistory.Clear();
        movementDirection = Direction.Down;
        continue;
    }

    snakePositionHistory.Add(new Coordinates(snakePosition.X, snakePosition.Y));

    if (snakePositionHistory.Count > snakeLength)
        snakePositionHistory.RemoveAt(0);

    DateTime time = DateTime.Now;

    while((DateTime.Now - time).Milliseconds < frameDelay)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;
            
            switch(key)
            {
                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left;
                    break;
                case ConsoleKey.UpArrow:
                    movementDirection = Direction.Up;
                    break;
                case ConsoleKey.RightArrow:
                    movementDirection = Direction.Right;
                    break;
                case ConsoleKey.DownArrow:
                    movementDirection = Direction.Down;
                    break;
            }
        }
    }
}
