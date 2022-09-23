using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MedicalCard
{
    public partial class LoginForm : Form
    {
        // глобальные переменные класса
        public int userID;
        public string userName = "";
        public string userSpec = "";
        public int userStatus;
        private bool userDelStatus;
        public LoginForm()
        {
            InitializeComponent();
        }

        // Проверка валидности введенных данных
        private bool IsLoginValid()
        {
            if (loginBox.Text == "")
            {
                MessageBox.Show("Введите логин!");
                return false;
            }
            else
                return true;
        }
        private bool IsPasswordValid()
        {
            if (passwordBox.Text == "")
            {
                MessageBox.Show("Введите пароль!");
                return false;
            }
            else
                return true;
        }

        // Обработчик нажатия кнопки "Вход в систему"
        private void enterButton_Click(object sender, EventArgs e)
        {
            bool res = false;
            bool authorization = false;
            if (IsLoginValid() && IsPasswordValid())
            {
                string login = loginBox.Text;

                // строка подключения
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MedDB.mdf;Integrated Security=True";
                string sqlExpression = "SELECT * FROM [User]";
                // создание подключения
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // открытие подключения
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчное считывание данных
                        {
                            string log = reader.GetString(3).Trim();
                            string pass = reader.GetString(4).Trim();
                            if ((login == log) && passwordBox.Text == pass)
                            {
                                userDelStatus = reader.GetBoolean(5);
                                res = true;
                                if (userDelStatus == false) // если пользователь активный
                                {
                                    // заполнение данными глобальных переменных
                                    userID = reader.GetInt32(0);
                                    userName = reader.GetString(1).Trim();
                                    userSpec = reader.GetString(2).Trim();
                                    userStatus = reader.GetInt32(6);
                                    authorization = true;
                                }
                                break;
                            }
                        }
                    }

                    reader.Close();

                    if (!res)
                        MessageBox.Show("Неверно введен логин или пароль", "Предупреждение",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else if(userDelStatus == true)
                        MessageBox.Show("Пользователь заблокирован. Обратитесь к системному администратору.", "Предупреждение",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (authorization)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }
    }
}
