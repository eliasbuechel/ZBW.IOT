
namespace LedBoardSim
{
    partial class LedBoardSimMain
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
            this.Widgets = new System.Windows.Forms.FlowLayoutPanel();
            this.Monitor = new System.Windows.Forms.TextBox();
            this.Widgets.SuspendLayout();
            this.SuspendLayout();
            // 
            // Widgets
            // 
            this.Widgets.AutoSize = true;
            this.Widgets.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Widgets.Controls.Add(this.Monitor);
            this.Widgets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Widgets.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Widgets.Location = new System.Drawing.Point(0, 0);
            this.Widgets.Name = "Widgets";
            this.Widgets.Size = new System.Drawing.Size(445, 290);
            this.Widgets.TabIndex = 0;
            // 
            // Monitor
            // 
            this.Monitor.Location = new System.Drawing.Point(3, 3);
            this.Monitor.Multiline = true;
            this.Monitor.Name = "Monitor";
            this.Monitor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Monitor.Size = new System.Drawing.Size(440, 210);
            this.Monitor.TabIndex = 0;
            // 
            // LedBoardSimMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(445, 290);
            this.Controls.Add(this.Widgets);
            this.Name = "LedBoardSimMain";
            this.Text = "LED Board Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LedBoardSimMain_FormClosing);
            this.Load += new System.EventHandler(this.LedBoard_Load);
            this.Widgets.ResumeLayout(false);
            this.Widgets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Widgets;
        private System.Windows.Forms.TextBox Monitor;
    }
}

