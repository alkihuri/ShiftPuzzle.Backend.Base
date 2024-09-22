namespace ShapeLibrary;

public class Triangle : Shape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    
    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }
    
    public override double GetArea()
    {
        var p = (A + B + C) / 2;
        
        var area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        return area;
    }

    public override double GetPerimeter()
    {
        var perimeter = A + B + C;
        return perimeter;
    }
}