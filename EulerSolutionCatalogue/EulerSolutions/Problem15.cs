namespace ProjectEuler.EulerSolutions;

public class Problem15 : IEulerSolution
{
    public string Name => "Problem 15";
    public string Description => "Lattice Paths: Finds the unique number of routes through a grid of the given size.";
    public void Run()
    {
        Console.WriteLine("Enter Grid Size (n where size = n x n): ");
        var gridSize = Convert.ToInt32(Console.ReadLine());
        
        var uniqueRoutesFound = FindRoutes(gridSize);
        Console.WriteLine("Found " + uniqueRoutesFound + " unique routes from top-left of grid to bottom-right of grid.");
    }

    private long FindRoutes(int gridSize)
    {
        long uniqueRoutes = 0;
        
        Grid grid = new Grid(gridSize);
        // grid.Print();
        
        var rootVector = grid.Vectors[0, 0];
        Route(rootVector);

        void Route(Vector v)
        {
            if (v.HasDownVector)
            {
                Route(v.DownVector!);
            }

            if (v.HasRightVector)
            {
                Route(v.RightVector!);
            }
            
            if (v is { HasDownVector: false, HasRightVector: false })
            {
                uniqueRoutes++;
            }
        }
        
        return uniqueRoutes;
    }

    class Grid
    {
        public Vector[,] Vectors;
        
        public Grid(int gridSize)
        {
            char key = 'A';
            int dimensionLimit = (gridSize + 1);
            
            Vectors = new Vector[dimensionLimit, dimensionLimit];
            
            for (int i = 0; i < dimensionLimit; i++)
            {
                for (int j = 0; j < dimensionLimit; j++)
                {
                    int x = -gridSize + i;
                    int y = gridSize - j;

                    var vector = new Vector(x, y, key);
                    key = (char)(key + 1);

                    if (i + 1 < dimensionLimit)
                    {
                        vector.HasDownVector = true;
                    }

                    if (j + 1 < dimensionLimit)
                    {
                        vector.HasRightVector = true;
                    }

                    if (i > 0)
                    {
                        Vectors[i - 1, j].DownVector = vector;
                    }

                    if (j > 0)
                    {
                        Vectors[i, j - 1].RightVector = vector;
                    }
                    
                    Vectors[i, j] = vector;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Vectors.GetLength(0); i++)
            {
                for (int j = 0; j < Vectors.GetLength(1); j++)
                {
                    var currentVector = Vectors[i, j];

                    string output = "";
                    // output = currentVector.LeftVectorId != null ? "<" : "";
                    // output += currentVector.UpVectorId != null ? "^" : "";
                    output += currentVector.Id.ToString();
                    // output += currentVector.HasDownVector ? "_" : "";
                    // output += currentVector.HasRightVector ? ">" : "";
                
                    Console.Write(output + '\t');
                }
            
                Console.Write('\n');
            }
        }
    }
    
    class Vector(int x, int y, char id)
    {
        public char Id = id;
        public int X = x;
        public int Y = y;
        public bool HasDownVector = false;
        public bool HasRightVector = false;
        public Vector? DownVector = null;
        public Vector? RightVector = null;
    }
}