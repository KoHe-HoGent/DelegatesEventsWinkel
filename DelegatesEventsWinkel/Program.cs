using System;

namespace DelegatesEventsWinkel
{
    class Program
    {
        static void Main()
        {

            Winkel w = new Winkel(); //publisher winkelverkoop
            Sales s = new Sales(); //subscriber winkelverkoop
            w.Winkelverkoop += s.OnWinkelVerkoop;
            Stockbeheer sb = new Stockbeheer(); //subscriber winkelverkoop + publisher stockaanvulling
            w.Winkelverkoop += sb.OnWinkelVerkoop;
            GrootHandelaar gh = new GrootHandelaar(); //subscriber stockaanvulling
            sb.StockAanvulling += gh.OnStockAanvulling;

            Bestelling b1 = new Bestelling { aantal = 4, adres = "abc", prijs = 1 * 1.5, type = ProductType.Kriek };
            Bestelling b2 = new Bestelling { aantal = 1, adres = "def", prijs = 5*2, type = ProductType.Trippel };
            Bestelling b3 = new Bestelling { aantal = 2, adres = "ghi", prijs = 76 * 1.5, type = ProductType.Pils };
            Bestelling b4 = new Bestelling { aantal = 3, adres = "jkl", prijs = 1 * 1.5, type = ProductType.Dubbel };
            Bestelling b5 = new Bestelling { aantal = 5, adres = "jkl", prijs = 1 * 1.5, type = ProductType.Trippel };
            Bestelling BB1 = new Bestelling { aantal = 50, adres = "mno", prijs = 1 * 1.5, type = ProductType.Kriek };
            Bestelling BB2 = new Bestelling { aantal = 30, adres = "mno", prijs = 1 * 1.5, type = ProductType.Kriek };
            Bestelling BB3 = new Bestelling { aantal = 60, adres = "mno", prijs = 1 * 1.5, type = ProductType.Pils };
            Bestelling BB4 = new Bestelling { aantal = 70, adres = "mno", prijs = 1 * 1.5, type = ProductType.Dubbel };

            w.VerkoopProduct(b1);
            w.VerkoopProduct(b2);
            w.VerkoopProduct(b3);
            w.VerkoopProduct(b4);
            w.VerkoopProduct(b5);
            sb.ShowStock();
            w.VerkoopProduct(BB1);
            w.VerkoopProduct(BB2);
            w.VerkoopProduct(BB3);
            w.VerkoopProduct(BB4);
            sb.ShowStock();

            s.ShowRapport();
            gh.AlleAanvullingen();
            gh.LaatsteAanvulling();
        }
    }
}
