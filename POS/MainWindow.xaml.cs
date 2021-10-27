using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace POS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         ObservableCollection<Artikal> artikli = new();
        public MainWindow()
        {
            InitializeComponent();
         
            tabela.ItemsSource = artikli;



        }

        private void UNOS_Click(object sender, RoutedEventArgs e)
        {
            EDIT q = new(artikli) ;
            q.Owner = this;
            q.ShowDialog();
        }
    }
}
