using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class UserControl1 : UserControl
    {
        private string _Temp= "";
        public string Temp
        {
            set { _Temp = value; }
            get { return _Temp; }
        }
        public string text
        {
            set { this.textBox1.Text = value; }
            get { return this.textBox1.Text; }
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
        private string _PA = "";
        public string PA
        {
            set { _PA = value; }
            get { return _PA; }
        }
        private string _PA_ = "";
        public string PA_
        {
            set { _PA_ = value; }
            get { return _PA_; }
        }
        private string _S = "";
        public string S
        {
            set { _S = value; }
            get { return _S; }
        }
        Boolean change = true;
        public UserControl1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (textboxbutton tb = new textboxbutton())
            {
                if (tb.ShowDialog() == DialogResult.OK)
                { 
                    
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (textboxbutton tb = new textboxbutton())
            {
                tb.Temp = Temp;
                tb.ID = ID;
                tb.DES = DES;
                if (tb.ShowDialog() == DialogResult.OK)
                {
                    this.textBox1.Text = tb.T1;
                    PA = tb.T;
                    PA_ = tb.T1;
                    S = PA;
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (S == PA)
            {
                textBox1.Text = PA;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == S)
            {
                textBox1.Text = PA_;
            }
            else 
            {
                S = textBox1.Text;
                string sql = "select " + DES + " from " + Temp + " where " + ID + " = '" + textBox1.Text + "'";
                DataTable dt = SqlHelper.ExecuteDataTable(sql);
                if (dt == null || dt.Rows.Count < 1 || dt.Rows[0][0].ToString() == "")
                {
                    
                    PA_ = S;
                }
                else
                {
                    PA = textBox1.Text;
                    PA_ = dt.Rows[0][0].ToString();
                    S = PA;
                    textBox1.Text = PA_; ;
                }
            }
                
        }


    }
}
