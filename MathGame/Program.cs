using MathGame;

GameUtilities gameUtilities = new GameUtilities();
Addition addition = new Addition(gameUtilities);
Subtraction subtraction = new Subtraction(gameUtilities);
bool exit = false;

while (!exit)
{
    gameUtilities.PresentGameMenu();
    string userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "1":
            addition.Play();
            break;
        case "2":
            subtraction.Play();
            break;
        case "3":
            Console.WriteLine("Multiplication game is not implemented yet.");
            break;
        case "4":
            Console.WriteLine("Division game is not implemented yet.");
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