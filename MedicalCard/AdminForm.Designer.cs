namespace MedicalCard
{
    partial class AdminForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.label1 = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUser = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.User_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User_Specialty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User_Login = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User_Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User_Del_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPagePacient = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.delPacButton = new System.Windows.Forms.Button();
            this.editPacButton = new System.Windows.Forms.Button();
            this.addPacButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewPacients = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.delStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPageUser.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPagePacient.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(122, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Администратор системы:";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameLabel.Location = new System.Drawing.Point(357, 36);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(242, 18);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "Веремейчик Сергей Валенинович";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLabel.Location = new System.Drawing.Point(651, 36);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(43, 18);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Date";
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(922, 31);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(142, 30);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Выход из системы";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLabel.Location = new System.Drawing.Point(827, 36);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(45, 18);
            this.timeLabel.TabIndex = 4;
            this.timeLabel.Text = "Time";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageUser);
            this.tabControl1.Controls.Add(this.tabPagePacient);
            this.tabControl1.Location = new System.Drawing.Point(12, 69);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1052, 414);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageUser
            // 
            this.tabPageUser.Controls.Add(this.panel1);
            this.tabPageUser.Controls.Add(this.label2);
            this.tabPageUser.Controls.Add(this.listViewUsers);
            this.tabPageUser.Location = new System.Drawing.Point(4, 22);
            this.tabPageUser.Name = "tabPageUser";
            this.tabPageUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUser.Size = new System.Drawing.Size(1044, 388);
            this.tabPageUser.TabIndex = 0;
            this.tabPageUser.Text = "Пользователи";
            this.tabPageUser.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Location = new System.Drawing.Point(309, 339);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 36);
            this.panel1.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(303, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(120, 30);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(153, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(120, 30);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "Редактировать";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(120, 30);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пользователи, зарегистрированные в системе";
            // 
            // listViewUsers
            // 
            this.listViewUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.User_ID,
            this.User_Name,
            this.User_Specialty,
            this.User_Login,
            this.User_Password,
            this.User_Del_Status,
            this.User_Status});
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewUsers.Location = new System.Drawing.Point(7, 33);
            this.listViewUsers.MultiSelect = false;
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(1031, 293);
            this.listViewUsers.TabIndex = 0;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            this.listViewUsers.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewUsers_ItemSelectionChanged);
            this.listViewUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewUsers_MouseDoubleClick);
            // 
            // User_ID
            // 
            this.User_ID.Text = "ID";
            // 
            // User_Name
            // 
            this.User_Name.Text = "Пользователь";
            this.User_Name.Width = 255;
            // 
            // User_Specialty
            // 
            this.User_Specialty.Text = "Специальность";
            this.User_Specialty.Width = 160;
            // 
            // User_Login
            // 
            this.User_Login.Text = "Логин";
            this.User_Login.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.User_Login.Width = 130;
            // 
            // User_Password
            // 
            this.User_Password.Text = "Пароль";
            this.User_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.User_Password.Width = 130;
            // 
            // User_Del_Status
            // 
            this.User_Del_Status.Text = "Статус активности";
            this.User_Del_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.User_Del_Status.Width = 115;
            // 
            // User_Status
            // 
            this.User_Status.Text = "Статус пользователя";
            this.User_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.User_Status.Width = 177;
            // 
            // tabPagePacient
            // 
            this.tabPagePacient.Controls.Add(this.panel2);
            this.tabPagePacient.Controls.Add(this.label3);
            this.tabPagePacient.Controls.Add(this.listViewPacients);
            this.tabPagePacient.Location = new System.Drawing.Point(4, 22);
            this.tabPagePacient.Name = "tabPagePacient";
            this.tabPagePacient.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePacient.Size = new System.Drawing.Size(1044, 388);
            this.tabPagePacient.TabIndex = 1;
            this.tabPagePacient.Text = "Пациенты";
            this.tabPagePacient.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.delPacButton);
            this.panel2.Controls.Add(this.editPacButton);
            this.panel2.Controls.Add(this.addPacButton);
            this.panel2.Location = new System.Drawing.Point(309, 341);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 36);
            this.panel2.TabIndex = 6;
            // 
            // delPacButton
            // 
            this.delPacButton.Enabled = false;
            this.delPacButton.Location = new System.Drawing.Point(303, 3);
            this.delPacButton.Name = "delPacButton";
            this.delPacButton.Size = new System.Drawing.Size(120, 30);
            this.delPacButton.TabIndex = 4;
            this.delPacButton.Text = "Удалить";
            this.delPacButton.UseVisualStyleBackColor = true;
            this.delPacButton.Click += new System.EventHandler(this.delPacButton_Click);
            // 
            // editPacButton
            // 
            this.editPacButton.Enabled = false;
            this.editPacButton.Location = new System.Drawing.Point(153, 3);
            this.editPacButton.Name = "editPacButton";
            this.editPacButton.Size = new System.Drawing.Size(120, 30);
            this.editPacButton.TabIndex = 3;
            this.editPacButton.Text = "Редактировать";
            this.editPacButton.UseVisualStyleBackColor = true;
            this.editPacButton.Click += new System.EventHandler(this.editPacButton_Click);
            // 
            // addPacButton
            // 
            this.addPacButton.Location = new System.Drawing.Point(3, 3);
            this.addPacButton.Name = "addPacButton";
            this.addPacButton.Size = new System.Drawing.Size(120, 30);
            this.addPacButton.TabIndex = 2;
            this.addPacButton.Text = "Добавить";
            this.addPacButton.UseVisualStyleBackColor = true;
            this.addPacButton.Click += new System.EventHandler(this.addPacButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(413, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пациенты, зарегистрированные в системе";
            // 
            // listViewPacients
            // 
            this.listViewPacients.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewPacients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewPacients.FullRowSelect = true;
            this.listViewPacients.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewPacients.Location = new System.Drawing.Point(7, 35);
            this.listViewPacients.MultiSelect = false;
            this.listViewPacients.Name = "listViewPacients";
            this.listViewPacients.Size = new System.Drawing.Size(1031, 293);
            this.listViewPacients.TabIndex = 4;
            this.listViewPacients.UseCompatibleStateImageBehavior = false;
            this.listViewPacients.View = System.Windows.Forms.View.Details;
            this.listViewPacients.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewPacients_ItemSelectionChanged);
            this.listViewPacients.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewPacients_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Пациент";
            this.columnHeader2.Width = 187;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Адрес проживания";
            this.columnHeader3.Width = 202;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Телефон";
            this.columnHeader4.Width = 88;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Пол";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 83;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Дата рождения";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 112;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Место работы (учёбы)";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 175;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Статус активности";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 120;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(155, 70);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Image = global::MedicalCard.Properties.Resources.edit_user;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editToolStripMenuItem.Text = "Редактировать";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Image = global::MedicalCard.Properties.Resources.delete_user;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editStripMenuItem1,
            this.delStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 48);
            // 
            // editStripMenuItem1
            // 
            this.editStripMenuItem1.Enabled = false;
            this.editStripMenuItem1.Image = global::MedicalCard.Properties.Resources.edit_user;
            this.editStripMenuItem1.Name = "editStripMenuItem1";
            this.editStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.editStripMenuItem1.Text = "Редактировать";
            this.editStripMenuItem1.Click += new System.EventHandler(this.editStripMenuItem1_Click);
            // 
            // delStripMenuItem1
            // 
            this.delStripMenuItem1.Enabled = false;
            this.delStripMenuItem1.Image = global::MedicalCard.Properties.Resources.delete_user;
            this.delStripMenuItem1.Name = "delStripMenuItem1";
            this.delStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.delStripMenuItem1.Text = "Удалить";
            this.delStripMenuItem1.Click += new System.EventHandler(this.delStripMenuItem1_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MedicalCard.Properties.Resources.bgnn;
            this.ClientSize = new System.Drawing.Size(1076, 494);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администратор";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageUser.ResumeLayout(false);
            this.tabPageUser.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPagePacient.ResumeLayout(false);
            this.tabPagePacient.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUser;
        private System.Windows.Forms.TabPage tabPagePacient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ColumnHeader User_Name;
        private System.Windows.Forms.ColumnHeader User_Specialty;
        private System.Windows.Forms.ColumnHeader User_Login;
        private System.Windows.Forms.ColumnHeader User_Password;
        private System.Windows.Forms.ColumnHeader User_Del_Status;
        private System.Windows.Forms.ColumnHeader User_Status;
        private System.Windows.Forms.ColumnHeader User_ID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button delPacButton;
        private System.Windows.Forms.Button editPacButton;
        private System.Windows.Forms.Button addPacButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewPacients;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem delStripMenuItem1;
    }
}