using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pr7_Peshin
{
    public abstract class GeometricFigure
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public Brush FillColor { get; set; } = Brushes.LightBlue;
        public Brush StrokeColor { get; set; } = Brushes.DarkBlue;
        public double StrokeThickness { get; set; } = 2;

        protected GeometricFigure(double centerX, double centerY)
        {
            CenterX = centerX;
            CenterY = centerY;
        }

        public abstract void Draw(Canvas canvas);
        public abstract string GetInfo();

        protected void DrawCenterPoint(Canvas canvas)
        {
            Ellipse centerPoint = new Ellipse
            {
                Width = 4,
                Height = 4,
                Fill = Brushes.Red,
                Stroke = Brushes.DarkRed,
                StrokeThickness = 1
            };
            Canvas.SetLeft(centerPoint, CenterX - 2);
            Canvas.SetTop(centerPoint, CenterY - 2);
            canvas.Children.Add(centerPoint);
        }
    }
}