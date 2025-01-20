using Snake;
using System;

Random random = new Random();
Coordinates gridDimensions = new Coordinates(50, 20);
Coordinates snakePosition = new Coordinates(10, 1);
Coordinates applePosition = new Coordinates(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
List<Coordinates> snakePositionHistory = new List<Coordinates>();
int snakeLength = 1;
int frameDelay = 100; // Renders at 100ms per frame
Direction movementDirection = Direction.Down;
int score = 0;
int highScore = 0;

// Set the console window size and buffer size
Console.SetWindowSize(gridDimensions.X + 1, gridDimensions.Y + 5);
Console.SetBufferSize(gridDimensions.X + 1, gridDimensions.Y + 5);
Console.CursorVisible = false;

// Draw the grid boundaries
for (int y = 0; y < gridDimensions.Y; y++)
{
    for (int x = 0; x < gridDimensions.X; x++)
    {
        if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }
    }
}

// Main game loop
while (true)
{
    // Update the score
    Console.SetCursorPosition(0, gridDimensions.Y);
    Console.Write($"Score: {score}      ");

    // Move the snake
    snakePosition.ApplyMovementDirection(movementDirection);

    // Check for collisions with the apple
    if (snakePosition.Equals(applePosition))
    {
        snakeLength++;
        score++;
        applePosition = new Coordinates(random.Next(1, gridDimensions.X - 1), random.Next(1, gridDimensions.Y - 1));
    }
    // Check for collisions with the walls or itself
    else if (snakePosition.X == 0 || snakePosition.Y == 0 ||
        snakePosition.X == gridDimensions.X - 1 || snakePosition.Y == gridDimensions.Y - 1 ||
        snakePositionHistory.Contains(snakePosition))
    {
        if (score > highScore)
        {
            highScore = score;
            Console.Write($"High Score: {highScore}      ");
        }

        // Clear the snake from the grid
        foreach (Coordinates position in snakePositionHistory)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(" ");
        }

        // Reset game
        score = 0;
        snakeLength = 1;
        snakePosition = new Coordinates(10, 1);
        snakePositionHistory.Clear();
        movementDirection = Direction.Down;
        continue;
    }

    // Add the snake's new position to the history
    snakePositionHistory.Add(new Coordinates(snakePosition.X, snakePosition.Y));
    if (snakePositionHistory.Count > snakeLength)
    {
        // Remove the tail of the snake
        Coordinates tail = snakePositionHistory[0];
        snakePositionHistory.RemoveAt(0);

        // Clear the tail from the console
        Console.SetCursorPosition(tail.X, tail.Y);
        Console.Write(" ");
    }

    // Draw the snake head
    Console.SetCursorPosition(snakePosition.X, snakePosition.Y);
    Console.Write("■");

    // Draw the apple
    Console.SetCursorPosition(applePosition.X, applePosition.Y);
    Console.Write("a");

    // Handle user input
    DateTime time = DateTime.Now;
    while ((DateTime.Now - time).Milliseconds < frameDelay)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    movementDirection = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    movementDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    movementDirection = Direction.Down;
                    break;
            }
        }
    }
}
