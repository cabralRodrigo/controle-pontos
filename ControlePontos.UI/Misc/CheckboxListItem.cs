namespace ControlePontos.Misc
{
    internal class CheckboxListItem<T>
    {
        public T Value { get; set; }
        public string Display { get; set; }

        public CheckboxListItem(T value, string item)
        {
            this.Value = value;
            this.Display = item;
        }

        public override string ToString()
        {
            return this.Display;
        }
    }
}