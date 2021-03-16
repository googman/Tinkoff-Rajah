using System.Collections.Generic;
using System.Drawing;
using Googman.TinkoffRajah.ClientApp.Models;
using Googman.TinkoffRajah.Domain;
using Googman.TinkoffRajah.Logic.Formatters;

namespace Googman.TinkoffRajah.ClientApp.UserControls
{
    public class CompleteDealItem : DealItemBase
    {
        public CompleteDealItem(GooOperationPair pair) : base(pair)
        {
        }

        protected override ListViewObject[] GetValues()
        {
            var values = new List<ListViewObject>();

            values.Add(new ListViewObject(Pair.MarketInstrument.Ticker));
            values.Add(new ListViewObject(Pair.MarketInstrument.Name));
            values.Add(new ListViewObject(Pair.Quantity, Pair.Quantity.ToString()));

            values.Add(new ListViewObject(
                Pair.LastDate,
                $"{Pair.Buy.Date:dd.MM.yyyy HH:mm:ss} — {Pair.Sell.Date:dd.MM.yyyy HH:mm:ss} ({(Pair.Sell.Date.Date - Pair.Buy.Date.Date).TotalDays} days)"));

            values.Add(new ListViewObject(Pair.ProfitPercent, Pair.ProfitPercent.FormatPercent(true)));
            values.Add(new ListViewObject(Pair.Profit, Pair.Profit.FormatCurrency(Pair.Currency, true)));

            values.Add(new ListViewObject(
                Pair.Buy.TotalPriceIncludingFee,
                $"Buy {Pair.Buy.TotalPriceIncludingFee.FormatCurrency(Pair.Currency)} ({Pair.Buy.PricePerShare.FormatCurrency(Pair.Currency)} x {Pair.Quantity} + {Pair.Buy.Fee.FormatCurrency(Pair.Currency)})"));

            values.Add(new ListViewObject(
                Pair.Sell.TotalPriceIncludingFee,
                $"Sell {Pair.Sell.TotalPriceIncludingFee.FormatCurrency(Pair.Currency)} ({Pair.Sell.PricePerShare.FormatCurrency(Pair.Currency)} x {Pair.Quantity} - {Pair.Sell.Fee.FormatCurrency(Pair.Currency)})"));


            return values.ToArray();
        }

        protected override void Colorize()
        {
            var profit = Pair.Profit;

            if (profit > 0)
            {
                BackColor = ColorTranslator.FromHtml("#e6ffea");
            }
            else if (profit < 0)
            {
                BackColor = ColorTranslator.FromHtml("#ffd9d9");
            }
            else
            {
                BackColor = Color.White;
            }
        }
    }
}
