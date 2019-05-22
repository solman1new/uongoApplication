using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uongoClient
{
    public partial class Form1 : Form
    {
        
        
        int idCurrent = -1;
        string dbCurrent = null;
        public DBUtils db = null;
        int rowIndex = -1;
        public Form1()
        {
            InitializeComponent();
            ConnectToDb();
            PushContentInElements();
            hiddenControlTimes();
            hiddenControlObruch();
            hiddenControlMeeting();
            this.Button1_Click(this.button1, null);

        }

        private void PushContentInElements()
        {
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
            this.label1.Visible = true;
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.TimesHours.Visible = true;
            this.TimesMinutes.Visible = true;
            this.TimesStatus.Visible = true;
            this.TimesTimePicker.Visible = true;
            this.TimesWho.Visible = true;
            this.button4.Visible = true;
            this.button5.Visible = true;
            this.button6.Visible = true;
        }

        private void hiddenControlTimes()
        {
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.TimesHours.Visible = false;
            this.TimesMinutes.Visible = false;
            this.TimesStatus.Visible = false;
            this.TimesTimePicker.Visible = false;
            this.TimesWho.Visible = false;
            this.button4.Visible = false;
            this.button5.Visible = false;
            this.button6.Visible = false;
        }

        private void showControlObruch()
        {
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.label6.Visible = true;
            this.label7.Visible = true;
            this.ObruchName.Visible = true;
            this.ObruchAddress.Visible = true;
            this.ObruchCity.Visible = true;
            this.ObruchPhone.Visible = true;
            this.ObruchSave.Visible = true;
            this.ObruchDelete.Visible = true;
            this.ObruchAdd.Visible = true;
        }

        private void hiddenControlObruch()
        {
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.label7.Visible = false;
            this.ObruchName.Visible = false;
            this.ObruchAddress.Visible = false;
            this.ObruchCity.Visible = false;
            this.ObruchPhone.Visible = false;
            this.ObruchSave.Visible = false;
            this.ObruchDelete.Visible = false;
            this.ObruchAdd.Visible = false;
        }

        private void showControlMeeting()
        {
            this.MeetingDelete.Visible = true;
            this.MeetingSave.Visible = true;
            this.MeetingStatus.Visible = true;
            this.label8.Visible = true;
        }

        private void hiddenControlMeeting()
        {
            this.MeetingDelete.Visible = false;
            this.MeetingSave.Visible = false;
            this.MeetingStatus.Visible = false;
            this.label8.Visible = false;
        }

        private void LoadMore_Click(object sender, EventArgs e)
        {
            if(db.statusConnect())
            {
                if(dbCurrent != null)
                {
                    if(idCurrent != -1)
                    {
                       string sql = null;
                        if (dbCurrent.Equals("obruch") || dbCurrent.Equals("times"))
                            sql = "SELECT * FROM `" + dbCurrent + "` WHERE `" + dbCurrent + "`.`id` < " + idCurrent + " ORDER BY `" + dbCurrent + "`.`id` DESC LIMIT 10";
                        else if (dbCurrent.Equals("deal"))
                            sql = "SELECT `deal`.`id`, `times`.`dt`, `childfio`, `birthday`, `deal`.`address`, `obruch`, `parent`, `deal`.`phone`, `end` FROM `deal` " +
                                "INNER JOIN `times` ON `deal`.`dt`=`times`.`id` " +
                                " WHERE `deal`.`id` < " + idCurrent +" ORDER BY `deal`.`id` DESC LIMIT 10";
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

                            if(dbCurrent.Equals("deal"))
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
                    } else
                    {
                        MessageBox.Show("Возможно, таблица пуста");
                    }
                } else
                {
                    MessageBox.Show("Возможно отсутствует подключение к базе");
                }
            } else
            {
                MessageBox.Show("Отсутствует подключения к базе. За помощью обратитесь к системному адрминистратору");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            hiddenControlTimes();
            hiddenControlObruch();
            showControlMeeting();
            rowIndex = -1;
            this.showMeeting();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            hiddenControlTimes();
            hiddenControlMeeting();
            showControlObruch();
            rowIndex = -1;
            this.ShowOrbuch();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            hiddenControlMeeting();
            hiddenControlObruch();
            showControlTimes();
            rowIndex = -1;
            this.showTime();
        }

        

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = this.dataGridView1.CurrentCell.RowIndex;
            this.dataGridView1.Rows[rowIndex].Selected = true;
            switch (dbCurrent)
            {
                case "times":
                    int[] date = Utils.ConverStrDateToIntArrDate(this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
                    this.TimesTimePicker.SetDate(new DateTime(date[2], date[1], date[0]));
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
                else {
                    MessageBox.Show("А для кого?");
                    return;
                }
                if (db != null)
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
            } else MessageBox.Show("Нужно выбрать строку в таблице");
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
            } else MessageBox.Show("Нужно выбрать строку в таблице");
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
    }
}
