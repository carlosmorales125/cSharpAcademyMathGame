namespace MathGame;

public class GameUtilities
{
    private readonly History _historyService = new();
    private const int NumberOfQuestions = 5;
    
    private static int RandomNumber(int min, int max)
    {
        var random = new Random();
        return random.Next(min, max);
    }
    
    private static (int, int) GetDivisionNumbers()
    {
        var random = new Random();
        var firstNumber = random.Next(1, 11);
        int secondNumber;

        do
        {
            secondNumber = random.Next(1, 11);
        } while (firstNumber % secondNumber != 0);

        return (firstNumber, secondNumber);
    }
    
    public void PresentGameMenu()
    {
        Console.WriteLine("Please select a math operator and you will get 5 questions:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Show me my game history");
        Console.WriteLine("6. Exit");
    }
    
    private void AddToHistory(Answer answer)
    {
        _historyService.Add(answer);
    }
    
    public void ShowHistory()
    {
        _historyService.ShowHistory();
    }
    
    private static string GetQuestion(int a, int b, string mathOperator)
    {
        return $"What is {a} {mathOperator} {b}?";
    }
    
    public static string GetMathOperator(GameType gameType)
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
    
    private int GetAnswer(int a, int b, string mathOperator)
    {
        return mathOperator switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => a / b,
            _ => throw new ArgumentOutOfRangeException(nameof(mathOperator), mathOperator, null)
        };
    }
    
    public void Play(GameType gameType)
    {
        var gamePlayCount = 0;
        
        var mathOperator = GetMathOperator(gameType);

        while (gamePlayCount < NumberOfQuestions)
        {
            int firstNumber, secondNumber;

            if (gameType == GameType.Division)
            {
                (firstNumber, secondNumber) = GetDivisionNumbers();
            }
            else
            {
                firstNumber = RandomNumber(1, 11);
                secondNumber = RandomNumber(1, 11);
            }
            
            var answer = GetAnswer(firstNumber, secondNumber, mathOperator);

            Console.WriteLine();
            Console.WriteLine(GetQuestion(firstNumber, secondNumber, mathOperator));

            var userInput = Console.ReadLine();
            int userAnswer;
            var tries = 0;

            do
            {
                if (int.TryParse(userInput, out userAnswer))
                {
                    if (userAnswer == answer)
                    {
                        Console.WriteLine(
                            $"Correct! {firstNumber} {mathOperator} {secondNumber} is {answer}. Good job!");
                        AddToHistory(new Answer
                        {
                            GameType = gameType,
                            FirstNumber = firstNumber,
                            SecondNumber = secondNumber,
                            AnswerValue = userAnswer,
                            IsCorrect = true
                        });
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Sorry! Try again. You have {2 - tries} left.");
                        Console.WriteLine(GetQuestion(firstNumber, secondNumber, mathOperator));
                        AddToHistory(new Answer
                        {
                            GameType = gameType,
                            FirstNumber = firstNumber,
                            SecondNumber = secondNumber,
                            AnswerValue = userAnswer,
                            IsCorrect = false
                        });
                    }

                    tries++;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter a number. You have {2 - tries} tries left.");
                }

                userInput = Console.ReadLine();
            } while (userAnswer != answer && tries < 2);
            
            if (userAnswer != answer)
            {
                Console.WriteLine($"Sorry but your answers were incorrect! The correct answer is {answer}.");
                Console.WriteLine("You can check the history to see your answers.");
                AddToHistory(new Answer
                {
                    GameType = gameType,
                    FirstNumber = firstNumber,
                    SecondNumber = secondNumber,
                    AnswerValue = userAnswer,
                    IsCorrect = false
                });
            }
            gamePlayCount++;
        }
    }
}