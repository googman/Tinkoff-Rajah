using System;
using System.Windows.Forms;
using Googman.TinkoffRajah.Domain;

namespace Googman.TinkoffRajah.ClientApp.UserControls
{
    public partial class DealCompletionStrategySelect : UserControl
    {
        public DealCompletionStrategySelect()
        {
            InitializeComponent();
            FillDealCompletionStrategies();
        }

        public GooDealCompleteStrategy SelectedStrategy => (GooDealCompleteStrategy)ctrlDealCompletionStrategy.SelectedItem;

        public event Action<GooDealCompleteStrategy> OnStrategySelected;

        private void FillDealCompletionStrategies()
        {
            foreach (var strategy in Enum.GetValues(typeof(GooDealCompleteStrategy)))
                ctrlDealCompletionStrategy.Items.Add(strategy);
            ctrlDealCompletionStrategy.SelectedItem = GooDealCompleteStrategy.LowFirst;
        }

        private void ctrlDealCompletionStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Action<GooDealCompleteStrategy> strategySelected = OnStrategySelected;
            strategySelected?.Invoke(SelectedStrategy);
        }
    }
}
