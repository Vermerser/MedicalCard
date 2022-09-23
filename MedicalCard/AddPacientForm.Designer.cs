namespace MedicalCard
{
    partial class AddPacientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPacientForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.stActivComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.streetBox = new System.Windows.Forms.TextBox();
            this.sityBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.middlenameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.surnameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.houseNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.korpBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.flatBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.telBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.sexComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.workTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.workTextBox);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.sexComboBox);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.telBox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.stActivComboBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.middlenameBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.surnameBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 424);
            this.panel1.TabIndex = 1;
            // 
            // stActivComboBox
            // 
            this.stActivComboBox.FormattingEnabled = true;
            this.stActivComboBox.Items.AddRange(new object[] {
            "Активный",
            "Удален"});
            this.stActivComboBox.Location = new System.Drawing.Point(7, 399);
            this.stActivComboBox.Name = "stActivComboBox";
            this.stActivComboBox.Size = new System.Drawing.Size(267, 21);
            this.stActivComboBox.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 383);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Статус активности";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flatBox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.korpBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.houseNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.streetBox);
            this.groupBox1.Controls.Add(this.sityBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(7, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 133);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Адрес проживания";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Город";
            // 
            // streetBox
            // 
            this.streetBox.Location = new System.Drawing.Point(9, 78);
            this.streetBox.Name = "streetBox";
            this.streetBox.Size = new System.Drawing.Size(248, 20);
            this.streetBox.TabIndex = 11;
            // 
            // sityBox
            // 
            this.sityBox.Location = new System.Drawing.Point(9, 39);
            this.sityBox.Name = "sityBox";
            this.sityBox.Size = new System.Drawing.Size(248, 20);
            this.sityBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Улица";
            // 
            // middlenameBox
            // 
            this.middlenameBox.Location = new System.Drawing.Point(7, 98);
            this.middlenameBox.Name = "middlenameBox";
            this.middlenameBox.Size = new System.Drawing.Size(267, 20);
            this.middlenameBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отчество";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(7, 59);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(267, 20);
            this.nameBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя";
            // 
            // surnameBox
            // 
            this.surnameBox.Location = new System.Drawing.Point(7, 20);
            this.surnameBox.Name = "surnameBox";
            this.surnameBox.Size = new System.Drawing.Size(267, 20);
            this.surnameBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(164, 446);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Дом";
            // 
            // houseNum
            // 
            this.houseNum.Location = new System.Drawing.Point(45, 102);
            this.houseNum.Name = "houseNum";
            this.houseNum.Size = new System.Drawing.Size(43, 20);
            this.houseNum.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(94, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Корп.";
            // 
            // korpBox
            // 
            this.korpBox.Location = new System.Drawing.Point(135, 102);
            this.korpBox.Name = "korpBox";
            this.korpBox.Size = new System.Drawing.Size(44, 20);
            this.korpBox.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(185, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Кв.";
            // 
            // flatBox
            // 
            this.flatBox.Location = new System.Drawing.Point(214, 102);
            this.flatBox.Name = "flatBox";
            this.flatBox.Size = new System.Drawing.Size(43, 20);
            this.flatBox.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 271);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Телефон:";
            // 
            // telBox
            // 
            this.telBox.Location = new System.Drawing.Point(68, 268);
            this.telBox.Name = "telBox";
            this.telBox.Size = new System.Drawing.Size(206, 20);
            this.telBox.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 296);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Пол пациента:";
            // 
            // sexComboBox
            // 
            this.sexComboBox.FormattingEnabled = true;
            this.sexComboBox.Items.AddRange(new object[] {
            "Женский",
            "Мужской"});
            this.sexComboBox.Location = new System.Drawing.Point(90, 293);
            this.sexComboBox.Name = "sexComboBox";
            this.sexComboBox.Size = new System.Drawing.Size(184, 21);
            this.sexComboBox.TabIndex = 20;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 323);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Дата рождения:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(99, 320);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(175, 20);
            this.dateTimePicker.TabIndex = 22;
            this.dateTimePicker.Value = new System.DateTime(2019, 4, 6, 0, 0, 0, 0);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 343);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Место работы (учёбы)";
            // 
            // workTextBox
            // 
            this.workTextBox.Location = new System.Drawing.Point(7, 360);
            this.workTextBox.Name = "workTextBox";
            this.workTextBox.Size = new System.Drawing.Size(267, 20);
            this.workTextBox.TabIndex = 24;
            // 
            // AddPacientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 488);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPacientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление нового пациента";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox stActivComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox streetBox;
        private System.Windows.Forms.TextBox sityBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox middlenameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox surnameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox telBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox flatBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox korpBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox houseNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox workTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox sexComboBox;
    }
}