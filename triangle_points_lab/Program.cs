namespace triangle_points_lab;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Hello, I'm a program that calculates a count of integer coordinates inside a triangle!");
            
            Point a;
            Point b;
            Point c;
            
            try
            {
                Console.WriteLine("Enter x1 and x2:");
                a = new Point(GetDouble(), GetDouble());
                Console.WriteLine("Enter y1 and y2:");
                b = new Point(GetDouble(), GetDouble());
                Console.WriteLine("Enter z1 and z2:");
                c = new Point(GetDouble(), GetDouble());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }
            
            // Calculates minimum x and y coordinates
            var xMin = Convert.ToInt32((new [] { a.X, b.X, c.X }).Min());
            var xMax = Convert.ToInt32((new [] { a.X, b.X, c.X }).Max());
            var yMin = Convert.ToInt32((new [] { a.Y, b.Y, c.Y }).Min());
            var yMax = Convert.ToInt32((new [] { a.Y, b.Y, c.Y }).Max());

            var triangle = new Triangle(a, b, c);
            var coordinateCount = 0;
            for (var i = xMin; i <= xMax; i++)
            {
                for (var j = yMin; j <= yMax; j++)
                {
                    var point = new Point(i,j);
                    if (triangle.IsPointInside(point))
                    {
                        coordinateCount++;
                    }
                }
            }
            Console.WriteLine($"Total points amount: {coordinateCount}\n");

            Console.WriteLine("Continue?\nYes/No");
            var input = Console.ReadLine()!.ToLower();
            if (input.Contains("no") || input == "n")
            {
                break;
            }
        }
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