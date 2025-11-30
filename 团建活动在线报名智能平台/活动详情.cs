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

namespace 团建活动在线报名智能平台
{
    public partial class 活动详情 : Form
    {
        public 活动详情()
        {
            InitializeComponent();
        }


        public 活动详情(string ID)
        {
            InitializeComponent();

            string connectionString = "Data Source=C:\\Users\\19231\\Desktop\\tuanjian.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM main WHERE ID = @ID";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            act_name.Text = reader["act_name"].ToString();
                            ps_name.Text = reader["ps_name"].ToString();
                            s_date.Value = Convert.ToDateTime(reader["s_date"]);
                            e_date.Value = Convert.ToDateTime(reader["e_date"]);
                            tip.Text = reader["tip"].ToString();
                            introduction.Text = reader["introduction"].ToString();
                        }
                    }
                }
            }
        }


        private void 活动详情_Load(object sender, EventArgs e)
        {
            // 在窗口加载时初始化控件的数据
            string ID = ""; // 填写需要查询的ID值
            loadDataFromDatabase(ID);
        }

        private void loadDataFromDatabase(string ID)
        {
            string connectionString = "Data Source=C:\\Users\\19231\\Desktop\\tuanjian.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM main WHERE ID = @ID";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            act_name.Text = reader["act_name"].ToString();
                            ps_name.Text = reader["ps_name"].ToString();
                            s_date.Text = reader["s_date"].ToString();
                            e_date.Text = reader["e_date"].ToString();
                            tip.Text = reader["tip"].ToString();
                            introduction.Text = reader["introduction"].ToString();
                        }
                    }
                }
            }
        }


    }
}
