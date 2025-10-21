namespace ProjectEuler.EulerSolutions;

public class Problem5 : IEulerSolution
{
    public string Name => "Problem 5";
    
    public string Description => "This program will return the smallest perfect remainder for a given number.";
    
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
            
            var validInput = int.TryParse(input, out int inputNumber);
            if (!validInput)
            {
                continue;
            }
            
            Console.WriteLine("Smallest perfect remainder found: " + GetSmallestPerfectRemainder(inputNumber) + '\n');
        }
    }
    
    private ulong GetSmallestPerfectRemainder(int number)
    {
        var ulongNum = (ulong)number;
        
        ulong smallestPerfectRemainderSource = 1;
        ulong i = ulongNum;
        
        while (i > 0)
        {
            if (smallestPerfectRemainderSource % i > 0)
            {
                smallestPerfectRemainderSource++;
                i = ulongNum;
            }
        
            i--;
        }
    
        return smallestPerfectRemainderSource;
    }
}