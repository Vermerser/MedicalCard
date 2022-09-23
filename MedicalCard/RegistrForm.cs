using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace MedicalCard
{
    public partial class RegistrForm : Form
    {
        // глобальные переменные класса
        public string _userName;    // ФИО регистратора
        public int MaxIndex;    // максимальный индекс зарегистрированного пациента
        // создание экземпляра класса DBWorking
        DBWorking workingDB = new DBWorking();

        // Структура для хранении информации
        struct PacientStruct
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
        public RegistrForm()
        {
            InitializeComponent();

            // установка в диалоге текущей даты и времени
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToShortTimeString();

            ReadPacients();
            listViewPacients.ContextMenuStrip = contextMenuStrip;  // ассоциация контекстного меню с данными пациентов
        }

        private void RegistrForm_Load(object sender, EventArgs e)
        {
            // установке в диалоге данных о имени регистратора
            userNameLabel.Text = _userName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // установка таймера
            timeLabel.Text = DateTime.Now.ToShortTimeString();
        }

        private void ReadPacients()
        {
            MaxIndex = 0;
            // создание коллекции объектов
            ArrayList pacientList = new ArrayList();
            pacientList.AddRange(workingDB.ReadUserPacientData("Pacient"));
            // заполнение таблицы данными из базы данных
            PrintPacient(listViewPacients, pacientList);
        }

        #region listViews
        // процедура вывода информации о пациенте в listView
        private void PrintPacient(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка пациентов
            ListViewItem lvi;

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

        // обработчик процедуры выбора элементов в списке пользователей
        private void listViewPacients_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewPacients.SelectedItems.Count > 0)
            {
                editPacButton.Enabled = true;
                switch (listViewPacients.SelectedItems[0].SubItems[7].Text)
                {
                    case "Активен":
                        delPacButton.Enabled = true;
                        deleteToolStripMenuItem.Enabled = true;
                        updatePacButton.Enabled = false;
                        updateToolStripMenuItem.Enabled = false;
                        break;
                    case "Удален":
                        delPacButton.Enabled = false;
                        deleteToolStripMenuItem.Enabled = false;
                        updatePacButton.Enabled = true;
                        updateToolStripMenuItem.Enabled = true;
                        break;
                }
                editToolStripMenuItem.Enabled = true;
            }
            else
            {
                editPacButton.Enabled = false;
                delPacButton.Enabled = false;
                updatePacButton.Enabled = false;
                editToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                updateToolStripMenuItem.Enabled = false;
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

        // обработчик кнопки "Добавить" пациента
        private void addPacButton_Click(object sender, EventArgs e)
        {
            AddPacientForm pacForm = new AddPacientForm();
            if (pacForm.ShowDialog(this) == DialogResult.OK)
            {
                // добавление нового пациента в базу данных
                MaxIndex++;
                int result = workingDB.AddDataInPacientTable(MaxIndex, pacForm.pacName, pacForm.pacAdres, 
                    pacForm.pacTelephone, pacForm.pacSex, pacForm.pacBirthDate, pacForm.pacWorkPlace, pacForm.pacDelStatus);
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
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delPacButton_Click(sender, e);
        }

        // обработчик кнопки "Восстановить" пациента
        private void updatePacButton_Click(object sender, EventArgs e)
        {
            if (listViewPacients.SelectedItems.Count == 0)
                return;
            else
            {
                // запрос на подтверждение восстановления пациента
                DialogResult confirmationResult = MessageBox.Show(
                        "Вы уверены, что хотите восстановить выбранного пациента в системе?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                if (confirmationResult == DialogResult.Yes)
                {
                    int delId = Convert.ToInt32(listViewPacients.SelectedItems[0].Text);
                    // обновление БД
                    int result = workingDB.UpdatePacientInTable(delId, false);
                    // считывание новых данных из БД и обновление данных в таблице listView
                    ReadPacients();
                    if (result > 0)
                    {
                        MessageBox.Show(
                        "Пациент успешно восстановлен в системе",
                        "Подтверждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
            }
        }

        // обработчик кнопки контекстного меню "Восстановить" пациента
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updatePacButton_Click(sender, e);
        }
        #endregion

        //-----------------------------------------------------------------
        // ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
        //-----------------------------------------------------------------

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
