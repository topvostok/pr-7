using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace pr7_Peshin
{
    public class Triangle : GeometricFigure
    {
        // Поля длин сторон треугольника
        private double sideA;
        private double sideB;
        private double sideC;

        public double SideA
        {
            get => sideA;
            set => sideA = value > 0 ? value : 1;
        }

        public double SideB
        {
            get => sideB;
            set => sideB = value > 0 ? value : 1;
        }

        public double SideC
        {
            get => sideC;
            set => sideC = value > 0 ? value : 1;
        }

        public Triangle(double centerX, double centerY, double sideA, double sideB, double sideC)
            : base(centerX, centerY)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            FillColor = Brushes.LightCoral;
            StrokeColor = Brushes.DarkRed;
            StrokeThickness = 2;
        }

        public override void Draw(Canvas canvas)
        {
            if (!IsValidTriangle())
            {
                TextBlock errorText = new TextBlock
                {
                    Text = "Невозможно построить треугольник с такими сторонами",
                    Foreground = Brushes.Red,
                    Background = Brushes.White,
                    FontSize = 12,
                    FontWeight = FontWeights.Bold
                };
                Canvas.SetLeft(errorText, CenterX);
                Canvas.SetTop(errorText, CenterY);
                canvas.Children.Add(errorText);
                return;
            }

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
            return SideA + SideB > SideC &&
                   SideA + SideC > SideB &&
                   SideB + SideC > SideA &&
                   SideA > 0 && SideB > 0 && SideC > 0;
        }

        private Point[] CalculateTriangleVertices()
        {
            // Вычисляем вершины треугольника относительно центра
            // Помещаем основание треугольника горизонтально
            double baseY = CenterY + GetTriangleHeight() / 3;

            Point p1 = new Point(CenterX - SideA / 2, baseY);
            Point p2 = new Point(CenterX + SideA / 2, baseY);

            // Вычисляем третью вершину используя теорему косинусов
            double angle = Math.Acos((SideB * SideB + SideA * SideA - SideC * SideC) / (2 * SideB * SideA));
            double height = SideB * Math.Sin(angle);

            Point p3 = new Point(CenterX - SideA / 2 + SideB * Math.Cos(angle), baseY - height);

            return new Point[] { p1, p2, p3 };
        }

        private double GetTriangleHeight()
        {
            double semiPerimeter = (SideA + SideB + SideC) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) *
                                   (semiPerimeter - SideB) * (semiPerimeter - SideC));
            return 2 * area / SideA; // Высота к основанию SideA
        }

        public override string GetInfo()
        {
            double perimeter = SideA + SideB + SideC;
            double semiPerimeter = perimeter / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) *
                                   (semiPerimeter - SideB) * (semiPerimeter - SideC));

            return $"Треугольник:\nЦентр({CenterX:F1}, {CenterY:F1})\n" +
                   $"Стороны: A={SideA:F1}, B={SideB:F1}, C={SideC:F1}\n" +
                   $"Периметр={perimeter:F1}\n" +
                   $"Площадь={area:F1}";
        }
    }
}