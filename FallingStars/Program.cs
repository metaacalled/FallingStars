// Author: Javier Fernández Cano
// Date: 27 Nov 2023



namespace myWorkspace
{
    public class FernandezJaviCode
    {
        public static void Main(string[] args)
        {
            // Constants

            const int playerLocationNum = 5;
            const int starLocationNum = 1;
            const int wallLocationNum = -1;

            const string gameEndedMessage = "Se acabó! Has conseguido recaudar {0} estrellas.";

            int[,] gameMap = {
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 },
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }
            };

            // Variables

            bool mainLoopController = true;
            bool isWall = false;

            int playerXPosition = 6;
            int playerYPosition = 6;
            int playerScore = 0;
            int defaultLoopsUntilRespawn = 3;
            int defaultLoopsUntilWallRespawn = 6;
            int loopsUntilRespawn = defaultLoopsUntilRespawn;
            int loopsUntilWallRespawn = defaultLoopsUntilWallRespawn;

            ConsoleKeyInfo KeyPressed;
            Random rnd = new Random();

            // Main code

            Console.CursorVisible = false;

            while (mainLoopController)
            {
                if (!isWall)
                {
                    if (loopsUntilRespawn != 0)
                    {
                        loopsUntilRespawn--;
                    }
                    else
                    {
                        int rndX = rnd.Next(0, gameMap.GetLength(0));
                        int rndY = rnd.Next(0, gameMap.GetLength(1));
                        while (gameMap[rndY, rndX] == wallLocationNum || gameMap[rndY, rndX] == playerLocationNum || gameMap[rndY, rndX] == starLocationNum)
                        {
                            rndX = rnd.Next(0, gameMap.GetLength(0));
                            rndY = rnd.Next(0, gameMap.GetLength(1));
                        }
                        gameMap[rndY, rndX] = starLocationNum;
                        loopsUntilRespawn = defaultLoopsUntilRespawn;
                    }

                    if (loopsUntilWallRespawn != 0)
                    {
                        loopsUntilWallRespawn--;
                    }
                    else
                    {
                        int rndX = rnd.Next(0, gameMap.GetLength(0));
                        int rndY = rnd.Next(0, gameMap.GetLength(1));
                        while (gameMap[rndY, rndX] == wallLocationNum || gameMap[rndY, rndX] == playerLocationNum)
                        {
                            rndX = rnd.Next(0, gameMap.GetLength(0));
                            rndY = rnd.Next(0, gameMap.GetLength(1));
                        }
                        gameMap[rndY, rndX] = wallLocationNum;
                        loopsUntilWallRespawn = defaultLoopsUntilWallRespawn;
                    }

                    gameMap[playerYPosition, playerXPosition] = playerLocationNum;

                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine();
                    }

                    Console.Write("\t\t\t\t\t\t      Estrellas: {0}", playerScore);

                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine();
                    }

                    for (int i = 0; i < gameMap.GetLength(0); i++)
                    {
                        Console.Write("\t\t\t\t\t");
                        for (int j = 0; j < gameMap.GetLength(1); j++)
                        {
                            if (gameMap[i, j] == wallLocationNum)
                            {
                                Console.Write("\\|/");
                            }
                            else if (gameMap[i, j] == starLocationNum)
                            {
                                Console.Write("[*]");
                            }
                            else if (gameMap[i, j] == 0)
                            {
                                Console.Write("   ");
                            }
                            else if (gameMap[i, j] == playerLocationNum)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\\o/");
                                Console.ResetColor();
                            }
                        }
                        Console.WriteLine();
                    }
                }

                isWall = false;

                KeyPressed = Console.ReadKey();

                if (KeyPressed.Key == ConsoleKey.DownArrow)
                {
                    gameMap[playerYPosition, playerXPosition] = 0;
                    if (gameMap[playerYPosition + 1, playerXPosition] != -1)
                    {
                        playerYPosition++;
                    }
                    else
                    {
                        isWall = !isWall;
                    }
                }
                else if (KeyPressed.Key == ConsoleKey.UpArrow)
                {
                    gameMap[playerYPosition, playerXPosition] = 0;
                    if (gameMap[playerYPosition - 1, playerXPosition] != -1)
                    {
                        playerYPosition--;
                    }
                    else
                    {
                        isWall = !isWall;
                    }
                }
                else if (KeyPressed.Key == ConsoleKey.RightArrow)
                {
                    gameMap[playerYPosition, playerXPosition] = 0;
                    if (gameMap[playerYPosition, playerXPosition + 1] != -1)
                    {
                        playerXPosition++;
                    }
                    else
                    {
                        isWall = !isWall;
                    }
                }
                else if (KeyPressed.Key == ConsoleKey.LeftArrow)
                {
                    gameMap[playerYPosition, playerXPosition] = 0;
                    if (gameMap[playerYPosition, playerXPosition - 1] != -1)
                    {
                        playerXPosition--;
                    }
                    else
                    {
                        isWall = !isWall;
                    }
                }

                if (gameMap[playerYPosition, playerXPosition] == 1)
                    playerScore++;

                if (gameMap[playerYPosition, playerXPosition - 1] == wallLocationNum && gameMap[playerYPosition, playerXPosition + 1] == wallLocationNum && gameMap[playerYPosition - 1, playerXPosition] == wallLocationNum && gameMap[playerYPosition + 1, playerXPosition] == wallLocationNum)
                {
                    Console.Write("\n\n" + gameEndedMessage, playerScore);
                    mainLoopController = !mainLoopController;
                    Console.ReadLine();
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                }
            }
        }
    }
}