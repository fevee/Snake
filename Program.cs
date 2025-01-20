using Snake;

Coordinates gridDimensions = new Coordinates(50, 20);
Coordinates snakePosition = new Coordinates(10, 1);
Random rand = new Random();
Coordinates applePosition = new Coordinates(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y -1));
int frameDelay = 100; //Renders at 100ms per frame
Direction movementDirection = Direction.Down;

// Set the console window size and buffer size, leaving extra space for system messages
Console.SetWindowSize(gridDimensions.X + 1, gridDimensions.Y + 5); 
Console.SetBufferSize(gridDimensions.X + 1, gridDimensions.Y + 5);  

// Print the grid
while(true)
{
    Console.Clear();
    snakePosition.ApplyMovementDirection(movementDirection);

    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coordinates currentCoordinate = new Coordinates(x, y);

            if (snakePosition.Equals(currentCoordinate))
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
