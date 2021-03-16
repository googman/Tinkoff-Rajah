using System;
using System.Threading;
using System.Threading.Tasks;
using Tinkoff.Trading.OpenApi.Models;

namespace Googman.TinkoffRajah.Domain
{
    public sealed class GooMarketInstrument
    {
        private readonly Func<int, Task<(decimal priceForSell, decimal priceForBuy)>> _getCurrentPrice;
        private readonly SemaphoreSlim _priceSemaphore = new SemaphoreSlim(1, 1);

        public string Figi { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        
        public DateTime? LastPriceDateTime { get; set; }
        public decimal LastPriceForSell { get; set; }
        public decimal LastPriceForBuy { get; set; }

        public GooMarketInstrument(
            MarketInstrument marketInstrument,
            Func<int, Task<(decimal priceForSell, decimal priceForBuy)>> getCurrentPrice)
        {
            _getCurrentPrice = getCurrentPrice;
            Figi = marketInstrument.Figi;
            Name = marketInstrument.Name;
            Ticker = marketInstrument.Ticker;
        }

        public async Task CalculatePriceAsync(int currentQuantity)
        {
            var success = await _priceSemaphore.WaitAsync(0);

            if (!success)
                return;

            try
            {
                (LastPriceForSell, LastPriceForBuy) = await _getCurrentPrice(currentQuantity);
                LastPriceDateTime = DateTime.Now;
            }
            finally
            {
                _priceSemaphore.Release();
            }
        }

        public override string ToString() => $"{Ticker} - {Name}";
    }
}
