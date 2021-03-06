using System;
using System.Collections.Generic;
using System.Data;
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
using database.DataSet1TableAdapters;

namespace database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private GameTableAdapter gameTableAdapter = new GameTableAdapter();
        private DataSet1 dataSet = new DataSet1();

    private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            gameTableAdapter.Fill(dataSet.Game);
            DataContext = dataSet.Game.DefaultView;
        }
        private void updateBTN_Click(object sender, RoutedEventArgs e)
        {
            gameTableAdapter.Update(dataSet);
        }
    }      
}

        
