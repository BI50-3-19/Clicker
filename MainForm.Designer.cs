
using System.Windows.Forms;

namespace Clicker
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ClickButton = new System.Windows.Forms.Button();
            this.interval = new System.Windows.Forms.Timer(this.components);
            this.scorePerSecondBox = new System.Windows.Forms.TextBox();
            this.scorePerClickBox = new System.Windows.Forms.TextBox();
            this.scoreBox = new System.Windows.Forms.TextBox();
            this.clickUpgradesPanel = new System.Windows.Forms.TableLayoutPanel();
            this.clickUpgradesLabel = new System.Windows.Forms.Label();
            this.scoreProgress = new System.Windows.Forms.ProgressBar();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.SuspendLayout();
            // 
            // ClickButton
            // 
            this.ClickButton.Image = ((System.Drawing.Image)(resources.GetObject("ClickButton.Image")));
            this.ClickButton.Location = new System.Drawing.Point(350, 194);
            this.ClickButton.Name = "ClickButton";
            this.ClickButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClickButton.Size = new System.Drawing.Size(160, 144);
            this.ClickButton.TabIndex = 0;
            this.ClickButton.UseVisualStyleBackColor = true;
            this.ClickButton.Click += new System.EventHandler(this.ClickOnMPT);
            // 
            // interval
            // 
            this.interval.Interval = 1000;
            // 
            // scorePerSecondBox
            // 
            this.scorePerSecondBox.Enabled = false;
            this.scorePerSecondBox.Location = new System.Drawing.Point(350, 154);
            this.scorePerSecondBox.Name = "scorePerSecondBox";
            this.scorePerSecondBox.Size = new System.Drawing.Size(160, 20);
            this.scorePerSecondBox.TabIndex = 2;
            this.scorePerSecondBox.Text = "0";
            this.scorePerSecondBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // scorePerClickBox
            // 
            this.scorePerClickBox.Enabled = false;
            this.scorePerClickBox.Location = new System.Drawing.Point(350, 106);
            this.scorePerClickBox.Name = "scorePerClickBox";
            this.scorePerClickBox.Size = new System.Drawing.Size(160, 20);
            this.scorePerClickBox.TabIndex = 3;
            this.scorePerClickBox.Text = "0";
            this.scorePerClickBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // scoreBox
            // 
            this.scoreBox.Enabled = false;
            this.scoreBox.Location = new System.Drawing.Point(350, 68);
            this.scoreBox.Name = "scoreBox";
            this.scoreBox.Size = new System.Drawing.Size(160, 20);
            this.scoreBox.TabIndex = 4;
            this.scoreBox.Text = "0";
            this.scoreBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // clickUpgradesPanel
            // 
            this.clickUpgradesPanel.Location = new System.Drawing.Point(12, 68);
            this.clickUpgradesPanel.Name = "clickUpgradesPanel";
            this.clickUpgradesPanel.Size = new System.Drawing.Size(276, 414);
            this.clickUpgradesPanel.TabIndex = 5;
            // 
            // clickUpgradesLabel
            // 
            this.clickUpgradesLabel.AutoSize = true;
            this.clickUpgradesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clickUpgradesLabel.Location = new System.Drawing.Point(5, 19);
            this.clickUpgradesLabel.Name = "clickUpgradesLabel";
            this.clickUpgradesLabel.Size = new System.Drawing.Size(256, 37);
            this.clickUpgradesLabel.TabIndex = 6;
            this.clickUpgradesLabel.Text = "Улучшения клика";
            // 
            // scoreProgress
            // 
            this.scoreProgress.Location = new System.Drawing.Point(350, 12);
            this.scoreProgress.Maximum = 2147483647;
            this.scoreProgress.Name = "scoreProgress";
            this.scoreProgress.Size = new System.Drawing.Size(160, 44);
            this.scoreProgress.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 505);
            this.Controls.Add(this.scoreProgress);
            this.Controls.Add(this.clickUpgradesLabel);
            this.Controls.Add(this.clickUpgradesPanel);
            this.Controls.Add(this.scoreBox);
            this.Controls.Add(this.scorePerClickBox);
            this.Controls.Add(this.scorePerSecondBox);
            this.Controls.Add(this.ClickButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "MainForm";
            this.Text = "MPT Clicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClickButton;
        private System.Windows.Forms.Timer interval;
        private System.Windows.Forms.TextBox scorePerSecondBox;
        private System.Windows.Forms.TextBox scorePerClickBox;
        private System.Windows.Forms.TextBox scoreBox;
        private System.Windows.Forms.TableLayoutPanel clickUpgradesPanel;
        private System.Windows.Forms.Label clickUpgradesLabel;
        private System.Windows.Forms.ProgressBar scoreProgress;
    }
}

