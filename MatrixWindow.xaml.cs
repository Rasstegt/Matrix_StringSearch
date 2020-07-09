using System.Windows;

namespace MatrixSearch
{
    /// <summary>
    /// Interaction logic for MatrixWindow.xaml
    /// </summary>
    public partial class MatrixWindow : Window
    {
        public MatrixWindow(string output, ResourceDictionary rd)
        {
            InitializeComponent();
            matrixOut.Text = output;
            Resources.MergedDictionaries.Add(rd);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var main = new MainWindow();
            main.Closed += (s, args) => this.Close();
            main.Show();
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            Search search = new Search(((searchText.Text).ToUpper()).ToCharArray());

            if (search.SearchString())
                MessageBox.Show(string.Format("String starts at Row: {0}, Column: {1} and follows {2} direction",
                    search.Row, search.Col, search.Direction),
                    "Search results", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("String doesnt exist", "Search results",
                    MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
