using System.Linq;
using System.Threading.Tasks;
using Googman.TinkoffRajah.Domain;
using Tinkoff.Trading.OpenApi.Network;

namespace Googman.TinkoffRajah.Logic.Tinkoff
{
    public sealed class TinkoffMarketInstrumentsGetter
    {
        private readonly string _token;
        private readonly TinkoffPriceGetter _tinkoffPriceGetter;

        public TinkoffMarketInstrumentsGetter(
            string token,
            TinkoffPriceGetter tinkoffPriceGetter)
        {
            _token = token;
            _tinkoffPriceGetter = tinkoffPriceGetter;
        }

        public async Task<GooMarketInstrument[]> GetOperationsAsync()
        {
            using var connection = ConnectionFactory.GetConnection(_token);
            using var context = connection.Context;

            return (await context.MarketStocksAsync()).Instruments
                .Union((await context.MarketEtfsAsync()).Instruments)
                .Union((await context.MarketBondsAsync()).Instruments)
                .Select(x => new GooMarketInstrument(
                    x,
                    currentQuantity => _tinkoffPriceGetter.GetCurrentPriceAsync(x.Figi, currentQuantity)))
                .ToArray();
        }
    }
}
