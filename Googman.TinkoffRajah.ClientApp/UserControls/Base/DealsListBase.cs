// ReSharper disable VirtualMemberCallInConstructor
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Googman.TinkoffRajah.Domain;

namespace Googman.TinkoffRajah.ClientApp.UserControls
{
    public abstract partial class DealsListBase : UserControl
    {
        private int _columnIndexForSort;
        private SortOrder _sortOrder;
        protected GooDealsResult Deals;

        protected DealsListBase()
        {
            _columnIndexForSort = DefaultSortColumnIndex;
            _sortOrder = DefaultSortOrder;
            
            InitializeComponent();
            
            list.GetType()
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(list, true);
            
            list.ColumnClick += (s, e) => OnColumnHeaderClicked(e.Column);
        }

        protected abstract int DefaultSortColumnIndex { get; }
        protected abstract SortOrder DefaultSortOrder { get; }
        
        public DealItemBase[] Items => list.Items.Cast<DealItemBase>().ToArray();

        public DealItemBase SelectedItem => Items.FirstOrDefault(x => x.Selected);
        
        public void Fill(GooDealsResult deals)
        {
            FillSortIconOnColumn();

            Deals = deals;

            var items = GetItems(deals);

            list.BeginUpdate();
            try
            {
                var selectedItemId = list.SelectedItems.Count > 0
                    ? ((DealItemBase)list.SelectedItems[0]).ItemId
                    : (int?)null;

                list.Items.Clear();

                var sortedItems = SortItems(items.ToArray());

                list.Items.AddRange(sortedItems.Cast<ListViewItem>().ToArray());

                var selectedItem = items.FirstOrDefault(x => x.ItemId == selectedItemId);
                if (selectedItem != null)
                    selectedItem.Selected = true;
            }
            finally
            {
                list.EndUpdate();
            }
        }

        protected abstract DealItemBase[] GetItems(GooDealsResult deals);

        protected IOrderedEnumerable<DealItemBase> SortItems(DealItemBase[] items)
        {
            return _sortOrder == SortOrder.Ascending
                ? items.OrderBy(x => x.GetValue(_columnIndexForSort))
                : items.OrderByDescending(x => x.GetValue(_columnIndexForSort));
        }

        protected void AddColumn(string columnName, int width)
        {
            list.Columns.Add(columnName, width);
        }

        private void OnColumnHeaderClicked(int columnIndex)
        {
            if (_columnIndexForSort == columnIndex)
            {
                _sortOrder = _sortOrder == SortOrder.Descending
                    ? SortOrder.Ascending
                    : SortOrder.Descending;
            }

            _columnIndexForSort = columnIndex;

            if (Deals != null)
                Fill(Deals);
        }

        private void FillSortIconOnColumn()
        {
            foreach (ColumnHeader listColumn in list.Columns)
            {
                listColumn.Text = listColumn.Text.Replace("🔽", "").Replace("🔼", "").Trim();
            }

            if (_sortOrder == SortOrder.Ascending)
            {
                list.Columns[_columnIndexForSort].Text += @" 🔽";
            }
            else
            {
                list.Columns[_columnIndexForSort].Text += @" 🔼";
            }
        }
    }
}
