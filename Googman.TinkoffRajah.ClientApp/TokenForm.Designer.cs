
namespace Googman.TinkoffRajah.ClientApp
{
    partial class TokenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlTokenText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlOkButton = new System.Windows.Forms.Button();
            this.ctrlCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlTokenText
            // 
            this.ctrlTokenText.Location = new System.Drawing.Point(12, 28);
            this.ctrlTokenText.Name = "ctrlTokenText";
            this.ctrlTokenText.Size = new System.Drawing.Size(413, 21);
            this.ctrlTokenText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter your Tinkoff API Token here:";
            // 
            // ctrlOkButton
            // 
            this.ctrlOkButton.Location = new System.Drawing.Point(12, 55);
            this.ctrlOkButton.Name = "ctrlOkButton";
            this.ctrlOkButton.Size = new System.Drawing.Size(75, 26);
            this.ctrlOkButton.TabIndex = 2;
            this.ctrlOkButton.Text = "OK";
            this.ctrlOkButton.UseVisualStyleBackColor = true;
            this.ctrlOkButton.Click += new System.EventHandler(this.ctrlOkButton_Click);
            // 
            // ctrlCancelButton
            // 
            this.ctrlCancelButton.Location = new System.Drawing.Point(93, 55);
            this.ctrlCancelButton.Name = "ctrlCancelButton";
            this.ctrlCancelButton.Size = new System.Drawing.Size(75, 26);
            this.ctrlCancelButton.TabIndex = 3;
            this.ctrlCancelButton.Text = "Cancel";
            this.ctrlCancelButton.UseVisualStyleBackColor = true;
            this.ctrlCancelButton.Click += new System.EventHandler(this.ctrlCancelButton_Click);
            // 
            // TokenForm
            // 
            this.AcceptButton = this.ctrlOkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ctrlCancelButton;
            this.ClientSize = new System.Drawing.Size(437, 92);
            this.Controls.Add(this.ctrlCancelButton);
            this.Controls.Add(this.ctrlOkButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlTokenText);
            this.Font = new System.Drawing.Font("Ubuntu", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TokenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tinkoff API Token";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ctrlTokenText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ctrlOkButton;
        private System.Windows.Forms.Button ctrlCancelButton;
    }
}