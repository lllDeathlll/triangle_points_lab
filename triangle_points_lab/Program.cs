namespace triangle_points_lab;

internal abstract class Program
{
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    
        public int X { get; init; }
        public int Y { get; init; }
    }
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
                a = new Point(GetInt(), GetInt());
                Console.WriteLine("Enter y1 and y2:");
                b = new Point(GetInt(), GetInt());
                Console.WriteLine("Enter z1 and z2:");
                c = new Point(GetInt(), GetInt());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                continue;
            }
            
            Console.WriteLine($"Total points amount: {InternalPointsCount(a,b,c)}\n");

            Console.WriteLine("Continue?\nY/N");
            var input = Console.ReadLine()!.ToLower();
            if (!input.Contains('y'))
            {
                break;
            }
        }
    }
    
    private static int GetInt()
    {
        try
        {
            var variable = Convert.ToInt32(Console.ReadLine());
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
    
    /// <summary>
    /// Returns greatest common denominator of two numbers
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private static int GetGcd(int a, int b)
    {
        if (b == 0)
            return a;
        return GetGcd(b, a % b);
    }
    
    /// <summary>
    /// Returns the number of int points between two points
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    static int GetBoundaryCount(Point x, Point y)
    {
        // Check if line parallel to axes
        if (x.X == y.X)
            return Math.Abs(x.Y - y.Y) - 1;
 
        if (x.Y == y.Y)
            return Math.Abs(x.X - y.X) - 1;
 
        return GetGcd(Math.Abs(x.X - y.X), 
            Math.Abs(x.Y - y.Y)) - 1;
    }
    
    /// <summary>
    /// Returns count of int points inside the triangle
    /// </summary>
    /// <returns></returns>
    private static int InternalPointsCount(Point a, Point b, Point c)
    {
        // 3 extra integer points for the vertices
        var boundaryPoints = GetBoundaryCount(a, b) + 
                             GetBoundaryCount(a, c) + 
                             GetBoundaryCount(b, c) + 3;
 
        // Calculate 2*A for the triangle
        var doubleArea = Math.Abs(a.X * (b.Y - c.Y) + 
                                   b.X * (c.Y - a.Y) + 
                                   c.X * (a.Y - b.Y));
 
        // Use Pick's theorem: Area =  i + b/2 - 1
        // (i - interior, b - boundary points)
        // to calculate the  number of Interior points
        return ((doubleArea - boundaryPoints + 2) / 2);
    }
}