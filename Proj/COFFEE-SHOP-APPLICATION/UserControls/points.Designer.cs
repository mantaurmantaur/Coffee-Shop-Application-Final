namespace COFFEE_SHOP_APPLICATION
{
    partial class points
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            redeembtn = new Button();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // redeembtn
            // 
            redeembtn.BackColor = Color.FromArgb(73, 54, 40);
            redeembtn.FlatStyle = FlatStyle.Flat;
            redeembtn.ForeColor = Color.White;
            redeembtn.Location = new Point(288, 178);
            redeembtn.Name = "redeembtn";
            redeembtn.Size = new Size(94, 29);
            redeembtn.TabIndex = 0;
            redeembtn.Text = "Redeem";
            redeembtn.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(15, 178);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(76, 100, 68);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(15, 31);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(367, 120);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // points
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(redeembtn);
            Name = "points";
            Size = new Size(407, 218);
            ResumeLayout(false);
        }

        #endregion

        private Button redeembtn;
        private Button button1;
        private RichTextBox richTextBox1;
    }
}
