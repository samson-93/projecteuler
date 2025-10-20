while (true)
{
    Console.WriteLine("Enter a number: ");
    var input = Console.ReadLine();

    if (input == "exit")
    {
        Environment.Exit(0);
        break;
    }
    
    var number = Int64.Parse(input);
    Console.WriteLine("The largest prime factor found was " + GetPrimeFactor(number));
}


Int64 GetPrimeFactor(Int64 number)
{
    int min = 2;
    int max = (int)Math.Ceiling(Math.Sqrt(number));

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