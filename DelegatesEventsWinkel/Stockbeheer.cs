using System;
using System.Collections.Generic;

namespace DelegatesEventsWinkel
{
    public class Stockbeheer
    {
        // stock
        private List<int> _stock = new List<int> { 100, 100, 100, 100 };
        private int MinimumAantal = 50;
        private int MaximumAantal = 100;
        public List<int> LageStock = new List<int>() { 0, 0, 0, 0 };

        //verkoopsevent
        public void OnWinkelVerkoop(object source, WinkelEventArgs args)
        {
            //bepaal index producttype, pas stock aan
            int stockIndex = -1;
            switch (args.bestelling.type.ToString()) 
            {
                case "Trippel": stockIndex = 0; break;
                case "Dubbel": stockIndex = 1; break;
                case "Kriek": stockIndex = 2; break;
                case "Pils": stockIndex = 3; break;
            }
            _stock[stockIndex] -= args.bestelling.aantal;

            //kijk naar nieuw cijfer, groothandelaar moet bestellen als te laag
            if (_stock[stockIndex] < MinimumAantal)
            {
                LageStock = new List<int>() { 0, 0, 0, 0 };
                for (int i = 0; i < _stock.Count; i++)
                {
                    //stel lijst te bestellen aantallen samen
                    if (_stock[i] < MaximumAantal) 
                    {
                        LageStock[i] = 100 - _stock[i];
                        //vul intern stock aan
                        _stock[i] = 100;
                        Console.WriteLine($"lagestock aangepast\n  {LageStock}\n  {_stock}");
                    }
                }
                //stuur aan te vullen aantallen naar groothandelaar
                OnStockaanvulling(LageStock);
            }
        }

        //stock aanvullen
        public event EventHandler<StockbeheerEventArgs> StockAanvulling;

        protected virtual void OnStockaanvulling(List<int> A)
        {
            StockAanvulling?.Invoke(this, new StockbeheerEventArgs { AanTeVullen = A });
        }

        // toon stock
        public void ShowStock()
        {
            Console.WriteLine(
                $"------------\nSTOCK\nTrippel: {_stock[0]}\nDubbel:  {_stock[1]}\nKriek:   {_stock[2]}\nPils:    {_stock[3]}\n------------");
        }
    }
}
