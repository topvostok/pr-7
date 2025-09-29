using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace pr7_Peshin
{
    public class Triangle : GeometricFigure
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        // Конструктор с вызовом базового конструктора
        public Triangle(double centerX, double centerY, double sideA, double sideB, double sideC)
            : base(centerX, centerY) // Вызов конструктора базового класса
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            FillColor = Brushes.LightCoral;
            StrokeColor = Brushes.DarkRed;
        }

        public override void Draw(Canvas canvas)
        {
            // Проверяем, могут ли стороны образовать треугольник
            if (!IsValidTriangle())
            {
                // Если треугольник невозможен, показываем сообщение об ошибке
                TextBlock errorText = new TextBlock
                {
                    Text = "Невозможно построить треугольник с такими сторонами",
                    Foreground = Brushes.Red,
                    Background = Brushes.White,
                    FontSize = 12
                };
                Canvas.SetLeft(errorText, CenterX);
                Canvas.SetTop(errorText, CenterY);
                canvas.Children.Add(errorText);
                return;
            }

            // Вычисляем координаты вершин треугольника
            Point[] vertices = CalculateTriangleVertices();

            Polygon polygon = new Polygon
            {
                Points = new PointCollection { vertices[0], vertices[1], vertices[2] },
                Fill = FillColor,
                Stroke = StrokeColor,
                StrokeThickness = StrokeThickness
            };
            canvas.Children.Add(polygon);
            DrawCenterPoint(canvas);
        }

        private bool IsValidTriangle()
        {
            // Проверяем неравенство треугольника
            return SideA + SideB > SideC &&
                   SideA + SideC > SideB &&
                   SideB + SideC > SideA &&
                   SideA > 0 && SideB > 0 && SideC > 0;
        }

        private Point[] CalculateTriangleVertices()
        {
            Point p1 = new Point(CenterX - SideA / 2, CenterY);
            Point p2 = new Point(CenterX + SideA / 2, CenterY);

            double angle = Math.Acos((SideB * SideB + SideA * SideA - SideC * SideC) / (2 * SideB * SideA));
            double height = SideB * Math.Sin(angle);

            Point p3 = new Point(CenterX - SideA / 2 + SideB * Math.Cos(angle), CenterY - height);

            return new Point[] { p1, p2, p3 };
        }

        public override string GetInfo()
        {
            double perimeter = SideA + SideB + SideC;
            double semiPerimeter = perimeter / 2;
            double area = Math.Sqrt(semiPerimeter *
                                   (semiPerimeter - SideA) *
                                   (semiPerimeter - SideB) *
                                   (semiPerimeter - SideC));

            return $"Треугольник: Центр({CenterX:F1}, {CenterY:F1}), " +
                   $"Стороны={SideA:F1}, {SideB:F1}, {SideC:F1}, " +
                   $"Периметр={perimeter:F1}, Площадь={area:F1}";
        }
    }
}