using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Galeria.Other_Classes
{
    public interface IArrangeAnimator
    {
        Rect Arrange(double elapsedTime,
                    Point desiredPosition,
                    Size desiredSize,
                    Point currentPosition,
                    Size currentSize);
    }
}
