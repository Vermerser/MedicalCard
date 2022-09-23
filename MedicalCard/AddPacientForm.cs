using System;
using System.Windows.Forms;

namespace MedicalCard
{
    public partial class AddPacientForm : Form
    {
        // переменные класса
        public string pacName;
        public string pacAdres;
        public string pacTelephone;
        public int pacSex;
        public DateTime pacBirthDate;
        public string pacWorkPlace;
        public bool pacDelStatus;

        public AddPacientForm()
        {
            InitializeComponent();

            sexComboBox.SelectedIndex = 0;
            stActivComboBox.SelectedIndex = 0;
            dateTimePicker.Value = DateTime.Today;
        }

        // обработчик кнопки "ОК"
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                pacName = surnameBox.Text + " " + nameBox.Text + " " + middlenameBox.Text;
                if ((korpBox.Text == "") && (flatBox.Text == ""))
                {
                    pacAdres = "г. " + sityBox.Text + ", ул. " + streetBox.Text + ", д. " + houseNum.Text;
                }
                else if ((korpBox.Text == "") && (flatBox.Text != ""))
                {
                    pacAdres = "г. " + sityBox.Text + ", ул. " + streetBox.Text + ", д. " + houseNum.Text + ", кв. " +
                               flatBox.Text;
                }
                else if ((korpBox.Text != "") && (flatBox.Text == ""))
                {
                    pacAdres = "г. " + sityBox.Text + ", ул. " + streetBox.Text + ", д. " + houseNum.Text + "/" +
                           korpBox.Text;
                }
                else
                {
                    pacAdres = "г. " + sityBox.Text + ", ул. " + streetBox.Text + ", д. " + houseNum.Text + "/" +
                           korpBox.Text + ", кв. " + flatBox.Text;
                }
                pacTelephone = telBox.Text;
                pacSex = sexComboBox.SelectedIndex;
                pacWorkPlace = workTextBox.Text;
                pacBirthDate = dateTimePicker.Value;
                pacDelStatus = DelStatus();
                
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
                MessageBox.Show("Введите фамилию пациента!");
                return false;
            }
            else if (nameBox.Text == "")
            {
                MessageBox.Show("Введите имя пациента!");
                return false;
            }
            else if (middlenameBox.Text == "")
            {
                MessageBox.Show("Введите отчество пациента!");
                return false;
            }
            else if ((sityBox.Text == "") || (streetBox.Text == "") || (houseNum.Text == ""))
            {
                MessageBox.Show("Введите адрес проживания пациента!");
                return false;
            }
            else if (workTextBox.Text == "")
            {
                MessageBox.Show("Введите место работы или учебы пациента!");
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
