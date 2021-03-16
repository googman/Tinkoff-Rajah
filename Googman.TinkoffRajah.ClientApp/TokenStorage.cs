using Microsoft.Win32;

namespace Googman.TinkoffRajah.ClientApp
{
    public static class TokenStorage
    {
        public static string Token
        {
            get => ReadFromRegistry("Token");
            set => WriteToRegistry("Token", value);
        }

        private static string ReadFromRegistry(string keyName)
        {
            var key = GetAppKey();
            return key.GetValue(keyName, null)?.ToString();
        }

        private static void WriteToRegistry(string keyName, string value)
        {
            var key = GetAppKey();
            key?.SetValue(keyName, value);
        }

        private static RegistryKey GetAppKey()
        {
            var key = Registry.CurrentUser.OpenSubKey("Software", true);
            if (key == null) return null;

            key.CreateSubKey("TinkoffRajah");
            key = key.OpenSubKey("TinkoffRajah", true);

            return key;
        }
    }
}
