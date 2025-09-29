using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pr7_Peshin
{
    public class Circle : GeometricFigure
    {
        public double Radius { get; set; }

        // Конструктор с вызовом базового конструктора
        public Circle(double centerX, double centerY, double radius)
            : base(centerX, centerY) // Вызов конструктора базового класса
        {
            Radius = radius;
            FillColor = Brushes.LightGreen;
            StrokeColor = Brushes.DarkGreen;
        }

        public override void Draw(Canvas canvas)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = Radius * 2,
                Height = Radius * 2,
                Fill = FillColor,
                Stroke = StrokeColor,
                StrokeThickness = StrokeThickness
            };

            Canvas.SetLeft(ellipse, CenterX - Radius);
            Canvas.SetTop(ellipse, CenterY - Radius);
            canvas.Children.Add(ellipse);

            // Добавляем точку центра
            DrawCenterPoint(canvas);
        }

        public override string GetInfo()
        {
            return $"Окружность: Центр({CenterX}, {CenterY}), Радиус={Radius}";
        }
    }
}