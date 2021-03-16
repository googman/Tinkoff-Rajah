using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tinkoff.Trading.OpenApi.Models;
using Tinkoff.Trading.OpenApi.Network;

namespace Googman.TinkoffRajah.Logic.Tinkoff
{
    public sealed class TinkoffPriceGetter
    {
        private readonly string _token;

        public TinkoffPriceGetter(string token)
        {
            _token = token;
        }

        public async Task<(decimal priceForSell, decimal priceForBuy)> GetCurrentPriceAsync(
            string figi,
            int currentQuantity)
        {
            using var connection = ConnectionFactory.GetConnection(_token);
            using var context = connection.Context;

            var orderbook = await context.MarketOrderbookAsync(figi, 20);
            var priceForSell = GetPriceFromOrderbook(orderbook.Bids, currentQuantity);
            var priceForBuy = GetPriceFromOrderbook(orderbook.Asks, currentQuantity);

            return (priceForSell, priceForBuy);
        }

        private decimal GetPriceFromOrderbook(IEnumerable<OrderbookRecord> records, int currentQuantity)
        {
            var prices = new List<decimal>();
            foreach (var record in records)
            {
                for (var i = 0; i < record.Quantity; i++)
                {
                    if (prices.Count == currentQuantity)
                        return prices.Average();

                    prices.Add(record.Price);
                }
            }

            return 0;
        }
    }
}
