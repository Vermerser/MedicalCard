using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MedicalCard
{
    public partial class SearchPacientForm : Form
    {
        // переменные класса
        public int id;
        public string pacName;
        public string pacAdres;
        public string pacTelephone;
        public int pacSex;
        public DateTime pacBirthDate;
        public string strPacBDate;
        public string pacWorkPlace;
        public bool pacDelStatus;

        public bool searchResult = false;   // результат поиска
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MedDB.mdf;Integrated Security=True";
        public SearchPacientForm()
        {
            InitializeComponent();
        }

        //  обработчик нажатия кнопки "Поиск"
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (sidBox.Text != "") // если поиск по номеру карточки
                {
                    id = Convert.ToInt32(sidBox.Text);
                    // строка подключения
                    string sqlExpression = $"SELECT * FROM [Pacient] WHERE pacient_id ='{id}'";
                    // создание подключения
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // открытие подключения
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows) // если есть данные
                        {
                            reader.Read();
                            pacName = reader.GetString(1);
                            pacAdres = reader.GetString(2).Trim();
                            pacTelephone = reader.GetString(3).Trim();
                            pacSex = reader.GetInt32(4);
                            pacBirthDate = reader.GetDateTime(5);
                            pacWorkPlace = reader.GetString(6).Trim();
                            pacDelStatus = reader.GetBoolean(7);
                            searchResult = true;
                        }
                        reader.Close();
                    }
                    if (pacDelStatus)   // если пациент "Удален"
                        searchResult = false;
                }
                else    // если поиск по ФИО пациента
                {
                    pacName = snameBox.Text;
                    if (pacName.Length < 100)
                        pacName = pacName.PadRight(100);
                    // строка подключения
                    string sqlExpression = $"SELECT * FROM [Pacient] WHERE pacient_name = N'{pacName}'";
                    // создание подключения
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // открытие подключения
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows) // если есть данные
                        {
                            reader.Read();
                            id = reader.GetInt32(0);
                            pacAdres = reader.GetString(2).Trim();
                            pacTelephone = reader.GetString(3).Trim();
                            pacSex = reader.GetInt32(4);
                            pacBirthDate = reader.GetDateTime(5);
                            pacWorkPlace = reader.GetString(6).Trim();
                            pacDelStatus = reader.GetBoolean(7);
                            searchResult = true;
                        }
                        reader.Close();
                    }
                    if (pacDelStatus)   // если пациент "Удален"
                        searchResult = false;
                }
                if (searchResult)
                    PrintSearchResult();
                else
                {
                    ClearSearchResult();
                    MessageBox.Show("Пациент с такими данными не найден!");
                }
            }
        }

        // обработчик нажатия кнопки "ОК"
        private void okButton_Click(object sender, EventArgs e)
        {
            if (searchResult)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        // Функция заполнения полей результатов поиска
        private void PrintSearchResult()
        {
            ClearSearchResult();

            idBox.Text = Convert.ToString(id);
            nameBox.Text = pacName.Trim();
            string tmp  = Convert.ToString(pacBirthDate);
            strPacBDate = _cutSubstringFromString(ref tmp, " ", 0);
            bdateBox.Text = strPacBDate;
            adresBox.Text = pacAdres;
            telBox.Text = pacTelephone;
            workBox.Text = pacWorkPlace;
        }

        // Функция очистки полей вывода результатов поиска
        private void ClearSearchResult()
        {
            idBox.Text = "";
            nameBox.Text = "";
            bdateBox.Text = "";
            adresBox.Text = "";
            telBox.Text = "";
            workBox.Text = "";
        }

        // Проверка валидности введенных данных
        private bool IsValidData()
        {
            if ((sidBox.Text == "") && (snameBox.Text == ""))
            {
                MessageBox.Show("Введите ФИО или номер карты пациента!");
                return false;
            }
            else
                return true;
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
