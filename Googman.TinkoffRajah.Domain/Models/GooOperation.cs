using System;
using System.Linq;
using Tinkoff.Trading.OpenApi.Models;

namespace Googman.TinkoffRajah.Domain
{
    public sealed class GooOperation : ICloneable
    {
        public GooMarketInstrument MarketInstrument { get; set; }
        public DateTime Date { get; set; }
        public GooOperationType OperationType { get; set; }
        public int Quantity { get; set; }
        public GooCurrency Currency { get; set; }
        public decimal PricePerShare { get; set; }
        public decimal TotalPrice => Math.Round(PricePerShare * Quantity, 8, MidpointRounding.AwayFromZero);
        public decimal Fee { get; set; }

        public GooOperation()
        {

        }

        public GooOperation(
            GooMarketInstrument marketInstrument, 
            Operation operation)
        {
            MarketInstrument = marketInstrument;
            Date = operation.Date;
            OperationType = ParseOperationType(operation.OperationType);
            Quantity = operation.Trades.Sum(x => x.Quantity);
            Currency = ParseCurrency(operation.Currency);
            PricePerShare = operation.Price;
            Fee = (operation.Commission?.Value ?? 0) * -1;
        }

        public decimal TotalPriceIncludingFee => OperationType switch
        {
            GooOperationType.Buy => TotalPrice + Fee,
            GooOperationType.Sell => TotalPrice - Fee,
            _ => throw new NotSupportedException($"Operation type {OperationType} is not supported.")
        };

        public GooOperation Split(int splittedQuantity)
        {
            if (splittedQuantity > Quantity)
                throw new InvalidOperationException("Quantity mismatch.");

            var currentQuantity = Quantity - splittedQuantity;
            var sourceFee = Fee;

            var newOperation = (GooOperation)MemberwiseClone();

            // 1
            Fee = currentQuantity / (decimal)Quantity * sourceFee;
            Quantity = currentQuantity;

            // 2
            newOperation.Fee = sourceFee - Fee;
            newOperation.Quantity = splittedQuantity;
            return newOperation;
        }

        private GooOperationType ParseOperationType(ExtendedOperationType operationType) => operationType switch
        {
            ExtendedOperationType.Buy => GooOperationType.Buy,
            ExtendedOperationType.BuyCard => GooOperationType.Buy,
            ExtendedOperationType.Sell => GooOperationType.Sell,
            _ => throw new NotSupportedException($"Operation type {operationType} is not supported.")
        };

        private GooCurrency ParseCurrency(Currency currency) => currency switch
        {
            Tinkoff.Trading.OpenApi.Models.Currency.Usd => GooCurrency.Usd,
            Tinkoff.Trading.OpenApi.Models.Currency.Rub => GooCurrency.Rub,
            Tinkoff.Trading.OpenApi.Models.Currency.Eur => GooCurrency.Eur,
            _ => throw new NotSupportedException($"Currency {currency} is not supported.")
        };

        public override string ToString() => $"{Date} :: {MarketInstrument} :: {OperationType} :: {Quantity} шт. :: {TotalPriceIncludingFee}";
        
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
