using System;
using System.Drawing;
using System.Windows.Forms;

public enum UpgradeType
{
    Click,
    AutoClick
}

namespace Clicker
{
    public class Upgrade
    {
        public Button Button;

        public Label Label;
        public int Price;
        public ProgressBar ProgressBar;
        public UpgradeType Type;
        public readonly int Value;

        public Upgrade(int price, int value, UpgradeType type)
        {
            Price = price;
            Value = value;
            Type = type;

            Label = new Label
            {
                Tag = this,
                Text = $@"{price}",
                TextAlign = ContentAlignment.MiddleCenter
            };
            Button = new Button
            {
                Tag = this,
                Text = $@"+{value}",
                TextAlign = ContentAlignment.MiddleCenter,
                Enabled = false
            };

            ProgressBar = new ProgressBar
            {
                Tag = this,
                Maximum = price
            };
        }

        public void UpdatePriceForUpgrade()
        {
            Price = (int)(Price * 1.4);
            Label.Text = $@"{Price}";
            ProgressBar.Maximum = Price;
        }

        public void UpdateView(int score)
        {
            if (score > Price - 1)
            {
                Button.Enabled = true;
                ProgressBar.Value = ProgressBar.Maximum;
            }
            else
            {
                Button.Enabled = false;
                ProgressBar.Value = score;
            }
        }
    }
}