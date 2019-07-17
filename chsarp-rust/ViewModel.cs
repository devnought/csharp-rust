namespace chsarp_rust
{
    public class ViewModel
    {
        public ViewModel(string stringValue, long intValue)
        {
            StringValue = stringValue;
            IntValue = intValue;
        }

        public string StringValue { get; }

        public long IntValue { get; }
    }
}
