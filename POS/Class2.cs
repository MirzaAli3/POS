using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
	public class Racun:INotifyPropertyChanged
	{
		private int _id;
		public int ID
		{
			get => _id;
			set
			{
				_id = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ID"));

			}
		}
		public DateTime VremeIzdavanje { get; set; }
		public Dictionary<Artikal, int> Artikli { get; set; } = new();
		public decimal Total
		{
			get=>Artikli.Aggregate<KeyValuePair<Artikal,int>,decimal>
				(0,(total,artikal)=>total+=artikal.Key.Cena*artikal.Value);
		}




		
				


		


		public event PropertyChangedEventHandler PropertyChanged;
	}
}
