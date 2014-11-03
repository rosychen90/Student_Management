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
    public partial class FormCheckAdmin : Form
    {
        public FormCheckAdmin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //检测用户是否输入用户名。
            if (this.textBox1.Text == string.Empty)
            {
                MessageBox.Show("请输入用户名！");
                this.textBox1.Focus();
                return;
            }
            //检测用户是否输入密码。
            else if (this.textBox2.Text == string.Empty)
            {
                MessageBox.Show("请输入密码！");
                this.textBox2.Focus();
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
                string sql = "SELECT username FROM T_User WHERE (username = '"+textBox1.Text+"')";
                string sql2 = "insert into T_User(username, password) values(" +
                     "'" +this.textBox1.Text + "'," +
                     "'" +this.textBox2.Text + "')";
                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();

                //判断是否存在该用户。
                if (myDataReader.HasRows)
                {
                    MessageBox.Show("用户名已存在，请输入其他名称！");
                    textBox1.Focus();
                    return;
                }
                else
                {
                    myConnection.Close();
                    myConnection.Open();
                    myCommand.CommandText = sql2;
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("成功添加用户！");
                    return;
                }


                //关闭数据库连接。
                myDataReader.Close();
                myConnection.Close();
                this.Close();
                
            /*
            //检测用户是否输入用户名。
            if (this.textBox1.Text == string.Empty)
            {
                MessageBox.Show("请输入用户名！");
                this.textBox1.Focus();
                return;
            }
            //检测用户是否输入密码。
            else if (this.textBox2.Text == string.Empty)
            {
                MessageBox.Show("请输入密码！");
                this.textBox2.Focus();
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
                string sql = "SELECT username, password FROM T_User WHERE (username = N'" + textBox1.Text.Trim() + "')";
                
                string sql2 = "insert into T_User(username, password) values(" +
                    "AdminName,"+"AdminPass)";
                    // "'" +frm.textBox1.Text + "'," +
                     //"'" +frm.textBox2.Text + "')";
                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();

                //判断是否存在该用户。
                if (!myDataReader.HasRows)
                {
                    MessageBox.Show("不存在这个管理员！");
                    return;
                }

                //读取数据库中的内容，并于当前输入比较。
                while (myDataReader.Read())
                {
                    //判断用户输入与数据库内容是否匹配。
                    if (myDataReader["password"].ToString().Trim() != textBox2.Text.Trim())
                    {
                        MessageBox.Show("密码不正确！");
                        textBox2.Focus();
                        return;
                    }
                    else
                    {
                        
                        myConnection.Close();
                        myConnection.Open();
                        myCommand.CommandText = sql2;
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        MessageBox.Show("成功添加用户！");
                        return;

                    }
                }

                */


            }
        }
    }
}