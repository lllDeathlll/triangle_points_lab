namespace triangle_points_lab;

internal abstract class Program
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
            var xMin = Convert.ToInt32((new [] { x[0], y[0], z[0] }).Min());
            var xMax = Convert.ToInt32((new [] { x[0], y[0], z[0] }).Max());
            var yMin = Convert.ToInt32((new [] { x[1], y[1], z[1] }).Min());
            var yMax = Convert.ToInt32((new [] { x[1], y[1], z[1] }).Max());
            
            int coordinateCount = 0;
            for (var i = xMin; i <= xMax; i++)
            {
                for (var j = yMin; j <= yMax; j++)
                {
                    var point = new double[] { i, j };
                    if (IsPointInTriangle(point, x, y, z))
                    {
                        coordinateCount++;
                    }
                }
            }
            Console.WriteLine($"Total points amount: {coordinateCount}\n");

            Console.WriteLine("Continue?\nYes/No");
            if (Console.ReadLine()!.ToLower().Contains("no"))
            {
                break;
            }
        }
    }

    /// <summary>
    /// Checks if point is in triangle.
    /// </summary>
    /// <param name="point"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    private static bool IsPointInTriangle(double[] point, double[] a, double[] b, double[] c)
    {
        // Calculate the differences in x and y coordinates between the given point and vertex a
        var xDifA = point[0] - a[0];
        var yDifA = point[1] - a[1];
        // Determine if the point is on the same side of the line AB as vertex C using cross product
        // ReSharper disable once InconsistentNaming
        var pointSideAB = (b[0] - a[0]) * yDifA - (b[1] - a[1]) * xDifA > 0;
        
        // Check if the point is on the same side of the line AC as vertex B using cross product
        if ((c[0]-a[0])*yDifA-(c[1]-a[1])*xDifA > 0 == pointSideAB) return false;
        // Check if the point is on the same side of the line BC as vertex A using cross product
        if ((c[0]-b[0])*(point[1]-b[1])-(c[1]-b[1])*(point[0]-b[0]) > 0 != pointSideAB) return false;
        // If point passes both checks, it lies within the triangle
        return true;
    }
    
    /// <summary>
    /// Gets coordinate (two doubles) from user input.
    /// </summary>
    /// <returns></returns>
    private static double[] GetCoordinate()
    {
        var x1 = GetDouble();
        var x2 = GetDouble();

        var coordinate = new []{x1, x2};
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