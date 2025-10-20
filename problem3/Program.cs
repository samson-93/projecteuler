namespace problem3;

public static class Program 
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter a number: ");
            var input = Console.ReadLine();

            if (input == "exit")
            {
                Environment.Exit(0);
                break;
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
    
    private static ulong GetPrimeFactor(ulong number)
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