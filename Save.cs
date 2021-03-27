namespace Clicker
{
    public readonly struct UpgradeSave // Предоставляет структуру для хранения данных об улучшении
    {
        public readonly int Price; // Отвечает за цену улучшения
        public readonly int Value; // Отвечает за значение улучшения
        public readonly UpgradeType Type; // Отвечает за тип улучшения

        public UpgradeSave(int price, int value, UpgradeType type)
        {
            Price = price;
            Value = value;
            Type = type;
        }
    }

    public readonly struct Save // Предоставляет структуру для хранения данных об сохранении
    {
        public readonly int Score; // Количество очков
        public readonly int ScorePerClick; // Количество очков за клик
        public readonly int ScorePerSecond; // Количество очков за секунду
        public readonly UpgradeSave[] Upgrades; // Массив с структурой данных улучшений

        public Save(int score, int scorePerClick, int scorePerSecond, UpgradeSave[] upgrades)
        {
            Score = score;
            ScorePerClick = scorePerClick;
            ScorePerSecond = scorePerSecond;
            Upgrades = upgrades;
        }
    }
}