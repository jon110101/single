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
    public partial class Form1add : Form
    {
        private string _Edit = "";
        public string Edit
        {
            set { _Edit = value; }
            get { return _Edit; }
        }

        private string _Department_Id = "";
        public string Department_Id
        {
            set { _Department_Id = value; }
            get { return _Department_Id; }
        }

        private string _Company_Id = "";
        public string Company_Id
        {
            set { _Company_Id = value; }
            get { return _Company_Id; }
        }
        private string Pa_Department_Id = "";
        public string PaDepartment_Id
        {
            set { Pa_Department_Id = value; }
            get { return Pa_Department_Id; }
        }
        private string _Remark = "";
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }
        private string _Desc_01 = "";
        public string Desc_01
        {
            set { _Desc_01 = value; }
            get { return _Desc_01; }
        }
        private string _Usr_Id = "";
        public string Usr_Id
        {
            set { _Usr_Id = value; }
            get { return _Usr_Id; }
        }
        private string _Create_Date = "";
        public string Create_Date
        {
            set { _Create_Date = value; }
            get { return _Create_Date; }
        }
        public Form1add()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
         
            if (String.IsNullOrEmpty(this.Department_Id_.Text) || String.IsNullOrEmpty(this.Desc_01_.Text) || String.IsNullOrEmpty(this.Remark_.Text))
            {
                MessageBox.Show("请输入完整信息");
                return;
            }
            
            if (Edit == "ADD")
            {
                string sql1 = "select count(1) from Department where Company_Id = 'CYGIA' and Department_Id = '" + this.Department_Id_.Text + "'";
                DataTable dt1 = SqlHelper.ExecuteDataTable(sql1);
                if (dt1 != null && dt1.Rows[0][0].ToString() != "0")
                {
                    MessageBox.Show("此部门编码已存在！");
                    return;
                }
                add();
            }
            else if (Edit == "ED")
            {
                ed();
            }
            Department_Id = this.Department_Id_.Text;
            Company_Id = "CYGIA";
        }

        private void Form1add_Load(object sender, EventArgs e)
        {
            load();
            this.UserControl1.Temp = "Department";
            this.UserControl1.ID = "Department_Id";
            this.UserControl1.DES = "Desc_01";
        }
        private void load()
        {
            if (Edit == "ADD")
            {
                this.Usr_Id_.Text = "Administrator";
                this.Create_Time_.Text = DateTime.Now.ToString();
                this.Text = "新增";
            }
            else if (Edit == "ED")
            {
                this.Department_Id_.Text = Department_Id;
                this.Desc_01_.Text = Desc_01;
                this.Remark_.Text = Remark;
                this.Create_Time_.Text = Create_Date;
                this.Usr_Id_.Text = Usr_Id;
                this.Department_Id_.ReadOnly = true;
            }
        }
        private void add()
        {
            
            string sql = "insert into Department (Company_Id, Department_Id, Desc_01, Parent_Department_Id, Parent_Company_Id, Remark, Usr__Id, Create__Date, Last_Modify_Date) values ('CYGIA', '" + this.Department_Id_.Text + "','" + this.Desc_01_.Text + "','" + this.UserControl1.PA + "','CYGIA','" + this.Remark_.Text + "','" + this.Usr_Id_.Text + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "')";
            int rst = SqlHelper.ExecuteQuery(sql);
            if (rst == 1)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private void ed()
        {
            string sql = "update Department set Desc_01 = '" + this.Desc_01_.Text + "', Parent_Department_Id = '" + this.UserControl1.PA + "', Remark = '" + this.Remark_.Text + "', Last_Modify_Date = '"  + DateTime.Now.ToString() + "' where Company_Id = '" + Company_Id + "' and Department_Id = '" + Department_Id + "'";
            int rst = SqlHelper.ExecuteQuery(sql);
            if (rst == 1)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
