using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 团建活动在线报名智能平台
{
    public partial class 注册 : Form
    {
        public 注册()
        {
            InitializeComponent();
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=C:\\Users\\19231\\Desktop\\tuanjian.db;Version=3;"; // SQLite 数据库文件路径

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string username = textBox1.Text;
                string password = textBox2.Text;
                string confirmPassword = textBox3.Text;

                if (password != confirmPassword)
                {
                    MessageBox.Show("两次输入的密码不同，请重新输入。");
                    return;
                }

                string query = "INSERT INTO user (用户名, 密码) VALUES (@username, @password);";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("注册成功！");

                connection.Close();

                // 关闭当前窗口并显示上一级窗口
                this.Close();
               

            }
        }



        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
