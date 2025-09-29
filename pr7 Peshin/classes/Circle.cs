using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pr7_Peshin
{
    public class Circle : GeometricFigure
    {
        // Поле диаметра
        private double diameter;

        public double Diameter
        {
            get => diameter;
            set => diameter = value > 0 ? value : 1;
        }

        public double Radius => Diameter / 2;

        public Circle(double centerX, double centerY, double diameter)
            : base(centerX, centerY)
        {
            Diameter = diameter;
            FillColor = Brushes.LightGreen;
            StrokeColor = Brushes.DarkGreen;
            StrokeThickness = 2;
        }

        public override void Draw(Canvas canvas)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = Diameter,
                Height = Diameter,
                Fill = FillColor,
                Stroke = StrokeColor,
                StrokeThickness = StrokeThickness
            };

            Canvas.SetLeft(ellipse, CenterX - Radius);
            Canvas.SetTop(ellipse, CenterY - Radius);
            canvas.Children.Add(ellipse);

            DrawCenterPoint(canvas);
        }

        public override string GetInfo()
        {
            double area = Math.PI * Radius * Radius;
            double circumference = 2 * Math.PI * Radius;

            return $"Окружность:\nЦентр({CenterX:F1}, {CenterY:F1})\n" +
                   $"Диаметр={Diameter:F1}\n" +
                   $"Радиус={Radius:F1}\n" +
                   $"Площадь={area:F1}\n" +
                   $"Длина окружности={circumference:F1}";
        }
    }
}