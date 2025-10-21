namespace ProjectEuler.EulerSolutions;

public class Problem7 : IEulerSolution
{
    public string Name => "Problem 7";
    public string Description => "This program will return the prime number located at the specified index (i.e. for input '5' the result would be '11' since '11' is the 5th prime number).";
    
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Specify a prime number by sequence value: ");
            
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
    
            Console.WriteLine(GetPrimeAt(inputNumber));
        }
    }
    
    private static int GetPrimeAt(int number)
    {
        var primeList = new List<int>(number) { 2 };

        var current = 3;
        while (primeList.Count < number)
        {
            var primeFound = true;
            foreach (var _ in primeList.Where(primeNumber => current % primeNumber == 0))
            {
                primeFound = false;
            }

            if (primeFound)
            {
                primeList.Add(current);
            }
        
            current++;
        }
    
        return primeList.Max();
    }
}