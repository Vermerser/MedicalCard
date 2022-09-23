using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalCard
{
    public partial class AdminForm : Form
    {
        // глобальные переменные класса
        public string _userName;    // ФИО администратора
        public int MaxIndex;    // максимальный индекс зарегистрированного пользователя
        // создание экземпляра класса DBWorking
        DBWorking workingDB = new DBWorking();
        
        // Структуры для хранении информации
        struct UserStruct   // пользователь
        {
            public string userID;
            public string userName;
            public string userSpecialty;
            public string userLogin;
            public string userPassword;
            public bool userDelStatus;
            public int userStatus;
        }

        struct PacientStruct    // пациент
        {
            public string pacID;
            public string pacName;
            public string pacAdres;
            public string pacTelephone;
            public int pacSex;
            public string pacBirthDate;
            public string pacWorkPlace;
            public bool pacDelStatus;
        }

        public AdminForm()
        {
            InitializeComponent();

            // установка в диалоге текущей даты и времени
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToShortTimeString();
            
            ReadUsers();
            listViewUsers.ContextMenuStrip = contextMenuStrip;  // ассоциация контекстного меню с данными пользователей
            listViewPacients.ContextMenuStrip = contextMenuStrip1;  // ассоциация контекстного меню с данными пациентов
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // установке в диалоге данных о имени администратора
            userNameLabel.Text = _userName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // установка таймера
            timeLabel.Text = DateTime.Now.ToShortTimeString();
        }

        // обработчик переключения между вкладками TabControl
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                ReadUsers();
            else if (tabControl1.SelectedIndex == 1)
                ReadPacients();
        }

        // Считывание данных из таблицы User
        private void ReadUsers()
        {
            MaxIndex = 0;
            // создание коллекции объектов
            ArrayList userList = new ArrayList();
            userList.AddRange(workingDB.ReadUserPacientData("User"));
            // заполнение таблицы данными из базы данных
            PrintUsers(listViewUsers, userList, "User");
        }

        // Считывание данных из таблицы Pacient
        private void ReadPacients()
        {
            MaxIndex = 0;
            // создание коллекции объектов
            ArrayList pacientList = new ArrayList();
            pacientList.AddRange(workingDB.ReadUserPacientData("Pacient"));
            // заполнение таблицы данными из базы данных
            PrintUsers(listViewPacients, pacientList, "Pacient");
        }

        #region listViews
        // процедура вывода информации о пользователе в listView
        private void PrintUsers(ListView listV, ArrayList list, string table)
        {
            listV.Items.Clear();    // очистка списка пользователей
            ListViewItem lvi;
            if (table == "User")
            {
                foreach (object item in list)
                {
                    UserStruct user = new UserStruct();
                    user = AddUser(item.ToString());
                    lvi = new ListViewItem(user.userID);
                    lvi.SubItems.Add(user.userName);
                    lvi.SubItems.Add(user.userSpecialty);
                    lvi.SubItems.Add(user.userLogin);
                    lvi.SubItems.Add(user.userPassword);
                    if (!user.userDelStatus)
                        lvi.SubItems.Add("Активен");
                    else
                        lvi.SubItems.Add("Заблокирован");
                    switch (user.userStatus)
                    {
                        case 0:
                            lvi.SubItems.Add("Администратор");
                            break;
                        case 1:
                            lvi.SubItems.Add("Регистратор");
                            break;
                        case 2:
                            lvi.SubItems.Add("Обычный пользователь");
                            break;
                        default:
                            lvi.SubItems.Add("");
                            break;
                    }
                    listV.Items.Add(lvi);
                    MaxIndex = Convert.ToInt32(user.userID);
                }
            }
            else if (table == "Pacient")
            {
                foreach (object item in list)
                {
                    PacientStruct pacient = new PacientStruct();
                    pacient = AddPacient(item.ToString());
                    lvi = new ListViewItem(pacient.pacID);
                    lvi.SubItems.Add(pacient.pacName);
                    lvi.SubItems.Add(pacient.pacAdres);
                    lvi.SubItems.Add(pacient.pacTelephone);
                    switch (pacient.pacSex)
                    {
                        case 0:
                            lvi.SubItems.Add("Женский");
                            break;
                        case 1:
                            lvi.SubItems.Add("Мужской");
                            break;
                    }
                    lvi.SubItems.Add(_cutSubstringFromString(ref pacient.pacBirthDate, " ", 0));
                    lvi.SubItems.Add(pacient.pacWorkPlace);
                    if (!pacient.pacDelStatus)
                        lvi.SubItems.Add("Активен");
                    else
                        lvi.SubItems.Add("Удален");
                    listV.Items.Add(lvi);
                    // выделение удаленных пациентов другим цветом
                    if (pacient.pacDelStatus)
                        lvi.ForeColor = Color.DarkGray;
                    MaxIndex = Convert.ToInt32(pacient.pacID);
                }
            }
            
        }

        // обработчик процедуры выбора элементов в списке пользователей
        private void listViewUsers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewUsers.SelectedItems.Count > 0)
            {
                editButton.Enabled = true;
                deleteButton.Enabled = true;
                editToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
            else
            {
                editButton.Enabled = false;
                deleteButton.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
        }

        // обработчик процедуры выбора элементов в списке пациентов
        private void listViewPacients_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewPacients.SelectedItems.Count > 0)
            {
                editPacButton.Enabled = true;
                switch (listViewPacients.SelectedItems[0].SubItems[7].Text)
                {
                    case "Активен":
                        delPacButton.Enabled = true;
                        delStripMenuItem1.Enabled = true;
                        break;
                    case "Удален":
                        delPacButton.Enabled = false;
                        delStripMenuItem1.Enabled = false;
                        break;
                }
                editStripMenuItem1.Enabled = true;
            }
            else
            {
                editPacButton.Enabled = false;
                delPacButton.Enabled = false;
                editStripMenuItem1.Enabled = false;
                delStripMenuItem1.Enabled = false;
            }
        }
        #endregion

        #region buttons

        // обработчик кнопки "Выход из системы"
        private void exitButton_Click(object sender, EventArgs e)
        {
            // запрос на подтверждение выхода из системы
            DialogResult confirmationResult = MessageBox.Show(
                    "Вы уверены, что хотите выйти из системы?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);

            if (confirmationResult == DialogResult.Yes)
                this.Close();
        }

        // ПОЛЬЗОВАТЕЛИ-------------------------------------------------
        // обработчик кнопки "Добавить" пользователя
        private void addButton_Click(object sender, EventArgs e)
        {
            AddUserForm userForm = new AddUserForm();
            if (userForm.ShowDialog(this) == DialogResult.OK)
            {
                // добавление нового пользователя в базу данных
                MaxIndex++;
                int result = workingDB.AddDataInUserTable(MaxIndex, userForm.userName, userForm.userSpecialty, userForm.userLogin,
                    userForm.userPassword, userForm.userDelStatus, userForm.userStatus);
                // считывание новых данных из БД и обновление данных в таблице listView
                ReadUsers();
                if (result > 0)
                {
                    MessageBox.Show(
                    "Пользователь успешно добавлен в систему",
                    "Подтверждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }

        // обработчик кнопки "Редактировать" пользователя
        private void editButton_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count == 0)
                return;
            else
            {
                UserStruct editUser = new UserStruct();
                int editId = Convert.ToInt32(listViewUsers.SelectedItems[0].Text);
                editUser.userName = listViewUsers.SelectedItems[0].SubItems[1].Text;
                editUser.userSpecialty = listViewUsers.SelectedItems[0].SubItems[2].Text;
                editUser.userLogin = listViewUsers.SelectedItems[0].SubItems[3].Text;
                editUser.userPassword = listViewUsers.SelectedItems[0].SubItems[4].Text;
                switch (listViewUsers.SelectedItems[0].SubItems[5].Text)
                {
                    case "Активный":
                        editUser.userDelStatus = false;
                        break;
                    case "Заблокирован":
                        editUser.userDelStatus = true;
                        break;
                }
                switch (listViewUsers.SelectedItems[0].SubItems[6].Text)
                {
                    case "Администратор":
                        editUser.userStatus = 0;
                        break;
                    case "Регистратор":
                        editUser.userStatus = 1;
                        break;
                    case "Обычный пользователь":
                        editUser.userStatus = 2;
                        break;
                }

                EditUserForm editForm = new EditUserForm(editUser.userName, editUser.userSpecialty, editUser.userLogin,
                    editUser.userPassword, editUser.userDelStatus, editUser.userStatus);
                
                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    // обновление БД
                    int result = workingDB.EditDataInUserTable(editId, editForm.name, editForm.spec, editForm.login,
                        editForm.pass, editForm.delStat, editForm.stat);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadUsers();
                    if (result > 0)
                    {
                        MessageBox.Show(
                        "Данные пользователя успешно изменены",
                        "Подтверждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
            }
        }

        // обработчик кнопки контекстного меню "Редактировать" пользователя
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editButton_Click(sender, e);
        }
        private void listViewUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editButton_Click(sender, e);
        }

        // обработчик кнопки "Удалить" пользователя
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count == 0)
                return;
            else
            {
                // запрос на подтверждение удаления
                DialogResult confirmationResult = MessageBox.Show(
                        "Вы уверены, что хотите удалить пользователя из системы?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (confirmationResult == DialogResult.Yes)
                {
                    int result = workingDB.DelDataFromUserTable(Convert.ToInt32(listViewUsers.SelectedItems[0].Text));
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadUsers();
                    if (result > 0)
                    {
                        MessageBox.Show(
                        "Данные пользователя успешно удалены",
                        "Подтверждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
            }
        }

        // обработчик кнопки контекстного меню "Удалить" пользователя
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteButton_Click(sender, e);
        }

        // ПАЦИЕНТЫ--------------------------------------------------------
        // обработчик кнопки "Добавить" пациента
        private void addPacButton_Click(object sender, EventArgs e)
        {
            AddPacientForm pacForm = new AddPacientForm();
            if (pacForm.ShowDialog(this) == DialogResult.OK)
            {
                // добавление нового пациента в базу данных
                MaxIndex++;
                int result = workingDB.AddDataInPacientTable(MaxIndex, pacForm.pacName, pacForm.pacAdres, pacForm.pacTelephone, pacForm.pacSex, 
                pacForm.pacBirthDate, pacForm.pacWorkPlace, pacForm.pacDelStatus);
                // считывание новых данных из БД и обновление данных в таблице listView
                ReadPacients();
                if (result > 0)
                {
                    MessageBox.Show(
                    "Пациент успешно добавлен в систему",
                    "Подтверждение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }

        // обработчик кнопки "Редактировать" пациента
        private void editPacButton_Click(object sender, EventArgs e)
        {
            if (listViewPacients.SelectedItems.Count == 0)
                return;
            else
            {
                PacientStruct editPacient = new PacientStruct();
                int editId = Convert.ToInt32(listViewPacients.SelectedItems[0].Text);
                editPacient.pacName = listViewPacients.SelectedItems[0].SubItems[1].Text;
                editPacient.pacAdres = listViewPacients.SelectedItems[0].SubItems[2].Text;
                editPacient.pacTelephone = listViewPacients.SelectedItems[0].SubItems[3].Text;
                switch (listViewPacients.SelectedItems[0].SubItems[4].Text)
                {
                    case "Женский":
                        editPacient.pacSex = 0;
                        break;
                    case "Мужской":
                        editPacient.pacSex = 1;
                        break;
                }
                editPacient.pacBirthDate = listViewPacients.SelectedItems[0].SubItems[5].Text;
                editPacient.pacWorkPlace = listViewPacients.SelectedItems[0].SubItems[6].Text;
                switch (listViewPacients.SelectedItems[0].SubItems[7].Text)
                {
                    case "Активен":
                        editPacient.pacDelStatus = false;
                        break;
                    case "Удален":
                        editPacient.pacDelStatus = true;
                        break;
                }

                EditPacientForm editForm = new EditPacientForm(editPacient.pacName, editPacient.pacAdres,
                    editPacient.pacTelephone, editPacient.pacSex, editPacient.pacBirthDate, editPacient.pacWorkPlace);

                if (editForm.ShowDialog(this) == DialogResult.OK)
                {
                    // обновление БД
                    int result = workingDB.EditDataInPacientTable(editId, editForm.name, editForm.adres, editForm.tel,
                        editForm.sex, editForm.birtndate, editForm.workplace, editPacient.pacDelStatus);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadPacients();
                    if (result > 0)
                    {
                        MessageBox.Show(
                        "Данные пациента успешно изменены",
                        "Подтверждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
            }
        }

        // обработчик кнопки контекстного меню "Редактировать" пациента
        private void editStripMenuItem1_Click(object sender, EventArgs e)
        {
            editPacButton_Click(sender, e);
        }
        private void listViewPacients_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editPacButton_Click(sender, e);
        }

        // обработчик кнопки "Удалить" пациента
        private void delPacButton_Click(object sender, EventArgs e)
        {
            if (listViewPacients.SelectedItems.Count == 0)
                return;
            else
            {
                // запрос на подтверждение удаления пациента
                DialogResult confirmationResult = MessageBox.Show(
                        "Вы уверены, что хотите удалить выбранного пациента из системы?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (confirmationResult == DialogResult.Yes)
                {
                    int delId = Convert.ToInt32(listViewPacients.SelectedItems[0].Text);
                    // обновление БД
                    int result = workingDB.UpdatePacientInTable(delId, true);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadPacients();
                    if (result > 0)
                    {
                        MessageBox.Show(
                        "Пациент успешно удален из системы",
                        "Подтверждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
            }
        }

        // обработчик кнопки контекстного меню "Удалить" пациента
        private void delStripMenuItem1_Click(object sender, EventArgs e)
        {
            delPacButton_Click(sender, e);
        }
        #endregion

        //-----------------------------------------------------------------
        // ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
        //-----------------------------------------------------------------
        // Функция обратного преобразования из строки в структуру UserStruct
        private UserStruct AddUser(string Str)
        {
            string separator = "$$$$$";
            // структура для возвращения результата
            UserStruct resUser = new UserStruct();
            // заполнение полей структуры
            resUser.userID = _cutSubstringFromString(ref Str, separator, 0);
            resUser.userName = _cutSubstringFromString(ref Str, separator, 0);
            resUser.userSpecialty = _cutSubstringFromString(ref Str, separator, 0);
            resUser.userLogin = _cutSubstringFromString(ref Str, separator, 0);
            resUser.userPassword = _cutSubstringFromString(ref Str, separator, 0);
            resUser.userDelStatus = Convert.ToBoolean(_cutSubstringFromString(ref Str, separator, 0));
            resUser.userStatus = Convert.ToInt32(Str);

            return resUser;
        }

        // Функция обратного преобразования из строки в структуру PacientStruct
        private PacientStruct AddPacient(string Str)
        {
            string separator = "$$$$$";
            // структура для возвращения результата
            PacientStruct resPacient = new PacientStruct();
            // заполнение полей структуры
            resPacient.pacID = _cutSubstringFromString(ref Str, separator, 0);
            resPacient.pacName = _cutSubstringFromString(ref Str, separator, 0);
            resPacient.pacAdres = _cutSubstringFromString(ref Str, separator, 0);
            resPacient.pacTelephone = _cutSubstringFromString(ref Str, separator, 0);
            resPacient.pacSex = Convert.ToInt32(_cutSubstringFromString(ref Str, separator, 0));
            resPacient.pacBirthDate = _cutSubstringFromString(ref Str, separator, 0);
            resPacient.pacWorkPlace = _cutSubstringFromString(ref Str, separator, 0);
            resPacient.pacDelStatus = Convert.ToBoolean(Str);
            
            return resPacient;
        }

        // метод отсечения части строки и образование новой строки
        private string _cutSubstringFromString(ref string s, string c, int startIndex)
        {
            int pos1 = s.IndexOf(c, startIndex);
            string retString = s.Substring(0, pos1);
            s = (s.Substring(pos1 + c.Length)).Trim();
            return retString;
        }
    }
}
