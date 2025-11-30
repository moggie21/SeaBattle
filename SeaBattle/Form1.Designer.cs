namespace SeaBattle
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
            enemyPanel = new TableLayoutPanel();
            label2 = new Label();
            panel1 = new Panel();
            radioHorizontal = new RadioButton();
            radioVertical = new RadioButton();
            label5 = new Label();
            btnShip3 = new Button();
            btnShip2 = new Button();
            btnShip1 = new Button();
            btnShip4 = new Button();
            label4 = new Label();
            label3 = new Label();
            playerPanel = new TableLayoutPanel();
            buttonNewGame = new Button();
            labelStatus = new Label();
            panelGame = new Panel();
            buttonStartSolo = new Button();
            buttonBackToMenu = new Button();
            panelMainMenu = new Panel();
            btnMultiplayer = new Button();
            btnSolo = new Button();
            label6 = new Label();
            panel1.SuspendLayout();
            panelGame.SuspendLayout();
            panelMainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // enemyPanel
            // 
            enemyPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            enemyPanel.ColumnCount = 10;
            enemyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            enemyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            enemyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            enemyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            enemyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            enemyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            enemyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            enemyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            enemyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            enemyPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            enemyPanel.Location = new Point(652, 115);
            enemyPanel.Name = "enemyPanel";
            enemyPanel.RowCount = 10;
            enemyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            enemyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            enemyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            enemyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            enemyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            enemyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            enemyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            enemyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            enemyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            enemyPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            enemyPanel.Size = new Size(300, 300);
            enemyPanel.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 83);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 4;
            label2.Text = "Ваше поле";
            // 
            // panel1
            // 
            panel1.Controls.Add(radioHorizontal);
            panel1.Controls.Add(radioVertical);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnShip3);
            panel1.Controls.Add(btnShip2);
            panel1.Controls.Add(btnShip1);
            panel1.Controls.Add(btnShip4);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(387, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(205, 329);
            panel1.TabIndex = 7;
            // 
            // radioHorizontal
            // 
            radioHorizontal.AutoSize = true;
            radioHorizontal.Location = new Point(19, 291);
            radioHorizontal.Name = "radioHorizontal";
            radioHorizontal.Size = new Size(137, 24);
            radioHorizontal.TabIndex = 9;
            radioHorizontal.TabStop = true;
            radioHorizontal.Text = "Горизонтально";
            radioHorizontal.UseVisualStyleBackColor = true;
            // 
            // radioVertical
            // 
            radioVertical.AutoSize = true;
            radioVertical.Checked = true;
            radioVertical.Location = new Point(19, 261);
            radioVertical.Name = "radioVertical";
            radioVertical.Size = new Size(120, 24);
            radioVertical.TabIndex = 8;
            radioVertical.TabStop = true;
            radioVertical.Text = "Вертикально";
            radioVertical.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(19, 229);
            label5.Name = "label5";
            label5.Size = new Size(174, 20);
            label5.TabIndex = 7;
            label5.Text = "Как хотите разместить?";
            // 
            // btnShip3
            // 
            btnShip3.Location = new Point(28, 87);
            btnShip3.Name = "btnShip3";
            btnShip3.Size = new Size(145, 34);
            btnShip3.TabIndex = 4;
            btnShip3.Text = "3-палубный";
            btnShip3.UseVisualStyleBackColor = true;
            btnShip3.Click += btnShip3_Click;
            // 
            // btnShip2
            // 
            btnShip2.Location = new Point(28, 127);
            btnShip2.Name = "btnShip2";
            btnShip2.Size = new Size(145, 34);
            btnShip2.TabIndex = 3;
            btnShip2.Text = "2-палубный";
            btnShip2.UseVisualStyleBackColor = true;
            btnShip2.Click += btnShip2_Click;
            // 
            // btnShip1
            // 
            btnShip1.Location = new Point(28, 167);
            btnShip1.Name = "btnShip1";
            btnShip1.Size = new Size(145, 34);
            btnShip1.TabIndex = 2;
            btnShip1.Text = "1-палубный";
            btnShip1.UseVisualStyleBackColor = true;
            btnShip1.Click += btnShip1_Click;
            // 
            // btnShip4
            // 
            btnShip4.Location = new Point(28, 47);
            btnShip4.Name = "btnShip4";
            btnShip4.Size = new Size(145, 34);
            btnShip4.TabIndex = 1;
            btnShip4.Text = "4-палубный";
            btnShip4.UseVisualStyleBackColor = true;
            btnShip4.Click += btnShip4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(19, 13);
            label4.Name = "label4";
            label4.Size = new Size(145, 20);
            label4.TabIndex = 0;
            label4.Text = "Выберите корабль:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(652, 83);
            label3.Name = "label3";
            label3.Size = new Size(133, 20);
            label3.TabIndex = 5;
            label3.Text = "Поле противника";
            // 
            // playerPanel
            // 
            playerPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            playerPanel.ColumnCount = 10;
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            playerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            playerPanel.Location = new Point(29, 115);
            playerPanel.Name = "playerPanel";
            playerPanel.RowCount = 10;
            playerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            playerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            playerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            playerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            playerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            playerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            playerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            playerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            playerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            playerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            playerPanel.Size = new Size(300, 300);
            playerPanel.TabIndex = 0;
            // 
            // buttonNewGame
            // 
            buttonNewGame.Location = new Point(333, 521);
            buttonNewGame.Name = "buttonNewGame";
            buttonNewGame.Size = new Size(316, 46);
            buttonNewGame.TabIndex = 8;
            buttonNewGame.Text = "Играть снова?";
            buttonNewGame.UseVisualStyleBackColor = true;
            buttonNewGame.Click += buttonNewGame_Click;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.Location = new Point(29, 33);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(313, 28);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "Расстановка кораблей...";
            // 
            // panelGame
            // 
            panelGame.BackColor = Color.White;
            panelGame.Controls.Add(buttonStartSolo);
            panelGame.Controls.Add(buttonBackToMenu);
            panelGame.Controls.Add(labelStatus);
            panelGame.Controls.Add(buttonNewGame);
            panelGame.Controls.Add(playerPanel);
            panelGame.Controls.Add(label3);
            panelGame.Controls.Add(panel1);
            panelGame.Controls.Add(label2);
            panelGame.Controls.Add(enemyPanel);
            panelGame.Dock = DockStyle.Fill;
            panelGame.Location = new Point(0, 0);
            panelGame.Name = "panelGame";
            panelGame.Size = new Size(982, 679);
            panelGame.TabIndex = 9;
            panelGame.Visible = false;
            // 
            // buttonStartSolo
            // 
            buttonStartSolo.BackColor = Color.FromArgb(192, 192, 255);
            buttonStartSolo.Cursor = Cursors.Hand;
            buttonStartSolo.FlatStyle = FlatStyle.Flat;
            buttonStartSolo.Location = new Point(333, 453);
            buttonStartSolo.Name = "buttonStartSolo";
            buttonStartSolo.Size = new Size(316, 46);
            buttonStartSolo.TabIndex = 10;
            buttonStartSolo.Text = "В бой";
            buttonStartSolo.UseVisualStyleBackColor = false;
            buttonStartSolo.Click += buttonStartSolo_Click;
            // 
            // buttonBackToMenu
            // 
            buttonBackToMenu.Location = new Point(333, 584);
            buttonBackToMenu.Name = "buttonBackToMenu";
            buttonBackToMenu.Size = new Size(316, 46);
            buttonBackToMenu.TabIndex = 9;
            buttonBackToMenu.Text = "← Назад в меню";
            buttonBackToMenu.UseVisualStyleBackColor = true;
            buttonBackToMenu.Click += buttonBackToMenu_Click;
            // 
            // panelMainMenu
            // 
            panelMainMenu.BackColor = Color.FromArgb(0, 0, 64);
            panelMainMenu.Controls.Add(btnMultiplayer);
            panelMainMenu.Controls.Add(btnSolo);
            panelMainMenu.Controls.Add(label6);
            panelMainMenu.Dock = DockStyle.Fill;
            panelMainMenu.Location = new Point(0, 0);
            panelMainMenu.Name = "panelMainMenu";
            panelMainMenu.Size = new Size(982, 679);
            panelMainMenu.TabIndex = 10;
            // 
            // btnMultiplayer
            // 
            btnMultiplayer.BackColor = Color.FromArgb(0, 0, 64);
            btnMultiplayer.Cursor = Cursors.Hand;
            btnMultiplayer.FlatStyle = FlatStyle.Flat;
            btnMultiplayer.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMultiplayer.ForeColor = Color.FromArgb(192, 192, 255);
            btnMultiplayer.Location = new Point(264, 326);
            btnMultiplayer.Name = "btnMultiplayer";
            btnMultiplayer.Size = new Size(442, 65);
            btnMultiplayer.TabIndex = 2;
            btnMultiplayer.Text = "Мультиплеерная игра";
            btnMultiplayer.UseVisualStyleBackColor = false;
            btnMultiplayer.Click += btnMultiplayer_Click;
            // 
            // btnSolo
            // 
            btnSolo.BackColor = Color.FromArgb(0, 0, 64);
            btnSolo.Cursor = Cursors.Hand;
            btnSolo.FlatStyle = FlatStyle.Flat;
            btnSolo.Font = new Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSolo.ForeColor = Color.FromArgb(192, 192, 255);
            btnSolo.Location = new Point(264, 213);
            btnSolo.Name = "btnSolo";
            btnSolo.Size = new Size(442, 65);
            btnSolo.TabIndex = 1;
            btnSolo.Text = "Одиночная игра";
            btnSolo.UseVisualStyleBackColor = false;
            btnSolo.Click += btnSolo_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Bookman Old Style", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(192, 192, 255);
            label6.Location = new Point(264, 103);
            label6.Name = "label6";
            label6.Size = new Size(442, 40);
            label6.TabIndex = 0;
            label6.Text = "Выберите режим игры";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 679);
            Controls.Add(panelMainMenu);
            Controls.Add(panelGame);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Морской Бой";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelGame.ResumeLayout(false);
            panelGame.PerformLayout();
            panelMainMenu.ResumeLayout(false);
            panelMainMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel enemyPanel;
        private Label label2;
        private Panel panel1;
        private RadioButton radioHorizontal;
        private RadioButton radioVertical;
        private Label label5;
        private Button btnShip3;
        private Button btnShip2;
        private Button btnShip1;
        private Button btnShip4;
        private Label label4;
        private Label label3;
        private TableLayoutPanel playerPanel;
        private Button buttonNewGame;
        private Label labelStatus;
        private Panel panelGame;
        private Panel panelMainMenu;
        private Button btnMultiplayer;
        private Button btnSolo;
        private Label label6;
        private Button buttonBackToMenu;
        private Button buttonStartSolo;
    }
}
