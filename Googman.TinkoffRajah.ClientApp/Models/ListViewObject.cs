namespace Googman.TinkoffRajah.ClientApp.Models
{
    public sealed class ListViewObject
    {
        public object Value { get; set; }
        public string DisplayAlias { get; set; }

        public override string ToString() => DisplayAlias;

        public ListViewObject(object value, string displayAlias)
        {
            Value = value;
            DisplayAlias = displayAlias;
        }

        public ListViewObject(string value)
        {
            Value = value;
            DisplayAlias = value;
        }
    }
}
