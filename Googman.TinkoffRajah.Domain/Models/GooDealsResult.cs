using System.Linq;

namespace Googman.TinkoffRajah.Domain
{
    public sealed class GooDealsResult
    {
        private readonly GooOperationMarketInstrumentGroup[] _groups;

        public GooDealsResult(GooOperationMarketInstrumentGroup[] groups)
        {
            _groups = groups;
        }

        public GooOperationMarketInstrumentGroup[] GetAll(GooCurrency? currency = null) =>
            _groups
                .Where(g => currency == null || g.Currency == currency)
                .ToArray();

        public GooOperationMarketInstrumentGroup[] GetIncomplete(GooCurrency? currency = null)
        {
            return GetOperationsWithCompleteness(currency, false);
        }

        public GooOperationMarketInstrumentGroup[] GetComplete(GooCurrency? currency = null)
        {
            return GetOperationsWithCompleteness(currency, true);
        }

        private GooOperationMarketInstrumentGroup[] GetOperationsWithCompleteness(
            GooCurrency? currency,
            bool isComplete)
        {
            return _groups
                .Where(g => currency == null || g.Currency == currency)
                .Select(x => new GooOperationMarketInstrumentGroup(
                    x.MarketInstrument,
                    x.Currency,
                    x.Pairs.Where(p => isComplete ? 
                        p.PairType == GooOperationPairType.Complete 
                        : p.PairType != GooOperationPairType.Complete).ToArray()))
                .Where(g => g.Pairs.Length > 0)
                .ToArray();
        }
    }
}
