using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class textboxbutton : Form
    {
        private string _Temp = "";
        public string Temp
        {
            set { _Temp = value; }
            get { return _Temp; }
        }
        private string _ID = "";
        public string ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        private string _DES = "";
        public string DES
        {
            set { _DES = value; }
            get { return _DES; }
        }
        private string _T = "";
        public string T
        {
            set { _T = value; }
            get { return _T; }
        }
        private string _T1 = "";
        public string T1
        {
            set { _T1 = value; }
            get { return _T1; }
        }
        public textboxbutton()
        {
            InitializeComponent();
        }

        private void textboxbutton_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            string sql = "";
            sql = "select " + ID +", " + DES + " from " + Temp;
            view(sql);
            
        }

        private void view(string sql)
        {
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteDataTable(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dt.Rows[i][0];
                    dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][1];
                }
            }
            else if(dt.Rows.Count == 0)
            {
                dataGridView1.Rows.Clear();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            T = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            T1 = this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            sql = "select " + ID + ", " + DES + " from " + Temp;
            if (textBox1.Text != "")
            {
                sql += " where Department_Id like '%" + textBox1.Text + "%' or Desc_01 like '%" + textBox1.Text + "%'";
            }
            view(sql);
        }
    }
}
