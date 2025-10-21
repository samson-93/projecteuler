namespace ProjectEuler.EulerSolutions;

public class Problem6 : IEulerSolution
{
    public string Name => "Problem 6";
        
    public string Description => "This program will return the absolute difference between the sum of squares of a " +
                                 "sequence of integers (1^2 + 2^2 + 3^2 + ...) and the square of the sums of a sequence " +
                                 "of integers ((1 + 2 + 3 + ...)^2) counting from 1 up to the provided limit.";

    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "exit")
            {
                return;
            }
            
            var validInput = int.TryParse(input, out int inputNumber);
            if (!validInput)
            {
                continue;
            }
    
            int sumOfSquares = GetSumOfSquaresUpTo(inputNumber);
            int squareOfSums = GetSquareOfSumsUpTo(inputNumber);
    
            Console.WriteLine(Math.Abs(sumOfSquares - squareOfSums));
        }
    }

    private int GetSumOfSquaresUpTo(int inputNumber)
    {
        int sum = 0;
        int i = inputNumber;
        while (i > 0)
        {
            sum += i * i;
            i--;
        }

        return sum;
    }

    private int GetSquareOfSumsUpTo(int inputNumber)
    {
        int sum = 0;
        int i = inputNumber;
        while (i > 0)
        {
            sum += i;
            i--;
        }

        return sum * sum;
    }
}