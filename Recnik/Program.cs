using System;
using System.Collections.Generic;

namespace Recnik
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Nesto> asd = new();
			List<int> kolicina = new();
			asd.Add(new Nesto { Cena = 200 });
			kolicina.Add(2);

			Dictionary<Nesto, int> asddd = new();

			asddd.Add(new Nesto { Cena = 200 }, 2);
			asddd.Add(new Nesto { Cena = 75 }, 5);

			decimal t = 0;
			foreach(var par in asddd)
			{
				t += par.Key.Cena * par.Value;
			}

			

		}
	}

	class Nesto
	{
		public decimal Cena { get; set; }
	}
}
