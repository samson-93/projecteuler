namespace ProjectEuler.EulerSolutions;

public class Problem12 : IEulerSolution
{
    public string Name => "Problem 12";
    public string Description => "This program will return the first triangle number that has at least the specified number of divisors.";
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Enter minimum number of divisors: ");
            
            var input = Console.ReadLine();
            if (input == "exit")
            {
                return;
            }

            if (!int.TryParse(input, out int divisorMin))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }
            
            var triangleNumber = GetTriangleNumberWithMinimumNumberOfDivisors(divisorMin);
            
            Console.WriteLine("The first triangle number with " + divisorMin + " number of divisors is " + triangleNumber);
        }
    }

    private long GetTriangleNumberWithMinimumNumberOfDivisors(int divisorMin)
    {
        int triangleNumberIndex = 1;
        
        while (true)
        {
            var triangleNumber = GenerateTriangleNumber(triangleNumberIndex);
            var divisorCount = GetDivisorCount(triangleNumber);

            if (divisorCount >= divisorMin)
            {
                return triangleNumber;
            }
            
            triangleNumberIndex++;
        }
    }
    
    private long GenerateTriangleNumber(int triangleNumberIndex)
    {
        return (long)triangleNumberIndex * (triangleNumberIndex + 1) / 2;
    }

    // gpt helped here
    private int GetDivisorCount(long number)
    {
        if (number <= 1)
        {
            return 1;
        }

        int divisorCount = 0;
        long sqrt = (long)Math.Sqrt(number);

        for (long divisor = 1; divisor <= sqrt; divisor++)
        {
            if (number % divisor == 0)
            {
                divisorCount += 2;
            }
        }

        if (sqrt * sqrt == number)
        {
            divisorCount--;
        }

        return divisorCount;
    }
}