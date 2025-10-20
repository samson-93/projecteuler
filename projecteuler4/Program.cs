namespace projecteuler4;

public static class Program
{
    public static void Main()
    {
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
            if (!intParsed)
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
        
        var largestPotentialProduct = int.Parse(new string('9', digits));
        var largestDisallowedProduct = int.Parse(new string('9', digits - 1));
    
        int foundPalindromeProductIndex = 0;
        PalindromeProduct[] foundPalindromeProducts = [];
        
        for (int i = largestPotentialProduct; i > largestDisallowedProduct; i--)
        {
            for (int j = largestPotentialProduct; j > largestDisallowedProduct; j--)
            {
                var sampledProduct = i * j;
                
                if (IsPalindrome(sampledProduct))
                {
                    foundPalindromeProducts[foundPalindromeProductIndex] = new PalindromeProduct(sampledProduct, j, i);
                    foundPalindromeProductIndex++;
                }
            }
        }
        
        if (foundPalindromeProducts.Length == 0)
        {
            return false;
        }
    
        // aggregate check
        var largestFoundPalindromeProduct = foundPalindromeProducts[0];
        for (int i = 1; i < foundPalindromeProducts.Length; i++)
        {
            if (foundPalindromeProducts[i].Number > largestFoundPalindromeProduct.Number)
            {
                largestFoundPalindromeProduct = foundPalindromeProducts[i];
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