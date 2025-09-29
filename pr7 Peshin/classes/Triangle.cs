using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
            // Простой равносторонний треугольник для демонстрации
            double height = SideA * Math.Sqrt(3) / 2;

            System.Windows.Point p1 = new System.Windows.Point(CenterX, CenterY - height / 2);
            System.Windows.Point p2 = new System.Windows.Point(CenterX - SideA / 2, CenterY + height / 2);
            System.Windows.Point p3 = new System.Windows.Point(CenterX + SideA / 2, CenterY + height / 2);

            Polygon polygon = new Polygon
            {
                Points = new PointCollection { p1, p2, p3 },
                Fill = FillColor,
                Stroke = StrokeColor,
                StrokeThickness = StrokeThickness
            };

            canvas.Children.Add(polygon);

            // Добавляем точку центра
            DrawCenterPoint(canvas);
        }

        public override string GetInfo()
        {
            return $"Треугольник: Центр({CenterX}, {CenterY}), Стороны={SideA}, {SideB}, {SideC}, Периметр={SideA + SideB + SideC}";
        }
    }
}