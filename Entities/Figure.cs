using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

public abstract class Figure
{
    public Color Color { get; set; }
    public abstract UIElement CreateUIElement(double size = 50);
}