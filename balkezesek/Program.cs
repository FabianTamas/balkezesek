using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace balkezesek
{
    class Program
    {
        static List<Balkezesek> balkezesekLista = new List<Balkezesek>();
        static int szam;

        static void Beolvas()
        {
            StreamReader file = new StreamReader("balkezesek.csv");
            file.ReadLine();
            while (!file.EndOfStream)
            {
                balkezesekLista.Add(new Balkezesek(file.ReadLine()));
            }
            file.Close();
        }

        static void feladat3()
        {
            Console.WriteLine("3. feladat: {0}", balkezesekLista.Count);
        }

        static void feladat4()
        {
            Console.WriteLine("4. feladat:");
            foreach (var b in balkezesekLista)
            {
                if (b.utolso.Contains("1999-10"))
                {
                    Console.WriteLine("\t{0}, {1:N1} cm",b.nev, b.magassag*2.54);
                }
            }
        }

        static void feladat5()
        {
            Console.WriteLine("5. feladat:");
            Console.Write("Kérek egy 1990 és 1999 közötti évszámot: ");
            szam = Convert.ToInt32(Console.ReadLine());
            while(szam<1990 || szam>1999)
            {
                Console.Write("Hibás adat! Kérek egy 1990 és 1999 közötti évszámot!: ");
                szam = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void feladat6()
        {
            double suly = 0;
            int db = 0;
            for (int i = 0; i < balkezesekLista.Count; i++)
            {
                if (szam >= Datum(balkezesekLista[i].elso) && szam <= Datum(balkezesekLista[i].utolso))
                {
                    suly += balkezesekLista[i].suly;
                    db++;
                }
            }
            Console.Write("6. feladat: ");
            Console.WriteLine("{0:N2} font",suly/db);
        }

        static int Datum(string datum)
        {
            string[] adat = datum.Split('-');
            return int.Parse(adat[0]);
        }

        static void feladat7()
        {
            var abc = from b in balkezesekLista orderby b.nev group b by b.nev[0] into abcTemp select abcTemp;

            foreach (var abcGroup in abc)
            {
                Console.WriteLine(abcGroup.Key);
                foreach (var item in abcGroup)
                {
                    Console.WriteLine($"\t{item.nev}");
                }
            }
        }

        static void Main(string[] args)
        {
            Beolvas();
            feladat3();
            feladat4();
            feladat5();
            feladat6();
            feladat7();

            Console.ReadKey();
        }
    }
}
