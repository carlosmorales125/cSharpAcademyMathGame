namespace MathGame;

public class Answer
{
    public GameType GameType;
    public int FirstNumber;
    public int SecondNumber;
    public int AnswerValue;
    public bool IsCorrect;
}

public enum GameType
{
    Addition = 1,
    Subtraction,
    Multiplication,
    Division,
}