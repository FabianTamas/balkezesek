using System;

namespace balkezesek
{
    internal class Balkezesek
    {
        public string nev { get; private set; }
        public string elso { get; private set; }
        public string utolso { get; private set; }
        public int suly { get; private set; }
        public double magassag { get; private set; }

        public Balkezesek(string szoveg)
        {
            string[] sor = szoveg.Split(';');
            nev = sor[0];
            elso = sor[1];
            utolso = sor[2];
            suly = int.Parse(sor[3]);
            magassag = Convert.ToDouble(sor[4]);
        }
    }
}