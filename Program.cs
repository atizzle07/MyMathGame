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


// -------------- Game Requirements ------------------------------------------

// TODO - You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.


// --------------- Challenges ------------------------------------------------
// UPGRADE - Add a timer to the program to see how quickly they can get to the point number
// UPGRADE - Implement difficulty levels
// UPGRADE - Implement a "random" game where the user will get a random operation rather than picking
// UPGRADE - Just use a single method for the entire game instead of one for each operation.

do
{
    Console.WriteLine("1. Addition\t\t(1.0 points)");
    Console.WriteLine("2. Subtraction\t\t(1.1 points)");
    Console.WriteLine("3. Multiplication\t(1.5 points)");
    Console.WriteLine("4. Division\t\t(1.75 points)\n");

    Console.WriteLine("Please select the math game you wish to play (Enter 1 - 4) or type 'exit' to finish playing:");
    input = Console.ReadLine();

    num1 = rand.Next(11);
    num2 = rand.Next(11);

    switch (input)
    {
        case "1":
            Console.WriteLine("You selected 1. Addition");
            AdditionGame();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(intercept: true);
            break;
        case "2":
            Console.WriteLine("You selected 2. Subtraction");
            SubtractionGame();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(intercept: true);
            break;
        case "3":
            Console.WriteLine("You selected 3. Multiplication");
            MultiplyGame();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(intercept: true);
            break;
        case "4":
            Console.WriteLine("You selected 4. Division");
            DivisionGame();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(intercept: true);
            break;
        case "exit":
            Console.WriteLine("Thanks for playing!");
            GameSummary();
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("Invalid Entry. Please try again.");
            break;
    }

    void UpdateScore(decimal value, decimal multiplier)
    {
        // updates current score by value * multiplier
        playerScore += (value * multiplier);
    }

    void ValidNumbers(ref int num1, ref int num2)
    {
        // ONLY REQUIRED FOR DIVISION GAME:
        // Takes in two values and determines if the result will be a whole integer. If the result is false this method will re-roll the numbers until a valid equationis reached
        
        int resultCheck = 1;
        do
        {
            
            if (num2 == 0) //check for divide by zero condition. If true, re-roll numbers
            {
                System.Console.WriteLine("Attempted to divide by zero, re-rolling numbers...");
                num1 = rand.Next(11);
                num2 = rand.Next(1,11);
                continue;
            }

            resultCheck = num1 % num2;
            System.Console.WriteLine($"Num1: {num1}");
            System.Console.WriteLine($"Num2: {num2}");
            System.Console.WriteLine($"mod: {resultCheck}");
            if (resultCheck != 0)
            {
                Console.WriteLine($"Invalid equation, re-rolling numbers...\n");
                num1 = rand.Next(11);
                num2 = rand.Next(1,11);
            }
            else
            {
                System.Console.WriteLine("Equation valid!");
            }
        }
        while (resultCheck != 0);
    }

    void AdditionGame()
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
            UpdateScore(1, additionMultiplier);
            Console.WriteLine($"Correct! Your score is now {playerScore} points");
        }

        else
        {
            UpdateScore(-1, additionMultiplier);
            Console.WriteLine($"Sorry, that is incorrect. The answer is {expectedAnswer}. Your score is now {playerScore} points.");
        }
    }

    void SubtractionGame()
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
            UpdateScore(1, subtractionMultiplier);
            Console.WriteLine($"Correct! Your score is now {playerScore} points");
        }

        else
        {
            UpdateScore(-1, subtractionMultiplier);
            Console.WriteLine($"Sorry, that is incorrect. The answer is {expectedAnswer}. Your score is now {playerScore} points.");
        }
    }

    void MultiplyGame()
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
            UpdateScore(1, multiplyMultiplier);
            Console.WriteLine($"Correct! Your score is now {playerScore} points");
        }

        else
        {
            UpdateScore(-1, multiplyMultiplier);
            Console.WriteLine($"Sorry, that is incorrect. The answer is {expectedAnswer}. Your score is now {playerScore} points.");
        }
    }

    void DivisionGame()
    {
        string? input = null;
        ValidNumbers(ref num1, ref num2);
        decimal expectedAnswer = num1 / num2;
        System.Console.WriteLine($"Num1: {num1}   Num2: {num2}   Answer: {expectedAnswer}");
        while (input == null)
        {
            Console.WriteLine($"What is {num1} / {num2}?");
            input = Console.ReadLine();
        }

        if (Convert.ToInt32(input) == expectedAnswer)
        {
            UpdateScore(1, divisionMultiplier);
            Console.WriteLine($"Correct! Your score is now {playerScore} points");
        }

        else
        {
            UpdateScore(-1, divisionMultiplier);
            Console.WriteLine($"Sorry, that is incorrect. The answer is {expectedAnswer}. Your score is now {playerScore} points.");
        }
    }

    void GameSummary()
    {
        
        Console.WriteLine();
        // TODO - add summary output
    }
}
while (input != "exit");