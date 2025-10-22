namespace ProjectEuler.EulerSolutions;

public class Problem14 : IEulerSolution
{ 
    public string Name => "Problem 14";
    public string Description => "This program calculates the largest Collatz sequence found for an integer equal or less than the provided value.";
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Enter integer: ");
            
            var input = Console.ReadLine();
            if (input == "exit")
            {
                return;
            }

            if (!long.TryParse(input, out long upperBound))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }
            
            Console.WriteLine("Longest Collatz sequence found with starting number: " + GetLongestCollatzSequence(upperBound));
        }
    }

    private long CurrentCollatzCount = 0;
    
    private long GetLongestCollatzSequence(long upperBound)
    {
        long startingNumberWithLongestCollatzSequence = upperBound;
        long longestCollatzSequenceCount = 0;
        
        for (long i = upperBound; i > 0; i--)
        {
            CurrentCollatzCount = 0;
            
            GetCollatzSequence(i);
            
            if (CurrentCollatzCount > longestCollatzSequenceCount)
            {
                longestCollatzSequenceCount = CurrentCollatzCount;
                startingNumberWithLongestCollatzSequence = i;
            }
        }
        
        return startingNumberWithLongestCollatzSequence;
    }

    private void GetCollatzSequence(long number)
    {
        while (true)
        {
            CurrentCollatzCount++;

            switch (number)
            {
                case >= 1 and 1:
                    return;
                case >= 1 when number % 2 == 0:
                    number /= 2;
                    continue;
                case >= 1:
                    number = 3 * number + 1;
                    continue;
                case <= 0:
                    throw new Exception("Integer is out of bounds!");
            }

            break;
        }
    }
}