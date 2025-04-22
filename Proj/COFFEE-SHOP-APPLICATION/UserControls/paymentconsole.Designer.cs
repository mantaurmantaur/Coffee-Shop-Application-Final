namespace COFFEE_SHOP_APPLICATION.UserControls
{
    partial class paymentconsole
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
            cashbox = new TextBox();
            changebox = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // cashbox
            // 
            cashbox.Location = new Point(33, 39);
            cashbox.Multiline = true;
            cashbox.Name = "cashbox";
            cashbox.PlaceholderText = "Enter Cash";
            cashbox.Size = new Size(547, 57);
            cashbox.TabIndex = 0;
            cashbox.TextChanged += cashInput;
            // 
            // changebox
            // 
            changebox.Location = new Point(33, 130);
            changebox.Multiline = true;
            changebox.Name = "changebox";
            changebox.PlaceholderText = "Change";
            changebox.Size = new Size(547, 57);
            changebox.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(73, 54, 40);
            button1.ForeColor = Color.White;
            button1.Location = new Point(486, 270);
            button1.Name = "button1";
            button1.Size = new Size(94, 47);
            button1.TabIndex = 2;
            button1.Text = "DONE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(76, 100, 68);
            button2.ForeColor = Color.White;
            button2.Location = new Point(33, 270);
            button2.Name = "button2";
            button2.Size = new Size(94, 47);
            button2.TabIndex = 3;
            button2.Text = "Receipt";
            button2.UseVisualStyleBackColor = false;
            // 
            // paymentconsole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(73, 54, 40);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(changebox);
            Controls.Add(cashbox);
            Name = "paymentconsole";
            Size = new Size(619, 354);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox cashbox;
        private TextBox changebox;
        private Button button1;
        private Button button2;
    }
}
