using System;
using System.Windows;

namespace MatrixSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int click = 0;
        ResourceDictionary skin;
        public MainWindow()
        {
            InitializeComponent();
            skin = Application.LoadComponent(new Uri("English.xaml", UriKind.Relative)) as ResourceDictionary;
            Resources.MergedDictionaries.Add(skin);
        }

        private void generate(object sender, RoutedEventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(boxForSize.Text);
                if (value < 5)
                {
                    MessageBox.Show("Matrix size has to be more than 5", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                else if (value > 25)
                {
                    MessageBox.Show("Matrix size can't be more than 25", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                else
                {
                    GenerateMatrix gm = new GenerateMatrix(value);
                    gm.MakeMatrix();
                    this.Hide();
                    var matrix = new MatrixWindow(gm.PrintMatrix(), skin);
                    matrix.Closed += (s, args) => this.Close();
                    matrix.Show();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("TextBox value must be numeric", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Don't fall asleep on the keyboard!", "Warning", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private void changeLanguage(object sender, RoutedEventArgs e)
        {
            click++;
            if (click % 2 != 0)
            {
                skin = Application.LoadComponent(new Uri("Russian.xaml", UriKind.Relative)) as ResourceDictionary;
                Resources.MergedDictionaries.Add(skin);
            }
            else
            {
                skin = Application.LoadComponent(new Uri("English.xaml", UriKind.Relative)) as ResourceDictionary;
                Resources.MergedDictionaries.Add(skin);
            }
        }
    }
}
