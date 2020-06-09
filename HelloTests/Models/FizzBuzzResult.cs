namespace HelloTests
{
    public class FizzBuzzResult
    {
        public FizzBuzzResult(int value, FizzBuzzState state)
        {
            this.Value = value;
            this.State = state;
        }

        public int Value { get; private set; }
        public FizzBuzzState State { get; private set; }
    }

}
