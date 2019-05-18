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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1172, 315);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // loadMore
            // 
            this.loadMore.BackColor = System.Drawing.Color.White;
            this.loadMore.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.loadMore.FlatAppearance.BorderSize = 0;
            this.loadMore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadMore.Location = new System.Drawing.Point(12, 362);
            this.loadMore.Name = "loadMore";
            this.loadMore.Size = new System.Drawing.Size(135, 49);
            this.loadMore.TabIndex = 2;
            this.loadMore.Text = "Загрузить ещё";
            this.loadMore.UseVisualStyleBackColor = false;
            this.loadMore.Click += new System.EventHandler(this.LoadMore_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(324, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Записи на обследвоание";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(438, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(324, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Образовательные учреждения ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(765, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(324, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Время обследования";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Дата и время";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 568);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Статус";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 604);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Для кого";
            // 
            // TimesHours
            // 
            this.TimesHours.Location = new System.Drawing.Point(442, 397);
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
            this.TimesMinutes.Location = new System.Drawing.Point(487, 397);
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
            this.TimesStatus.FormattingEnabled = true;
            this.TimesStatus.Location = new System.Drawing.Point(266, 565);
            this.TimesStatus.Name = "TimesStatus";
            this.TimesStatus.Size = new System.Drawing.Size(290, 21);
            this.TimesStatus.TabIndex = 14;
            // 
            // TimesWho
            // 
            this.TimesWho.FormattingEnabled = true;
            this.TimesWho.Location = new System.Drawing.Point(266, 601);
            this.TimesWho.Name = "TimesWho";
            this.TimesWho.Size = new System.Drawing.Size(290, 21);
            this.TimesWho.TabIndex = 15;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(266, 628);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Сохранить";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(371, 628);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 17;
            this.button5.Text = "Удалить";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(481, 628);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 18;
            this.button6.Text = "Добавить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // TimesTimePicker
            // 
            this.TimesTimePicker.Location = new System.Drawing.Point(266, 397);
            this.TimesTimePicker.Name = "TimesTimePicker";
            this.TimesTimePicker.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1196, 661);
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
            this.Name = "Form1";
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
    }
}

