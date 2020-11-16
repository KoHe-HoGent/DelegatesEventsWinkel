using System.Collections.Generic;
using System;

namespace DelegatesEventsWinkel
{
    class Sales
    {
        //alle  geplaatste  bestellingen 
        private Dictionary<string, List<Bestelling>> _rapport = new Dictionary<string, List<Bestelling>>(); //adres, lijst bestellingen

        //verkoopsevent
        public void OnWinkelVerkoop(object source, WinkelEventArgs args)
        {
            //if adres geen key in dict, maak key aan
            if (!_rapport.ContainsKey(args.bestelling.adres))
            {
                _rapport.Add(args.bestelling.adres, new List<Bestelling>());
            }
            //voeg bestelling toe aan adres key
            _rapport[args.bestelling.adres].Add(args.bestelling);
        }

        //beschikt  over  een methode  om te  rapporteren.   
        public void ShowRapport()
        {
            foreach (KeyValuePair<string, List<Bestelling>> entry in _rapport)
            {
                Console.WriteLine(entry.Key);
                foreach (Bestelling b in entry.Value)
                {
                    Console.WriteLine($"  {b.aantal} {b.type}");
                }
            }
        }
        

    }
}
