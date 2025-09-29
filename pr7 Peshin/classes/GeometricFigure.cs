using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pr7_Peshin
{
    public abstract class GeometricFigure
    {
        // Поля координат центра фигуры
        private double centerX;
        private double centerY;

        public double CenterX
        {
            get => centerX;
            set => centerX = value >= 0 ? value : 0;
        }

        public double CenterY
        {
            get => centerY;
            set => centerY = value >= 0 ? value : 0;
        }

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