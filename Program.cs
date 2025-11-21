Console.WriteLine("Welcome to the MathGame!\n");
Console.Write("Please enter your name to get started: ");

// ------------ Helper variable declarations ---------------------------------
string? playerName = Console.ReadLine();
Random rand = new();
decimal playerScore = 0;
string? input;
decimal winningScore = 10;
decimal scoreAdder = 0;
int num1;
int num2;
int expectedAnswer;

//  ------------Set multiplier values for each game --------------------------
decimal additionMultiplier = 1.0m;
decimal subtractionMultiplier = 1.1m;
decimal multiplyMultiplier = 1.5m;
decimal divisionMultiplier = 1.75m;

Console.WriteLine();
Console.WriteLine($"Thanks for playing {playerName}\n");
Console.WriteLine("You will be pick questions for each math operation. For each correct answer you will gain points and for each wrong answer you will lose the same number of points (including multiplier).");

do
{
    Console.WriteLine("1. Addition\t\t(1.0x score multiplier)");
    Console.WriteLine("2. Subtraction\t\t(1.1x score multiplier)");
    Console.WriteLine("3. Multiplication\t(1.5x score multiplier)");
    Console.WriteLine("4. Division\t\t(1.75x score multiplier)\n");

    Console.WriteLine("Please select the math game you wish to play (Enter 1 - 4) or type 'exit' to finish playing:");
    input = Console.ReadLine();

    num1 = rand.Next(11);
    num2 = rand.Next(11);

    switch (input)
    {
        case "1":
            Console.WriteLine("You selected 1. Addition");
            additionGame();
            Console.ReadLine();
            break;
        case "2":
            Console.WriteLine("You selected 2. Subtraction");
            subtractionGame();
            Console.ReadLine();
            break;
        case "3":
            Console.WriteLine("You selected 3. Multiplication");
            multiplyGame();
            Console.ReadLine();
            break;
        case "4":
            Console.WriteLine("You selected 4. Division");
            Console.WriteLine("This game is not complete, come back later...");
            Console.ReadKey(intercept: true);
            break;
        case "exit":
            Console.WriteLine("Thanks for playing! Press enter to leave...");
            Console.ReadLine();
            //TODO: add in summary of score and how close player was to winning
            break;
        default:
            Console.WriteLine("Invalid Entry. Please try again.");
            break;
    }

    void updateScore(decimal value, decimal multiplier)
    {
        // updates current score by value * multiplier
        playerScore += (value * multiplier);
    }

    void getValidGame(int num1, int num2)
    {
        // ONLY REQUIRED FOR DIVISION GAME:
        // Takes in two values and determines if the result will be a whole integer. If the result is false this method will re-roll the numbers until a valid equationis reached
        decimal resultCheck = 0;

        do
        {
            resultCheck = (num1 / num2) % 1;
            if (resultCheck != 0)
            {
                Console.WriteLine("Invalid equation, re-rolling numbers...\n");
                num1 = rand.Next(11);
                num2 = rand.Next(11);
            }
        }
        while (resultCheck != 0);
    }

    void additionGame()
    {
        string? input = null;
        expectedAnswer = num1 + num2;

        while (input == null)
        {
            Console.WriteLine($"What is {num1} + {num2}?");
            input = Console.ReadLine();
        }

        if (Convert.ToInt32(input) == expectedAnswer)
        {
            updateScore(1, additionMultiplier);
            Console.WriteLine($"Correct! Your score is now {playerScore} points");
        }

        else
        {
            updateScore(-1, additionMultiplier);
            Console.WriteLine($"Sorry, that is incorrect. The answer is {expectedAnswer}. Your score is now {playerScore} points.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(intercept: true);
    }

    void subtractionGame()
    {
        string? input = null;
        expectedAnswer = num1 - num2;

        while (input == null)
        {
            Console.WriteLine($"What is {num1} - {num2}?");
            input = Console.ReadLine();
        }

        if (Convert.ToInt32(input) == expectedAnswer)
        {
            updateScore(1, subtractionMultiplier);
            Console.WriteLine($"Correct! Your score is now {playerScore} points");
        }

        else
        {
            updateScore(-1, subtractionMultiplier);
            Console.WriteLine($"Sorry, that is incorrect. The answer is {expectedAnswer}. Your score is now {playerScore} points.");
        }
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey(intercept: true);
    }

    void multiplyGame()
    {
        string? input = null;
        expectedAnswer = num1 * num2;

        while (input == null)
        {
            Console.WriteLine($"What is {num1} x {num2}?");
            input = Console.ReadLine();
        }

        if (Convert.ToInt32(input) == expectedAnswer)
        {
            updateScore(1, multiplyMultiplier);
            Console.WriteLine($"Correct! Your score is now {playerScore} points");
        }

        else
        {
            updateScore(-1, subtractionMultiplier);
            Console.WriteLine($"Sorry, that is incorrect. The answer is {expectedAnswer}. Your score is now {playerScore} points.");
        }
        Console.WriteLine("Press any key to contine...");
        Console.ReadKey(intercept: true);
    }

    static void divisionGame()
    {
        //TODO: Add division game logic, including equation validity
    }
}
while (input != "exit");