namespace CheckDomain
{
    partial class Form1
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
            lblUrl = new Label();
            txtUrl = new TextBox();
            btnChecker = new Button();
            txtPreview = new TextBox();
            SuspendLayout();
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new Point(13, 15);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(62, 16);
            lblUrl.TabIndex = 0;
            lblUrl.Text = "Enter Url:";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(74, 12);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(201, 23);
            txtUrl.TabIndex = 1;
            // 
            // btnChecker
            // 
            btnChecker.Location = new Point(281, 12);
            btnChecker.Name = "btnChecker";
            btnChecker.Size = new Size(75, 23);
            btnChecker.TabIndex = 2;
            btnChecker.Text = "Check";
            btnChecker.UseVisualStyleBackColor = true;
            btnChecker.Click += btnChecker_Click;
            // 
            // txtPreview
            // 
            txtPreview.Location = new Point(13, 42);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.ScrollBars = ScrollBars.Vertical;
            txtPreview.Size = new Size(343, 278);
            txtPreview.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 332);
            Controls.Add(txtPreview);
            Controls.Add(btnChecker);
            Controls.Add(txtUrl);
            Controls.Add(lblUrl);
            Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUrl;
        private TextBox txtUrl;
        private Button btnChecker;
        private TextBox txtPreview;
    }
}
