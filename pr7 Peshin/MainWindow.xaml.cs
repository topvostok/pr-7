using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace pr7_Peshin
{
    public partial class MainWindow : Window
    {
        private List<GeometricFigure> figures = new List<GeometricFigure>();

        public MainWindow()
        {
            InitializeComponent();
            UpdateStatus("Приложение запущено. Создайте геометрические фигуры.");
        }

        private void BtnCreateCircle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(circleX.Text);
                double y = double.Parse(circleY.Text);
                double diameter = double.Parse(circleDiameter.Text);

                Circle circle = new Circle(x, y, diameter);
                figures.Add(circle);
                RedrawCanvas();
                UpdateStatus($"Создана окружность: Центр({x}, {y}), Диаметр={diameter}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании окружности: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCreateTriangle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(triangleX.Text);
                double y = double.Parse(triangleY.Text);
                double a = double.Parse(sideA.Text);
                double b = double.Parse(sideB.Text);
                double c = double.Parse(sideC.Text);

                Triangle triangle = new Triangle(x, y, a, b, c);
                figures.Add(triangle);
                RedrawCanvas();
                UpdateStatus($"Создан треугольник: Центр({x}, {y}), Стороны={a}, {b}, {c}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании треугольника: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            figures.Clear();
            RedrawCanvas();
            UpdateStatus("Все фигуры удалены");
        }

        private void RedrawCanvas()
        {
            drawingCanvas.Children.Clear();
            infoText.Visibility = figures.Count == 0 ? Visibility.Visible : Visibility.Hidden;

            foreach (var figure in figures)
            {
                figure.Draw(drawingCanvas);

                // Добавляем информационную подпись для каждой фигуры
                TextBlock info = new TextBlock
                {
                    Text = figure.GetInfo(),
                    FontSize = 10,
                    Foreground = Brushes.DarkBlue,
                    Background = Brushes.White,
                    Padding = new Thickness(3),
                    MaxWidth = 200,
                    TextWrapping = System.Windows.TextWrapping.Wrap
                };

                Canvas.SetLeft(info, figure.CenterX + 15);
                Canvas.SetTop(info, figure.CenterY + 15);
                drawingCanvas.Children.Add(info);
            }
        }

        private void UpdateStatus(string message)
        {
            statusText.Text = $"[{DateTime.Now:HH:mm:ss}] {message}";
        }
    }
}