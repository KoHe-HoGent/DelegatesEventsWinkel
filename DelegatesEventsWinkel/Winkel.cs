using System;

namespace DelegatesEventsWinkel
{
    class Winkel
    {

        //verkoop
        public void VerkoopProduct(Bestelling p)
        {
            Console.WriteLine($"verkoopproduct - {p}");
            OnWinkelVerkoop(p);
        }

        //event
        public event EventHandler<WinkelEventArgs> Winkelverkoop;
        protected virtual void OnWinkelVerkoop(Bestelling p)
        {
            Winkelverkoop?.Invoke(this, new WinkelEventArgs { bestelling = p });
        }
    }
}
