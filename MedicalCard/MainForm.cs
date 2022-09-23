using System;
using System.Windows.Forms;

namespace MedicalCard
{
    public partial class MainForm : Form
    {
        // глобальные переменные класса
        public int userID;
        public string userName;
        public string userSpec;
        public int userStatus;
        // переменная авторизации пользователя
        private bool authorization = false;
        public MainForm()
        {
            InitializeComponent();
            UserAuthorization();
        }

        // открытие нужного диалогового окна
        public void OpenNecessaryDialog()
        {
            if (userStatus == 0) // если вошел Администратор
            {
                AdminForm adminForm = new AdminForm();
                adminForm._userName = userName;
                if (adminForm.ShowDialog(this) == DialogResult.Cancel)
                {
                    authorization = false; // пользователь не авторизован
                    UserAuthorization();
                }
            }
            else if (userStatus == 1) // если вошел Регистратор
            {
                RegistrForm registrForm = new RegistrForm();
                registrForm._userName = userName;
                if (registrForm.ShowDialog(this) == DialogResult.Cancel)
                {
                    authorization = false; // пользователь не авторизован
                    UserAuthorization();
                }
            }
            else if (userStatus == 2) // если вошел Обычный пользователь
            {
                DoctorForm docForm = new DoctorForm();
                docForm.UserId = userID;
                docForm._userName = userName;
                docForm._userSpec = userSpec;
                if (docForm.ShowDialog(this) == DialogResult.Cancel)
                {
                    authorization = false; // пользователь не авторизован
                    UserAuthorization();
                }
            }
        }

        // авторизация пользователя в системе
        public void UserAuthorization()
        {
            if (!authorization)
            {
                LoginForm logForm = new LoginForm();
                if (logForm.ShowDialog(this) == DialogResult.OK)
                {
                    userID = logForm.userID;
                    userName = logForm.userName;
                    userSpec = logForm.userSpec;
                    userStatus = logForm.userStatus;

                    authorization = true; // пользователь авторизован
                }
                else
                    Environment.Exit(0);
            }
            OpenNecessaryDialog();
        }
    }
}
