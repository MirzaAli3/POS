using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public ObservableCollection<Artikal> artikli = new();
        public ObservableCollection<Racun> racuni = new();
       public Racun racun = new();

		public event PropertyChangedEventHandler PropertyChanged;


        private string _sifra;

		public string Sifra {
            get=>_sifra;
            set {
                _sifra = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sifra"));
            }
                 }
        private int _kolicina = 1;
        public int Kolicina
        {
            get => _kolicina;
            set
            {
                _kolicina = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Kolicina"));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            artikli.Add(new Artikal { Ucena = 10, Sifra = "1111", Naziv = "Cocca", Cena = 11, Kolicina = 10});
            artikli.Add(new Artikal { Ucena = 7 ,Sifra = "222", Naziv = "Fanta", Cena = 22, Kolicina = 8 });
            artikli.Add(new Artikal { Ucena = 3  ,Sifra = "3333",Naziv = "Voda", Cena = 33, Kolicina = 4 });
            artikli.Add(new Artikal { Ucena = 12 , Sifra = "4444",Naziv = "Pepsi", Cena = 44, Kolicina = 6 });

            tabela.ItemsSource = artikli;
            
            ArtikliNaRacunu.ItemsSource = racun.Artikli;

            PregledRacuna.ItemsSource = racuni;




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

                    Sifra = string.Empty;
                    Kolicina = 1;

                }
                else
                    MessageBox.Show("Kolicina jok");
            }
            else
                MessageBox.Show("Artikal jok");

            
		}

		private void ZavrsiRacun(object sender, RoutedEventArgs e)
		{
            racun.VremeIzdavanje = DateTime.Now;
            racuni.Add(racun);
            racun = new();
            ArtikliNaRacunu.ItemsSource = null;
            ArtikliNaRacunu.ItemsSource = racun.Artikli;
        }
	}
}
