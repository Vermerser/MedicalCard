using System;
using System.Windows.Forms;

namespace MedicalCard
{
    public partial class AddUserForm : Form
    {
        // переменные класса
        public string userName;
        public string userSpecialty;
        public string userLogin;
        public string userPassword;
        public bool userDelStatus;
        public int userStatus;

        public AddUserForm()
        {
            InitializeComponent();

            stActivComboBox.SelectedIndex = 0;
            statusComboBox.SelectedIndex = 0;
        }

        // обработчик кнопки "ОК"
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                userName = surnameBox.Text + " " + nameBox.Text + " " + middlenameBox.Text;
                userSpecialty = specialtyBox.Text;
                userLogin = loginBox.Text;
                userPassword = passwordBox.Text;
                userDelStatus = DelStatus();
                userStatus = statusComboBox.SelectedIndex;

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
            if (surnameBox.Text == "")
            {
                MessageBox.Show("Введите фамилию пользователя!");
                return false;
            }
            else if (nameBox.Text == "")
            {
                MessageBox.Show("Введите имя пользователя!");
                return false;
            }
            else if (middlenameBox.Text == "")
            {
                MessageBox.Show("Введите отчество пользователя!");
                return false;
            }
            else if (specialtyBox.Text == "")
            {
                MessageBox.Show("Введите специальность пользователя!");
                return false;
            }
            else if (loginBox.Text == "")
            {
                MessageBox.Show("Введите логин пользователя!");
                return false;
            }
            else if (passwordBox.Text == "")
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
            switch (stActivComboBox.SelectedIndex)
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
