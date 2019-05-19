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
        }

        private void PushContentInElements()
        {
            // times

            this.TimesStatus.Items.Clear();
            this.TimesWho.Items.Add("Школьник");
            this.TimesWho.Items.Add("Дошкольник");

            this.TimesStatus.Items.Add("Свободно");
            this.TimesStatus.Items.Add("Занято");

            //end times
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
                        row[8] = "Было";
                    else row[8] = "Актуально";

                    this.dataGridView1.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Отсутствует подключения к базе. За помощью обратитесь к ");
            }
        }

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
                        row[2] = "Использовано";
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
                                    row[2] = "Использовано";
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
            this.showMeeting();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.ShowOrbuch();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
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

                    this.TimesStatus.SelectedText = this.dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
                    this.TimesWho.SelectedText = this.dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
                    //int index = 0;
                    //string[] s = this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString().Split(new char[] { ' ' });
                    //foreach (string item in s[3].Split('г', '.', '-', ':'))
                    //{

                    //    Console.WriteLine("[" + (index++) + "](" + item + ")");
                    //}
                    //string[] arrTime = this.dataGridView1.Rows[rowIndex].Cells[1].Value.ToString().Split(new char[] {'-', 'г'});
                    //foreach(string ar in arrTime)
                    //{

                    //}
                    //string[] arrHour = arrTime[3].Split(new char[] {':'});

                    //this.TimesHours.Value = Convert.ToInt32(arrHour[0]);
                    //this.TimesMinutes.Value = Convert.ToInt32(arrHour[1]);




                    break;
                default:
                    break;
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.dateTimePicker1.Value.ToLongDateString());
        }

        //private int[] ConvertArrayStringDateToArrayInt(string date)
        //{
            
        //    string[] temp = date.Split(new char[] { ' ' });
        //    int[] result = new int[temp.Length];
        //    switch(temp[1])
        //    {
                
        //        default:
        //            // ...
        //            break;
        //    }
        //    return result;
        //}

        private void Button6_Click(object sender, EventArgs e)
        {
            try
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
            catch (FormatException exc)
            {
                MessageBox.Show("Ошибка формата");
            }
        }

        private void TimesTimePicker_DateChanged(object sender, DateRangeEventArgs e)
        {
            //MessageBox.Show(this.TimesTimePicker.SelectionRange.Start.ToLongDateString());
            //Console.WriteLine(this.TimesTimePicker.SelectionRange.Start.Month.ToString());
        }
    }
}
