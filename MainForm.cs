using System;
using System.Windows.Forms;

namespace Clicker
{
    public partial class MainForm : Form
    {
        private readonly Upgrade[] _clickUpgradesList = new Upgrade[5]
        {
            new Upgrade( 20, 10, UpgradeType.Click),
            new Upgrade( 200, 25,  UpgradeType.Click),
            new Upgrade( 500, 100,  UpgradeType.Click),
            new Upgrade( 5000, 250,  UpgradeType.Click),
            new Upgrade( 10000, 500,  UpgradeType.Click)
        };

        private readonly Upgrade[] _autoClickUpgradesList = new Upgrade[5]
        {
            new Upgrade( 20, 10, UpgradeType.AutoClick),
            new Upgrade( 200, 25, UpgradeType.AutoClick),
            new Upgrade( 500, 100, UpgradeType.AutoClick),
            new Upgrade( 5000, 250, UpgradeType.AutoClick),
            new Upgrade( 10000, 500, UpgradeType.AutoClick)
        };

        private Score _scoreData = new Score(0, 1, 0);

        public MainForm()
        {
            InitializeComponent();
            BindUpgradesButton();
            Render();
            RenderClickUpgrade();
        }

        private void BindUpgradesButton()
        {
            foreach (var currentClickUpgrade in _clickUpgradesList)
            {
                currentClickUpgrade.Button.Click += BuyUpgrade;
            }
        }

        private void RenderClickUpgrade()
        {
            clickUpgradesPanel.Controls.Clear();
            clickUpgradesPanel.RowCount = 0;

            for (var clickUpgradeIndex = 0; clickUpgradeIndex < _clickUpgradesList.Length; clickUpgradeIndex++)
            {
                var currentClickUpgrade = _clickUpgradesList[clickUpgradeIndex];

                clickUpgradesPanel.Controls.Add(currentClickUpgrade.Button, 2, clickUpgradeIndex);
                clickUpgradesPanel.Controls.Add(
                    currentClickUpgrade.Label, 1,
                    clickUpgradeIndex);

                clickUpgradesPanel.Controls.Add(
                    currentClickUpgrade.ProgressBar, 3, clickUpgradeIndex);
            }
        }

        private void UpdateUpgradesView()
        {
            foreach (var selectedUpgrade in _clickUpgradesList)
                selectedUpgrade.UpdateView(_scoreData.Value);
        }

        private void RenderScore()
        {
            scoreBox.Text = $@"{_scoreData.Value}";
            scoreProgress.Value = _scoreData.Value;
        }

        private void RenderScorePerClick()
        {
            scorePerClickBox.Text = $@"{_scoreData.PerClick} за клик.";
        }

        private void RenderScorePerSecond()
        {
            scorePerSecondBox.Text = $@"{_scoreData.PerSecond} в секунду.";
        }

        private void Render()
        {
            RenderScore();
            RenderScorePerClick();
            RenderScorePerSecond();
        }

        private void ClickOnMPT(object sender, EventArgs e)
        {
            _scoreData.Value += _scoreData.PerClick;
            UpdateUpgradesView();
            RenderScore();
        }

        private void BuyUpgrade(object sender, EventArgs e)
        {
            var eventButton = sender as Button;
            var selectedUpgrade = eventButton.Tag as Upgrade;
            if (_scoreData.Value >= selectedUpgrade.Price)
            {
                _scoreData.Value -= selectedUpgrade.Price;
                switch (selectedUpgrade.Type)
                {
                    case UpgradeType.Click:
                        _scoreData.PerClick += selectedUpgrade.Value;
                        break;
                    case UpgradeType.AutoClick:
                        _scoreData.PerSecond += selectedUpgrade.Value;
                        break;
                    default:
                        return;
                }
                selectedUpgrade.UpdatePriceForUpgrade();
                UpdateUpgradesView();
                Render();
            }
            else
            {
                selectedUpgrade.Button.Enabled = false;
            }
        
        }
    }
}