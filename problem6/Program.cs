while (true)
{
    var input = Console.ReadLine();
    var validInput = int.TryParse(input, out int inputNumber);
    
    if (!validInput) continue;
    
    int sumOfSquares = GetSumOfSquaresUpTo(inputNumber);
    int squareOfSums = GetSquareOfSumsUpTo(inputNumber);
    
    Console.WriteLine(Math.Abs(sumOfSquares - squareOfSums));
}

int GetSumOfSquaresUpTo(int inputNumber)
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

int GetSquareOfSumsUpTo(int inputNumber)
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