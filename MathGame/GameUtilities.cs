namespace MathGame;

public class GameUtilities
{
    private readonly History _historyService = new();
    public string GetInvalidInputMessage(int tries)
    {
        return $"Invalid input. Please enter a number. You have {tries} tries left.";
    }
    
    public int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    
    public void PresentGameMenu()
    {
        Console.WriteLine("Welcome to the Math Game!");
        Console.WriteLine("Please select a game type:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Show Me My Game History");
        Console.WriteLine("6. Exit");
    }
    
    public void AddToHistory(Answer answer)
    {
        _historyService.Add(answer);
    }
    
    public void ShowHistory()
    {
        _historyService.ShowHistory();
    }
}