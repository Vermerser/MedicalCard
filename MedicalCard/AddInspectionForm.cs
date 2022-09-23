using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalCard
{
    public partial class AddInspectionForm : Form
    {
        // переменные класса
        public string inspResult;
        public string inspRecom;

        public AddInspectionForm()
        {
            InitializeComponent();
        }

        // Обработчик кнопки "ОК"
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                inspResult = resultTextBox.Text;
                inspRecom = recomTextBox.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        // Проверка валидности введенных данных
        private bool IsValidData()
        {
            if (resultTextBox.Text == "")
            {
                MessageBox.Show("Введите результаты осмотра пациента!");
                return false;
            }
            else
                return true;
        }
    }
}
