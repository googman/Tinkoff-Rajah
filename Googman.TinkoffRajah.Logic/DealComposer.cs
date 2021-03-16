using System;
using System.Collections.Generic;
using System.Linq;
using Googman.TinkoffRajah.Domain;

namespace Googman.TinkoffRajah.Logic
{
    public sealed class DealComposer
    {
        public GooDealsResult GetDeals(
            GooDealCompleteStrategy dealCompleteStrategy,
            params GooOperation[] operations)
        {
            operations = operations.Select(x => x.Clone()).Cast<GooOperation>().ToArray();

            var instrumentGroups = operations
                .Where(x => x.MarketInstrument != null)
                .OrderBy(x => x.Date).ToArray()
                .GroupBy(x => x.MarketInstrument)
                .ToArray();

            var groups = new List<GooOperationMarketInstrumentGroup>();
            foreach (var instrumentGroup in instrumentGroups)
            {
                var pairs = GetPairs(instrumentGroup, dealCompleteStrategy);

                var currencyPairGroups = pairs.GroupBy(x => x.Currency);

                foreach (var currencyPairGroup in currencyPairGroups)
                {
                    var group = new GooOperationMarketInstrumentGroup(
                        instrumentGroup.Key,
                        currencyPairGroup.Key,
                        currencyPairGroup.ToArray());

                    groups.Add(group);
                }
            }

            return new GooDealsResult(groups.ToArray());
        }

        private GooOperationPair[] GetPairs(
            IEnumerable<GooOperation> instrumentOperations,
            GooDealCompleteStrategy dealCompleteStrategy)
        {
            var instrumentPairs = new List<GooOperationPair>();

            foreach (var operation in instrumentOperations.OrderBy(x => x.Date))
            {
                FillPairs(operation, instrumentPairs, dealCompleteStrategy);
            }

            return instrumentPairs.ToArray();
        }

        private void FillPairs(
            GooOperation operation,
            ICollection<GooOperationPair> instrumentPairs,
            GooDealCompleteStrategy dealCompleteStrategy)
        {
            var isBuy = operation.OperationType == GooOperationType.Buy;

            bool Predicate(GooOperationPair pair) => isBuy
                ? pair.Sell != null && pair.Buy == null
                : pair.Buy != null && pair.Sell == null;

            var activePairs = instrumentPairs.Where(Predicate);

            var orderedActivePairs = SortActivePairs(isBuy, activePairs, dealCompleteStrategy);

            foreach (var activePair in orderedActivePairs)
            {
                if (operation.Quantity == 0)
                    break;

                if (operation.Quantity < activePair.Quantity)
                {
                    var pairOperation = isBuy ? activePair.Sell : activePair.Buy;
                    var splittedOperation = pairOperation.Split(pairOperation.Quantity - operation.Quantity);

                    if (isBuy)
                        activePair.Buy = operation;
                    else
                        activePair.Sell = operation;

                    var newwPair = new GooOperationPair();
                    if (isBuy)
                        newwPair.Sell = splittedOperation;
                    else
                        newwPair.Buy = splittedOperation;

                    instrumentPairs.Add(newwPair);

                    return;
                }

                var splitOp = operation.Split(activePair.Quantity);

                if (isBuy)
                    activePair.Buy = splitOp;
                else
                    activePair.Sell = splitOp;
            }

            if (operation.Quantity == 0)
                return;

            var newPair = new GooOperationPair();

            if (isBuy)
                newPair.Buy = operation;
            else
                newPair.Sell = operation;

            instrumentPairs.Add(newPair);
        }

        private static IOrderedEnumerable<GooOperationPair> SortActivePairs(
            bool isBuy, 
            IEnumerable<GooOperationPair> activePairs,
            GooDealCompleteStrategy dealCompleteStrategy)
        {
            switch (dealCompleteStrategy)
            {
                case GooDealCompleteStrategy.LowFirst:
                    return isBuy
                        ? activePairs.OrderByDescending(x => x.Sell?.PricePerShare)
                        : activePairs.OrderBy(x => x.Buy?.PricePerShare);
                case GooDealCompleteStrategy.Fifo:
                    return isBuy
                        ? activePairs.OrderBy(x => x.Sell?.Date)
                        : activePairs.OrderBy(x => x.Buy?.Date);
                case GooDealCompleteStrategy.Lifo:
                    return isBuy
                        ? activePairs.OrderByDescending(x => x.Sell?.Date)
                        : activePairs.OrderByDescending(x => x.Buy?.Date);
                default:
                    throw new InvalidOperationException($"Deal completion strategy {dealCompleteStrategy} is not supported.");
            }
        }
    }
}
