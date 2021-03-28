namespace Clicker
{
    public struct Score
    {
        public int Value; // Количество очков
        public int PerClick; // Количество очков за клик
        public int PerSecond; // Количество очков за секунду

        public Score(int inputValue, int inputPerClick, int inputPerSecond)
        {
            Value = inputValue;
            PerClick = inputPerClick;
            PerSecond = inputPerSecond;
        }
    }
}