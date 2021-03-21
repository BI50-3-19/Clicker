namespace Clicker
{
    public struct UpgradeSave
    {
        private int _price;
        private int _value;
        private UpgradeType _type;

        public UpgradeSave(int price, int value, UpgradeType type)
        {
            _price = price;
            _value = value;
            _type = type;
        }
    }

    public struct Save
    {
        private int _score;
        private int _scorePerClick;
        private int _scorePerSecond;
        private UpgradeSave[] _upgrades;

        public Save(int score, int scorePerClick, int scorePerSecond, UpgradeSave[] upgrades)
        {
            _score = score;
            _scorePerClick = scorePerClick;
            _scorePerSecond = scorePerSecond;
            _upgrades = upgrades;
        }
    }
}