using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace stdent
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void 推出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //检测用户是否输入用户名。
            if (this.txtUsername.Text == string.Empty)
            {
                MessageBox.Show("请输入用户名！");
                this.txtUsername.Focus();
                return;
            }
            //检测用户是否输入密码。
            else if (this.txtPassword.Text == string.Empty)
            {
                MessageBox.Show("请输入密码！");
                this.txtPassword.Focus();
                return;
            }
            else
            {
                //设置用户字符串
                string connectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";

                //建立连接。
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();

                //读取所填用户名的密码。
                SqlCommand myCommand = myConnection.CreateCommand();
                string sql = "SELECT username, password FROM T_User WHERE (username = N'" + txtUsername.Text.Trim() + "')";
                
                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();

                //判断是否存在该用户。
                if (!myDataReader.HasRows)
                {
                    MessageBox.Show("用户名不存在！");
                    return;
                }
                
                //读取数据库中的内容，并于当前输入比较。
                while (myDataReader.Read())
                {
                    //判断用户输入与数据库内容是否匹配。
                    if (myDataReader["password"].ToString().Trim() != txtPassword.Text.Trim())
                    {
                        MessageBox.Show("密码不正确！");
                        txtUsername.Focus();
                        return;
                    }
                    else
                    {
                        this.Hide();
                        ManagerForm managerform=new ManagerForm();
                        managerform.ShowDialog();
                    }
                }

                //关闭数据库连接。
                myDataReader.Close();
                myConnection.Close();
                this.Close();
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtUsername.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}