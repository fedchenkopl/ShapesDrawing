using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShapesDrawing.Factories
{
}
public class GreenFactory : IFigureFactory
{
    public Circle CreateCircle() => new Circle { Color = Colors.Green };
    public Square CreateSquare() => new Square { Color = Colors.Green };
    public Triangle CreateTriangle() => new Triangle { Color = Colors.Green };
}
