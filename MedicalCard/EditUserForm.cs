using System;
using System.Windows.Forms;

namespace MedicalCard
{
    public partial class EditUserForm : Form
    {
        // переменные формы
        public string name;
        public string spec;
        public string login;
        public string pass;
        public bool delStat;
        public int stat;

        public EditUserForm()
        {
            InitializeComponent();
        }

        public EditUserForm(string _name, string _spec, string _login, string _pass, bool _delStat, int _stat)
        {
            InitializeComponent();

            // перенос полученных данных от родителя на форму
            nameBox.Text = _name;
            specBox.Text = _spec;
            loginBox.Text = _login;
            passBox.Text = _pass;
            if (!_delStat)
                delStComboBox.SelectedIndex = 0;
            else
                delStComboBox.SelectedIndex = 1;
            stComboBox.SelectedIndex = _stat;
        }

        // обработчик кнопки "ОК"
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                // присвоение измененных данных переменным формы
                name = nameBox.Text;
                spec = specBox.Text;
                login = loginBox.Text;
                pass = passBox.Text;
                delStat = DelStatus();
                stat = stComboBox.SelectedIndex;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // обработчик кнопки "Отмена"
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Проверка валидности введенных данных
        private bool IsValidData()
        {
            if (nameBox.Text == "")
            {
                MessageBox.Show("Введите ФИО пользователя!");
                return false;
            }
            else if (specBox.Text == "")
            {
                MessageBox.Show("Введите специальность пользователя!");
                return false;
            }
            else if (loginBox.Text == "")
            {
                MessageBox.Show("Введите логин пользователя!");
                return false;
            }
            else if (passBox.Text == "")
            {
                MessageBox.Show("Введите пароль пользователя!");
                return false;
            }
            else
                return true;
        }

        // присвоение статуса активности
        private bool DelStatus()
        {
            bool result = false;
            switch (delStComboBox.SelectedIndex)
            {
                case 0:
                    result = false;
                    break;
                case 1:
                    result = true;
                    break;
            }
            return result;
        }
    }
}
