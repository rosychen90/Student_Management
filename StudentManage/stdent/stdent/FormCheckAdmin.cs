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
            //����û��Ƿ������û�����
            if (this.textBox1.Text == string.Empty)
            {
                MessageBox.Show("�������û�����");
                this.textBox1.Focus();
                return;
            }
            //����û��Ƿ��������롣
            else if (this.textBox2.Text == string.Empty)
            {
                MessageBox.Show("���������룡");
                this.textBox2.Focus();
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
                string sql = "SELECT username FROM T_User WHERE (username = '"+textBox1.Text+"')";
                string sql2 = "insert into T_User(username, password) values(" +
                     "'" +this.textBox1.Text + "'," +
                     "'" +this.textBox2.Text + "')";
                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();

                //�ж��Ƿ���ڸ��û���
                if (myDataReader.HasRows)
                {
                    MessageBox.Show("�û����Ѵ��ڣ��������������ƣ�");
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
                    MessageBox.Show("�ɹ�����û���");
                    return;
                }


                //�ر����ݿ����ӡ�
                myDataReader.Close();
                myConnection.Close();
                this.Close();
                
            /*
            //����û��Ƿ������û�����
            if (this.textBox1.Text == string.Empty)
            {
                MessageBox.Show("�������û�����");
                this.textBox1.Focus();
                return;
            }
            //����û��Ƿ��������롣
            else if (this.textBox2.Text == string.Empty)
            {
                MessageBox.Show("���������룡");
                this.textBox2.Focus();
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
                string sql = "SELECT username, password FROM T_User WHERE (username = N'" + textBox1.Text.Trim() + "')";
                
                string sql2 = "insert into T_User(username, password) values(" +
                    "AdminName,"+"AdminPass)";
                    // "'" +frm.textBox1.Text + "'," +
                     //"'" +frm.textBox2.Text + "')";
                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();

                //�ж��Ƿ���ڸ��û���
                if (!myDataReader.HasRows)
                {
                    MessageBox.Show("�������������Ա��");
                    return;
                }

                //��ȡ���ݿ��е����ݣ����ڵ�ǰ����Ƚϡ�
                while (myDataReader.Read())
                {
                    //�ж��û����������ݿ������Ƿ�ƥ�䡣
                    if (myDataReader["password"].ToString().Trim() != textBox2.Text.Trim())
                    {
                        MessageBox.Show("���벻��ȷ��");
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
                        MessageBox.Show("�ɹ�����û���");
                        return;

                    }
                }

                */


            }
        }
    }
}