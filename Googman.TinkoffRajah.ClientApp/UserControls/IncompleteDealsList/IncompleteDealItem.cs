using System.Collections.Generic;
using System.Drawing;
using Googman.TinkoffRajah.ClientApp.Models;
using Googman.TinkoffRajah.Domain;
using Googman.TinkoffRajah.Logic.Formatters;
using Googman.TinkoffRajah.Logic.Utils;

namespace Googman.TinkoffRajah.ClientApp.UserControls
{
    public class IncompleteDealItem : DealItemBase
    {
        public IncompleteDealItem(GooOperationPair pair) : base(pair)
        {
        }

        protected override ListViewObject[] GetValues()
        {
            var values = new List<ListViewObject>();

            var profit = Pair.Profit;
            var lastPrice = Pair.MarketInstrument.LastPriceForSell;

            values.Add(new ListViewObject(Pair.MarketInstrument.Ticker));
            values.Add(new ListViewObject(Pair.MarketInstrument.Name));
            values.Add(new ListViewObject(Pair.Buy?.Date, Pair.Buy?.Date.ToString("dd.MM.yyyy HH:mm:ss")));
            values.Add(new ListViewObject(Pair.Quantity, Pair.Quantity.ToString()));
            values.Add(new ListViewObject(Pair.Buy?.PricePerShare, Pair.Buy?.PricePerShare.FormatCurrency(Pair.Currency)));
            values.Add(new ListViewObject(Pair.Buy?.Fee, Pair.Buy?.Fee.FormatCurrency(Pair.Currency)));
            values.Add(new ListViewObject(Pair.Buy?.TotalPrice, Pair.Buy?.TotalPrice.FormatCurrency(Pair.Currency)));
            values.Add(new ListViewObject(Pair.Buy?.TotalPriceIncludingFee, Pair.Buy?.TotalPriceIncludingFee.FormatCurrency(Pair.Currency)));
            values.Add(new ListViewObject(lastPrice, lastPrice.FormatCurrency(Pair.Currency, false, true)));
            values.Add(new ListViewObject(
                lastPrice > 0 ? (decimal?)profit : null,
                lastPrice > 0 ? profit.FormatCurrency(Pair.Currency, true) : ""));
            values.Add(new ListViewObject(
                lastPrice > 0 ? (decimal?)Pair.ProfitPercent : null,
                lastPrice > 0 ? Pair.ProfitPercent.FormatPercent(true) : ""));
            values.Add(new ListViewObject(Pair.MarketInstrument.LastPriceDateTime, Pair.MarketInstrument.LastPriceDateTime?.ToString("dd.MM.yyyy HH:mm:ss") ?? ""));

            return values.ToArray();
        }

        protected override void Colorize()
        {
            var profit = Pair.Profit;
            var lastPrice = Pair.MarketInstrument.LastPriceForSell;

            if (lastPrice == 0)
            {
                BackColor = ColorTranslator.FromHtml("#ececec");
            }
            else
            {
                var colors = ColorUtils.MakeProfitColor(Pair.ProfitPercent);
                BackColor = colors.back;
                ForeColor = colors.fore;
            }
        }
    }
}
