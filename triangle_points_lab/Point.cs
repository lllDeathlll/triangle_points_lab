namespace triangle_points_lab;

public struct Point
{
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
    
    public double X { get; init; }
    public double Y { get; init; }
}