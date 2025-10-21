namespace ProjectEuler.EulerSolutions;

public class Problem4 : IEulerSolution
{
    public string Name => "Problem 4";

    public string Description =>
        "This program will find the largest product that produces a palindrome from a given input. " +
        "The input will be an integer that will represent the number of digits in both factors. " +
        "For example, given the input value of 2 the result will be 9009 which is the product of 91 x 99, each factor consisting of 2 digits.";

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Enter number of digits in a number to check for a palindrome: ");
    
            var input = Console.ReadLine();
            if (input == "exit")
            {
                return;
            }

            var intParsed = int.TryParse(input, out int digits);
            if (!intParsed || digits <= 1)
            {
                continue;
            }
            
            var productFound = TryGetLargestPalindromeProduct(digits, out PalindromeProduct? palindromeProduct);
            
            if (productFound)
            {
                Console.WriteLine("The largest palindrome found was " + palindromeProduct?.Number + " made up of " + palindromeProduct?.Product1 + " x " + palindromeProduct?.Product2);
            }
            else
            {
                Console.WriteLine("No palindrome found from products.");
            }
        }
    }
    
    private static bool TryGetLargestPalindromeProduct(int digits, out PalindromeProduct? largestPalindromeProduct)
    {
        largestPalindromeProduct = null;
        
        int largestPotentialProduct = int.Parse(new string('9', digits));
        int largestDisallowedProduct = int.Parse(new string('9', digits - 1));
    
        var foundPalindromeProducts = new List<PalindromeProduct>();
        
        for (int i = largestPotentialProduct; i > largestDisallowedProduct; i--)
        {
            for (int j = largestPotentialProduct; j > largestDisallowedProduct; j--)
            {
                var sampledProduct = i * j;
                
                if (IsPalindrome(sampledProduct))
                {
                    foundPalindromeProducts.Add(new PalindromeProduct(sampledProduct, j, i));
                }
            }
        }
        
        var largestFoundPalindromeProduct = foundPalindromeProducts.FirstOrDefault();
        if (foundPalindromeProducts.Count == 0 || largestFoundPalindromeProduct == null)
        {
            return false;
        }
        
        // aggregate check
        foreach (var palindromeProduct in foundPalindromeProducts)
        {
            if (palindromeProduct.Number > largestFoundPalindromeProduct.Number)
            {
                largestFoundPalindromeProduct = palindromeProduct;
            }
        }
    
        largestPalindromeProduct = largestFoundPalindromeProduct;
        return true;
    }
    
    private static bool IsPalindrome(int number)
    {
        var stringifiedNumber = number.ToString();
    
        var length = stringifiedNumber.Length / 2;
        int i = 0;
        
        while (i < length)
        {
            if (stringifiedNumber[i] != stringifiedNumber[(stringifiedNumber.Length - i - 1)])
            {
                return false;
            }
    
            i++;
        }
    
        return true;
    }
}

internal record PalindromeProduct(int Number, int Product1, int Product2);