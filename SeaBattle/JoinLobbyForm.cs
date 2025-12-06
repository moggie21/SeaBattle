using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class JoinLobbyForm : Form
    {
        public string EnteredPassword => textBoxPassword.Text; // введенный пароль
        public JoinLobbyForm()
        {
            InitializeComponent();
        }

        // подключиться
        private void buttonJoin_Click(object sender, EventArgs e)
        {
            //если пароль не введен
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Введите пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        // отмена
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
