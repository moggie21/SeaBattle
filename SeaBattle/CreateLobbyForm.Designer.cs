namespace SeaBattle
{
    partial class CreateLobbyForm
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
            label1 = new Label();
            textBoxName = new TextBox();
            labelPassword = new Label();
            textBoxPassword = new TextBox();
            checkBoxPrivate = new CheckBox();
            buttonCreate = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 192, 255);
            label1.Location = new Point(45, 50);
            label1.Name = "label1";
            label1.Size = new Size(216, 28);
            label1.TabIndex = 0;
            label1.Text = "Название лобби:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(279, 53);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(340, 27);
            textBoxName.TabIndex = 1;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPassword.ForeColor = Color.FromArgb(192, 192, 255);
            labelPassword.Location = new Point(152, 202);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(109, 28);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Пароль:";
            labelPassword.Visible = false;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(279, 203);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(340, 27);
            textBoxPassword.TabIndex = 3;
            textBoxPassword.Visible = false;
            // 
            // checkBoxPrivate
            // 
            checkBoxPrivate.AutoSize = true;
            checkBoxPrivate.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBoxPrivate.ForeColor = Color.FromArgb(192, 192, 255);
            checkBoxPrivate.Location = new Point(279, 120);
            checkBoxPrivate.Name = "checkBoxPrivate";
            checkBoxPrivate.Size = new Size(178, 32);
            checkBoxPrivate.TabIndex = 4;
            checkBoxPrivate.Text = "   закрытое";
            checkBoxPrivate.UseVisualStyleBackColor = true;
            checkBoxPrivate.CheckedChanged += checkBoxPrivate_CheckedChanged;
            // 
            // buttonCreate
            // 
            buttonCreate.Cursor = Cursors.Hand;
            buttonCreate.FlatStyle = FlatStyle.Flat;
            buttonCreate.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCreate.ForeColor = Color.FromArgb(192, 192, 255);
            buttonCreate.Location = new Point(45, 315);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(216, 52);
            buttonCreate.TabIndex = 5;
            buttonCreate.Text = "Создать";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCancel.ForeColor = Color.FromArgb(192, 192, 255);
            buttonCancel.Location = new Point(403, 315);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(216, 52);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // CreateLobbyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(691, 450);
            Controls.Add(buttonCancel);
            Controls.Add(buttonCreate);
            Controls.Add(checkBoxPrivate);
            Controls.Add(textBoxPassword);
            Controls.Add(labelPassword);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "CreateLobbyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Создание Лобби";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxName;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private CheckBox checkBoxPrivate;
        private Button buttonCreate;
        private Button buttonCancel;
    }
}