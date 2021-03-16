using System;
using System.Linq;
using Tinkoff.Trading.OpenApi.Models;

namespace Googman.TinkoffRajah.Domain
{
    public sealed class GooOperationPair
    {
        public int Quantity
        {
            get
            {
                var quantities = new[] { Buy?.Quantity, Sell?.Quantity }.Where(x => x.HasValue).Distinct().ToArray();
                if (quantities.Length == 0)
                    return 0;

                if (quantities.Length > 1)
                    throw new InvalidOperationException("Quantitites of Buy & Sell operations should be the same.");

                return quantities[0].GetValueOrDefault();
            }
        }

        public GooMarketInstrument MarketInstrument => Buy?.MarketInstrument ?? Sell?.MarketInstrument;

        public DateTime LastDate => new[] { Buy?.Date, Sell?.Date }.OrderByDescending(dt => dt).FirstOrDefault().GetValueOrDefault();
        public DateTime FirstDate => new[] { Buy?.Date, Sell?.Date }.OrderBy(dt => dt).FirstOrDefault().GetValueOrDefault();

        public GooOperation Buy { get; set; }
        public GooOperation Sell { get; set; }

        public GooOperationPairType PairType
        {
            get
            {
                if (Buy != null && Sell != null)
                    return GooOperationPairType.Complete;

                if (Buy != null)
                    return GooOperationPairType.IncompleteLong;

                return GooOperationPairType.IncompleteShort;
            }
        }

        public GooCurrency Currency => Buy?.Currency ?? Sell?.Currency ?? throw new InvalidOperationException("There should be at least buy or sell operation.");

        public decimal Profit
        {
            get
            {
                if (Buy == null && Sell == null)
                    return 0m;

                var buy = Buy?.TotalPriceIncludingFee ?? MarketInstrument.LastPriceForBuy * Quantity + Sell.Fee;
                var sell = Sell?.TotalPriceIncludingFee ?? MarketInstrument.LastPriceForSell * Quantity - Buy.Fee;

                return sell - buy;
            }
        }

        public decimal ProfitPercent
        {
            get
            {
                if (Buy == null && Sell == null)
                    return 0m;

                var buy = Buy?.TotalPriceIncludingFee ?? MarketInstrument.LastPriceForBuy * Quantity + Sell.Fee;
                var sell = Sell?.TotalPriceIncludingFee ?? MarketInstrument.LastPriceForSell * Quantity - Buy.Fee;
                
                if (buy == sell)
                    return 0m;

                if (sell > buy)
                    return (sell - buy) / buy * 100;

                return ((buy - sell) / buy * 100) * -1;
            }
        }

        public override string ToString() => $"{MarketInstrument} :: {PairType} :: Profit {Profit} {Currency.ToString().ToUpper()}";
    }
}
