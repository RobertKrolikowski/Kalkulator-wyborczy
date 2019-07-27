namespace kalkulator_wyborczy
{
    partial class VoteWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.VoteButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(12, 619);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(125, 51);
            this.LogoutButton.TabIndex = 0;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // VoteButton
            // 
            this.VoteButton.Location = new System.Drawing.Point(1069, 619);
            this.VoteButton.Name = "VoteButton";
            this.VoteButton.Size = new System.Drawing.Size(125, 51);
            this.VoteButton.TabIndex = 1;
            this.VoteButton.Text = "Vote";
            this.VoteButton.UseVisualStyleBackColor = true;
            this.VoteButton.Click += new System.EventHandler(this.VoteButton_Click);
            // 
            // chart1
            // 
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            chartArea2.AxisX2.IsLabelAutoFit = false;
            chartArea2.AxisX2.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 94F;
            chartArea2.Position.Width = 70F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 3F;
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.IsTextAutoFit = false;
            legend2.ItemColumnSpacing = 2;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Candidate";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1160, 601);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // chartButton
            // 
            this.chartButton.Location = new System.Drawing.Point(587, 619);
            this.chartButton.Name = "chartButton";
            this.chartButton.Size = new System.Drawing.Size(123, 51);
            this.chartButton.TabIndex = 3;
            this.chartButton.Text = "Chart";
            this.chartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.chartButton.UseVisualStyleBackColor = true;
            this.chartButton.Visible = false;
            this.chartButton.Click += new System.EventHandler(this.chartButton_Click);
            // 
            // VoteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 682);
            this.Controls.Add(this.chartButton);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.VoteButton);
            this.Controls.Add(this.LogoutButton);
            this.Name = "VoteWindow";
            this.Text = "Vote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VoteWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Button VoteButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button chartButton;
    }
}