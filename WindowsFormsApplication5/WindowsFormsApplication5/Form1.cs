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
    public partial class Form1 : Form
    {
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
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load();
            this.userControl12.Temp = "Department";
            this.userControl12.ID = "Department_Id";
            this.userControl12.DES = "Desc_01";
            this.userControl13.Temp = "Department";
            this.userControl13.ID = "Department_Id";
            this.userControl13.DES = "Desc_01";
            this.userControl14.Temp = "Department";
            this.userControl14.ID = "Department_Id";
            this.userControl14.DES = "Desc_01";
        }

        private void load()
        {
            this.dataGridView1.Rows.Clear();
            string sql = "select Company_Id, Department_Id, Desc_01,Parent_Department_Id, Remark, Usr__Id, Create__Date from Department";
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (dt.Rows[i][1].ToString() == "") continue;
                    this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    this.dataGridView1.Rows[i].Cells[1].Value= dt.Rows[i][0];
                    this.dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][1];
                    this.dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][2];
                    this.dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][3];
                    this.dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][4];
                    this.dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][5];
                    this.dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][6];
                    if (dt.Rows[i][0].ToString() == Company_Id && dt.Rows[i][1].ToString() == Department_Id)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                    }
                }

            }

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void userControl12_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Form1add fa = new Form1add())
            {
                fa.Edit = "ADD";
                if (fa.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("添加成功");
                    Department_Id = fa.Department_Id;
                    Company_Id = fa.Company_Id;
                    load();
                }

            }
            
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            using (Form1add fa = new Form1add())
            {
                int rowindex = this.dataGridView1.CurrentCell.RowIndex;
                fa.Edit = "ED";
                fa.Department_Id = this.dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
                fa.Company_Id = this.dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
                fa.PaDepartment_Id= this.dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
                fa.Desc_01 = this.dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
                fa.Remark = this.dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
                fa.Usr_Id = this.dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
                fa.Create_Date = this.dataGridView1.Rows[rowindex].Cells[7].Value.ToString();
                
                if (fa.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("修改成功");
                    Department_Id = fa.Department_Id;
                    Company_Id = fa.Company_Id;
                    load();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("真的要删除部门（" + this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString() + "）吗", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                
                string sql = "delete from Department where Company_Id = '" + this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString() + "' and Department_Id = '" + this.dataGridView1.Rows[this.dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString() + "'";
                int rst = SqlHelper.ExecuteQuery(sql);
                if (rst == 1)
                {
                    MessageBox.Show("删除成功");
                    load();
                } 

                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select Company_Id, Department_Id, Desc_01,Parent_Department_Id, Remark, Usr__Id, Create__Date from Department where 1=1 and Company_Id = 'CYGIA'");
            if (!string.IsNullOrEmpty(this.userControl12.text) && !string.IsNullOrEmpty(this.userControl13.text))
            {
                //if (this.userControl12.text != this.userControl12.PA_) this.userControl12.PA = this.userControl12.text;
                //if (this.userControl13.text != this.userControl13.PA_) this.userControl13.PA = this.userControl13.text;
                sb.Append(string.Format("and Department_Id between '{0}'  and '{1}'", this.userControl12.PA, this.userControl13.PA));
            }
            if (!string.IsNullOrEmpty(userControl14.text))
            {
                sb.Append(string.Format("and Desc_01 like '%{0}%'",userControl14.text));
            }
            string sql = sb.ToString();
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            this.dataGridView1.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (dt.Rows[i][1].ToString() == "") continue;
                    this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    this.dataGridView1.Rows[i].Cells[1].Value = dt.Rows[i][0];
                    this.dataGridView1.Rows[i].Cells[2].Value = dt.Rows[i][1];
                    this.dataGridView1.Rows[i].Cells[3].Value = dt.Rows[i][2];
                    this.dataGridView1.Rows[i].Cells[4].Value = dt.Rows[i][3];
                    this.dataGridView1.Rows[i].Cells[5].Value = dt.Rows[i][4];
                    this.dataGridView1.Rows[i].Cells[6].Value = dt.Rows[i][5];
                    this.dataGridView1.Rows[i].Cells[7].Value = dt.Rows[i][6];

                }
            }
        }
    }
}
