using System.Drawing;

namespace Googman.TinkoffRajah.Logic.Utils
{
    public static class ColorUtils
    {
        public static (Color back, Color fore) MakeProfitColor(decimal profitPercent)
        {
            if (profitPercent == 0)
                return (Color.White, Color.Black);

            if (profitPercent < 0)
            {
                return (profitPercent * -1) switch
                {
                    >= 18 => (ColorTranslator.FromHtml("#ff8080"), Color.Black),
                    >= 15 => (ColorTranslator.FromHtml("#ff9898"), Color.Black),
                    >= 12 => (ColorTranslator.FromHtml("#fea8a8"), Color.Black),
                    >= 9 => (ColorTranslator.FromHtml("#ffbdbd"), Color.Black),
                    >= 6 => (ColorTranslator.FromHtml("#fed0d0"), Color.Black),
                    >= 3 => (ColorTranslator.FromHtml("#ffe1e1"), Color.Black),
                    _ => (ColorTranslator.FromHtml("#ffeeee"), Color.Black)
                };
            }
            else
            {
                return (profitPercent) switch
                {
                    >= 18 => (ColorTranslator.FromHtml("#35ff3a"), Color.Black),
                    >= 15 => (ColorTranslator.FromHtml("#5afe5e"), Color.Black),
                    >= 12 => (ColorTranslator.FromHtml("#78ff7b"), Color.Black),
                    >= 9 => (ColorTranslator.FromHtml("#95ff97"), Color.Black),
                    >= 6 => (ColorTranslator.FromHtml("#b1feb3"), Color.Black),
                    >= 3 => (ColorTranslator.FromHtml("#cffed0"), Color.Black),
                    _ => (ColorTranslator.FromHtml("#e9ffea"), Color.Black)
                };
            }
        }
    }
}
