using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Clicker
{
    public partial class MainForm : Form
    {
        private readonly List<Upgrade> _autoClickUpgradesList = new List<Upgrade>();
        private readonly List<Upgrade> _clickUpgradesList = new List<Upgrade>();
        private Save _save;

        private Score _scoreData = new Score(0, 1, 0);

        public MainForm()
        {
            InitializeComponent();
            LoadSave();
            BindUpgradesButton();
            Render();
            RenderClickUpgrades();
            RenderAutoClickUpgrades();
        }

        private void LoadSave()
        {
            UpgradeSave[] defaultUpgrades =
            {
                new UpgradeSave(20, 10, UpgradeType.Click),
                new UpgradeSave(200, 25, UpgradeType.Click),
                new UpgradeSave(500, 100, UpgradeType.Click),
                new UpgradeSave(5000, 250, UpgradeType.Click),
                new UpgradeSave(10000, 500, UpgradeType.Click),

                new UpgradeSave(20, 10, UpgradeType.AutoClick),
                new UpgradeSave(200, 25, UpgradeType.AutoClick),
                new UpgradeSave(500, 100, UpgradeType.AutoClick),
                new UpgradeSave(5000, 250, UpgradeType.AutoClick),
                new UpgradeSave(10000, 500, UpgradeType.AutoClick)
            };

            _save = File.Exists("save.json")
                ? JsonConvert.DeserializeObject<Save>(File.ReadAllText("save.json"))
                : new Save(0, 1, 0, defaultUpgrades);

            _scoreData.Value = _save.Score;
            _scoreData.PerClick = _save.ScorePerClick;
            _scoreData.PerSecond = _save.ScorePerSecond;
            if (_scoreData.PerSecond > 0 && interval.Enabled == false)
            {
                interval.Enabled = true;
                interval.Tick += IntervalEventProcessor;
            }
            
            foreach (var upgrade in _save.Upgrades)
                if (upgrade.Type == UpgradeType.Click)
                    _clickUpgradesList.Add(new Upgrade(upgrade.Price, upgrade.Value, upgrade.Type));
                else if (upgrade.Type == UpgradeType.AutoClick)
                    _autoClickUpgradesList.Add(new Upgrade(upgrade.Price, upgrade.Value, upgrade.Type));
        }

        private void UpdateSaveData()
        {
            var upgradesToSave = new List<UpgradeSave>();
            _clickUpgradesList.ForEach(upgrade =>
            {
                upgradesToSave.Add(new UpgradeSave(upgrade.Price, upgrade.Value, upgrade.Type));
            });

            _autoClickUpgradesList.ForEach(upgrade =>
            {
                upgradesToSave.Add(new UpgradeSave(upgrade.Price, upgrade.Value, upgrade.Type));
            });
            _save = new Save(_scoreData.Value, _scoreData.PerClick, _scoreData.PerSecond, upgradesToSave.ToArray());
        }

        private void WriteSave()
        {
            UpdateSaveData();
            File.WriteAllText("save.json", JsonConvert.SerializeObject(_save));
        }

        private void BindUpgradesButton()
        {
            foreach (var currentClickUpgrade in _clickUpgradesList.Concat(_autoClickUpgradesList))
                currentClickUpgrade.Button.Click += BuyUpgrade;
        }

        private void RenderClickUpgrades()
        {
            clickUpgradesPanel.Controls.Clear();
            clickUpgradesPanel.RowCount = 0;

            for (var clickUpgradeIndex = 0; clickUpgradeIndex < _clickUpgradesList.Count; clickUpgradeIndex++)
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

        private void RenderAutoClickUpgrades()
        {
            autoClickUpgradesPanel.Controls.Clear();
            autoClickUpgradesPanel.RowCount = 0;
            for (var autoClickUpgradeIndex = 0;
                autoClickUpgradeIndex < _autoClickUpgradesList.Count;
                autoClickUpgradeIndex++)
            {
                var currentAutoClickUpgrade = _autoClickUpgradesList[autoClickUpgradeIndex];

                autoClickUpgradesPanel.Controls.Add(currentAutoClickUpgrade.Button, 2, autoClickUpgradeIndex);
                autoClickUpgradesPanel.Controls.Add(
                    currentAutoClickUpgrade.Label, 3,
                    autoClickUpgradeIndex);

                autoClickUpgradesPanel.Controls.Add(
                    currentAutoClickUpgrade.ProgressBar, 1, autoClickUpgradeIndex);
            }
        }

        private void UpdateUpgradesView()
        {
            foreach (var selectedUpgrade in _clickUpgradesList.Concat(_autoClickUpgradesList))
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

        private void IntervalEventProcessor(object intervalTick, EventArgs e)
        {
            _scoreData.Value += _scoreData.PerSecond;
            RenderScore();
            UpdateUpgradesView();
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
                        if (interval.Enabled == false)
                        {
                            interval.Enabled = true;
                            interval.Tick += IntervalEventProcessor;
                        }

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

        private void MainFormClosing(object sender, FormClosedEventArgs e)
        {
            WriteSave();
        }
    }
}