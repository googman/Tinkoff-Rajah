using System.Windows.Forms;
using Googman.TinkoffRajah.ClientApp.Models;
using Googman.TinkoffRajah.Domain;

namespace Googman.TinkoffRajah.ClientApp.UserControls
{
    public abstract class DealItemBase : ListViewItem
    {
        private GooOperationPair _pair;
        private ListViewObject[] _values;

        public int ItemId { get; set; }

        public GooOperationPair Pair
        {
            get => _pair;
            set
            {
                _pair = value;
                Refresh();
            }
        }

        public object GetValue(int columnIndex)
        {
            return _values[columnIndex].Value;
        }

        public void Refresh()
        {
            _values = GetValues();

            SubItems.Clear();
            for (var i = 0; i < _values.Length; i++)
            {
                var value = _values[i];

                if (i == 0)
                    Text = value.DisplayAlias;
                else
                    SubItems.Add(value.DisplayAlias);
            }

            Colorize();
        }

        protected DealItemBase(
            GooOperationPair pair)
        {
            _pair = pair;
            CalculateItemId();

            Refresh();
        }

        protected abstract ListViewObject[] GetValues();

        private void CalculateItemId()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + _pair.MarketInstrument.Ticker.GetHashCode();
                hash = hash * 23 + _pair.Sell?.Date.GetHashCode() ?? 0;
                hash = hash * 23 + _pair.Sell?.Quantity.GetHashCode() ?? 0;
                hash = hash * 23 + _pair.Buy?.Date.GetHashCode() ?? 0;
                hash = hash * 23 + _pair.Buy?.Quantity.GetHashCode() ?? 0;
                ItemId = hash;
            }
        }

        protected abstract void Colorize();
    }
}
