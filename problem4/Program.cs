using System.Diagnostics;

namespace problem4;

public static class Program
{
    public static void Main()
    {
        var stopWatch = new Stopwatch();
        
        while (true)
        {
            Console.WriteLine("Enter number of digits in a number to check for a palindrome: ");
    
            var input = Console.ReadLine();
            if (input == "exit")
            {
                Environment.Exit(0);
                break;
            }

            var intParsed = int.TryParse(input, out int digits);
            if (!intParsed || digits <= 1)
            {
                continue;
            }
            
            stopWatch.Start();
            var productFound = TryGetLargestPalindromeProduct(digits, out PalindromeProduct? palindromeProduct);
            stopWatch.Stop();
            
            if (productFound)
            {
                Console.WriteLine("The largest palindrome found was " + palindromeProduct?.Number + " made up of " + palindromeProduct?.Product1 + " x " + palindromeProduct?.Product2);
            }
            else
            {
                Console.WriteLine("No palindrome found from products.");
            }

            Console.WriteLine("Calculation time: " + stopWatch.Elapsed);
            stopWatch.Reset();
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