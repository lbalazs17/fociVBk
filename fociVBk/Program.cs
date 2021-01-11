using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fociVBk
{
	class Program
	{
		static void Main(string[] args)
		{
			bool Magy = false;
			int Aszámlál = 0;
			int Bszámlál = 0;
			var sorok = File.ReadAllLines("fociVBk.csv");
			var csapatok = new List<Csapat>();
			foreach (var sor in sorok)
			{
				var értékek = sor.Split(';');
				var csapat = new Csapat()
				{
					Név = értékek[0],
					Részv = Int32.Parse(értékek[1]),
					ElsRészv = Int32.Parse(értékek[2]),
					LegRészv = Int32.Parse(értékek[3]),
					Ered = értékek[4]
				};
				csapatok.Add(csapat);
			}

			Console.WriteLine("1. feladat: csapatok száma: " + csapatok.Count());

			Console.Write("2. feladat: 2018-as VB csapatai: ");
			foreach (var csapat in csapatok)
			{
				if (csapat.LegRészv == 2018)
				{
					Console.Write(csapat.Név + " ");
				}
				if (csapat.Név == "Belgium" || csapat.Név == "Hollandia" || csapat.Név == "Luxemburg")
				{
					Aszámlál++;
				}
				if (csapat.Ered.Contains("Világbajnok"))
				{
					Bszámlál++;
				}

			}
			Console.WriteLine();

			Console.WriteLine("3. feladat: A BeNeLux országok összesen " + Aszámlál + " alkalommal vettek részt a VB-n");

			int n = csapatok.Count();
			int min;
			min = csapatok[0].ElsRészv;
			for (int i = 1; i < n; i++)
				if (csapatok[i].ElsRészv < min)
					min = csapatok[i].ElsRészv;
			Console.WriteLine("4. feladat: Az első VB-t " + min + "-ban rendezték");

			Console.WriteLine("5. feladat: Eddig " + Bszámlál + " ország csapata volt világbajnok");



			Console.ReadKey();
		}
	}
	public class Csapat
	{
		public string Név { get; set; }
		public int Részv { get; set; }
		public int ElsRészv { get; set; }
		public int LegRészv { get; set; }
		public string Ered { get; set; }
	}
}
