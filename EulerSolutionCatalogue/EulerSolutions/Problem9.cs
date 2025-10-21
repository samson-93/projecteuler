namespace ProjectEuler.EulerSolutions;

public class Problem9 : IEulerSolution
{
    public string Name => "Problem 9";
    public string Description => "This program will find the product (if it exists) of a Pythagorean triplet that sums to the provided number.";
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Enter an integer: ");
            var input = Console.ReadLine();
            if (input == "exit")
            {
                return;
            }

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            var triplet = GetProductOfPythagoreanTripletsWhichEqual(number);
            if (triplet == null)
            {
                Console.WriteLine("No triplet found.");
                continue;
            }
            
            Console.WriteLine("Triplet: " + triplet.A + " < " + triplet.B + " < " + triplet.C);
            Console.WriteLine("Triplet Equation: " + triplet.A + "^2 x " + triplet.B + "^2 = " + triplet.C + "^2");
            Console.WriteLine("Triplet Sum: " + triplet.A + " + " + triplet.B + " + " + triplet.C + " = " + triplet.TripletSum);
            Console.WriteLine("Triplet Product: " + triplet.A + " x " + triplet.B + " x " + triplet.C + " = " + triplet.TripletProduct);
            Console.WriteLine();
        }
    }

    private PythagoreanTriplet? GetProductOfPythagoreanTripletsWhichEqual(int number = 1000)
    {
        for (int a = 1; a <= number; a++)
        {
            for (int b = (a + 1); b <= number; b++)
            {
                var trip = new PythagoreanTriplet(a, b);
                if (trip.C % 1 == 0 && (int)trip.TripletSum == number)
                {
                    return trip;
                }
            }
        }

        return null;
    }
}

internal class PythagoreanTriplet(int a, int b)
{
    public int A => a;
    public int B => b;
    public double C => Math.Sqrt(A * A + B * B);
    public double TripletSum => A + B + C;
    public double TripletProduct => A * B * C;
}