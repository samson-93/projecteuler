namespace ProjectEuler.EulerSolutions;

public class Problem3 : IEulerSolution
{
    public string Name => "Problem 3";
    public string Description => "This program will attempt to find the largest prime factor for a given integer input.";
    
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Enter a number: ");
            
            var input = Console.ReadLine();
            if (input == "exit")
            {
                return;
            }

            var intParsed = ulong.TryParse(input, out var number);
            if (intParsed)
            {
                Console.WriteLine("The largest prime factor found was " + GetPrimeFactor(number));
            }
            else
            {
                Console.WriteLine("Enter a valid number.");
            }
        }
    }

    // super inefficient, rewrite in the future sometime
    private ulong GetPrimeFactor(ulong number)
    {
        uint min = 2;
        uint max = (uint)Math.Ceiling(Math.Sqrt(number));

        while (min <= max)
        {
            if (number % min == 0)
            {
                return GetPrimeFactor(number / min);
            }
        
            min++;
        }

        return number;
    }
}