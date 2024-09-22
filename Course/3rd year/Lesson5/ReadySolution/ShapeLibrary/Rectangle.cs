namespace ShapeLibrary;

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    
    public override double GetArea()
    {
        var area = Width * Height;
        return area;
    }

    public override double GetPerimeter()
    {
        var perimeter = Width * Height / 2;
        return perimeter;
    }
}