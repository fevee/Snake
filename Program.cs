using Snake;

Coordinates gridDimensions = new Coordinates(75, 25);
Coordinates snakePosition = new Coordinates(10, 1);

// Set the console window size and buffer size, leaving extra space for system messages
Console.SetWindowSize(gridDimensions.X + 1, gridDimensions.Y + 8); 
Console.SetBufferSize(gridDimensions.X + 1, gridDimensions.Y + 8);  

// Print the grid
for (int y = 0; y < gridDimensions.Y; y++)
{
    for (int x = 0; x < gridDimensions.X; x++)
    {
        Coordinates currentCoordinate = new Coordinates(x, y);

            if (snakePosition.Equals(currentCoordinate))
                Console.Write("■");
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
                Console.Write("#");
            else
                Console.Write(" ");
    }
    Console.WriteLine();  // Move to the next line after drawing each row
}

