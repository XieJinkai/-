using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 团建活动在线报名智能平台
{
    public partial class 登录 : Form
    {
        public 登录()
        {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load);
            this.Text = "登录";
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }

        private void 登录_Load(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请输入用户名！");
                return;
            }

            string connectionString = "Data Source=C:\\Users\\19231\\Desktop\\tuanjian.db;Version=3;"; // SQLite 数据库文件路径
            string username = textBox1.Text;
            string password = textBox2.Text;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // 校验数据库中是否存在以用户名为表名的表
                string checkTableQuery = $"SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@tableName;";
                using (SQLiteCommand checkTableCommand = new SQLiteCommand(checkTableQuery, connection))
                {
                    checkTableCommand.Parameters.AddWithValue("@tableName", username);

                    int tableCount = Convert.ToInt32(checkTableCommand.ExecuteScalar());

                    if (tableCount == 0)
                    {
                        // 如果表不存在，则创建表
                        string createTableQuery = $"CREATE TABLE {username} (活动编号 INTEGER PRIMARY KEY, 活动名称 TEXT, 费用 DECIMAL, 支付时间 TEXT);";
                        using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
                        {
                            createTableCommand.ExecuteNonQuery();
                        }
                    }

                    // 校验用户名和密码
                    string query = $"SELECT COUNT(*) FROM user WHERE 用户名 = @username AND 密码 = @password;";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("登录成功！");

                            if (remember.Checked)
                            {
                                Properties.Settings.Default.Username = username;
                                Properties.Settings.Default.Password = password;
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                Properties.Settings.Default.Username = "";
                                Properties.Settings.Default.Password = "";
                                Properties.Settings.Default.Save();
                            }

                            // 关闭当前登录窗口
                            this.Hide();

                            // 显示主界面窗口
                            主界面 mainForm = new 主界面(textBox1.Text);
                            mainForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码错误！");
                        }
                    }
                }
            }
        }







        private void uiButton2_Click(object sender, EventArgs e)
        {
            // 创建注册窗体的实例
            注册 registerForm = new 注册();
            registerForm.Owner = this; // 设置上级窗体为当前窗体
            registerForm.Show();

          
          
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Username) && !string.IsNullOrEmpty(Properties.Settings.Default.Password))
            {
                textBox1.Text = Properties.Settings.Default.Username;
                textBox2.Text = Properties.Settings.Default.Password;
                remember.Checked = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
