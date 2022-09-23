using System;
using System.Windows.Forms;

namespace MedicalCard
{
    public partial class EditPacientForm : Form
    {
        // переменные формы
        public string name;
        public string adres;
        public string tel;
        public int sex;
        public DateTime birtndate;
        public string workplace;

        public EditPacientForm()
        {
            InitializeComponent();
        }

        public EditPacientForm(string _name, string _adres, string _tel, int _sex, string _birtndate, string _workplace)
        {
            InitializeComponent();

            // перенос полученных данных от родителя на форму
            nameBox.Text = _name;
            adresBox.Text = _adres;
            telBox.Text = _tel;
            sexComboBox.SelectedIndex = _sex;
            dateTimePicker.Value = Convert.ToDateTime(_birtndate);
            workTextBox.Text = _workplace;
        }

        // обработчик кнопки "ОК"
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                // присвоение измененных данных переменным формы
                name = nameBox.Text;
                adres = adresBox.Text;
                tel = telBox.Text;
                sex = sexComboBox.SelectedIndex;
                birtndate = dateTimePicker.Value;
                workplace = workTextBox.Text;

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
                MessageBox.Show("Введите ФИО пациента!");
                return false;
            }
            else if (adresBox.Text == "")
            {
                MessageBox.Show("Введите адрес проживания пациента!");
                return false;
            }
            else if (telBox.Text == "")
            {
                MessageBox.Show("Введите телефон пациента!");
                return false;
            }
            else if (workTextBox.Text == "")
            {
                MessageBox.Show("Введите место работы (учёбы) пациента!");
                return false;
            }
            else
                return true;
        }
    }
}
