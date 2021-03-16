using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Googman.TinkoffRajah.Domain;
using Googman.TinkoffRajah.Logic;
using Googman.TinkoffRajah.Logic.Tinkoff;

namespace Googman.TinkoffRajah.ClientApp
{
    public partial class Mainform : Form
    {
        private readonly SemaphoreSlim _updateSemaphore;

        private readonly DealComposer _dealComposer;
        private readonly TinkoffOperationsGetter _opsGetter;

        private GooOperation[] _operations;

        public Mainform()
        {
            InitializeComponent();

            _updateSemaphore = new SemaphoreSlim(1, 1);

            _dealComposer = new DealComposer();

            var priceGetter = new TinkoffPriceGetter(TokenStorage.Token);
            var marketInstrumentsGetter = new TinkoffMarketInstrumentsGetter(TokenStorage.Token, priceGetter);
            _opsGetter = new TinkoffOperationsGetter(TokenStorage.Token, marketInstrumentsGetter);
        }
        
        private async Task ReloadOperationsAsync(
            ExtendedBool reloadOperationsFromTinkoff,
            bool reloadPricesFromTinkoff)
        {
            if (reloadOperationsFromTinkoff == ExtendedBool.True)
            {
                await _updateSemaphore.WaitAsync();
            }
            else
            {
                var success = await _updateSemaphore.WaitAsync(0);
                if (!success)
                    return;
            }

            try
            {
                if (reloadOperationsFromTinkoff != ExtendedBool.False || _operations == null)
                {
                    ctrlOperationsLastUpdated.Text = @"Loading...";
                    _operations = await _opsGetter.GetOperationsAsync();
                    ctrlOperationsLastUpdated.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                }

                var deals = _dealComposer.GetDeals(ctrlDealCompletionStrategy.SelectedStrategy, _operations);

                if (reloadPricesFromTinkoff)
                {
                    var marketInstruments = deals
                        .GetIncomplete()
                        .Select(group => (group.MarketInstrument, Quantity: group.Pairs.Sum(p => p.Quantity)))
                        .Distinct()
                        .ToArray();

                    ctrlPricesLastUpdated.Text = @"Loading...";
                    await Task.WhenAll(marketInstruments.Select(x => x.MarketInstrument.CalculatePriceAsync(x.Quantity)));
                    ctrlPricesLastUpdated.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                }

                ctrlIncompleteDealsList.Fill(deals);
                ctrlCompleteDealsList.Fill(deals);
            }
            finally
            {
                _updateSemaphore.Release();
            }
        }

        private async void dealCompletionStrategySelect1_OnStrategySelected(GooDealCompleteStrategy strategy)
        {
            await ReloadOperationsAsync(ExtendedBool.Try, false);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await ReloadOperationsAsync(ExtendedBool.True, true);
        }

        private enum ExtendedBool
        {
            True, Try, False,
        }

        private async void ctrlTimerOperations_Tick(object sender, EventArgs e)
        {
            await ReloadOperationsAsync(ExtendedBool.True, true);
        }

        private async void ctrlTimerPrices_Tick(object sender, EventArgs e)
        {
            await ReloadOperationsAsync(ExtendedBool.False, true);
        }

        private async void ctrlTimerCurrentPrice_Tick(object sender, EventArgs e)
        {
            var item = ctrlIncompleteDealsList.SelectedItem;

            if (item == null)
                return;

            var pair = ctrlIncompleteDealsList.SelectedItem.Pair;
            var marketInstrument = pair.MarketInstrument;
            await marketInstrument.CalculatePriceAsync(pair.Quantity);

            foreach (var itemToRefresh in ctrlIncompleteDealsList.Items
                .Where(x => x.Pair.MarketInstrument.Figi == marketInstrument.Figi))
            {
                itemToRefresh.Refresh();
            }
        }
    }
}
