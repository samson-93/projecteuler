while (true)
{
    var input = Console.ReadLine();
    var validInput = int.TryParse(input, out int inputNumber);
    
    if (!validInput) continue;
    
    Console.WriteLine(GetSmallestPerfectRemainder(inputNumber));
}

int GetSmallestPerfectRemainder(int number)
{
    int smallestPerfectRemainderSource = 1;
    
    int i = number;
    while (i > 0)
    {
        if (smallestPerfectRemainderSource % i > 0)
        {
            smallestPerfectRemainderSource++;
            i = number;
        }
        
        i--;
    }
    
    return smallestPerfectRemainderSource;
}