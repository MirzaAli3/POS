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
using System.Windows.Shapes;

namespace POS
{
	/// <summary>
	/// Interaction logic for PregledRacuna.xaml
	/// </summary>
	public partial class PregledRacuna : Window
	{
		public PregledRacuna(Racun r)
		{

			InitializeComponent();
			DataContext = r;
			PregledajGrid.ItemsSource = r.Artikli;
		}
	}
}
