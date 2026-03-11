using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShapesDrawing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Текущие создатели для каждой фигуры
        private CircleCreator _currentCircleCreator;
        private SquareCreator _currentSquareCreator;
        private TriangleCreator _currentTriangleCreator;

        public MainWindow()
        {
            InitializeComponent();

            // Устанавливаем начальный цвет (первый элемент в ComboBox)
            // ВАЖНО: делаем это ПОСЛЕ InitializeComponent(), но до установки обработчика
            if (ColorComboBox.Items.Count > 0)
            {
                ColorComboBox.SelectedIndex = 0; // Выбираем первый элемент (Красный)
            }

            // Теперь можно обновить создателей
            UpdateCreatorsBasedOnColor();
        }

        // Метод для обновления всех создателей при смене цвета
        private void UpdateCreatorsBasedOnColor()
        {
            // Проверяем, что SelectedItem существует и это ComboBoxItem
            if (ColorComboBox.SelectedItem == null) return;

            var selectedItem = ColorComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem?.Content == null) return;

            switch (selectedItem.Content.ToString())
            {
                case "Красный":
                    _currentCircleCreator = new RedCircleCreator();
                    _currentSquareCreator = new RedSquareCreator();
                    _currentTriangleCreator = new RedTriangleCreator();
                    break;
                case "Синий":
                    _currentCircleCreator = new BlueCircleCreator();
                    _currentSquareCreator = new BlueSquareCreator();
                    _currentTriangleCreator = new BlueTriangleCreator();
                    break;
                case "Зеленый":
                    _currentCircleCreator = new GreenCircleCreator();
                    _currentSquareCreator = new GreenSquareCreator();
                    _currentTriangleCreator = new GreenTriangleCreator();
                    break;
                default:
                    return;
            }

            // Очищаем фигуры при смене цвета
            ClearShapes();
        }

        private void AddCircleButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentCircleCreator == null) return;
            var circle = _currentCircleCreator.CreateCircle();
            ShapesPanel.Children.Add(circle.CreateUIElement());
        }

        private void AddSquareButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentSquareCreator == null) return;
            var square = _currentSquareCreator.CreateSquare();
            ShapesPanel.Children.Add(square.CreateUIElement());
        }

        private void AddTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentTriangleCreator == null) return;
            var triangle = _currentTriangleCreator.CreateTriangle();
            ShapesPanel.Children.Add(triangle.CreateUIElement());
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearShapes();
        }

        private void ClearShapes()
        {
            ShapesPanel.Children.Clear();
        }

        // Обработчик смены выбора в ComboBox
        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Дополнительная проверка, чтобы избежать ошибки при инициализации
            if (!IsInitialized) return;

            UpdateCreatorsBasedOnColor();
        }
    }
}