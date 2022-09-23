using System;
using System.Collections;
using System.Windows.Forms;

namespace MedicalCard
{
    public partial class DoctorForm : Form
    {
        // глобальные переменные класса
        public string _userName;    // ФИО пользователя
        public string _userSpec;    // специальность пользователя
        private int userId;         // ID пользователя
        private int pacientId;      // ID пациента
        // создание экземпляра класса DBWorking
        DBWorking workingDB = new DBWorking();

        // Структуры для хранения информации
        struct AnpmtStruct
        {
            public string anpmtDate;
            public string anpmtWeight;
            public string anpmtHeight;
            public string anpmtPressure;
            public int userID;
        }

        struct VaccinStruct
        {
            public string vaccinDate;
            public string vaccinName;
            public string vaccinDatch;
            public string vaccinDose;
            public string vaccinState;
            public int userID;
        }

        struct DoseCommStruct
        {
            public string doseCommNumber;
            public string doseCommDate;
            public string doseCommType;
            public string doseCommDose;
        }

        struct DiagnoseStruct
        {
            public string diagnoseDate;
            public string diagnoseName;
            public bool diagnoseStatus;
            public int userID;
        }

        struct TempDisStruct
        {
            public string tempDisYear;
            public string tempDisReason;
            public string tempDisPeriod;
            public int tempDisCount;
            public int userID;
        }

        struct InspectionStruct
        {
            public string inspDate;
            public string inspResult;
            public string inspRecomendation;
            public int userID;
        }

        struct DiagnosticsStruct
        {
            public string diagDate;
            public string diagType;
            public string diagDiagnose;
            public string diagResult;
            public int userID;
        }
        
        struct LaboratoryStruct
        {
            public string labDate;
            public string labType;
            public int labNumber;
            public int userID;
        }
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }
        public DoctorForm()
        {
            InitializeComponent();

            // установка в диалоге текущей даты и времени
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToShortTimeString();
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            // установке в диалоге данных о враче
            this.Text = "Врач: " + _userSpec;
            userNameLabel.Text = _userName;
            if (pacientId == 0)
                tabControl1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // установка таймера
            timeLabel.Text = DateTime.Now.ToShortTimeString();
        }

        #region buttons
        // обработчик кнопки "Поиск пациента"
        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchPacientForm searchPacient = new SearchPacientForm();
            if (searchPacient.ShowDialog(this) == DialogResult.OK)
            {
                pacientId = searchPacient.id;
                idBox.Text = Convert.ToString(pacientId);
                nameBox.Text = searchPacient.pacName;
                DateTime bDate = searchPacient.pacBirthDate;
                bdateBox.Text = searchPacient.strPacBDate;
                // вычисление возраста пациента
                int age = AddFuulYears(bDate, DateTime.Today);
                ageBox.Text = Convert.ToString(age);
                adresBox.Text = searchPacient.pacAdres;
                telBox.Text = searchPacient.pacTelephone;
                workBox.Text = searchPacient.pacWorkPlace;
                tabControl1.Enabled = true;
                ReadData("Anpmt_data");
            }
        }

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
        #endregion

        // Изменение вкладок
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = "Anpmt_data";
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    table = "Anpmt_data";
                    break;
                case 1:
                    table = "Vaccinations";
                    break;
                case 2:
                    table = "Dose_commitment";
                    break;
                case 3:
                    table = "Diagnose";
                    break;
                case 4:
                    table = "Temp_disability";
                    break;
                case 5:
                    table = "Inspection";
                    break;
                case 6:
                    table = "Diagnostics";
                    break;
                case 7:
                    table = "Laboratory";
                    break;
                default:
                    break;
            }
            ReadData(table);
            ClearTextBox();
        }

        // Вывод имеющихся данных на экран
        private void ReadData(string table)
        {
            // создание коллекции объектов
            ArrayList dataList = new ArrayList();
            dataList.AddRange(workingDB.ReadOthersData(table, pacientId));
            // заполнение таблицы данными из базы данных
            switch (table)
            {
                case "Anpmt_data":
                    PrintAnpmtData(listViewAntpData, dataList);
                    break;
                case "Vaccinations":
                    PrintVaccinData(listViewVaccinData, dataList);
                    break;
                case "Dose_commitment":
                    PrintDoseData(listViewDoseData, dataList);
                    break;
                case "Diagnose":
                    PrintDiagnoseData(listViewDiagnoseData, dataList);
                    break;
                case "Temp_disability":
                    PrintTempDisData(listViewDisabilityData, dataList);
                    break;
                case "Inspection":
                    PrintInspData(listViewInspectionData, dataList);
                    break;
                case "Diagnostics":
                    PrintDiagnosticsData(listViewDiagnisticData, dataList);
                    break;
                case "Laboratory":
                    PrintLaboratoryData(listViewLabData, dataList);
                    break;
                default:
                    break;
            }
        }

        #region anpmtdata
        // АНТРОПОМЕТРИЧЕСКИЕ ДАННЫЕ ПАЦИЕНТА-----------------------------------
        // процедура вывода информации о пациенте в listView
        private void PrintAnpmtData(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка
            ListViewItem lvi;

            foreach (object item in list)
            {
                var anpmt = new AnpmtStruct();
                anpmt = AddAnpmt(item.ToString());
                lvi = new ListViewItem(_cutSubstringFromString(ref anpmt.anpmtDate, " ", 0));
                lvi.SubItems.Add(anpmt.anpmtWeight);
                lvi.SubItems.Add(anpmt.anpmtHeight);
                lvi.SubItems.Add(anpmt.anpmtPressure);
                // вывод имени пользователя, внесшего данные
                lvi.SubItems.Add(workingDB.ReadUserName(anpmt.userID));
                listV.Items.Add(lvi);
            }

        }
        
        // Добавление новых данных
        // Вес
        private void weightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressValid1(e);
        }

        // Рост
        private void growthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressValid1(e);
        }

        // Артериальное давление
        private void pressureTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 47) // цифры, клавиша BackSpace и слэш
            {
                e.Handled = true;
            }
        }

        // Обработчик нажатия клавиши "Добавить данные"
        private void addDataButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                float weight = Convert.ToSingle(weightTextBox.Text);
                float height = Convert.ToSingle(growthTextBox.Text);
                DateTime day = DateTime.Today;
            
                workingDB.AddDataInAnpmtTable(day, weight, height, pressureTextBox.Text, pacientId, userId);
                // считывание новых данных из БД и обновление данных в таблице listView
                ReadData("Anpmt_data");
                ClearTextBox();
            }
        }
        #endregion

        #region vaccinationsdata
        // КАРТА ПРИВИВОК ПАЦИЕНТА----------------------------------------------
        // процедура вывода информации о прививках в listView
        private void PrintVaccinData(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка
            ListViewItem lvi;

            foreach (object item in list)
            {
                var vaccin = new VaccinStruct();
                vaccin = AddVaccin(item.ToString());
                lvi = new ListViewItem(_cutSubstringFromString(ref vaccin.vaccinDate, " ", 0));
                lvi.SubItems.Add(vaccin.vaccinName);
                lvi.SubItems.Add(vaccin.vaccinDatch);
                lvi.SubItems.Add(vaccin.vaccinDose);
                lvi.SubItems.Add(vaccin.vaccinState);
                // вывод имени пользователя, внесшего данные
                lvi.SubItems.Add(workingDB.ReadUserName(vaccin.userID));
                listV.Items.Add(lvi);
            }
        }

        // Добавление новых данных
        // Доза
        private void doseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressValid1(e);
        }

        // Обработчик нажатия клавиши "Добавить данные"
        private void addDataButton2_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                float dose = Convert.ToSingle(doseTextBox.Text);
                DateTime day = DateTime.Today;
                workingDB.AddDataInVaccinationsTable(day, nameTextBox.Text, serTextBox.Text, dose, stateTextBox.Text,
                    pacientId, userId);
                // считывание новых данных из БД и обновление данных в таблице listView
                ReadData("Vaccinations");
                ClearTextBox();
            }
        }
        #endregion

        #region dosecommitmentdata
        // ДОЗОВАЯ НАГРУЗКА ПРИ РЕНТГЕНОЛОГИЧЕСКОМ ИССЛЕДОВАНИИ-----------------
        // процедура вывода информации о дозовых нагрузках в listView
        private void PrintDoseData(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка
            ListViewItem lvi;

            foreach (object item in list)
            {
                var dose = new DoseCommStruct();
                dose = AddDose(item.ToString());
                lvi = new ListViewItem(dose.doseCommNumber);
                lvi.SubItems.Add(_cutSubstringFromString(ref dose.doseCommDate, " ", 0));
                lvi.SubItems.Add(dose.doseCommType);
                lvi.SubItems.Add(dose.doseCommDose);
                listV.Items.Add(lvi);
            }
        }

        // Добавление новых данных
        // Доза излучения
        private void dDoseTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressValid1(e);
        }

        // Обработчик нажатия клавиши "Добавить данные"
        private void addDataButton3_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                int number = Convert.ToInt32(numberTextBox.Text);
                float dose = Convert.ToSingle(dDoseTextBox.Text);
                workingDB.AddDataInDoseCommitmentTable(number, dDateTimePicker.Value, typeTextBox.Text, 
                    dose, pacientId, userId);
                // считывание новых данных из БД и обновление данных в таблице listView
                ReadData("Dose_commitment");
                ClearTextBox();
            }
        }
        #endregion

        #region diagnose
        // ЗАКЛЮЧИТЕЛЬНЫЙ (УТОЧНЕННЫЙ) ДИАГНОЗ----------------------------------
        // процедура вывода информации о диагнозах в listView
        private void PrintDiagnoseData(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка
            ListViewItem lvi;

            foreach (object item in list)
            {
                var diagnose = new DiagnoseStruct();
                diagnose = AddDiagnose(item.ToString());
                string status = diagnose.diagnoseStatus ? "да" : "нет";
                lvi = new ListViewItem(_cutSubstringFromString(ref diagnose.diagnoseDate, " ", 0));
                lvi.SubItems.Add(diagnose.diagnoseName);
                lvi.SubItems.Add(status);
                // вывод имени пользователя, внесшего данные
                lvi.SubItems.Add(workingDB.ReadUserName(diagnose.userID));
                listV.Items.Add(lvi);
            }
        }

        // Обработчик нажатия клавиши "Добавить данные"
        private void addDataButton4_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                bool status = firstTimeCheckBox.Checked ? true : false;
                workingDB.AddDataInDiagnoseTable(dgDateTimePicker.Value, diagnoseTextBox.Text, 
                    status, pacientId, userId);
                // считывание новых данных из БД и обновление данных в таблице listView
                ReadData("Diagnose");
                ClearTextBox();
            }
        }
        #endregion

        #region tempdisability
        // ВРЕМЕННАЯ НЕТРУДОСПОСОБНОСТЬ-----------------------------------------
        // процедура вывода информации о больничных листах в listView
        private void PrintTempDisData(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка
            ListViewItem lvi;

            foreach (object item in list)
            {
                var dis = new TempDisStruct();
                dis = AddDisability(item.ToString());
                lvi = new ListViewItem(dis.tempDisYear);
                lvi.SubItems.Add(dis.tempDisReason);
                lvi.SubItems.Add(dis.tempDisPeriod);
                lvi.SubItems.Add(Convert.ToString(dis.tempDisCount));
                // вывод имени пользователя, внесшего данные
                lvi.SubItems.Add(workingDB.ReadUserName(dis.userID));
                listV.Items.Add(lvi);
            }
        }

        // Обработчик нажатия клавиши "Добавить данные"
        private void addDataButton5_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                DateTime fDay, lDay;
                fDay = startDateTimePicker.Value;
                lDay = finDateTimePicker.Value;
                // год учета
                string year = fDay.ToString("yyyy");
                // срок больничного листа
                string period = fDay.ToString("dd.MM.yyyy") + "-" + 
                    lDay.ToString("dd.MM.yyyy");
                // количество дней
                TimeSpan cDays = lDay - fDay;
                int count = Convert.ToInt32(cDays.Days);

                workingDB.AddDataInTempDisTable(year, disDiagnoseTextBox.Text, period, 
                    count, pacientId, userId);
                // считывание новых данных из БД и обновление данных в таблице listView
                ReadData("Temp_disability");
                ClearTextBox();
            }
        }
        #endregion

        #region inspection
        // ОСМОТР ВРАЧЕЙ-СПЕЦИАЛИСТОВ-------------------------------------------
        // процедура вывода информации об осмотрах в listView
        private void PrintInspData(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка
            ListViewItem lvi;

            foreach (object item in list)
            {
                var insp = new InspectionStruct();
                insp = AddInspection(item.ToString());
                lvi = new ListViewItem(_cutSubstringFromString(ref insp.inspDate, " ", 0));
                lvi.SubItems.Add(insp.inspResult);
                lvi.SubItems.Add(insp.inspRecomendation);
                // вывод имени пользователя, внесшего данные
                lvi.SubItems.Add(workingDB.ReadUserName(insp.userID));
                listV.Items.Add(lvi);
            }
        }

        // Обработчик нажатия клавиши "Внесение результатов осмотра"
        private void addDataButton6_Click(object sender, EventArgs e)
        {
            AddInspectionForm inspForm = new AddInspectionForm();
            if (inspForm.ShowDialog(this) == DialogResult.OK)
            {
                DateTime day = DateTime.Today;
                workingDB.AddDataInInspTable(day, inspForm.inspResult, inspForm.inspRecom, 
                    pacientId, userId);
                // считывание новых данных из БД и обновление данных в таблице listView
                ReadData("Inspection");
                ClearTextBox();
            }
        }
        #endregion

        #region diagnostics
        // ДИАГНОСТИЧЕСКИЕ ИССЛЕДОВАНИЯ-----------------------------------------
        // процедура вывода информации об исследованиях в listView
        private void PrintDiagnosticsData(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка
            ListViewItem lvi;

            foreach (object item in list)
            {
                var diag = new DiagnosticsStruct();
                diag = AddDiagnostics(item.ToString());
                lvi = new ListViewItem(_cutSubstringFromString(ref diag.diagDate, " ", 0));
                lvi.SubItems.Add(diag.diagType);
                lvi.SubItems.Add(diag.diagDiagnose);
                lvi.SubItems.Add(diag.diagResult);
                // вывод имени пользователя, внесшего данные
                lvi.SubItems.Add(workingDB.ReadUserName(diag.userID));
                listV.Items.Add(lvi);
            }
        }

        // Обработчик нажатия клавиши "Добавить данные"
        private void addDataButton7_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                DateTime day = DateTime.Today;
                workingDB.AddDataInDiagnosticsTable(day, diTypeTextBox.Text, diDiagnoseTextBox.Text,
                    diResultTextBox.Text, pacientId, userId);
                // считывание новых данных из БД и обновление данных в таблице listView
                ReadData("Diagnostics");
                ClearTextBox();
            }
        }
        #endregion

        #region laboratory
        // ЛАБОРАТОРНЫЕ ИССЛЕДОВАНИЯ--------------------------------------------
        // процедура вывода информации об исследованиях в listView
        private void PrintLaboratoryData(ListView listV, ArrayList list)
        {
            listV.Items.Clear();    // очистка списка
            ListViewItem lvi;

            foreach (object item in list)
            {
                var lab = new LaboratoryStruct();
                lab = AddLaboratory(item.ToString());
                lvi = new ListViewItem(_cutSubstringFromString(ref lab.labDate, " ", 0));
                lvi.SubItems.Add(lab.labType);
                lvi.SubItems.Add(Convert.ToString(lab.labNumber));
                // вывод имени пользователя, внесшего данные
                lvi.SubItems.Add(workingDB.ReadUserName(lab.userID));
                listV.Items.Add(lvi);
            }
        }

        // № исследования
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        // Обработчик нажатия клавиши "Добавить данные"
        private void addDataButton8_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                DateTime day = DateTime.Today;
                workingDB.AddDataInLaboratoryTable(day, lTypeTextBox.Text, Convert.ToInt32(textBox4.Text), 
                    pacientId, userId);
                // считывание новых данных из БД и обновление данных в таблице listView
                ReadData("Laboratory");
                ClearTextBox();
            }
        }
        #endregion
        //-----------------------------------------------------------------
        // ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
        //-----------------------------------------------------------------
        // Функция вычисления количества полных лет пациента
        private int AddFuulYears(DateTime dt1, DateTime dt2)
        {
            if (dt2.Year <= dt1.Year)
                return 0;
            int result = dt2.Year - dt1.Year;
            if (dt1.DayOfYear > dt2.DayOfYear)
                --result;
            return result;
        }

        // Допуск ввода цифры, клавиши BackSpace и запятой
        private void KeyPressValid1(KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        // Проверка валидности введенных данных
        private bool IsValidData()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    if ((weightTextBox.Text == "") || (growthTextBox.Text == "") || (pressureTextBox.Text == ""))
                    {
                        MessageBox.Show("Заполните все поля формы!");
                        return false;
                    }
                    else
                        return true;
                case 1:
                    if ((nameTextBox.Text == "") || (serTextBox.Text == "") || 
                        (doseTextBox.Text == "") || (stateTextBox.Text == ""))
                    {
                        MessageBox.Show("Заполните все поля формы!");
                        return false;
                    }
                    else
                        return true;
                case 2:
                    if ((numberTextBox.Text == "") || (dDoseTextBox.Text == "") || (typeTextBox.Text == ""))
                    {
                        MessageBox.Show("Заполните все поля формы!");
                        return false;
                    }
                    else
                        return true;
                case 3:
                    if (diagnoseTextBox.Text == "")
                    {
                        MessageBox.Show("Заполните все поля формы!");
                        return false;
                    }
                    else
                        return true;
                case 4:
                    if (disDiagnoseTextBox.Text == "")
                    {
                        MessageBox.Show("Заполните все поля формы!");
                        return false;
                    }
                    else
                        return true;
                case 6:
                    if ((diTypeTextBox.Text == "") || (diDiagnoseTextBox.Text == "") || (diResultTextBox.Text == ""))
                    {
                        MessageBox.Show("Заполните все поля формы!");
                        return false;
                    }
                    else
                        return true;
                case 7:
                    if ((lTypeTextBox.Text == "") || (textBox4.Text == ""))
                    {
                        MessageBox.Show("Заполните все поля формы!");
                        return false;
                    }
                    else
                        return true;
                default:
                    return false;
            }
            
        }

        // Функция обратного преобразования из строки в структуру AnpmtStruct
        private AnpmtStruct AddAnpmt(string Str)
        {
            string separator = "$$$$$";
            // структура для возвращения результата
            var res = new AnpmtStruct();
            // заполнение полей структуры
            res.anpmtDate = _cutSubstringFromString(ref Str, separator, 0);
            res.anpmtWeight = _cutSubstringFromString(ref Str, separator, 0);
            res.anpmtHeight = _cutSubstringFromString(ref Str, separator, 0);
            res.anpmtPressure = _cutSubstringFromString(ref Str, separator, 0);
            _cutSubstringFromString(ref Str, separator, 0);
            res.userID = Convert.ToInt32(Str);

            return res;
        }

        // Функция обратного преобразования из строки в структуру VaccinStruct
        private VaccinStruct AddVaccin(string Str)
        {
            string separator = "$$$$$";
            // структура для возвращения результата
            var res = new VaccinStruct();
            // заполнение полей структуры
            res.vaccinDate = _cutSubstringFromString(ref Str, separator, 0);
            res.vaccinName = _cutSubstringFromString(ref Str, separator, 0);
            res.vaccinDatch = _cutSubstringFromString(ref Str, separator, 0);
            res.vaccinDose = _cutSubstringFromString(ref Str, separator, 0);
            res.vaccinState = _cutSubstringFromString(ref Str, separator, 0);
            _cutSubstringFromString(ref Str, separator, 0);
            res.userID = Convert.ToInt32(Str);

            return res;
        }

        // Функция обратного преобразования из строки в структуру DoseCommStruct
        private DoseCommStruct AddDose(string Str)
        {
            string separator = "$$$$$";
            // структура для возвращения результата
            var res = new DoseCommStruct();
            // заполнение полей структуры
            res.doseCommNumber = _cutSubstringFromString(ref Str, separator, 0);
            res.doseCommDate = _cutSubstringFromString(ref Str, separator, 0);
            res.doseCommType = _cutSubstringFromString(ref Str, separator, 0);
            res.doseCommDose = _cutSubstringFromString(ref Str, separator, 0);

            return res;
        }

        // Функция обратного преобразования из строки в структуру DiagnoseStruct
        private DiagnoseStruct AddDiagnose(string Str)
        {
            string separator = "$$$$$";
            // структура для возвращения результата
            var res = new DiagnoseStruct();
            // заполнение полей структуры
            res.diagnoseDate = _cutSubstringFromString(ref Str, separator, 0);
            res.diagnoseName = _cutSubstringFromString(ref Str, separator, 0);
            res.diagnoseStatus = Convert.ToBoolean(_cutSubstringFromString(ref Str, separator, 0));
            _cutSubstringFromString(ref Str, separator, 0);
            res.userID = Convert.ToInt32(Str);

            return res;
        }

        // Функция обратного преобразования из строки в структуру TempDisStruct
        private TempDisStruct AddDisability(string Str)
        {
            string separator = "$$$$$";
            // структура для возвращения результата
            var res = new TempDisStruct();
            // заполнение полей структуры
            res.tempDisYear = _cutSubstringFromString(ref Str, separator, 0);
            res.tempDisReason = _cutSubstringFromString(ref Str, separator, 0);
            res.tempDisPeriod = _cutSubstringFromString(ref Str, separator, 0);
            res.tempDisCount = Convert.ToInt32(_cutSubstringFromString(ref Str, separator, 0));
            _cutSubstringFromString(ref Str, separator, 0);
            res.userID = Convert.ToInt32(Str);

            return res;
        }

        // Функция обратного преобразования из строки в структуру InspectionStruct
        private InspectionStruct AddInspection(string Str)
        {
            string separator = "$$$$$";
            // структура для возвращения результата
            var res = new InspectionStruct();
            // заполнение полей структуры
            res.inspDate = _cutSubstringFromString(ref Str, separator, 0);
            res.inspResult = _cutSubstringFromString(ref Str, separator, 0);
            res.inspRecomendation = _cutSubstringFromString(ref Str, separator, 0);
            _cutSubstringFromString(ref Str, separator, 0);
            res.userID = Convert.ToInt32(Str);

            return res;
        }

        // Функция обратного преобразования из строки в структуру DiagnosticsStruct
        private DiagnosticsStruct AddDiagnostics(string Str)
        {
            string separator = "$$$$$";
            // структура для возвращения результата
            var res = new DiagnosticsStruct();
            // заполнение полей структуры
            res.diagDate = _cutSubstringFromString(ref Str, separator, 0);
            res.diagType = _cutSubstringFromString(ref Str, separator, 0);
            res.diagDiagnose = _cutSubstringFromString(ref Str, separator, 0);
            res.diagResult = _cutSubstringFromString(ref Str, separator, 0);
            _cutSubstringFromString(ref Str, separator, 0);
            res.userID = Convert.ToInt32(Str);

            return res;
        }

        // Функция обратного преобразования из строки в структуру LaboratoryStruct
        private LaboratoryStruct AddLaboratory(string Str)
        {
            string separator = "$$$$$";
            // структура для возвращения результата
            var res = new LaboratoryStruct();
            // заполнение полей структуры
            res.labDate = _cutSubstringFromString(ref Str, separator, 0);
            res.labType = _cutSubstringFromString(ref Str, separator, 0);
            res.labNumber = Convert.ToInt32(_cutSubstringFromString(ref Str, separator, 0));
            _cutSubstringFromString(ref Str, separator, 0);
            res.userID = Convert.ToInt32(Str);

            return res;
        }

        // Функция очистки заполненных ранее TextBox
        private void ClearTextBox()
        {
            weightTextBox.Text = "";
            weightTextBox.Clear();
            growthTextBox.Text = "";
            growthTextBox.Clear();
            pressureTextBox.Text = "";
            pressureTextBox.Clear();
            nameTextBox.Text = "";
            nameTextBox.Clear();
            serTextBox.Text = "";
            serTextBox.Clear();
            doseTextBox.Text = "";
            doseTextBox.Clear();
            stateTextBox.Text = "";
            stateTextBox.Clear();
            numberTextBox.Text = "";
            numberTextBox.Clear();
            dDoseTextBox.Text = "";
            dDoseTextBox.Clear();
            typeTextBox.Text = "";
            typeTextBox.Clear();
            dDateTimePicker.Value = DateTime.Now;
            diagnoseTextBox.Text = "";
            diagnoseTextBox.Clear();
            dgDateTimePicker.Value = DateTime.Now;
            firstTimeCheckBox.Checked = true;
            startDateTimePicker.Value = DateTime.Now;
            finDateTimePicker.Value = DateTime.Now;
            disDiagnoseTextBox.Text = "";
            disDiagnoseTextBox.Clear();
            diTypeTextBox.Text = "";
            diTypeTextBox.Clear();
            diDiagnoseTextBox.Text = "";
            diDiagnoseTextBox.Clear();
            diResultTextBox.Text = "";
            diResultTextBox.Clear();
            lTypeTextBox.Text = "";
            lTypeTextBox.Clear();
            textBox4.Text = "";
            textBox4.Clear();
        }
        // Метод отсечения части строки и образование новой строки
        private string _cutSubstringFromString(ref string s, string c, int startIndex)
        {
            int pos1 = s.IndexOf(c, startIndex);
            string retString = s.Substring(0, pos1);
            s = (s.Substring(pos1 + c.Length)).Trim();
            return retString;
        }
    }
}
