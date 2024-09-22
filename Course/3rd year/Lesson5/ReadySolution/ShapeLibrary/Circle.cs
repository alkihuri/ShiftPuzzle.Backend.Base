namespace ShapeLibrary;

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        var area = Math.PI * Radius * Radius;
        return area;
    }

    public override double GetPerimeter()
    {
        var perimeter = 2 * Math.PI * Radius;
        return perimeter;
    }
}