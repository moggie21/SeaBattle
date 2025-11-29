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
            playerPanel = new TableLayoutPanel();
            enemyPanel = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            labelPort = new TextBox();
            label1 = new Label();
            textBoxIp = new TextBox();
            labelIp = new Label();
            groupBox2 = new GroupBox();
            buttonStartSolo = new Button();
            label2 = new Label();
            label3 = new Label();
            labelStatus = new Label();
            panel1 = new Panel();
            label5 = new Label();
            checkBoxHorizontal = new CheckBox();
            checkBoxVertical = new CheckBox();
            btnShip3 = new Button();
            btnShip2 = new Button();
            btnShip1 = new Button();
            btnShip4 = new Button();
            label4 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
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
            playerPanel.Location = new Point(49, 107);
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
            enemyPanel.Location = new Point(637, 107);
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
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(labelPort);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxIp);
            groupBox1.Controls.Add(labelIp);
            groupBox1.Location = new Point(49, 465);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(413, 191);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cетевая игра";
            // 
            // button2
            // 
            button2.Location = new Point(176, 134);
            button2.Name = "button2";
            button2.Size = new Size(124, 34);
            button2.TabIndex = 5;
            button2.Text = "Подключиться";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(15, 134);
            button1.Name = "button1";
            button1.Size = new Size(124, 34);
            button1.TabIndex = 4;
            button1.Text = "Создать игру";
            button1.UseVisualStyleBackColor = true;
            // 
            // labelPort
            // 
            labelPort.Location = new Point(91, 83);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(278, 27);
            labelPort.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 86);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 2;
            label1.Text = "Порт:";
            // 
            // textBoxIp
            // 
            textBoxIp.Location = new Point(91, 36);
            textBoxIp.Name = "textBoxIp";
            textBoxIp.Size = new Size(278, 27);
            textBoxIp.TabIndex = 1;
            // 
            // labelIp
            // 
            labelIp.AutoSize = true;
            labelIp.Location = new Point(15, 39);
            labelIp.Name = "labelIp";
            labelIp.Size = new Size(70, 20);
            labelIp.TabIndex = 0;
            labelIp.Text = "IP-адрес:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonStartSolo);
            groupBox2.Location = new Point(554, 465);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(383, 88);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Одиночная игра";
            // 
            // buttonStartSolo
            // 
            buttonStartSolo.Location = new Point(34, 35);
            buttonStartSolo.Name = "buttonStartSolo";
            buttonStartSolo.Size = new Size(298, 39);
            buttonStartSolo.TabIndex = 0;
            buttonStartSolo.Text = "Играть против бота";
            buttonStartSolo.UseVisualStyleBackColor = true;
            buttonStartSolo.Click += buttonStartSolo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(49, 75);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 4;
            label2.Text = "Ваше поле";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(637, 75);
            label3.Name = "label3";
            label3.Size = new Size(133, 20);
            label3.TabIndex = 5;
            label3.Text = "Поле противника";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Bookman Old Style", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.Location = new Point(49, 22);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(244, 21);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "Расстановка кораблей...";
            // 
            // panel1
            // 
            panel1.Controls.Add(label5);
            panel1.Controls.Add(checkBoxHorizontal);
            panel1.Controls.Add(checkBoxVertical);
            panel1.Controls.Add(btnShip3);
            panel1.Controls.Add(btnShip2);
            panel1.Controls.Add(btnShip1);
            panel1.Controls.Add(btnShip4);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(390, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(205, 329);
            panel1.TabIndex = 7;
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
            // checkBoxHorizontal
            // 
            checkBoxHorizontal.AutoSize = true;
            checkBoxHorizontal.Location = new Point(19, 291);
            checkBoxHorizontal.Name = "checkBoxHorizontal";
            checkBoxHorizontal.Size = new Size(138, 24);
            checkBoxHorizontal.TabIndex = 6;
            checkBoxHorizontal.Text = "Горизонтально";
            checkBoxHorizontal.UseVisualStyleBackColor = true;
            // 
            // checkBoxVertical
            // 
            checkBoxVertical.AutoSize = true;
            checkBoxVertical.Checked = true;
            checkBoxVertical.CheckState = CheckState.Checked;
            checkBoxVertical.Location = new Point(19, 261);
            checkBoxVertical.Name = "checkBoxVertical";
            checkBoxVertical.Size = new Size(121, 24);
            checkBoxVertical.TabIndex = 5;
            checkBoxVertical.Text = "Вертикально";
            checkBoxVertical.UseVisualStyleBackColor = true;
            checkBoxVertical.CheckedChanged += checkBoxVertical_CheckedChanged;
            // 
            // btnShip3
            // 
            btnShip3.Location = new Point(19, 86);
            btnShip3.Name = "btnShip3";
            btnShip3.Size = new Size(145, 34);
            btnShip3.TabIndex = 4;
            btnShip3.Text = "3-палубный";
            btnShip3.UseVisualStyleBackColor = true;
            btnShip3.Click += btnShip3_Click;
            // 
            // btnShip2
            // 
            btnShip2.Location = new Point(19, 126);
            btnShip2.Name = "btnShip2";
            btnShip2.Size = new Size(145, 34);
            btnShip2.TabIndex = 3;
            btnShip2.Text = "2-палубный";
            btnShip2.UseVisualStyleBackColor = true;
            btnShip2.Click += btnShip2_Click;
            // 
            // btnShip1
            // 
            btnShip1.Location = new Point(19, 166);
            btnShip1.Name = "btnShip1";
            btnShip1.Size = new Size(145, 34);
            btnShip1.TabIndex = 2;
            btnShip1.Text = "1-палубный";
            btnShip1.UseVisualStyleBackColor = true;
            btnShip1.Click += btnShip1_Click;
            // 
            // btnShip4
            // 
            btnShip4.Location = new Point(19, 46);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 679);
            Controls.Add(panel1);
            Controls.Add(labelStatus);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(enemyPanel);
            Controls.Add(playerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Морской Бой";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel playerPanel;
        private TableLayoutPanel enemyPanel;
        private GroupBox groupBox1;
        private TextBox textBoxIp;
        private Label labelIp;
        private Button button1;
        private TextBox labelPort;
        private Label label1;
        private Button button2;
        private GroupBox groupBox2;
        private Button buttonStartSolo;
        private Label label2;
        private Label label3;
        private Label labelStatus;
        private Panel panel1;
        private Button btnShip3;
        private Button btnShip2;
        private Button btnShip1;
        private Button btnShip4;
        private Label label4;
        private Label label5;
        private CheckBox checkBoxHorizontal;
        private CheckBox checkBoxVertical;
    }
}
