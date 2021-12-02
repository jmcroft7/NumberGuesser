// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

GetAppInfo();
GreetUser();
while (true)
{

    Random random = new Random();

    int lowerLimit = 0;

    int upperLimit = 11;

    int correctNumber = random.Next(lowerLimit, upperLimit);

    int userGuess = 0;

    int guessCount = 0;

    Console.WriteLine("Guess a number between 1 and 10");


    // While userGuess is not correct
    while (userGuess != correctNumber)
    {
        string input = Console.ReadLine();

        // Make sure its a number
        if (!int.TryParse(input, out userGuess))
        {
            PrintColorMessage(ConsoleColor.Red, "Please use an actual number");

            continue;
        }
        userGuess = Int32.Parse(input);

        // Game logic
        if (userGuess > upperLimit - 1 || userGuess < lowerLimit)
        {
            PrintColorMessage(ConsoleColor.Red, "Guess is out of range of answer possibilities! Please try again!");
            guessCount++;
        }
        else if (userGuess > correctNumber)
        {
            PrintColorMessage(ConsoleColor.Red, "Guess is too high! Please try again!");
            guessCount++;
        }

        else
        {
            PrintColorMessage(ConsoleColor.Red, "Guess is too low! Please try again!");
            guessCount++;
        }
    }

    PrintColorMessage(ConsoleColor.Yellow, $"CORRECT! You guessed the answer in {guessCount} tries!");

    Console.WriteLine("Play Again? [Y or N]");

    string answer = Console.ReadLine().ToUpper();

    if (answer == "Y" || answer == "YES")
    {
        continue;
    }
    else if (answer == "N" || answer == "NO")
    {
        return;
    }
    else
    {
        PrintColorMessage(ConsoleColor.Red, $"{answer} is not an option. Thank you.");
        return;
    }
}           

static void GetAppInfo()
{
    string appName = "Number Guesser";
    string appVersion = "1.0.0";
    string appAuthor = "Johnathan Croft";

    Console.ForegroundColor = ConsoleColor.Blue;

    Console.WriteLine($"{appName}: Version {appVersion} by {appAuthor}");

    Console.ResetColor();
}

static void GreetUser()
{
    Console.WriteLine("What is your name?");

    string inputName = Console.ReadLine();

    if (!Regex.IsMatch(inputName, "^[a-z]+$", RegexOptions.IgnoreCase))
    {
        PrintColorMessage(ConsoleColor.Red, "Please enter a name!");
        GreetUser();
    }
    else
    {
    string fixedName = char.ToUpper(inputName[0]) + inputName.Substring(1);

    PrintColorMessage(ConsoleColor.Blue, $"Hello {fixedName}, Lets play a game!");
    }

}

// Print color message
static void PrintColorMessage(ConsoleColor color, string message)
{
    // Change text color
    Console.ForegroundColor = color;

    // Tell user its not a number
    Console.WriteLine(message);

    // Reset text color
    Console.ResetColor();
}
