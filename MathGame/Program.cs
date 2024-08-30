using MathGame;

GameUtilities gameUtilities = new GameUtilities();
bool exit = false;

Console.WriteLine("Welcome to the Math Game!");

while (!exit)
{
    gameUtilities.PresentGameMenu();
    string userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "1":
            gameUtilities.Play(GameType.Addition);
            break;
        case "2":
            gameUtilities.Play(GameType.Subtraction);
            break;
        case "3":
            gameUtilities.Play(GameType.Multiplication);
            break;
        case "4":
            gameUtilities.Play(GameType.Division);
            break;
        case "5":
            gameUtilities.ShowHistory();
            break;
        case "6":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid menu input.");
            break;
    }
}

Console.WriteLine("Thank you for playing the Math Game!");