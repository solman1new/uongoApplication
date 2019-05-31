using System;
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
    public partial class MarkAsFinished : Form
    {
        DBUtils db = null;

        public MarkAsFinished(DBUtils db)
        {
            this.db = db;
            InitializeComponent();
        }

        public MarkAsFinished()
        {
            InitializeComponent();
            
        }

        public MarkAsFinished(string[] args)
        {
            InitializeComponent();
            SetTestLabel(args);
            SetSizeWindos();
            TranslateControl();
        }

        private void MarkAsFinished_Load(object sender, EventArgs e)
        {

        }

        private void SetSizeWindos()
        {
            this.Size = new Size(this.label1.Width + 10, 200);
        }

        private void TranslateControl()
        {
            this.label1.Left = ClientRectangle.Width / 2 - this.label1.Width / 2;
            this.label1.Top = ClientRectangle.Height / 2 - 10;

            this.label2.Left = ClientRectangle.Width / 2 - this.label2.Width / 2;
            this.label2.Top = ClientRectangle.Height / 2 + 10;
        }

        public void SetTestLabel(string[] args)
        {
            this.label1.Text = args[0];
            this.label2.Text = args[1];
            SetSizeWindos();
            TranslateControl();
        }

    }
}
