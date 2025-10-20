while (true)
{
    var input = Console.ReadLine();
    var validInput = int.TryParse(input, out int inputNumber);
    
    if (!validInput) continue;
    
    Console.WriteLine(GetPrimeIndex(inputNumber));
}

int GetPrimeIndex(int number)
{
    var primeList = new List<int>(number);
    primeList.Add(2);

    var current = 3;
    while (primeList.Count < number)
    {
        var primeFound = true;
        foreach (var primeNumber in primeList)
        {
            if (current % primeNumber == 0)
            {
                primeFound = false;
            }
        }

        if (primeFound)
        {
            primeList.Add(current);
        }
        
        current++;
    }
    
    return primeList.Max();
}