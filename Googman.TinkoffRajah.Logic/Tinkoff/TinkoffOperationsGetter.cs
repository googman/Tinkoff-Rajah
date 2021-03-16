using System;
using System.Linq;
using System.Threading.Tasks;
using Googman.TinkoffRajah.Domain;
using Tinkoff.Trading.OpenApi.Models;
using Tinkoff.Trading.OpenApi.Network;

namespace Googman.TinkoffRajah.Logic.Tinkoff
{
    public sealed class TinkoffOperationsGetter
    {
        private readonly string _token;
        private readonly TinkoffMarketInstrumentsGetter _marketInstrumentsGetter;
        private GooMarketInstrument[] _marketInstruments;

        public TinkoffOperationsGetter(
            string token,
            TinkoffMarketInstrumentsGetter marketInstrumentsGetter)
        {
            _token = token;
            _marketInstrumentsGetter = marketInstrumentsGetter;
        }

        public async Task<GooOperation[]> GetOperationsAsync()
        {
            using var connection = ConnectionFactory.GetConnection(_token);
            using var context = connection.Context;

            _marketInstruments ??= await _marketInstrumentsGetter.GetOperationsAsync();

            var operations =
                await context.OperationsAsync(DateTime.Today.AddYears(-10), DateTime.Today.AddYears(10), null);

            return operations
                .Where(x => x.OperationType == ExtendedOperationType.Buy
                            || x.OperationType == ExtendedOperationType.BuyCard
                            || x.OperationType == ExtendedOperationType.Sell)
                .Where(x => x.Status == OperationStatus.Done)
                .Select(x => new GooOperation(_marketInstruments.FirstOrDefault(s => s.Figi == x.Figi), x))
                .ToArray();
        }
    }
}
