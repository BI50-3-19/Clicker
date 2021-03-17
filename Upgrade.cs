﻿using System;
using System.Drawing;
using System.Windows.Forms;

public enum UpgradeType
{
    Click = 0,
    AutoClick = 1
}

namespace Clicker
{
    public class Upgrade
    {
        public Button Button;

        private int ID;
        public Label Label;
        public int Price;
        public ProgressBar ProgressBar;
        public UpgradeType Type;
        public readonly int Value;

        public Upgrade(int id, int price, int value, UpgradeType type)
        {
            ID = id;
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