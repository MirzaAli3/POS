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
using System.Windows.Shapes;

namespace POS
{
    /// <summary>
    /// Interaction logic for EDIT.xaml
    /// </summary>
    public partial class EDIT : Window
    {
        private ObservableCollection<Artikal> art;
        public EDIT(ObservableCollection<Artikal> b)
        {
            InitializeComponent();
            DataContext = new Artikal ();
            art = b;
            
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            art.Add(DataContext as Artikal);
            DataContext = new Artikal();
            
        }
        
    }

}
