namespace SeaBattle
{
    partial class JoinLobbyForm
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
            labelPrompt = new Label();
            label1 = new Label();
            textBoxPassword = new TextBox();
            buttonJoin = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelPrompt
            // 
            labelPrompt.AutoSize = true;
            labelPrompt.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrompt.ForeColor = Color.FromArgb(192, 192, 255);
            labelPrompt.Location = new Point(42, 178);
            labelPrompt.Name = "labelPrompt";
            labelPrompt.Size = new Size(219, 28);
            labelPrompt.TabIndex = 0;
            labelPrompt.Text = "Введите пароль:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 192, 255);
            label1.Location = new Point(173, 94);
            label1.Name = "label1";
            label1.Size = new Size(360, 28);
            label1.TabIndex = 1;
            label1.Text = "Лобби является закрытым!";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(291, 181);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(341, 27);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonJoin
            // 
            buttonJoin.Cursor = Cursors.Hand;
            buttonJoin.FlatStyle = FlatStyle.Flat;
            buttonJoin.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonJoin.ForeColor = Color.FromArgb(192, 192, 255);
            buttonJoin.Location = new Point(45, 304);
            buttonJoin.Name = "buttonJoin";
            buttonJoin.Size = new Size(296, 52);
            buttonJoin.TabIndex = 6;
            buttonJoin.Text = "Присоединиться";
            buttonJoin.UseVisualStyleBackColor = true;
            buttonJoin.Click += buttonJoin_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancel.ForeColor = Color.FromArgb(192, 192, 255);
            buttonCancel.Location = new Point(416, 304);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(216, 52);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // JoinLobbyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(691, 450);
            Controls.Add(buttonCancel);
            Controls.Add(buttonJoin);
            Controls.Add(textBoxPassword);
            Controls.Add(label1);
            Controls.Add(labelPrompt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "JoinLobbyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Подключение к лобби";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPrompt;
        private Label label1;
        private TextBox textBoxPassword;
        private Button buttonJoin;
        private Button buttonCancel;
    }
}