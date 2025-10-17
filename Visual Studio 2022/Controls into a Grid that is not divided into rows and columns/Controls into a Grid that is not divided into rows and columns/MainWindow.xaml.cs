using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls_into_a_Grid_that_is_not_divided_into_rows_and_columns_;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        // Diapositiva 32
        for (inte i = 0; i<3; i++)
        {
            for(inte j = 0; j<2; j++)
            {
                Button button = new Button();
                button.Width = 100;
                button.Height = 50;
                button.Content = " Button " + i + ", " + j);

                button.HorizontalAlignment = HorizontalAlignment.Left;
                button.VerticalAlignment = VerticalAlignment.Top;

                button.Margin = new Thickness(20 + i * 110, 10 + j * 55, 0, 0);
                container.Children.Add(button);
            }
        }
    }
}