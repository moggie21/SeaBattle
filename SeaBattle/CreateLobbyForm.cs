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
    public partial class CreateLobbyForm : Form
    {
        public string LobbyName => textBoxName.Text.Trim(); // название лобби 
        public string Password => checkBoxPrivate.Checked ? textBoxPassword.Text : ""; // пароль если закрытое
        public bool IsPrivate => checkBoxPrivate.Checked; // закрытое

        public CreateLobbyForm()
        {
            InitializeComponent();
        }

        // если лобби выбрано как закрытое, то появится возможность ввести пароль
        private void checkBoxPrivate_CheckedChanged(object sender, EventArgs e)
        {
            bool isPrivate = checkBoxPrivate.Checked;
            labelPassword.Visible = isPrivate;
            textBoxPassword.Visible = isPrivate;

            if (!isPrivate)
            {
                textBoxPassword.Text = ""; // очищаем, ксли убрать галочку
            }
        }

        // создание формы, валидация полей
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите название лобби!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkBoxPrivate.Checked && string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Для закрытого лобби нужен пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        // отмена - закрываем форму
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
