using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace pr7_Peshin.classes
{
    public class GeometricFigure
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public Brush FillColor { get; set; }
        public Brush StrokeColor { get; set; }
        public double StrokeThickness { get; set; }
        public GeometricFigure(double centerX, double centerY)
        {
            CenterX = centerX;
            CenterY = centerY;
            FillColor = Brushes.LightBlue;
            StrokeColor = Brushes.DarkBlue;
            StrokeThickness = 2;
        }

        public abstract void Draw(Canvas canvas);
        public abstract string GetInfo();
    }
}
