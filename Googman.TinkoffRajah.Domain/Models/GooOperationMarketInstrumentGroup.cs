using System.Linq;
using Tinkoff.Trading.OpenApi.Models;

namespace Googman.TinkoffRajah.Domain
{
    public sealed class GooOperationMarketInstrumentGroup
    {
        public GooMarketInstrument MarketInstrument { get; set; }

        public GooOperationPair[] Pairs { get; set; }

        public decimal Profit => Pairs.Sum(x => x.Profit);

        public GooCurrency Currency { get; set; }

        public GooOperationMarketInstrumentGroup(
            GooMarketInstrument marketInstrument,
            GooCurrency currency,
            GooOperationPair[] pairs)
        {
            MarketInstrument = marketInstrument;
            Currency = currency;
            Pairs = pairs;
        }

        public override string ToString() => $"{MarketInstrument} :: {Pairs.Length} pair(s) :: Profit {Profit} {Currency.ToString().ToUpper()}";
    }
}
