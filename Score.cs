namespace Clicker
{
    public  struct Score
    {
        public int Value;
        public int PerClick;
        public int PerSecond;

        public Score(int inputValue, int inputPerClick, int inputPerSecond)
        {
            Value = inputValue;
            PerClick = inputPerClick;
            PerSecond = inputPerSecond;
        }
    }
}