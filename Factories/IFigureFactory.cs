using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesDrawing.Factories
{
}
public interface IFigureFactory
{
    Circle CreateCircle();
    Square CreateSquare();
    Triangle CreateTriangle();
}