namespace triangle_points_lab;

public class Triangle
{
    public Point A { get; set; }
    public Point B { get; set; }
    public Point C { get; set; }

    public Triangle(Point a, Point b, Point c)
    {
        this.A = a;
        this.B = b;
        this.C = c;
    }
    
    /// <summary>
    /// Checks if the point is in triangle
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public bool IsPointInside(Point x)
    {
        // Calculate area of triangle ABC
        var a = TriangleArea(A, B, C);
        // Calculate area of triangle XBC
        var a1 = TriangleArea(x, B, C);
        // Calculate area of triangle AXC
        var a2 = TriangleArea(A, x, C);
        // Calculate area of triangle ABX
        var a3 = TriangleArea(A, B, x);
        
        // If sum of areas equals to sum of
        // the triangle then the point is inside
        return (Math.Abs(a - (a1 + a2 + a3)) < 0.001);
    }
    
    /// <summary>
    /// Calculates area of a triangle made with points
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static double TriangleArea(Point a, Point b, Point c)
    {
        return Math.Abs((a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)) / 2.0);
    }
}