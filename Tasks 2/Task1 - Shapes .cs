using System;

class Shape
{
    public string Name { get; set; }

    public virtual double CalculateArea()
    {
        return 0;
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

class Triangle : Shape
{
    public double Base { get; set; }
    public double TriangleHeight { get; set; }

    public override double CalculateArea()
    {
        return (Base * TriangleHeight) / 2;
    }
}

class Program
{
    static void PrintShapeArea(Shape shape)
    {
        Console.WriteLine($"Shape: {shape.Name}, Area: {shape.CalculateArea():F2}");
    }

    static void Main(string[] args)
    {
        Circle circle = new Circle { Name = "Circle", Radius = 5 };
        Rectangle rectangle = new Rectangle { Name = "Rectangle", Width = 4, Height = 6 };
        Triangle triangle = new Triangle { Name = "Triangle", Base = 7, TriangleHeight = 3 };

        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
    }
}
