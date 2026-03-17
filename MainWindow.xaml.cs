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

    private IFigureFactory _currentFactory;

        public MainWindow()
        {
            InitializeComponent();

            // Устанавливаем начальный цвет ПОСЛЕ инициализации компонентов
            // НО до подписки на события, чтобы избежать лишних вызовов
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Устанавливаем начальное значение ComboBox
            if (ColorComboBox.Items.Count > 0)
            {
                ColorComboBox.SelectedIndex = 0;
            }

            // Теперь можно безопасно обновить фабрику
            UpdateFactoryBasedOnColor();
        }

        // Метод для обновления фабрики при смене цвета
        private void UpdateFactoryBasedOnColor()
        {
            // Важно: проверяем, что SelectedItem существует
            if (ColorComboBox.SelectedItem == null) return;

            var selectedItem = ColorComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem?.Content == null) return;

            switch (selectedItem.Content.ToString())
            {
                case "Красный":
                    _currentFactory = new RedFactory();
                    break;
                case "Синий":
                    _currentFactory = new BlueFactory();
                    break;
                case "Зеленый":
                    _currentFactory = new GreenFactory();
                    break;
                default:
                    return;
            }

            // При смене цвета очищаем старые фигуры
            ClearShapes();
        }

        private void AddCircleButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentFactory == null) return;
            var circle = _currentFactory.CreateCircle();
            ShapesPanel.Children.Add(circle.CreateUIElement());
        }

        private void AddSquareButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentFactory == null) return;
            var square = _currentFactory.CreateSquare();
            ShapesPanel.Children.Add(square.CreateUIElement());
        }

        private void AddTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentFactory == null) return;
            var triangle = _currentFactory.CreateTriangle();
            ShapesPanel.Children.Add(triangle.CreateUIElement());
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearShapes();
        }

        private void ClearShapes()
        {
            // Дополнительная проверка, что ShapesPanel не null
            if (ShapesPanel != null)
            {
                ShapesPanel.Children.Clear();
            }
        }

        // Обработчик смены выбора в ComboBox
        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Защита от вызова до полной инициализации
            if (!IsLoaded) return;

            UpdateFactoryBasedOnColor();
        }
    }
}
