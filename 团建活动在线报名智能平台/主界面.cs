using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunny.UI;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Aop.Api.Domain;
using System.Speech.Recognition;


namespace 团建活动在线报名智能平台
{
    public partial class 主界面 : UIForm
    {
        string username;
        public 主界面(string textBox1_text)
        {
            username = textBox1_text;
            InitializeComponent();
            DataGridView_init();
            loadDataFromDatabase();
            loadDataFromDatabase2(username);
            InitializeSpeechRecognition();
            // 绑定 FormClosing 事件处理程序
            this.Load += new EventHandler(MainForm_Load); // 确保绑定加载事件
            this.FormClosing += 主界面_FormClosing;
        }

        // 主界面关闭时触发的事件处理程序
        private void 主界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // 退出应用程序
        }

        private void 主界面_Load(object sender, EventArgs e)
        {
            // 主界面加载时的处理代码
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            // 此处放置选项卡点击事件的处理代码
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void uiTabControlMenu1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void uiTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=C:\\Users\\19231\\Desktop\\tuanjian.db;Version=3;";
            string act_nameText = act_name.Text.Trim(); // 获取活动名称文本框内容并去除空格
            string ps_nameText = ps_name.Text.Trim(); // 获取人员名称文本框内容并去除空格
            string s_dateText = s_date.Text.Trim(); // 获取开始日期文本框内容并去除空格
            string e_dateText = e_date.Text.Trim(); // 获取结束日期文本框内容并去除空格
            string tipText = tip.Text.Trim(); // 获取提示文本框内容并去除空格
            string introductionText = introduction.Text.Trim(); // 获取介绍文本框内容并去除空格
            // 检查文本框是否有空值
            if (string.IsNullOrEmpty(act_nameText) || string.IsNullOrEmpty(ps_nameText) ||
                string.IsNullOrEmpty(s_dateText) || string.IsNullOrEmpty(e_dateText) ||
                string.IsNullOrEmpty(tipText) || string.IsNullOrEmpty(introductionText))
            {
                MessageBox.Show("请确保所有内容都不为空。");
                return; // 如果任何文本框为空，停止执行并返回
            }
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO main(act_name, ps_name, s_date, e_date, tip, introduction) VALUES (@act_name, @ps_name, @s_date, @e_date, @tip, @introduction)";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@act_name", act_nameText);
                    command.Parameters.AddWithValue("@ps_name", ps_nameText);
                    command.Parameters.AddWithValue("@s_date", s_dateText);
                    command.Parameters.AddWithValue("@e_date", e_dateText);
                    command.Parameters.AddWithValue("@tip", tipText);
                    command.Parameters.AddWithValue("@introduction", introductionText);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("您的申请已提交");
                        }
                        else
                        {
                            MessageBox.Show("申请提交失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                // 关闭数据库连接
                connection.Close();
            }
        }


        private void uiLabel7_Click(object sender, EventArgs e)
        {

        }



        private void uiButton2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=C:\\Users\\19231\\Desktop\\tuanjian.db;Version=3;"; // SQLite 数据库文件路径
            string keyword = ID.Text;
            string actName, psName, sDate, eDate, tip, introduction;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT act_name, ps_name, s_date, e_date, tip, introduction FROM main WHERE ID = @keyword;";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@keyword", keyword);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            actName = reader["act_name"].ToString();
                            psName = reader["ps_name"].ToString();
                            sDate = reader["s_date"].ToString();
                            eDate = reader["e_date"].ToString();
                            tip = reader["tip"].ToString();
                            introduction = reader["introduction"].ToString();

                            // 显示查询结果
                            s_act_name.Text = actName;
                            s_ps_name.Text = psName;
                            s_s_date.Text = sDate;
                            s_e_date.Text = eDate;
                            s_tip.Text = tip;
                            s_introduction.Text = introduction;

                        }
                        else
                        {
                            MessageBox.Show("未找到匹配的记录！");
                        }
                    }
                }
            }
        }
        private void DataGridView_init()
        {
            // 设置表头
            uiDataGridView1.ColumnCount = 6;
            uiDataGridView1.Columns[0].Name = "id编号";
            uiDataGridView1.Columns[1].Name = "活动名";
            uiDataGridView1.Columns[2].Name = "申请人";
            uiDataGridView1.Columns[3].Name = "开始时间";
            uiDataGridView1.Columns[4].Name = "结束时间";
            uiDataGridView1.Columns[5].Name = "费用";


            uiDataGridView2.ColumnCount = 6;
            uiDataGridView2.Columns[0].Name = "id编号";
            uiDataGridView2.Columns[1].Name = "活动名";
            uiDataGridView2.Columns[2].Name = "申请人";
            uiDataGridView2.Columns[3].Name = "开始时间";
            uiDataGridView2.Columns[4].Name = "结束时间";
            uiDataGridView2.Columns[5].Name = "费用";



        }

        void loadDataFromDatabase()
        {
            string connectionString = "Data Source=C:\\Users\\19231\\Desktop\\tuanjian.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM main";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // 设置 AllowUserToAddRows 为 false
                    uiDataGridView1.AllowUserToAddRows = false;

                    // 清空 DataGridView 中的行
                    uiDataGridView1.Rows.Clear();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        uiDataGridView1.Rows.Add(row["ID"], row["act_name"], row["ps_name"], row["s_date"], row["e_date"], row["tip"]);
                    }
                }

                // 关闭数据库连接
                connection.Close();
            }
        }



        void loadDataFromDatabase2(string username)
        {
            string connectionString = "Data Source=C:\\Users\\19231\\Desktop\\tuanjian.db;Version=3;";

            string tableName = username;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM main INNER JOIN {tableName} ON main.ID = {tableName}.活动编号;";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // 设置 AllowUserToAddRows 为 false
                    uiDataGridView2.AllowUserToAddRows = false;

                    // 清空 DataGridView 中的行
                    uiDataGridView2.Rows.Clear();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        uiDataGridView2.Rows.Add(row["ID"], row["act_name"], row["ps_name"], row["s_date"], row["e_date"], row["tip"]);
                    }
                }
            }
        }





        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedID = uiDataGridView1.Rows[e.RowIndex].Cells["id编号"].Value.ToString();
                活动详情 a = new 活动详情(selectedID);
                a.Show();
                /* string tip = uiDataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                 string message = "该活动费用为 " + tip + " 元，是否确定参加活动？";
                 DialogResult result = MessageBox.Show(message, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                 if (result == DialogResult.Yes)
                 {


                     // 创建一个新的支付窗口实例
                     支付 payWindow = new 支付(username,ID.Text,s_act_name.Text,s_s_date.Text,s_e_date.Text,s_tip.Text);

                     // 显示支付窗口
                     payWindow.Show();
                 }*/
            }
        }

        private void s_e_date_ValueChanged(object sender, DateTime value)
        {

        }

        private void uiLabel14_Click(object sender, EventArgs e)
        {

        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            // 创建一个新的支付窗口实例
            支付 payWindow = new 支付(username, ID.Text, s_act_name.Text, s_s_date.Text, s_e_date.Text, s_tip.Text);

            // 显示支付窗口
            payWindow.Show();
        }

        private void uiDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedID = uiDataGridView2.Rows[e.RowIndex].Cells["id编号"].Value.ToString();
                活动详情 a = new 活动详情(selectedID);
                a.Show();
            }
            else
            {
                MessageBox.Show("选择时出现错误");
            }
        }
        private SpeechRecognitionEngine recognizer;

        private void InitializeSpeechRecognition()
        {
            recognizer = new SpeechRecognitionEngine();
            recognizer.SetInputToDefaultAudioDevice();

            Choices commands = new Choices();
            commands.Add("活动列表");
            commands.Add("活动查询");
            commands.Add("活动申请");
            commands.Add("我的活动");

            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(commands);

            Grammar grammar = new Grammar(grammarBuilder);

            recognizer.LoadGrammar(grammar);
            recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
        }
        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "活动列表")
            {
                tabControl1.SelectedTab = hdlb;
            }
            else if (e.Result.Text == "活动查询")
            {
                tabControl1.SelectedTab = hdcx;
            }
            else if (e.Result.Text == "活动申请")
            {
                tabControl1.SelectedTab = hdsq;
            }
            else if (e.Result.Text == "我的活动")
            {
                tabControl1.SelectedTab = wdhd;
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            // 主界面加载时的处理代码
            recognizer.RecognizeAsync(RecognizeMode.Multiple); // 开始异步语音识别
        }

        private void s_date_ValueChanged(object sender, DateTime value)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}



