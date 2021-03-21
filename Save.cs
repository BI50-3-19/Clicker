namespace Clicker
{
    public readonly struct UpgradeSave
    {
        public readonly int Price;
        public readonly int Value;
        public readonly UpgradeType Type;

        public UpgradeSave(int price, int value, UpgradeType type)
        {
            Price = price;
            Value = value;
            Type = type;
        }
    }

    public readonly struct  Save
    {
        public readonly int Score;
        public readonly int ScorePerClick;
        public readonly int ScorePerSecond;
        public readonly UpgradeSave[] Upgrades;

        public Save(int score, int scorePerClick, int scorePerSecond, UpgradeSave[] upgrades)
        {
            Score = score;
            ScorePerClick = scorePerClick;
            ScorePerSecond = scorePerSecond;
            Upgrades = upgrades;
        }
    }
}