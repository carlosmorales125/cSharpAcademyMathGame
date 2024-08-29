namespace MathGame;

public class Addition
{
    private readonly GameUtilities gameUtilities;
    private int NumberOfQuestions = 5;
    
    public Addition(GameUtilities gameUtilities)
    {
        this.gameUtilities = gameUtilities;
    }
    private int Add(int a, int b)
    {
        return a + b;
    }
    
    private string GetQuestion(int a, int b)
    {
        return $"What is {a} + {b}?";
    }
    
    private string GetIncorrectAnswerMessage(int tries)
    {
        return $"Sorry! Try again. You have {tries} left.";
    }
    
    private string GetCorrectAnswerMessage(int a, int b)
    {
        return $"Correct! {a} + {b} is {a + b}. Good job!";
    }

    public void Play()
    {
        int gamePlayCount = 0;

        while (gamePlayCount < NumberOfQuestions)
        {
            int firstNumber = gameUtilities.RandomNumber(1, 11);
            int secondNumber = gameUtilities.RandomNumber(1, 11);
            int sum = Add(firstNumber, secondNumber);

            Console.WriteLine();
            Console.WriteLine(GetQuestion(firstNumber, secondNumber));

            string userInput = Console.ReadLine();
            int userAnswer = -1;
            int tries = 0;

            while (userAnswer != sum && tries < 2)
            {
                if (int.TryParse(userInput, out userAnswer))
                {
                    if (userAnswer == sum)
                    {
                        Console.WriteLine(GetCorrectAnswerMessage(firstNumber, secondNumber));
                        gameUtilities.AddToHistory(new Answer
                        {
                            GameType = GameType.Addition,
                            FirstNumber = firstNumber,
                            SecondNumber = secondNumber,
                            AnswerValue = userAnswer,
                            IsCorrect = true
                        });
                        break;
                    }
                    else
                    {
                        Console.WriteLine(GetIncorrectAnswerMessage(2 - tries));
                        Console.WriteLine(GetQuestion(firstNumber, secondNumber));
                        gameUtilities.AddToHistory(new Answer
                        {
                            GameType = GameType.Addition,
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
                    Console.WriteLine(gameUtilities.GetInvalidInputMessage(2 - tries));
                }
                userInput = Console.ReadLine();
            }
            gamePlayCount++;
        }
    }
}