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

        private void �Ƴ�ToolStripMenuItem_Click(object sender, EventArgs e)
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
            //����û��Ƿ������û�����
            if (this.txtUsername.Text == string.Empty)
            {
                MessageBox.Show("�������û�����");
                this.txtUsername.Focus();
                return;
            }
            //����û��Ƿ��������롣
            else if (this.txtPassword.Text == string.Empty)
            {
                MessageBox.Show("���������룡");
                this.txtPassword.Focus();
                return;
            }
            else
            {
                //�����û��ַ���
                string connectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";

                //�������ӡ�
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();

                //��ȡ�����û��������롣
                SqlCommand myCommand = myConnection.CreateCommand();
                string sql = "SELECT username, password FROM T_User WHERE (username = N'" + txtUsername.Text.Trim() + "')";
                
                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();

                //�ж��Ƿ���ڸ��û���
                if (!myDataReader.HasRows)
                {
                    MessageBox.Show("�û��������ڣ�");
                    return;
                }
                
                //��ȡ���ݿ��е����ݣ����ڵ�ǰ����Ƚϡ�
                while (myDataReader.Read())
                {
                    //�ж��û����������ݿ������Ƿ�ƥ�䡣
                    if (myDataReader["password"].ToString().Trim() != txtPassword.Text.Trim())
                    {
                        MessageBox.Show("���벻��ȷ��");
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

                //�ر����ݿ����ӡ�
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