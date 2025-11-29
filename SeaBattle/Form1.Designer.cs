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
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            playerPanel.Location = new Point(42, 52);
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
            enemyPanel.Location = new Point(631, 52);
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
            groupBox1.Location = new Point(41, 376);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(383, 191);
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
            groupBox2.Location = new Point(41, 583);
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
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(42, 20);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 4;
            label2.Text = "Ваше поле";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(631, 20);
            label3.Name = "label3";
            label3.Size = new Size(133, 20);
            label3.TabIndex = 5;
            label3.Text = "Поле противника";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.Location = new Point(396, 52);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(180, 20);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "Расстановка кораблей...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 704);
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
    }
}
