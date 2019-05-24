namespace uongoClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.loadMore = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TimesHours = new System.Windows.Forms.NumericUpDown();
            this.TimesMinutes = new System.Windows.Forms.NumericUpDown();
            this.TimesStatus = new System.Windows.Forms.ComboBox();
            this.TimesWho = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.TimesTimePicker = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ObruchName = new System.Windows.Forms.TextBox();
            this.ObruchAddress = new System.Windows.Forms.TextBox();
            this.ObruchCity = new System.Windows.Forms.TextBox();
            this.ObruchPhone = new System.Windows.Forms.TextBox();
            this.ObruchAdd = new System.Windows.Forms.Button();
            this.ObruchDelete = new System.Windows.Forms.Button();
            this.ObruchSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.MeetingStatus = new System.Windows.Forms.ComboBox();
            this.MeetingSave = new System.Windows.Forms.Button();
            this.MeetingDelete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimesHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimesMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 35);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(1002, 315);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // loadMore
            // 
            this.loadMore.BackColor = System.Drawing.Color.White;
            this.loadMore.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.loadMore.FlatAppearance.BorderSize = 0;
            this.loadMore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadMore.Location = new System.Drawing.Point(2, 349);
            this.loadMore.Name = "loadMore";
            this.loadMore.Size = new System.Drawing.Size(1002, 50);
            this.loadMore.TabIndex = 2;
            this.loadMore.Text = "Загрузить ещё";
            this.loadMore.UseVisualStyleBackColor = false;
            this.loadMore.Click += new System.EventHandler(this.LoadMore_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(335, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Записи на обследвоание";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(335, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "Образовательные учреждения ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(669, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(335, 34);
            this.button3.TabIndex = 5;
            this.button3.Text = "Время обследования";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(74, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Дата и время";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Статус";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(666, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Для кого";
            // 
            // TimesHours
            // 
            this.TimesHours.Location = new System.Drawing.Point(261, 439);
            this.TimesHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.TimesHours.Name = "TimesHours";
            this.TimesHours.Size = new System.Drawing.Size(39, 20);
            this.TimesHours.TabIndex = 12;
            // 
            // TimesMinutes
            // 
            this.TimesMinutes.Location = new System.Drawing.Point(328, 439);
            this.TimesMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.TimesMinutes.Name = "TimesMinutes";
            this.TimesMinutes.Size = new System.Drawing.Size(39, 20);
            this.TimesMinutes.TabIndex = 13;
            // 
            // TimesStatus
            // 
            this.TimesStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimesStatus.Location = new System.Drawing.Point(418, 439);
            this.TimesStatus.Name = "TimesStatus";
            this.TimesStatus.Size = new System.Drawing.Size(192, 21);
            this.TimesStatus.TabIndex = 14;
            // 
            // TimesWho
            // 
            this.TimesWho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimesWho.FormattingEnabled = true;
            this.TimesWho.Location = new System.Drawing.Point(669, 439);
            this.TimesWho.Name = "TimesWho";
            this.TimesWho.Size = new System.Drawing.Size(194, 21);
            this.TimesWho.TabIndex = 15;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(370, 619);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 37);
            this.button4.TabIndex = 16;
            this.button4.Text = "Сохранить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(678, 619);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(185, 37);
            this.button5.TabIndex = 17;
            this.button5.Text = "Удалить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(77, 619);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(185, 37);
            this.button6.TabIndex = 18;
            this.button6.Text = "Добавить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // TimesTimePicker
            // 
            this.TimesTimePicker.Location = new System.Drawing.Point(77, 439);
            this.TimesTimePicker.Name = "TimesTimePicker";
            this.TimesTimePicker.TabIndex = 19;
            this.TimesTimePicker.TrailingForeColor = System.Drawing.Color.MediumOrchid;
            this.TimesTimePicker.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.TimesTimePicker_DateChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(74, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Наименование";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(502, 467);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "Адрес";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(502, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Город";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(74, 467);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Телефон";
            // 
            // ObruchName
            // 
            this.ObruchName.Location = new System.Drawing.Point(77, 439);
            this.ObruchName.Name = "ObruchName";
            this.ObruchName.Size = new System.Drawing.Size(358, 20);
            this.ObruchName.TabIndex = 24;
            this.ObruchName.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // ObruchAddress
            // 
            this.ObruchAddress.Location = new System.Drawing.Point(505, 485);
            this.ObruchAddress.Name = "ObruchAddress";
            this.ObruchAddress.Size = new System.Drawing.Size(358, 20);
            this.ObruchAddress.TabIndex = 25;
            // 
            // ObruchCity
            // 
            this.ObruchCity.Location = new System.Drawing.Point(505, 439);
            this.ObruchCity.Name = "ObruchCity";
            this.ObruchCity.Size = new System.Drawing.Size(358, 20);
            this.ObruchCity.TabIndex = 26;
            // 
            // ObruchPhone
            // 
            this.ObruchPhone.Location = new System.Drawing.Point(77, 485);
            this.ObruchPhone.Name = "ObruchPhone";
            this.ObruchPhone.Size = new System.Drawing.Size(358, 20);
            this.ObruchPhone.TabIndex = 27;
            // 
            // ObruchAdd
            // 
            this.ObruchAdd.Location = new System.Drawing.Point(77, 617);
            this.ObruchAdd.Name = "ObruchAdd";
            this.ObruchAdd.Size = new System.Drawing.Size(185, 39);
            this.ObruchAdd.TabIndex = 30;
            this.ObruchAdd.Text = "Добавить";
            this.ObruchAdd.UseVisualStyleBackColor = true;
            this.ObruchAdd.Click += new System.EventHandler(this.ObruchAdd_Click);
            // 
            // ObruchDelete
            // 
            this.ObruchDelete.Location = new System.Drawing.Point(678, 617);
            this.ObruchDelete.Name = "ObruchDelete";
            this.ObruchDelete.Size = new System.Drawing.Size(185, 39);
            this.ObruchDelete.TabIndex = 29;
            this.ObruchDelete.Text = "Удалить";
            this.ObruchDelete.UseVisualStyleBackColor = true;
            this.ObruchDelete.Click += new System.EventHandler(this.ObruchDelete_Click);
            // 
            // ObruchSave
            // 
            this.ObruchSave.Location = new System.Drawing.Point(370, 617);
            this.ObruchSave.Name = "ObruchSave";
            this.ObruchSave.Size = new System.Drawing.Size(185, 39);
            this.ObruchSave.TabIndex = 28;
            this.ObruchSave.Text = "Сохранить";
            this.ObruchSave.UseVisualStyleBackColor = true;
            this.ObruchSave.Click += new System.EventHandler(this.ObruchSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(74, 422);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Статус";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(678, 619);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 32;
            // 
            // MeetingStatus
            // 
            this.MeetingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeetingStatus.FormattingEnabled = true;
            this.MeetingStatus.Location = new System.Drawing.Point(77, 438);
            this.MeetingStatus.Name = "MeetingStatus";
            this.MeetingStatus.Size = new System.Drawing.Size(289, 21);
            this.MeetingStatus.TabIndex = 33;
            // 
            // MeetingSave
            // 
            this.MeetingSave.Location = new System.Drawing.Point(77, 617);
            this.MeetingSave.Name = "MeetingSave";
            this.MeetingSave.Size = new System.Drawing.Size(185, 39);
            this.MeetingSave.TabIndex = 34;
            this.MeetingSave.Text = "Сохранить";
            this.MeetingSave.UseVisualStyleBackColor = true;
            this.MeetingSave.Click += new System.EventHandler(this.MeetingSave_Click);
            // 
            // MeetingDelete
            // 
            this.MeetingDelete.Location = new System.Drawing.Point(359, 617);
            this.MeetingDelete.Name = "MeetingDelete";
            this.MeetingDelete.Size = new System.Drawing.Size(185, 39);
            this.MeetingDelete.TabIndex = 35;
            this.MeetingDelete.Text = "Отменить";
            this.MeetingDelete.UseVisualStyleBackColor = true;
            this.MeetingDelete.Click += new System.EventHandler(this.MeetingDelete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(258, 415);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Час";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(325, 417);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Минута";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1006, 675);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.MeetingDelete);
            this.Controls.Add(this.MeetingSave);
            this.Controls.Add(this.MeetingStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ObruchAdd);
            this.Controls.Add(this.ObruchDelete);
            this.Controls.Add(this.ObruchSave);
            this.Controls.Add(this.ObruchPhone);
            this.Controls.Add(this.ObruchCity);
            this.Controls.Add(this.ObruchAddress);
            this.Controls.Add(this.ObruchName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TimesTimePicker);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.TimesWho);
            this.Controls.Add(this.TimesStatus);
            this.Controls.Add(this.TimesMinutes);
            this.Controls.Add(this.TimesHours);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loadMore);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimesHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimesMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button loadMore;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown TimesHours;
        private System.Windows.Forms.NumericUpDown TimesMinutes;
        private System.Windows.Forms.ComboBox TimesStatus;
        private System.Windows.Forms.ComboBox TimesWho;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.MonthCalendar TimesTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ObruchName;
        private System.Windows.Forms.TextBox ObruchAddress;
        private System.Windows.Forms.TextBox ObruchCity;
        private System.Windows.Forms.TextBox ObruchPhone;
        private System.Windows.Forms.Button ObruchAdd;
        private System.Windows.Forms.Button ObruchDelete;
        private System.Windows.Forms.Button ObruchSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox MeetingStatus;
        private System.Windows.Forms.Button MeetingSave;
        private System.Windows.Forms.Button MeetingDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

