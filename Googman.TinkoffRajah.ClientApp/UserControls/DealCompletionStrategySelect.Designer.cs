using System;
using System.Drawing;
using System.Windows.Forms;

namespace Googman.TinkoffRajah.ClientApp.UserControls
{
    partial class DealCompletionStrategySelect
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private ComboBox ctrlDealCompletionStrategy;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlDealCompletionStrategy = new ComboBox();
            this.SuspendLayout();
            this.ctrlDealCompletionStrategy.Dock = DockStyle.Fill;
            this.ctrlDealCompletionStrategy.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ctrlDealCompletionStrategy.FormattingEnabled = true;
            this.ctrlDealCompletionStrategy.Location = new Point(0, 0);
            this.ctrlDealCompletionStrategy.Name = "ctrlDealCompletionStrategy";
            this.ctrlDealCompletionStrategy.Size = new Size(150, 23);
            this.ctrlDealCompletionStrategy.TabIndex = 2;
            this.ctrlDealCompletionStrategy.SelectedIndexChanged += new EventHandler(this.ctrlDealCompletionStrategy_SelectedIndexChanged);
            this.AutoScaleDimensions = new SizeF(7f, 15f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add((Control)this.ctrlDealCompletionStrategy);
            this.Name = nameof(DealCompletionStrategySelect);
            this.ResumeLayout(false);
        }
    }
}
