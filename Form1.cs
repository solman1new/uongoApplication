using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace uongoClient
{
    public partial class Form1 : Form
    {


        int idCurrent = -1;
        string dbCurrent = null;
        public DBUtils db = null;
        int rowIndex = -1;
        
        

        int normalWidth, selectedWidth, unselectWidth;
        int indexSelButton, oldIndexSelButton;

        public Form1()
        {
            InitializeComponent();
            ConnectToDb();
            PushContentInElements();
            hiddenControlTimes();
            hiddenControlObruch();
            hiddenControlMeeting();

            this.Button1_Click(this.button1, null);

            JustifControl();
            ResizeForm();
            normalWidth = ClientRectangle.Width / 3;
            selectedWidth = normalWidth + (normalWidth / 2) * 2;
            unselectWidth = normalWidth / 2;

            

        }


        private void ResizeForm()
        {
            
            normalWidth = this.flowLayoutPanel1.Width / 3;
            selectedWidth = normalWidth + (normalWidth / 2) * 2;
            unselectWidth = normalWidth / 2;
            ButtonOnResizeForm();

            this.flowLayoutPanel1.Left = ClientRectangle.Left;
            this.flowLayoutPanel1.Width = ClientRectangle.Width;
            this.dataGridView1.Width = ClientRectangle.Width;
            this.loadMore.Width = ClientRectangle.Width;

            this.MeetinggroupBox.Width = ClientRectangle.Width;
            this.TimegroupBox.Width = ClientRectangle.Width;
            this.ObruchgroupBox.Width = ClientRectangle.Width;

            this.MeetinggroupBox.Left = ClientRectangle.Right;
            this.TimegroupBox.Left = ClientRectangle.Right;
            this.ObruchgroupBox.Left = ClientRectangle.Right;

            TranslateGroupBoxs();

            Console.WriteLine(this.flowLayoutPanel1.Width);
        }

        private void JustifControl()
        {
            this.flowLayoutPanel1.Margin = new Padding(0);
            this.flowLayoutPanel1.Padding = new Padding(0);

            this.flowLayoutPanel1.Height = this.button1.Height + 1;
            this.flowLayoutPanel1.Top = ClientRectangle.Top;
            this.flowLayoutPanel1.Left = ClientRectangle.Left;
            this.flowLayoutPanel1.Width = ClientRectangle.Width;

        }

        private void PushContentInElements()
        {
            //groupBoxs
            this.ObruchgroupBox.Top = this.MeetinggroupBox.Top = this.TimegroupBox.Top = this.button1.Height + this.dataGridView1.Height + this.loadMore.Height;
            this.ObruchgroupBox.Height = this.MeetinggroupBox.Height = this.TimegroupBox.Height = ClientRectangle.Height - (this.button1.Height + this.dataGridView1.Height + this.loadMore.Height);
            this.ObruchgroupBox.Width = this.MeetinggroupBox.Width = this.TimegroupBox.Width = ClientRectangle.Width;
            this.ObruchgroupBox.Left = this.MeetinggroupBox.Left = this.TimegroupBox.Left = ClientRectangle.Left;

            // times

            this.TimesStatus.Items.Clear();
            this.TimesWho.Items.Add("Дошкольник");
            this.TimesWho.Items.Add("Школьник");


            this.TimesStatus.Items.Add("Свободно");
            this.TimesStatus.Items.Add("Занято");

            //end times

            //meeting

            this.MeetingStatus.Items.Add("Актуально");
            this.MeetingStatus.Items.Add("Завершено");
            //end meeting
        }

        private void ConnectToDb()
        {
            try
            {
                Dictionary<string, string> arr = new Dictionary<string, string>();

                foreach (string line in File.ReadLines(Directory.GetCurrentDirectory() + "\\config.txt"))
                {
                    string[] temp = line.Split(':');
                    arr.Add(temp[0], temp[1]);
                }

                db = new DBUtils(arr["url"], Convert.ToInt32(arr["port"]), arr["namedb"], arr["username"], arr["password"]);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("До свидания");
        }


        private void ShowOrbuch()
        {
            if (db.statusConnect())
            {
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.Columns.Clear();

                this.dataGridView1.ColumnCount = 5;
                string[] enumColumns = new string[] { "id", "Наименование", "Адрес", "Город", "Телефон" };



                for (int i = 0; i < 5; i++)
                    this.dataGridView1.Columns[i].HeaderText = enumColumns[i];
                this.dataGridView1.Columns[0].Visible = false;


                dbCurrent = "obruch";
                string sql = "SELECT * FROM `obruch` ORDER BY `id` DESC LIMIT 10";
                ArrayList arr = db.SqlQuery(sql, "obruch");



                foreach (string[] row in arr)
                {
                    idCurrent = Convert.ToInt32(row[0]);

                    this.dataGridView1.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Отсутствует подключения к базе. За помощью обратитесь к системному адрминистратору");
            }
        }

        private void showMeeting()
        {
            if (db.statusConnect())
            {
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.Columns.Clear();

                this.dataGridView1.ColumnCount = 9;
                string[] enumColumns = new string[] { "id", "Время приема", "ФИО ребенка", "Д/р ребенка", "Адрес", "Обр. учреждение", "ФИО представителя", "Телефон", "Завершено" };

                for (int i = 0; i < 9; i++)
                    this.dataGridView1.Columns[i].HeaderText = enumColumns[i];
                this.dataGridView1.Columns[0].Visible = false;

                dbCurrent = "deal";
                string sql = "SELECT `deal`.`id`, `times`.`dt`, `childfio`, `birthday`, `deal`.`address`, `obruch`, `parent`, `deal`.`phone`, `end` FROM `deal` " +
                    "INNER JOIN `times` ON `deal`.`dt`=`times`.`id` ORDER BY `deal`.`id` DESC LIMIT 10";

                ArrayList arr = db.SqlQuery(sql, "deal");
                ArrayList obruch = db.SqlQuery("SELECT * FROM `obruch`", "obruch");


                foreach (string[] row in arr)
                {
                    idCurrent = Convert.ToInt32(row[0]);

                    foreach (string[] rowObruch in obruch)
                        if (row[5].Equals(rowObruch[0]))
                            row[5] = rowObruch[1];
                        else if (row[5].Equals("0"))
                            row[5] = "Дошкольник";

                    if (row[8].Equals("1"))
                        row[8] = "Завершено";
                    else row[8] = "Актуально";

                    this.dataGridView1.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Отсутствует подключения к базе. За помощью обратитесь к ");
            }
        }

        // вермя для запси на обследование
        private void showTime()
        {
            if (db.statusConnect())
            {
                this.dataGridView1.Rows.Clear();
                this.dataGridView1.Columns.Clear();

                this.dataGridView1.ColumnCount = 4;
                string[] enumColumns = new string[] { "id", "Дата и Время", "Использовано", "Для кого" };


                for (int i = 0; i < 4; i++)
                    this.dataGridView1.Columns[i].HeaderText = enumColumns[i];
                this.dataGridView1.Columns[0].Visible = false;

                dbCurrent = "times";
                string sql = "SELECT * FROM `times` ORDER BY `id` DESC LIMIT 10";
                ArrayList arr = db.SqlQuery(sql, "times");



                foreach (string[] row in arr)
                {
                    idCurrent = Convert.ToInt32(row[0]);

                    if (row[2].Equals("1"))
                        row[2] = "Занято";
                    else row[2] = "Свободно";
                    if (row[3].Equals("1"))
                        row[3] = "Школьник";
                    else row[3] = "Дошкольник";

                    this.dataGridView1.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Отсутствует подключения к базе. За помощью обратитесь к системному адрминистратору");
            }
        }

        private void showControlTimes()
        {
            indexSelButton = 3;
            this.TimegroupBox.Visible = true;
            ResizeButtonOnSelect();
        }

        private void hiddenControlTimes()
        {
            
            //this.TimegroupBox.Visible = false;
        }

        private void showControlObruch()
        {
            indexSelButton = 2;
            ResizeButtonOnSelect();
            //this.ObruchgroupBox.Visible = true;
        }

        private void hiddenControlObruch()
        {
            //this.ObruchgroupBox.Visible = false;
        }

        private void showControlMeeting()
        {
            indexSelButton = 1;
            ResizeButtonOnSelect();
            this.MeetinggroupBox.Visible = true;
        }

        

        private void hiddenControlMeeting()
        {
            //this.MeetinggroupBox.Visible = false;
        }

        private void LoadMore_Click(object sender, EventArgs e)
        {
            if (db.statusConnect())
            {
                if (dbCurrent != null)
                {
                    if (idCurrent != -1)
                    {
                        string sql = null;
                        if (dbCurrent.Equals("obruch") || dbCurrent.Equals("times"))
                            sql = "SELECT * FROM `" + dbCurrent + "` WHERE `" + dbCurrent + "`.`id` < " + idCurrent + " ORDER BY `" + dbCurrent + "`.`id` DESC LIMIT 10";
                        else if (dbCurrent.Equals("deal"))
                            sql = "SELECT `deal`.`id`, `times`.`dt`, `childfio`, `birthday`, `deal`.`address`, `obruch`, `parent`, `deal`.`phone`, `end` FROM `deal` " +
                                "INNER JOIN `times` ON `deal`.`dt`=`times`.`id` " +
                                " WHERE `deal`.`id` < " + idCurrent + " ORDER BY `deal`.`id` DESC LIMIT 10";
                        ArrayList arr = db.SqlQuery(sql, dbCurrent);

                        bool firstElement = false;
                        foreach (string[] row in arr)
                        {
                            if (!firstElement)
                            {
                                idCurrent = Convert.ToInt32(row[0]);
                                firstElement = true;
                            }

                            if (dbCurrent.Equals("times"))
                            {
                                if (row[2].Equals("1"))
                                    row[2] = "Занято";
                                else row[2] = "Свободно";
                                if (row[3].Equals("1"))
                                    row[3] = "Школьник";
                                else row[3] = "Дошкольник";
                            }

                            if (dbCurrent.Equals("deal"))
                            {
                                ArrayList obruch = db.SqlQuery("SELECT * FROM `obruch`", "obruch");

                                foreach (string[] rowObruch in obruch)
                                    if (row[5].Equals(rowObruch[0]))
                                        row[5] = rowObruch[1];
                                    else if (row[5].Equals("0"))
                                        row[5] = "Дошкольник";
                            }

                            this.dataGridView1.Rows.Add(row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Возможно, таблица пуста");
                    }
                }
                else
                {
                    MessageBox.Show("Возможно отсутствует подключение к базе");
                }
            }
            else
            {
                MessageBox.Show("Отсутствует подключения к базе. За помощью обратитесь к системному адрминистратору");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            indexSelButton = 1;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            hiddenControlTimes();
            hiddenControlObruch();
            showControlMeeting();
            rowIndex = -1;
            this.showMeeting();
            TranslateGroupBoxs();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            indexSelButton = 2;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            hiddenControlTimes();
            hiddenControlMeeting();
            showControlObruch();
            rowIndex = -1;
            this.ShowOrbuch();
            TranslateGroupBoxs();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            indexSelButton = 3;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            hiddenControlMeeting();
            hiddenControlObruch();
            showControlTimes();
            rowIndex = -1;
            this.showTime();
            TranslateGroupBoxs();
        }



        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = this.dataGridView1.CurrentCell.RowIndex;
            this.dataGridView1.Rows[rowIndex].Selected = true;
            switch (dbCurrent)
            {
                case "times":
                    //this.TimesTimePicker.ShowToday = false;
                    int[] date = Utils.ConverStrDateToIntArrDate(this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
                    this.TimesTimePicker.RemoveBoldedDate(this.TimesTimePicker.SelectionStart);
                    this.TimesTimePicker.SetDate(new DateTime(date[2], date[1], date[0]));
                    this.TimesTimePicker.AddBoldedDate(this.TimesTimePicker.SelectionStart);
                    this.TimesTimePicker.UpdateBoldedDates();
                    //this.TimesTimePicker.AddBoldedDate(this.TimesTimePicker.date)
                    //MessageBox.Show(this.TimesTimePicker.SelectionStart.ToString());
                    int[] arrTime = Utils.GetHourAndMinutes((this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString().Split(new char[] { ' ' })[3]).Split(new char[] { 'г', '.', '-' })[3]);
                    this.TimesHours.Value = arrTime[0];
                    this.TimesMinutes.Value = arrTime[1];

                    this.TimesStatus.SelectedIndex = this.TimesStatus.Items.IndexOf(this.dataGridView1.Rows[rowIndex].Cells[2].Value);
                    this.TimesWho.SelectedIndex = this.TimesWho.Items.IndexOf(this.dataGridView1.Rows[rowIndex].Cells[3].Value);
                    break;

                case "obruch":
                    this.ObruchName.Text = this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                    this.ObruchAddress.Text = this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                    this.ObruchCity.Text = this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                    this.ObruchPhone.Text = this.dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
                    break;
                case "deal":
                    this.MeetingStatus.SelectedIndex = this.MeetingStatus.Items.IndexOf(this.dataGridView1.Rows[rowIndex].Cells[8].Value);
                    break;
                default:
                    break;
            }
        }



        private void Button6_Click(object sender, EventArgs e)
        {
            string result = this.TimesTimePicker.SelectionRange.Start.ToLongDateString() + "-" + this.TimesHours.Value.ToString() + ":" + TimesMinutes.Value.ToString();
            string type = null;

            if (!string.IsNullOrEmpty(this.TimesWho.Text))
                type = Convert.ToString(this.TimesWho.SelectedIndex);
            else
            {
                MessageBox.Show("А для кого?");
                return;
            }
            if (db != null)
            {
                if (db.QueryOnExist("SELECT * FROM `times` WHERE `dt`='" + result + "'"))
                {
                    MessageBox.Show("Такое время уже есть в таблице");
                    return;
                }
                else
                {
                    string sql = "INSERT INTO `times`(dt, used, type) " +
                        "VALUES('" + result + "', '0', '" + type + "')";
                    int count = db.ExNonQuery(sql, dbCurrent);
                    if (count > 0)
                    {
                        MessageBox.Show("Успешно");
                        this.showTime();
                    }
                    else MessageBox.Show("Не удалось добавить");
                }
            }
            else
            {
                MessageBox.Show("Нужно подключиться к базе");
            }
        }

        private void TimesTimePicker_DateChanged(object sender, DateRangeEventArgs e)
        {
            //MessageBox.Show(this.TimesTimePicker.SelectionRange.Start.ToLongDateString());
            //Console.WriteLine(this.TimesTimePicker.SelectionRange.Start.Month.ToString());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {

                string result = this.TimesTimePicker.SelectionRange.Start.ToLongDateString() + "-" + this.TimesHours.Value.ToString() + ":" + TimesMinutes.Value.ToString();
                string type = null;
                string used = null;


                if (!string.IsNullOrEmpty(this.TimesWho.Text))
                    type = Convert.ToString(this.TimesWho.SelectedIndex);
                else
                {
                    MessageBox.Show("А для кого?");
                    return;
                }

                if (!string.IsNullOrEmpty(this.TimesStatus.Text))
                    used = Convert.ToString(this.TimesStatus.SelectedIndex);
                else
                {
                    MessageBox.Show("Нужно выбрать статус");
                    return;
                }

                if (db != null)
                {

                    string sql = "UPDATE `times` SET `dt`='" + result + "', `used`=" + used + ", `type`=" + type + " WHERE `id`=" + this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                    int count = db.ExNonQuery(sql, dbCurrent);
                    if (count > 0)
                    {
                        MessageBox.Show("Успешно");
                        this.showTime();
                    }
                    else MessageBox.Show("Не удалось добавить");

                }
                else
                {
                    MessageBox.Show("Нужно подключиться к базе");
                }
            }
            else MessageBox.Show("Вы не выбрали строку для редактирования");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ObruchAdd_Click(object sender, EventArgs e)
        {
            string name = this.ObruchName.Text.Trim();
            string address = this.ObruchAddress.Text.Trim();
            string city = this.ObruchCity.Text.Trim();
            string phone = this.ObruchPhone.Text.Trim();


            if (name.Equals("") || address.Equals("") || city.Equals("") || phone.Equals(""))
            {
                MessageBox.Show("Не все поля заполнены");

            }
            else
            {
                if (db != null)
                {
                    if (db.QueryOnExist("SELECT * FROM `obruch` WHERE `name`='" + name + "' AND `city`='" + city + "'"))
                    {
                        MessageBox.Show("Учебное учреждение с таким наименованием в этом населенном пункте уже есть в таблице");
                        return;
                    }
                    else
                    {
                        string sql = "INSERT INTO `obruch`(name, address, city, phone) " +
                        "VALUES('" + name + "', '" + address + "', '" + city + "', '" + phone + "')";
                        int count = db.ExNonQuery(sql, dbCurrent);
                        if (count > 0)
                        {
                            MessageBox.Show("Успешно");
                            this.ShowOrbuch();
                        }
                        else MessageBox.Show("Не удалось добавить");
                    }
                }
                else
                {
                    MessageBox.Show("Нужно подключиться к базе");
                }
            }
        }

        private void ObruchDelete_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {
                string id = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                if (db != null)
                {
                    string sql = "DELETE FROM `obruch` WHERE `" + dbCurrent + "`.`id`= " + id;
                    int count = db.ExNonQuery(sql, dbCurrent);
                    if (count > 0)
                    {
                        MessageBox.Show("Успешно");
                        this.ShowOrbuch();
                    }
                    else MessageBox.Show("Не удалось добавить");

                }
                else
                {
                    MessageBox.Show("Нужно подключиться к базе");
                }
            }
            else MessageBox.Show("Нужно выбрать строку в таблице");
        }

        private void ObruchSave_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {
                string id = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                string name = this.ObruchName.Text.Trim();
                string address = this.ObruchAddress.Text.Trim();
                string city = this.ObruchCity.Text.Trim();
                string phone = this.ObruchPhone.Text.Trim();

                if (name.Equals("") || address.Equals("") || city.Equals("") || phone.Equals(""))
                {
                    MessageBox.Show("Не все поля заполнены");

                }
                else
                {
                    if (db != null)
                    {
                        string sql = "UPDATE `obruch` SET `name`='" + name + "', `address`='" + address + "', `city`='" + city + "', `phone`='" + phone + "' WHERE `id`=" + id;
                        int count = db.ExNonQuery(sql, dbCurrent);
                        if (count > 0)
                        {
                            MessageBox.Show("Успешно");
                            this.ShowOrbuch();
                        }
                        else MessageBox.Show("Не удалось добавить");

                    }
                    else
                    {
                        MessageBox.Show("Нужно подключиться к базе");
                    }
                }
            }
            else MessageBox.Show("Нужно выбрать строку в таблице");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {
                string id = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                if (db != null)
                {
                    string sql = "DELETE FROM `times` WHERE `" + dbCurrent + "`.`id`= " + id;
                    int count = db.ExNonQuery(sql, dbCurrent);
                    if (count > 0)
                    {
                        MessageBox.Show("Успешно");
                        this.showTime();
                    }
                    else MessageBox.Show("Не удалось добавить");

                }
                else
                {
                    MessageBox.Show("Нужно подключиться к базе");
                }
            }
            else MessageBox.Show("Нужно выбрать строку в таблице");
        }

        

        private void MeetingSave_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {

                string id = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                string status = null;
                if (!string.IsNullOrEmpty(this.MeetingStatus.Text))
                    status = Convert.ToString(this.MeetingStatus.SelectedIndex);
                if (db != null)
                {
                    //string sql = "DELETE FROM `deal` WHERE `" + dbCurrent + "`.`id`= " + id;
                    string sql = "UPDATE `deal` SET `end`=" + this.MeetingStatus.SelectedIndex.ToString() + " WHERE `id`=" + id;
                    int count = db.ExNonQuery(sql, dbCurrent);
                    if (count > 0)
                    {
                        MessageBox.Show("Успешно");
                        this.showMeeting();
                    }
                    else MessageBox.Show("Не удалось добавить");

                }
                else
                {
                    MessageBox.Show("Нужно подключиться к базе");
                }
            }
            else MessageBox.Show("Нужно выбрать строку в таблице");
        }

        private void MeetingDelete_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {
                string id = this.dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                if (db != null)
                {
                    string sql = "DELETE FROM `deal` WHERE `" + dbCurrent + "`.`id`= " + id;
                    int count = db.ExNonQuery(sql, dbCurrent);
                    if (count > 0)
                    {
                        MessageBox.Show("Успешно");
                        this.showMeeting();
                    }
                    else MessageBox.Show("Не удалось добавить");

                }
                else
                {
                    MessageBox.Show("Нужно подключиться к базе");
                }
            }
            else MessageBox.Show("Нужно выбрать строку в таблице");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
            ResizeForm();
            ButtonSizeOnResizeWindow();
            ButtonOnResizeForm();

            
        }

        

        private void ButtonSizeOnResizeWindow()
        {
            normalWidth = ClientRectangle.Width / 3;
            indexSelButton = normalWidth + (normalWidth / 2) * 2;
            unselectWidth = normalWidth / 2;
        }

        private void ResizeButtonOnSelect()
        {
            switch (indexSelButton)
            {
                case 1:
                    this.timer1.Start();
                    this.timer4.Start();
                    this.timer6.Start();
                    //this.button1.Width = selectedWidth;
                    //this.button2.Width = unselectWidth;
                    //this.button3.Width = unselectWidth;
                    break;
                case 2:
                    this.timer3.Start();
                    this.timer2.Start();
                    this.timer6.Start();
                    //this.button2.Width = selectedWidth;
                    //this.button1.Width = unselectWidth;
                    //this.button3.Width = unselectWidth;
                    break;
                case 3:
                    this.timer5.Start();
                    this.timer2.Start();
                    this.timer4.Start();
                    //this.button3.Width = selectedWidth;
                    //this.button1.Width = unselectWidth;
                    //this.button2.Width = unselectWidth;
                    break;
            }
        }
        private void ButtonOnResizeForm()
        {
            switch (indexSelButton)
            {
                case 1:
                    this.button1.Width = selectedWidth;
                    this.button2.Width = unselectWidth;
                    this.button3.Width = unselectWidth;
                    break;
                case 2:
                    this.button2.Width = selectedWidth;
                    this.button1.Width = unselectWidth;
                    this.button3.Width = unselectWidth;
                    break;
                case 3:
                    this.button3.Width = selectedWidth;
                    this.button1.Width = unselectWidth;
                    this.button2.Width = unselectWidth;
                    break;
            }
        }

        private void TranslateGroupBoxs()
        {
            switch (indexSelButton)
            {
                case 1:
                    this.MeetinggroupBox.Left = ClientRectangle.Left;
                    this.TimegroupBox.Left = ClientRectangle.Right;
                    this.ObruchgroupBox.Left = ClientRectangle.Right;
                    break;
                case 2:
                    this.ObruchgroupBox.Left = ClientRectangle.Left;
                    this.TimegroupBox.Left = ClientRectangle.Right;
                    this.MeetinggroupBox.Left = ClientRectangle.Right;
                    break;
                case 3:
                    this.TimegroupBox.Left = ClientRectangle.Left;
                    this.MeetinggroupBox.Left = ClientRectangle.Right;
                    this.ObruchgroupBox.Left = ClientRectangle.Right;
                    break;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(this.button1.Width < selectedWidth)
                this.button1.Width += 30;
            else this.timer1.Stop();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if(this.button1.Width > unselectWidth)
                this.button1.Width -= 30;
            else this.timer2.Stop();
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            if(this.button2.Width < selectedWidth)
                this.button2.Width += 30;
            else this.timer3.Stop();
        }

        private void Timer4_Tick(object sender, EventArgs e)
        {
            if (this.button2.Width > unselectWidth)
                this.button2.Width -= 30;
            else this.timer4.Stop();
        }

        private void Timer5_Tick(object sender, EventArgs e)
        {
            if (this.button3.Width < selectedWidth)
                this.button3.Width += 30;
            else this.timer5.Stop();
        }

        private void Timer6_Tick(object sender, EventArgs e)
        {
            if (this.button3.Width > unselectWidth)
                this.button3.Width -= 30;
            else this.timer6.Stop();
        }
    }
}
