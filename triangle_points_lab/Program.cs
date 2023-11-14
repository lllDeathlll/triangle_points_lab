internal class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Hello, I'm a program that calculates a count of integer coordinates inside a triangle!");
            
            double[] x;
            double[] y;
            double[] z;
            
            try
            {
                Console.WriteLine("Enter x1 and x2:");
                x = GetCoordinate();
                Console.WriteLine("Enter y1 and y2:");
                y = GetCoordinate();
                Console.WriteLine("Enter z1 and z2:");
                z = GetCoordinate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }
            
            // Calculates minimum x and y coordinates
            var xMin = Convert.ToInt32((new double[3] { x[0], y[0], z[0] }).Min());
            var xMax = Convert.ToInt32((new double[3] { x[0], y[0], z[0] }).Max());
            var yMin = Convert.ToInt32((new double[3] { x[1], y[1], z[1] }).Min());
            var yMax = Convert.ToInt32((new double[3] { x[1], y[1], z[1] }).Max());
            
            int coordinateCount = 0;
            for (var i = xMin; i < xMax; i++)
            {
                for (var j = yMin; j < yMax; j++)
                {
                    var point = new double[2] { i, j };
                    if (IsPointInTriangle(point, x, y, z))
                    {
                        coordinateCount++;
                    }
                }
            }
            Console.WriteLine($"Total points amount: {coordinateCount}\n");

            Console.WriteLine("Continue?\nYes/No");
            if (Console.ReadLine().ToLower().Contains("no"))
            {
                break;
            }
        }
    }

    /// <summary>
    /// Checks if point is in triangle.
    /// </summary>
    /// <param name="point"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    private static bool IsPointInTriangle(double[] point, double[] x, double[] y, double[] z)
    {
        /*
         * Check the sign of the areas of
         * smaller triangles formed by the
         * point and pairs of vertices
         */
        var a = Sign(point, x, y) < 0.0;
        var b = Sign(point, y, z) < 0.0;
        var c = Sign(point, z, x) < 0.0;
        
        // Returns true, if the signs are all the same (inside the triangle)
        return (a == b) && (b == c);
    }
    
    /// <summary>
    /// Calculates the sign of area formed by point.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    private static double Sign(double[] x, double[] y, double[] z)
    {
        
        return (x[0] - z[0]) * (y[1] - z[1]) - (y[0] - z[0]) * (x[1] - z[1]);
    }
    
    /// <summary>
    /// Gets coordinate (two doubles) from user input.
    /// </summary>
    /// <returns></returns>
    private static double[] GetCoordinate()
    {
        var x1 = GetDouble();
        var x2 = GetDouble();

        var coordinate = new double[2]{x1, x2};
        return coordinate;
    }
    
    /// <summary>
    /// Gets user input and converts it to double.
    /// </summary>
    /// <returns></returns>
    private static double GetDouble()
    {
        try
        {
            var variable = Convert.ToDouble(Console.ReadLine());
            return variable;
        }
        catch (OverflowException)
        {
            throw new Exception("Error: The number is too big!");
        }
        catch (FormatException)
        {
            throw new Exception("Error: You must enter a number!");
        }
        catch (Exception e)
        {
            throw new Exception($"Error {e}");
        }
    }
}