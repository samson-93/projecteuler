namespace ProjectEuler.EulerSolutions;

public class Problem10 : IEulerSolution
{
    public string Name => "Problem 10";

    public string Description => "This program will return the sum of all primes found below the provided integer.";
    
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Enter upper bound: ");
            
            var input = Console.ReadLine();
            if (input == "exit")
            {
                return;
            }

            if (!int.TryParse(input, out int upperBound))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }
            
            var sum = GetSumOfPrimesBelowUpperBound(upperBound);
            
            Console.WriteLine("The sum of primes found below " + upperBound + ": " + sum);
        }
    }

    private long GetSumOfPrimesBelowUpperBound(int upperBound)
    {
        var primeList = new List<long> { 2 };

        for (long i = 3; i <= upperBound; i += 2)
        {
            var primeFound = true;
            foreach (var prime in primeList)
            {
                // i dont know why this is true yet
                if (prime * prime > i)
                {
                    break;
                }
                
                if (i % prime == 0)
                {
                    primeFound = false;
                    break;
                }
            }

            if (primeFound)
            {
                primeList.Add(i);
            }
        }
    
        return primeList.Sum();
    }
}