namespace BackgroundProcessUI
{
    partial class BackgroundProcessUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackgroundProcessUI));
            StartProcess = new Button();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            Url = new TextBox();
            Browsers = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // StartProcess
            // 
            StartProcess.AutoEllipsis = true;
            StartProcess.BackColor = Color.Transparent;
            StartProcess.BackgroundImageLayout = ImageLayout.None;
            StartProcess.FlatAppearance.BorderColor = SystemColors.Desktop;
            StartProcess.FlatAppearance.BorderSize = 0;
            StartProcess.FlatAppearance.MouseDownBackColor = Color.Transparent;
            StartProcess.FlatAppearance.MouseOverBackColor = Color.Transparent;
            StartProcess.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            StartProcess.ForeColor = SystemColors.Desktop;
            StartProcess.Location = new Point(423, 264);
            StartProcess.Name = "StartProcess";
            StartProcess.Size = new Size(232, 36);
            StartProcess.TabIndex = 0;
            StartProcess.Text = "Start Process";
            StartProcess.UseVisualStyleBackColor = false;
            StartProcess.Click += StartProcess_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(Url);
            panel1.Controls.Add(Browsers);
            panel1.Controls.Add(StartProcess);
            panel1.Location = new Point(-1, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(906, 475);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("HoloLens MDL2 Assets", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(225, 195);
            label2.Name = "label2";
            label2.Size = new Size(115, 28);
            label2.TabIndex = 5;
            label2.Text = "Insert URL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("HoloLens MDL2 Assets", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(225, 135);
            label1.Name = "label1";
            label1.Size = new Size(158, 28);
            label1.TabIndex = 4;
            label1.Text = "Select Browser";
            // 
            // Url
            // 
            Url.Location = new Point(422, 204);
            Url.Multiline = true;
            Url.Name = "Url";
            Url.Size = new Size(232, 32);
            Url.TabIndex = 3;
            // 
            // Browsers
            // 
            Browsers.FormattingEnabled = true;
            Browsers.Location = new Point(423, 144);
            Browsers.Name = "Browsers";
            Browsers.Size = new Size(231, 29);
            Browsers.TabIndex = 2;
            // 
            // BackgroundProcessUI
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 472);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "BackgroundProcessUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button StartProcess;
        private Panel panel1;
        private Label label1;
        private TextBox Url;
        private ComboBox Browsers;
        private Label label2;
    }
}