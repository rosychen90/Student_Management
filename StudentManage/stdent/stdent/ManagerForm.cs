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
    public partial class ManagerForm : Form
    {

        public ManagerForm()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void couNumberLable1_Click(object sender, EventArgs e)
        {

        }
        

        private void classComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet stuNumberCombo = new DataSet();
            string connectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";
            string stuNumberstrconn = "select distinct stuNumber from stuInfor where college='" + collegeComboBox.Text + "' and class='" + classComboBox.Text + "'";
            SqlConnection stuNumberconn = new SqlConnection(connectionString);
            SqlDataAdapter stuNumbersqlda = new SqlDataAdapter(stuNumberstrconn, stuNumberconn);
            //建立连接,查找所有学号并填充到combobox
            stuNumberCombo.Clear();
            stuNumberComboBox.Items.Clear();
            stuNumbersqlda.Fill(stuNumberCombo, "stuNumber");
            for (int i = 0; i < stuNumberCombo.Tables[0].Rows.Count; i++)
            {
                stuNumberComboBox.Items.Add(stuNumberCombo.Tables[0].Rows[i][0]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentScoreDataSet.stuScore' table. You can move, or remove it, as needed.
            this.stuScoreTableAdapter.Fill(this.studentScoreDataSet.stuScore);
            // TODO: This line of code loads data into the 'studentInforDataSet.stuInfor' table. You can move, or remove it, as needed.
            this.stuInforTableAdapter.Fill(this.studentInforDataSet.stuInfor);
          
            this.courseTableAdapter1.Fill(this.studentcourseDataSet3.course);
            DataSet collegeCombo = new DataSet();
            string connectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";
            string collegestrconn = "select distinct college from stuInfor";
            SqlConnection collegeconn = new SqlConnection(connectionString);
            SqlDataAdapter collegesqlda = new SqlDataAdapter(collegestrconn, collegeconn);
            //建立连接,查找所有学院名并填充到combobox
            collegeCombo.Clear();
            collegeComboBox.Items.Clear();
            collegesqlda.Fill(collegeCombo, "college");
            for (int i = 0; i < collegeCombo.Tables[0].Rows.Count; i++)
            {
                collegeComboBox.Items.Add(collegeCombo.Tables[0].Rows[i][0]);
            }

            DataSet couCombo = new DataSet();
            string coustrconn = "select distinct couName from course";
            SqlConnection couconn = new SqlConnection(connectionString);
            SqlDataAdapter cousqlda = new SqlDataAdapter(coustrconn, couconn);
            //建立连接,查找所有课程并填充到combobox
            couCombo.Clear();
            couComboBox.Items.Clear();
            cousqlda.Fill(couCombo, "cou");
            for (int i = 0; i < couCombo.Tables[0].Rows.Count; i++)
            {
                couComboBox.Items.Add(couCombo.Tables[0].Rows[i][0]);
            }

            

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void collegeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet classCombo = new DataSet();
            string connectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";
            string classstrconn = "select distinct class from stuInfor where college='" + collegeComboBox.Text + "'";
            SqlConnection classconn = new SqlConnection(connectionString);
            SqlDataAdapter classsqlda = new SqlDataAdapter(classstrconn, classconn);
            //建立连接,查找所有班级名并填充到combobox
            classCombo.Clear();
            classComboBox.Items.Clear();
            classsqlda.Fill(classCombo, "class");
            classComboBox.Text = "请选择...";
            stuNumberComboBox.Text = "请选择...";
            for (int i = 0; i < classCombo.Tables[0].Rows.Count; i++)
            {
                classComboBox.Items.Add(classCombo.Tables[0].Rows[i][0]);
            }

            DataSet couCombo = new DataSet();
            string coustrconn = "select distinct couName from course where college='" + collegeComboBox.Text + "'";
            SqlConnection couconn = new SqlConnection(connectionString);
            SqlDataAdapter cousqlda = new SqlDataAdapter(coustrconn, couconn);
            //建立连接,查找所有课程名并填充到combobox
            couCombo.Clear();
            couComboBox.Items.Clear();
            cousqlda.Fill(couCombo, "cou");
            couComboBox.Text = "请选择...";
            for (int i = 0; i < couCombo.Tables[0].Rows.Count; i++)
            {
                couComboBox.Items.Add(couCombo.Tables[0].Rows[i][0]);
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出吗？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void stuNumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void stuScoreBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void stuInforBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void couComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";
            string Sql = "select  score from stuScore where stuNumber = '" + stuNumberComboBox.Text + "'";

            SqlConnection thisConnection = new SqlConnection(ConnectionString);
            SqlCommand thisCommand = new SqlCommand(Sql, thisConnection);
            thisCommand.CommandType = CommandType.Text;

            // 打开数据库连接
            thisCommand.Connection.Open();
            // 执行SQL语句，并返回DataReader对象
            SqlDataReader sdr = thisCommand.ExecuteReader();
            if (sdr.Read())
            {
                scoTextBox.Text = sdr.ToString();
               
            }
            sdr.Close();

        }

        private void stuNumberComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";
            string Sql = "select  * from stuInfor where college='" + collegeComboBox.Text + "' and stuNumber = '" + stuNumberComboBox.Text + "'";

            SqlConnection thisConnection = new SqlConnection(ConnectionString);
            SqlCommand thisCommand = new SqlCommand(Sql,thisConnection);
            thisCommand.CommandType = CommandType.Text;

                 // 打开数据库连接
                thisCommand.Connection.Open();
                // 执行SQL语句，并返回DataReader对象
                SqlDataReader sdr = thisCommand.ExecuteReader();
                if (sdr.Read())
                {
                    nameTextBox.Text = sdr["stuName"].ToString();
                    majorTextBox.Text = sdr["major"].ToString();
                }
                sdr.Close();
           
        }

        private void scoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void couComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";
            string Sql = "select  score from stuScore,course where stuScore.couNumber=course.couNumber and couName='" + couComboBox.Text + "' and stuNumber = '" + stuNumberComboBox.Text + "'";

            SqlConnection thisConnection = new SqlConnection(ConnectionString);
            SqlCommand thisCommand = new SqlCommand(Sql, thisConnection);
            thisCommand.CommandType = CommandType.Text;

            // 打开数据库连接
            thisCommand.Connection.Open();
            // 执行SQL语句，并返回DataReader对象
            SqlDataReader sdr = thisCommand.ExecuteReader();
            
            if (sdr.Read())
            {
                scoTextBox.Text = sdr["score"].ToString();
                
            }
            else
            {
                scoTextBox.Text = "";
            }
            sdr.Close();
        }

        private void scoTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(collegeComboBox.Text.Trim()==string.Empty||classComboBox.Text.Trim()==string.Empty||stuNumberComboBox.Text.Trim()==string.Empty||nameTextBox.Text.Trim()==string.Empty||majorTextBox.Text.Trim()==string.Empty||couComboBox.Text.Trim()==string.Empty||scoTextBox.Text.Trim()==string.Empty)
            {
                MessageBox.Show("请填完整所有信息！");
                nameTextBox.Focus();
            }
            else
            {
                string connectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();

                SqlCommand myCommand=myConnection.CreateCommand();
                string sql = "select * from stuInfor where stuNumber = '" + stuNumberComboBox.Text + "'";
                string sql2 = "update stuInfor set " +
                   "stuNumber = '" + stuNumberComboBox.Text + "'," +
                   "stuName = '" + nameTextBox.Text + "'," +
                   " college = '" + collegeComboBox.Text + "'," +
                   " major = '" + majorTextBox.Text + "'," +
                   " class = '" + classComboBox.Text + "' where stuNumber = '" + stuNumberComboBox.Text + "'";
                string sql21 ="update stuScore set score='" + scoTextBox.Text + "' where stuNumber = '" + stuNumberComboBox.Text + "' and couNumber=(select couNumber from course where couName='" + couComboBox .Text+ "')";
                string sql22 = "update stuScore set stuName='" + nameTextBox.Text + "' where stuNumber = '" + stuNumberComboBox.Text + "' and couNumber=(select couNumber from course where couName='" + couComboBox.Text + "')";
                string sql3 = "insert into stuInfor(stuNumber,stuName,college,major,class) values(" +
                     "'" + stuNumberComboBox.Text + "'," +
                     "'" + nameTextBox.Text + "'," +
                     "'" + collegeComboBox.Text + "'," +
                     "'" + majorTextBox.Text + "'," +
                     "'" + classComboBox.Text + "')";
                string sql31="insert into stuScore(stuNumber,stuName,score) values(" +
                     "'" + stuNumberComboBox.Text + "'," +
                     "'" + nameTextBox.Text + "'," +
                     
                     "'" + scoTextBox.Text + "')";
                string sql32 = "update stuScore set couNumber=(select couNumber from course where couName= '" + couComboBox.Text + "') where stuNumber='" + stuNumberComboBox.Text + "'";
                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();
                

                if (myDataReader.HasRows)
                {
                    DialogResult result = MessageBox.Show("学生信息已存在，是否仅更新？", "Attetion!",MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    switch (result)
                    {
                        case DialogResult.OK:
                            myConnection.Close();
                            myConnection.Open();
                            myCommand.CommandText = sql2;
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            myConnection.Open();
                            myCommand.CommandText = sql21;
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            myConnection.Open();
                            myCommand.CommandText = sql22;
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            
                            
                            MessageBox.Show("已完成对旧信息的更新！");
                            this.Hide();
                            ManagerForm managerform = new ManagerForm();
                            managerform.ShowDialog();
                            break;
                        case DialogResult.Cancel:
                            MessageBox.Show("未作任何修改！");
                            break;
                    }
                    
                }
                else
                {
                    myConnection.Close();
                    myConnection.Open();
                    myCommand.CommandText = sql3;
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    myConnection.Open();
                    myCommand.CommandText = sql31;
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    myConnection.Open();
                    myCommand.CommandText = sql32;
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    MessageBox.Show("新记录添加成功！");
                    this.Hide();
                    ManagerForm managerform = new ManagerForm();
                    managerform.ShowDialog();
                }
                
            }
           // this.dataGridView1.DataSource ="" ;
            
           // this.dataGridView1.DataSource = stuInforBindingSource;
           // this.dataGridView1.Refresh();
           // this.dataGridView1.RefreshEdit();
            
            
         }

        private void majorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (stuNumberComboBox.Text.Trim() == string.Empty || couComboBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请指定删除谁的哪门课！");
                nameTextBox.Focus();
            }
            else
            {
                string connectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();

                SqlCommand myCommand = myConnection.CreateCommand();
                string sql = "select stuNumber from stuScore where stuNumber = '" + stuNumberComboBox.Text + "' and couNumber=(select couNumber from course where couName='" + couComboBox.Text + "') ";
                string sql2 = "delete from stuScore where stuNumber = '" + stuNumberComboBox.Text + "' and couNumber=(select couNumber from course where couName='"+couComboBox.Text+"')";
                
                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();


                if (myDataReader.HasRows)
                {
                    DialogResult result = MessageBox.Show("是否删除该生成绩信息？", "Attetion!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    switch (result)
                    {
                        case DialogResult.OK:
                            myConnection.Close();
                            myConnection.Open();
                            myCommand.CommandText = sql2;
                            myCommand.ExecuteNonQuery();
                            

                            myConnection.Close();
                           

                            MessageBox.Show("已完成对该生成绩信息的删除！");
                            this.Hide();
                            ManagerForm managerform = new ManagerForm();
                            managerform.ShowDialog();
                            break;
                        case DialogResult.Cancel:
                            MessageBox.Show("未作任何修改！");
                            break;
                    }

                }
                else
                {
                   MessageBox.Show("不存在此信息，无法删除！");
                   myConnection.Close();
                }

            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (couNumberTextBox.Text.Trim() == string.Empty || couNumberTextBox.Text.Trim() == string.Empty || collegeComboBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请填齐学院，课程号，课程名！");
                nameTextBox.Focus();
            }
            else
            {
                string connectionString = @"Data Source=SAMSUNG-CRAZY;Initial Catalog=studentSystem;Integrated Security=True";
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();

                SqlCommand myCommand = myConnection.CreateCommand();
                string sql = "select * from course where couName='" + couNameTextBox.Text + "' or couNumber='"+couNumberTextBox.Text+"' ";
                string sql2 = "insert into course (couNumber,couName,college) values(" +
                     "'" + couNumberTextBox.Text + "'," +
                     "'" + couNameTextBox.Text + "',"+
                     "'" + collegeComboBox.Text + "')";
                string sql3 = "update course set " +
                    " couNumber = '" + couNumberTextBox.Text + "'," +
                    " couName = '" + couNameTextBox.Text + "',"+
                    " college = '" + collegeComboBox.Text + "' where couName='" + couNameTextBox.Text + "' or couNumber='" + couNumberTextBox.Text + "'";

                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();


                if (myDataReader.HasRows)
                {
                    DialogResult result = MessageBox.Show("已存在课程，是否仅在原有基础上更新信息？", "Attetion!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    switch (result)
                    {
                        case DialogResult.OK:
                            myConnection.Close();
                            myConnection.Open();
                            myCommand.CommandText = sql3;
                            myCommand.ExecuteNonQuery();


                            myConnection.Close();


                            MessageBox.Show("已完成课程信息更新！");
                            break;
                        case DialogResult.Cancel:
                            MessageBox.Show("未作任何修改！");
                            break;
                    }

                }
                else
                {
                    

                    myConnection.Close();
                    myConnection.Open();
                    myCommand.CommandText = sql2;
                    myCommand.ExecuteNonQuery();
                    
                    myConnection.Close();
                    MessageBox.Show("添加该新课程成功！");
                }

            }
            this.Hide();
            ManagerForm managerform = new ManagerForm();
            managerform.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
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
                string sql = "SELECT username, password FROM T_User WHERE (username = 'admin') ";
                
               
                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();

                
                
                    //读取数据库中的内容，并于当前输入比较。
                    while (myDataReader.Read())
                    {
                        //判断是否存在该用户。
                        if (textBox1.Text != "admin")
                        {
                            MessageBox.Show("不存在这个管理员！");
                            return;
                        }
                        //判断用户输入与数据库内容是否匹配。
                        if (myDataReader["password"].ToString().Trim() != textBox2.Text.Trim())
                        {
                            MessageBox.Show("密码不正确！");
                            textBox2.Focus();
                            return;
                        }
                        else
                        {

                            FormCheckAdmin checkform = new FormCheckAdmin();
                            checkform.ShowDialog();

                        }
                    }
                

           /* //检测用户是否输入用户名。
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
                    
                    FormCheckAdmin checkform = new FormCheckAdmin();
                    checkform.ShowDialog();
                }


                //关闭数据库连接。
                myDataReader.Close();
                myConnection.Close();
                this.Close();
                */
            
        
            }    
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //检测用户是否输入用户名。
            if (this.textBox3.Text == string.Empty)
            {
                MessageBox.Show("请输入用户名！");
                this.textBox3.Focus();
                return;
            }
            //检测用户是否输入原密码。
            else if (this.textBox4.Text == string.Empty)
            {
                MessageBox.Show("请输入原密码！");
                this.textBox4.Focus();
                return;
            }
            //检测用户是否输入新密码。
            else if (this.textBox5.Text == string.Empty)
            {
                MessageBox.Show("请输入新密码！");
                this.textBox5.Focus();
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
                string sql = "SELECT username, password FROM T_User WHERE (username ='" + textBox3.Text + "')";
                string sql2 = "update T_User set password='" + textBox5.Text + "' where username='" + textBox3.Text + "'";

                myCommand.CommandText = sql;
                SqlDataReader myDataReader = myCommand.ExecuteReader();

                //判断是否存在该用户。
                if (!myDataReader.HasRows)
                {
                    MessageBox.Show("不存在这个用户！");
                    return;
                }

                //读取数据库中的内容，并于当前输入比较。
                while (myDataReader.Read())
                {
                    //判断用户输入与数据库内容是否匹配。
                    if (myDataReader["password"].ToString().Trim() != textBox4.Text.Trim())
                    {
                        MessageBox.Show("提供的原密码不正确！");
                        textBox4.Focus();
                        return;
                    }
                    else
                    {
                        myConnection.Close();
                        myConnection.Open();
                        myCommand.CommandText = sql2;
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        MessageBox.Show("成功修改了用户密码！");
                        return;


                    }
                }

                //关闭数据库连接。
                myDataReader.Close();
                myConnection.Close();
                this.Close();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        } 
    }
}

    
