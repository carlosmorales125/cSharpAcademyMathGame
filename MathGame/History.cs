namespace MathGame;

public class History
{
    private readonly List<Answer> _answers = new();

    public void Add(Answer answer)
    {
        _answers.Add(answer);
    }
    
    private string GetMathOperator(GameType gameType)
    {
        return gameType switch
        {
            GameType.Addition => "+",
            GameType.Subtraction => "-",
            GameType.Multiplication => "*",
            GameType.Division => "/",
            _ => throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null)
        };
    }

    public void ShowHistory()
    {
        Console.WriteLine("Game History:");
        Console.WriteLine();

        if (_answers.Count == 0)
        {
            Console.WriteLine("No game history found.");
        }
        else
        {
            foreach (var answer in _answers)
            {
                Console.WriteLine("--------------------------------------------------");
                string mathOperator = GetMathOperator(answer.GameType);
                var correctMessage = answer.IsCorrect ? "Your answer was Correct" : "Your answer was Incorrect";
                Console.WriteLine($"{answer.GameType} - {answer.FirstNumber} {mathOperator} {answer.SecondNumber} = {answer.AnswerValue} - {correctMessage}");
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}