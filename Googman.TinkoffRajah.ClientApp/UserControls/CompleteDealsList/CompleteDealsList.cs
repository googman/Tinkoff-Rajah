using System.Linq;
using System.Windows.Forms;
using Googman.TinkoffRajah.Domain;

namespace Googman.TinkoffRajah.ClientApp.UserControls
{
    public sealed partial class CompleteDealsList : DealsListBase
    {
        protected override int DefaultSortColumnIndex => 3;
        protected override SortOrder DefaultSortOrder => SortOrder.Descending;

        public CompleteDealsList()
        {
            InitializeComponent();

            list.Columns.Clear();
            AddColumn("Ticker", 60);
            AddColumn("Name", 120);
            AddColumn("Qty", 65);
            AddColumn("Buy/Sell Dates", 330);
            AddColumn("Profit, %", 90);
            AddColumn("Profit", 90);
            AddColumn("Buy details", 240);
            AddColumn("Sell details", 240);
        }

        protected override DealItemBase[] GetItems(GooDealsResult deals)
        {
            var pairs = deals.GetComplete()
                .SelectMany(group => group.Pairs)
                .ToArray();

            return pairs.Select(pair => new CompleteDealItem(pair)).Cast<DealItemBase>().ToArray();
        }
    }
}
