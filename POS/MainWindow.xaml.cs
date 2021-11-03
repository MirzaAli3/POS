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
        public ObservableCollection<Artikal> artikli = new();
       public Racun racun = new();
       public string Sifra {
            get;
            set; }
        public int Kolicina { get; set; } = 1;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            racun.Artikli.Add(new Artikal { Sifra = "123" }, 5);
         
            tabela.ItemsSource = artikli;
            ArtikliNaRacunu.ItemsSource = racun.Artikli;
            



        }

        private void UNOS_Click(object sender, RoutedEventArgs e)
        {
            EDIT q = new(artikli) ;
            q.Owner = this;
            q.ShowDialog();
        }

        private void brisanje(object sender, RoutedEventArgs e)
        {
            if (tabela.SelectedItem is not null)
            {
                artikli.Remove(tabela.SelectedItem as Artikal);
            }
        }

		private void UnosAritkla(object sender, RoutedEventArgs e)
		{
            if (artikli.Where(a => a.Sifra == Sifra).Any())
            {
                Artikal art = artikli.Where(a => a.Sifra == Sifra).First();
                if (art.Kolicina >= Kolicina)
                {
                    art.Kolicina -= Kolicina;
                    if (racun.Artikli.ContainsKey(art))
                        racun.Artikli[art] += Kolicina;
                    else
                       racun.Artikli.Add(art, Kolicina);
                    ArtikliNaRacunu.ItemsSource = null;
                    ArtikliNaRacunu.ItemsSource = racun.Artikli;

                }
                else
                    MessageBox.Show("Kolicina jok");
            }
            else
                MessageBox.Show("Artikal jok");
            
		}
	}
}
