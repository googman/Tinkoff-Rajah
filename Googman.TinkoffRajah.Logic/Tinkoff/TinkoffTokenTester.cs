using System.Threading.Tasks;
using Tinkoff.Trading.OpenApi.Network;

namespace Googman.TinkoffRajah.Logic.Tinkoff
{
    public sealed class TinkoffTokenTester
    {
        public async Task<bool> IsTokenValidAsync(string token)
        {
            using var connection = ConnectionFactory.GetConnection(token);
            using var context = connection.Context;

            try
            {
                var portfolio = await context.PortfolioAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
