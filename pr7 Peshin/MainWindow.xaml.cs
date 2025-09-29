using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pr7_Peshin
{
    public abstract class GeometricFigure
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public Brush FillColor { get; set; }
        public Brush StrokeColor { get; set; }
        public double StrokeThickness { get; set; }

        // Конструктор базового класса
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

        protected void DrawCenterPoint(Canvas canvas)
        {
            Ellipse centerPoint = new Ellipse
            {
                Width = 6,
                Height = 6,
                Fill = Brushes.Red,
                Stroke = Brushes.DarkRed,
                StrokeThickness = 1
            };

            Canvas.SetLeft(centerPoint, CenterX - 3);
            Canvas.SetTop(centerPoint, CenterY - 3);
            canvas.Children.Add(centerPoint);
        }
    }
}