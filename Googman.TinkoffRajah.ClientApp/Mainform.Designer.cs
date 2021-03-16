
namespace Googman.TinkoffRajah.ClientApp
{
    partial class Mainform
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlIncompleteDealsList = new Googman.TinkoffRajah.ClientApp.UserControls.IncompleteDealsList();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlCompleteDealsList = new Googman.TinkoffRajah.ClientApp.UserControls.CompleteDealsList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlPricesLastUpdated = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlOperationsLastUpdated = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlDealCompletionStrategy = new Googman.TinkoffRajah.ClientApp.UserControls.DealCompletionStrategySelect();
            this.ctrlTimerOperations = new System.Windows.Forms.Timer(this.components);
            this.ctrlTimerPrices = new System.Windows.Forms.Timer(this.components);
            this.ctrlTimerCurrentPrice = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(16, 73);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 369);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlIncompleteDealsList);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(760, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Incomplete Deals";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlIncompleteDealsList
            // 
            this.ctrlIncompleteDealsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlIncompleteDealsList.Font = new System.Drawing.Font("Ubuntu Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ctrlIncompleteDealsList.Location = new System.Drawing.Point(2, 2);
            this.ctrlIncompleteDealsList.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.ctrlIncompleteDealsList.Name = "ctrlIncompleteDealsList";
            this.ctrlIncompleteDealsList.Size = new System.Drawing.Size(756, 336);
            this.ctrlIncompleteDealsList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlCompleteDealsList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(760, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Complete Deals";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlCompleteDealsList
            // 
            this.ctrlCompleteDealsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlCompleteDealsList.Location = new System.Drawing.Point(2, 2);
            this.ctrlCompleteDealsList.Name = "ctrlCompleteDealsList";
            this.ctrlCompleteDealsList.Size = new System.Drawing.Size(756, 336);
            this.ctrlCompleteDealsList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ctrlPricesLastUpdated);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ctrlOperationsLastUpdated);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ctrlDealCompletionStrategy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(16, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 65);
            this.panel1.TabIndex = 1;
            // 
            // ctrlPricesLastUpdated
            // 
            this.ctrlPricesLastUpdated.AutoSize = true;
            this.ctrlPricesLastUpdated.Font = new System.Drawing.Font("Ubuntu", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ctrlPricesLastUpdated.Location = new System.Drawing.Point(386, 28);
            this.ctrlPricesLastUpdated.Name = "ctrlPricesLastUpdated";
            this.ctrlPricesLastUpdated.Size = new System.Drawing.Size(12, 16);
            this.ctrlPricesLastUpdated.TabIndex = 6;
            this.ctrlPricesLastUpdated.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ubuntu", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(386, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Prices last updated:";
            // 
            // ctrlOperationsLastUpdated
            // 
            this.ctrlOperationsLastUpdated.AutoSize = true;
            this.ctrlOperationsLastUpdated.Font = new System.Drawing.Font("Ubuntu", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ctrlOperationsLastUpdated.Location = new System.Drawing.Point(197, 28);
            this.ctrlOperationsLastUpdated.Name = "ctrlOperationsLastUpdated";
            this.ctrlOperationsLastUpdated.Size = new System.Drawing.Size(12, 16);
            this.ctrlOperationsLastUpdated.TabIndex = 4;
            this.ctrlOperationsLastUpdated.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(197, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Operations last updated:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Deal completion strategy:";
            // 
            // ctrlDealCompletionStrategy
            // 
            this.ctrlDealCompletionStrategy.AutoSize = true;
            this.ctrlDealCompletionStrategy.Location = new System.Drawing.Point(7, 25);
            this.ctrlDealCompletionStrategy.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.ctrlDealCompletionStrategy.Name = "ctrlDealCompletionStrategy";
            this.ctrlDealCompletionStrategy.Size = new System.Drawing.Size(149, 27);
            this.ctrlDealCompletionStrategy.TabIndex = 1;
            this.ctrlDealCompletionStrategy.OnStrategySelected += new System.Action<Googman.TinkoffRajah.Domain.GooDealCompleteStrategy>(this.dealCompletionStrategySelect1_OnStrategySelected);
            // 
            // ctrlTimerOperations
            // 
            this.ctrlTimerOperations.Enabled = true;
            this.ctrlTimerOperations.Interval = 30000;
            this.ctrlTimerOperations.Tick += new System.EventHandler(this.ctrlTimerOperations_Tick);
            // 
            // ctrlTimerPrices
            // 
            this.ctrlTimerPrices.Enabled = true;
            this.ctrlTimerPrices.Interval = 15000;
            this.ctrlTimerPrices.Tick += new System.EventHandler(this.ctrlTimerPrices_Tick);
            // 
            // ctrlTimerCurrentPrice
            // 
            this.ctrlTimerCurrentPrice.Enabled = true;
            this.ctrlTimerCurrentPrice.Interval = 5000;
            this.ctrlTimerCurrentPrice.Tick += new System.EventHandler(this.ctrlTimerCurrentPrice_Tick);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Ubuntu", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Mainform";
            this.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tinkoff Rajah";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private UserControls.DealCompletionStrategySelect ctrlDealCompletionStrategy;
        private UserControls.IncompleteDealsList ctrlIncompleteDealsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer ctrlTimerOperations;
        private System.Windows.Forms.Timer ctrlTimerPrices;
        private System.Windows.Forms.Label ctrlPricesLastUpdated;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ctrlOperationsLastUpdated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer ctrlTimerCurrentPrice;
        private UserControls.CompleteDealsList ctrlCompleteDealsList;
    }
}

