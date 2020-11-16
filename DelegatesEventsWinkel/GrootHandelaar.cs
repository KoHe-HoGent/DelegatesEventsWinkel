using System.Collections.Generic;
using System;

namespace DelegatesEventsWinkel
{
    public class GrootHandelaar
    {
        //lijst van alle bestellingen
        private List<List<int>> _aanvullingenLijst = new List<List<int>>();

        //stock aanvullen
        public void OnStockAanvulling(object source, StockbeheerEventArgs args)
        {
            //toevoegen aan lijst aanvullingen
            _aanvullingenLijst.Add(args.AanTeVullen);
        }

        //alle bestellingen op te roepen
        public void AlleAanvullingen() 
        {
            Console.WriteLine("-----------------\nALLE AANVULLINGEN");
            foreach (List<int> lijstAanvulling in _aanvullingenLijst) 
            {
                Console.Write("\nAanvulling:");
                if (lijstAanvulling[0] != 0) {Console.Write($" Trippel {lijstAanvulling[0]}");}
                if (lijstAanvulling[1] != 0) {Console.Write($" Dubbel {lijstAanvulling[1]}");}
                if (lijstAanvulling[2] != 0) {Console.Write($" Kriek {lijstAanvulling[2]}");}
                if (lijstAanvulling[3] != 0) {Console.Write($" Pils {lijstAanvulling[3]}");}
            
            }
            Console.WriteLine("\n-----------------\n");
        }
        //laatste bestellingoproepen
        public void LaatsteAanvulling()
        {
            if (_aanvullingenLijst != null) 
            {
                List<int> laatste = _aanvullingenLijst[_aanvullingenLijst.Count - 1];

                Console.WriteLine("------------------\nLAATSTE AANVULLING");
                Console.Write("\nAanvulling:");
                if (laatste[0] != 0) { Console.Write($" Trippel {laatste[0]}"); }
                if (laatste[1] != 0) { Console.Write($" Dubbel {laatste[1]}"); }
                if (laatste[2] != 0) { Console.Write($" Kriek {laatste[2]}"); }
                if (laatste[3] != 0) { Console.Write($" Pils {laatste[3]}"); }
                Console.WriteLine("\n------------------\n");
            }
            else { Console.WriteLine("aanvullingen leeg"); }
        }
    }
}
