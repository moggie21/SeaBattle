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
            btnAutoPlace = new Button();
            label4 = new Label();
            label3 = new Label();
            playerPanel = new TableLayoutPanel();
            buttonNewGame = new Button();
            labelStatus = new Label();
            panelGame = new Panel();
            groupEhh = new GroupBox();
            btnJoin = new Button();
            btnHost = new Button();
            txtPort = new TextBox();
            txtIP = new TextBox();
            label7 = new Label();
            label1 = new Label();
            buttonStartSolo = new Button();
            buttonBackToMenu = new Button();
            panelMainMenu = new Panel();
            btnMultiplayer = new Button();
            btnSolo = new Button();
            label6 = new Label();
            panelLobby = new Panel();
            btnBackToMtnu = new Button();
            btnCreateLobby = new Button();
            textBoxNickname = new TextBox();
            labelNickname = new Label();
            flowLayoutPanelLobbies = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panelGame.SuspendLayout();
            groupEhh.SuspendLayout();
            panelMainMenu.SuspendLayout();
            panelLobby.SuspendLayout();
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
            panel1.Controls.Add(btnAutoPlace);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(387, 86);
            panel1.Name = "panel1";
            panel1.Size = new Size(205, 329);
            panel1.TabIndex = 7;
            // 
            // radioHorizontal
            // 
            radioHorizontal.AutoSize = true;
            radioHorizontal.Location = new Point(19, 296);
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
            radioVertical.Location = new Point(19, 266);
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
            label5.Location = new Point(19, 244);
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
            // btnAutoPlace
            // 
            btnAutoPlace.Location = new Point(28, 207);
            btnAutoPlace.Name = "btnAutoPlace";
            btnAutoPlace.Size = new Size(145, 34);
            btnAutoPlace.TabIndex = 1;
            btnAutoPlace.Text = "Автоматически";
            btnAutoPlace.UseVisualStyleBackColor = true;
            btnAutoPlace.Click += btnAutoPlace_Click;
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
            panelGame.Controls.Add(groupEhh);
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
            // groupEhh
            // 
            groupEhh.BackColor = SystemColors.Control;
            groupEhh.Controls.Add(btnJoin);
            groupEhh.Controls.Add(btnHost);
            groupEhh.Controls.Add(txtPort);
            groupEhh.Controls.Add(txtIP);
            groupEhh.Controls.Add(label7);
            groupEhh.Controls.Add(label1);
            groupEhh.Location = new Point(681, 455);
            groupEhh.Name = "groupEhh";
            groupEhh.Size = new Size(271, 196);
            groupEhh.TabIndex = 11;
            groupEhh.TabStop = false;
            groupEhh.Text = "эхх";
            groupEhh.Visible = false;
            // 
            // btnJoin
            // 
            btnJoin.Location = new Point(161, 140);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(80, 29);
            btnJoin.TabIndex = 5;
            btnJoin.Text = "Join";
            btnJoin.UseVisualStyleBackColor = true;
            // 
            // btnHost
            // 
            btnHost.Location = new Point(26, 140);
            btnHost.Name = "btnHost";
            btnHost.Size = new Size(80, 29);
            btnHost.TabIndex = 4;
            btnHost.Text = "Host";
            btnHost.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(79, 76);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(171, 27);
            txtPort.TabIndex = 3;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(79, 31);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(171, 27);
            txtIP.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 79);
            label7.Name = "label7";
            label7.Size = new Size(47, 20);
            label7.TabIndex = 1;
            label7.Text = "Порт:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 34);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 0;
            label1.Text = "IP:";
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
            btnMultiplayer.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMultiplayer.ForeColor = Color.FromArgb(192, 192, 255);
            btnMultiplayer.Location = new Point(264, 326);
            btnMultiplayer.Name = "btnMultiplayer";
            btnMultiplayer.Size = new Size(442, 65);
            btnMultiplayer.TabIndex = 2;
            btnMultiplayer.Text = "Мультиплеер";
            btnMultiplayer.UseVisualStyleBackColor = false;
            btnMultiplayer.Click += btnMultiplayer_Click;
            // 
            // btnSolo
            // 
            btnSolo.BackColor = Color.FromArgb(0, 0, 64);
            btnSolo.Cursor = Cursors.Hand;
            btnSolo.FlatStyle = FlatStyle.Flat;
            btnSolo.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            // panelLobby
            // 
            panelLobby.BackColor = Color.FromArgb(0, 0, 64);
            panelLobby.Controls.Add(btnBackToMtnu);
            panelLobby.Controls.Add(btnCreateLobby);
            panelLobby.Controls.Add(textBoxNickname);
            panelLobby.Controls.Add(labelNickname);
            panelLobby.Controls.Add(flowLayoutPanelLobbies);
            panelLobby.Dock = DockStyle.Fill;
            panelLobby.Location = new Point(0, 0);
            panelLobby.Name = "panelLobby";
            panelLobby.Size = new Size(982, 679);
            panelLobby.TabIndex = 11;
            panelLobby.Visible = false;
            // 
            // btnBackToMtnu
            // 
            btnBackToMtnu.BackColor = Color.FromArgb(0, 0, 64);
            btnBackToMtnu.Cursor = Cursors.Hand;
            btnBackToMtnu.FlatStyle = FlatStyle.Flat;
            btnBackToMtnu.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackToMtnu.ForeColor = Color.FromArgb(192, 192, 255);
            btnBackToMtnu.Location = new Point(593, 573);
            btnBackToMtnu.Name = "btnBackToMtnu";
            btnBackToMtnu.Size = new Size(270, 50);
            btnBackToMtnu.TabIndex = 10;
            btnBackToMtnu.Text = "← Назад в меню";
            btnBackToMtnu.UseVisualStyleBackColor = false;
            btnBackToMtnu.Click += btnBackToMenu_Click;
            // 
            // btnCreateLobby
            // 
            btnCreateLobby.BackColor = Color.FromArgb(0, 0, 64);
            btnCreateLobby.Cursor = Cursors.Hand;
            btnCreateLobby.FlatStyle = FlatStyle.Flat;
            btnCreateLobby.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateLobby.ForeColor = Color.FromArgb(192, 192, 255);
            btnCreateLobby.Location = new Point(119, 573);
            btnCreateLobby.Name = "btnCreateLobby";
            btnCreateLobby.Size = new Size(272, 50);
            btnCreateLobby.TabIndex = 3;
            btnCreateLobby.Text = "Создать лобби";
            btnCreateLobby.UseVisualStyleBackColor = false;
            btnCreateLobby.Click += btnCreateLobby_Click;
            // 
            // textBoxNickname
            // 
            textBoxNickname.BackColor = Color.White;
            textBoxNickname.Cursor = Cursors.Hand;
            textBoxNickname.Location = new Point(264, 64);
            textBoxNickname.Name = "textBoxNickname";
            textBoxNickname.Size = new Size(599, 27);
            textBoxNickname.TabIndex = 2;
            // 
            // labelNickname
            // 
            labelNickname.AutoSize = true;
            labelNickname.Font = new Font("Bookman Old Style", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNickname.ForeColor = Color.FromArgb(192, 192, 255);
            labelNickname.Location = new Point(119, 61);
            labelNickname.Name = "labelNickname";
            labelNickname.Size = new Size(139, 28);
            labelNickname.TabIndex = 1;
            labelNickname.Text = "Nickname:";
            // 
            // flowLayoutPanelLobbies
            // 
            flowLayoutPanelLobbies.AutoScroll = true;
            flowLayoutPanelLobbies.BackColor = Color.White;
            flowLayoutPanelLobbies.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelLobbies.Location = new Point(121, 133);
            flowLayoutPanelLobbies.Name = "flowLayoutPanelLobbies";
            flowLayoutPanelLobbies.Padding = new Padding(5);
            flowLayoutPanelLobbies.Size = new Size(742, 392);
            flowLayoutPanelLobbies.TabIndex = 0;
            flowLayoutPanelLobbies.WrapContents = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 679);
            Controls.Add(panelLobby);
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
            groupEhh.ResumeLayout(false);
            groupEhh.PerformLayout();
            panelMainMenu.ResumeLayout(false);
            panelMainMenu.PerformLayout();
            panelLobby.ResumeLayout(false);
            panelLobby.PerformLayout();
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
        private Button btnAutoPlace;
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
        private GroupBox groupEhh;
        private Label label1;
        private Button btnJoin;
        private Button btnHost;
        private TextBox txtPort;
        private TextBox txtIP;
        private Label label7;
        private Panel panelLobby;
        private FlowLayoutPanel flowLayoutPanelLobbies;
        private TextBox textBoxNickname;
        private Label labelNickname;
        private Button btnCreateLobby;
        private Button btnBackToMtnu;
    }
}
