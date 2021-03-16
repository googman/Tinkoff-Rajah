using System;
using Googman.TinkoffRajah.Domain;

namespace Googman.TinkoffRajah.Logic.Formatters
{
    public static class FormattingUtils
    {
        public static string FormatCurrency(
            this decimal value,
            GooCurrency currency,
            bool addPlusSign = false,
            bool returnEmptyForZeroes = false)
        {
            string sign;
            bool signBefore;

            switch (currency)
            {
                case GooCurrency.Usd:
                    sign = "$ ";
                    signBefore = true;
                    break;
                case GooCurrency.Eur:
                    sign = " €";
                    signBefore = false;
                    break;
                case GooCurrency.Rub:
                    sign = " ₽";
                    signBefore = false;
                    break;
                default:
                    sign = $" {currency.ToString().ToUpper()}";
                    signBefore = false;
                    break;
            }

            return Format(value, sign, signBefore, addPlusSign, returnEmptyForZeroes, 4);
        }

        public static string FormatPercent(
            this decimal value,
            bool addPlusSign = false,
            bool returnEmptyForZeroes = false)
        {
            return Format(value, "%", false, addPlusSign, returnEmptyForZeroes, 2);
        }

        private static string Format(
            decimal value, 
            string sign,
            bool signBefore,
            bool addPlusSign, 
            bool returnEmptyForZeroes,
            int maxNumberAfterFloatingPoint)
        {
            if (value == 0m && returnEmptyForZeroes)
                return "";

            var isMinus = value < 0;

            var format = $"0.{new string('#', maxNumberAfterFloatingPoint)}";
            var stringValue = $"{Math.Abs(value).ToString(format)}";

            stringValue = signBefore ? $"{sign}{stringValue}" : $"{stringValue}{sign}";

            if (isMinus)
                stringValue = $"- {stringValue}";

            if (addPlusSign && !isMinus && value != 0m)
                stringValue = $"+ {stringValue}";

            return stringValue;
        }
    }
}
