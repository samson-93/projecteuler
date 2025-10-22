namespace ProjectEuler.EulerSolutions;

public class Problem15 : IEulerSolution
{
    public string Name => "Problem 15";
    public string Description => "Lattice Paths: Finds the unique number of routes through a grid of the given size.";
    public void Run()
    {
        Console.WriteLine("Enter Grid Size (n where size = n x n): ");
        var gridSize = Convert.ToInt32(Console.ReadLine());
        
        var uniqueRoutesFound = FindUniqueRoutes(gridSize);
        Console.WriteLine("Found " + uniqueRoutesFound + " unique routes from top-left of grid to bottom-right of grid.");
    }

    private long FindUniqueRoutes(long gridSize)
    {
        return GetBinomialCoefficient((2 * gridSize), gridSize);
    }

    // gpt had to give me a reeducation here :<
    private long GetBinomialCoefficient(long n, long k)
    {
        long aggregate = 1;

        for (long i = 0; i < k; i++)
        {
            aggregate *= n - i;
            aggregate /= i + 1;
        }
        
        return aggregate;
    }
}