using System.Linq;
using System.Windows.Forms;
using Googman.TinkoffRajah.Domain;

namespace Googman.TinkoffRajah.ClientApp.UserControls
{
    public sealed partial class IncompleteDealsList : DealsListBase
    {
        protected override int DefaultSortColumnIndex => 2;
        protected override SortOrder DefaultSortOrder => SortOrder.Descending;

        public IncompleteDealsList()
        {
            InitializeComponent();
            
            list.Columns.Clear();
            AddColumn("Ticker", 80);
            AddColumn("Name", 120);
            AddColumn("Buy date", 140);
            AddColumn("Qty", 65);
            AddColumn("Price / share", 110);
            AddColumn("Fee", 65);
            AddColumn("Sum", 80);
            AddColumn("Sum incl. fee", 100);
            AddColumn("Current price", 110);
            AddColumn("Virtual profit", 110);
            AddColumn("Virtual profit, %", 120);
            AddColumn("Updated at", 140);
        }

        protected override DealItemBase[] GetItems(GooDealsResult deals)
        {
            var pairs = deals.GetIncomplete()
                .SelectMany(group => group.Pairs)
                .ToArray();

            return pairs.Select(pair => new IncompleteDealItem(pair)).Cast<DealItemBase>().ToArray();
        }
    }
}
