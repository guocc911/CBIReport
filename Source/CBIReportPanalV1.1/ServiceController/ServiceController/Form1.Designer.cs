namespace ServiceController
{
    partial class MainForm
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
            this.ServiceTextBox = new System.Windows.Forms.TextBox();
            this.ServiceNameLabel = new System.Windows.Forms.Label();
            this.StatusButton = new System.Windows.Forms.Button();
            this.DisableButton = new System.Windows.Forms.Button();
            this.EnableButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServiceTextBox
            // 
            this.ServiceTextBox.Location = new System.Drawing.Point(168, 40);
            this.ServiceTextBox.Name = "ServiceTextBox";
            this.ServiceTextBox.Size = new System.Drawing.Size(198, 31);
            this.ServiceTextBox.TabIndex = 0;
            this.ServiceTextBox.Text = "Spooler";
            // 
            // ServiceNameLabel
            // 
            this.ServiceNameLabel.AutoSize = true;
            this.ServiceNameLabel.Location = new System.Drawing.Point(13, 43);
            this.ServiceNameLabel.Name = "ServiceNameLabel";
            this.ServiceNameLabel.Size = new System.Drawing.Size(149, 25);
            this.ServiceNameLabel.TabIndex = 1;
            this.ServiceNameLabel.Text = "Service name:";
            // 
            // StatusButton
            // 
            this.StatusButton.Location = new System.Drawing.Point(18, 229);
            this.StatusButton.Name = "StatusButton";
            this.StatusButton.Size = new System.Drawing.Size(334, 47);
            this.StatusButton.TabIndex = 5;
            this.StatusButton.Text = "Status";
            this.StatusButton.UseVisualStyleBackColor = true;
            this.StatusButton.Click += new System.EventHandler(this.StatusButton_Click);
            // 
            // DisableButton
            // 
            this.DisableButton.Location = new System.Drawing.Point(18, 97);
            this.DisableButton.Name = "DisableButton";
            this.DisableButton.Size = new System.Drawing.Size(156, 47);
            this.DisableButton.TabIndex = 1;
            this.DisableButton.Text = "Disable";
            this.DisableButton.UseVisualStyleBackColor = true;
            this.DisableButton.Click += new System.EventHandler(this.DisableButton_Click);
            // 
            // EnableButton
            // 
            this.EnableButton.Location = new System.Drawing.Point(18, 164);
            this.EnableButton.Name = "EnableButton";
            this.EnableButton.Size = new System.Drawing.Size(156, 47);
            this.EnableButton.TabIndex = 3;
            this.EnableButton.Text = "Enable";
            this.EnableButton.UseVisualStyleBackColor = true;
            this.EnableButton.Click += new System.EventHandler(this.EnableButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(196, 97);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(156, 47);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(196, 164);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(156, 47);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 305);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.EnableButton);
            this.Controls.Add(this.DisableButton);
            this.Controls.Add(this.StatusButton);
            this.Controls.Add(this.ServiceNameLabel);
            this.Controls.Add(this.ServiceTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "ServiceController v1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServiceTextBox;
        private System.Windows.Forms.Label ServiceNameLabel;
        private System.Windows.Forms.Button StatusButton;
        private System.Windows.Forms.Button DisableButton;
        private System.Windows.Forms.Button EnableButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
    }
}

