using ShapeLibrary;

Circle circle = new Circle(5);
Rectangle rectangle = new Rectangle(4, 6);
Triangle triangle = new Triangle(3, 4, 3);

var shapes = new List<Shape> { circle, rectangle, triangle };

foreach (var shape in shapes)
{
    Console.WriteLine("Area: " + shape.GetArea() + ", Perimeter: " + shape.GetPerimeter());
}