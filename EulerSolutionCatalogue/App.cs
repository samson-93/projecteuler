using System.Diagnostics;
using ProjectEuler.EulerSolutions;

namespace ProjectEuler;

public class App(IEnumerable<IEulerSolution> EulerSolutions)
{
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Which #projecteuler solution would you like to run?");

            var input = Console.ReadLine();
            if (input == "exit")
            {
                Environment.Exit(0);
                break;
            }
            
            var intParsed = int.TryParse(input, out var number);
            if (!intParsed || !TryRunSolution(number))
            {
                Console.WriteLine("Failed to load the solution for the specified problem.");
            }
        }
    }
    
    private bool TryRunSolution(int problemNumber)
    {
        var targetSolution = EulerSolutions.FirstOrDefault(x => x.Name.Equals($"Problem {problemNumber}"));
        if (targetSolution == null)
        {
            Debug.WriteLine($"Solution for Problem {problemNumber} was not found.");
            return false;
        }
        
        Console.WriteLine("Loading program...\n");
        Console.WriteLine(targetSolution.Description);
        
        targetSolution.Run();
        
        Console.WriteLine();
        
        return true;
    }
}