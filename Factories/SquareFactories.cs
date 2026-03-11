using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShapesDrawing.Factories
{
    internal class SquareFactories
    {
    }
}
public abstract class SquareCreator
{
    public abstract Square CreateSquare();
}

public class RedSquareCreator : SquareCreator
{
    public override Square CreateSquare() => new Square { Color = Colors.Red };
}

public class BlueSquareCreator : SquareCreator
{
    public override Square CreateSquare() => new Square { Color = Colors.Blue };
}

public class GreenSquareCreator : SquareCreator
{
    public override Square CreateSquare() => new Square { Color = Colors.Green };
}