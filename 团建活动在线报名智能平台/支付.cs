using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
namespace 团建活动在线报名智能平台
{
    public partial class 支付 : UIForm
    {
        string username;
        string ID;
        string s_act_name;
        string s_s_date;
        string s_e_date;
        string s_tip;

        private void InitializeVariables()
        {
            hdm.Text= s_act_name ;  // 将 hdm.Text 的值赋给 s_act_name
            jine.Text= s_tip;     // 将 jine.Text 的值赋给
        }

        public 支付(string username,string ID,string s_act_name,string s_s_date,string s_e_date,string s_tip )
        {
            this.username = username;
            this.ID = ID;
            this.s_act_name = s_act_name;
            this.s_s_date = s_s_date;
            this.s_e_date = s_e_date;
            this.s_tip = s_tip;
            InitializeComponent();
            InitializeVariables();

        }

        private void 支付_Load(object sender, EventArgs e)
        {

        }

        private void uiLabel2_Click(object sender, EventArgs e)
        {

        }

        private void fukuanma_TextChanged(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {

            //从串口工具读取数据
            var length = serialPort1.BytesToRead;
            var buff = new byte[length];
            serialPort1.Read(buff, 0, buff.Length);
            var message = Encoding.UTF8.GetString(buff).Replace("\r", "");

            //获取订单号和付款码
            this.Invoke(new Action(() =>
            {

                //订单号
                dingdanhao.Text = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next();

                //付款码接收
                fukuanma.Text = message.ToString();
            }));

        }

        private void fukuanma_Enter(object sender, EventArgs e)
        {

            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法打开串口： " + ex.Message);
                }
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=C:\\Users\\19231\\Desktop\\tuanjian.db";
            string tableName = username; // 请将username替换为实际的表名
            string hdmText = hdm.Text;
            MessageBox.Show(tableName);
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} WHERE 活动名称 = '{hdmText}'";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("您已报名该活动！");
                        }
                        else
                        {
                            userformBLL userformBLL = new userformBLL(dingdanhao.Text, jine.Text, hdm.Text, fukuanma.Text);
                            userformBLL.setTransferHelp(Properties.Resources.APPID, Properties.Resources.Apply_private_key, Properties.Resources.Alipay_public_key);
                            bool result = userformBLL.Pay(dingdanhao.Text, jine.Text, hdm.Text, fukuanma.Text, timer1);
                            if (result)
                            {
                                Successful();
                                timer1.Start();
                            }
                            else
                            {
                                MessageBox.Show("支付失败！");
                            }
                        }
                    }
                }
            }
            this.Close();
        }



        private void Successful()
        {
            string dataSource = "Data Source=C:\\Users\\19231\\Desktop\\tuanjian.db;Version=3;";
            string tableName = username;
            string activityName = hdm.Text;
            string fee = jine.Text;
            string paymentTime = DateTime.Now.ToString(); // 使用当前时间作为支付时间

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE 活动编号 = @ID";

            using (SQLiteConnection connection = new SQLiteConnection(dataSource))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("您已报名该活动！");
                    }
                    else
                    {
                        using (SQLiteCommand insertCommand = new SQLiteCommand($"INSERT INTO {tableName} (活动编号, 活动名称, 费用, 支付时间) VALUES (@ID, @ActivityName, @Fee, @PaymentTime)", connection))
                        {
                            insertCommand.Parameters.AddWithValue("@ID", ID);
                            insertCommand.Parameters.AddWithValue("@ActivityName", activityName);
                            insertCommand.Parameters.AddWithValue("@Fee", fee);
                            insertCommand.Parameters.AddWithValue("@PaymentTime", paymentTime);

                            int result = insertCommand.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("活动报名成功！");
                            }
                            else
                            {
                                MessageBox.Show("活动报名失败。");
                            }
                        }
                    }
                }
            }
        }





        //时间控件
        private void timer1_Tick(object sender, EventArgs e)
        {

            userformBLL userformBLL = new userformBLL(dingdanhao.Text, jine.Text, hdm.Text, fukuanma.Text);
            string response = userformBLL.ResponseReturnMsg(userformBLL.getTransferHelp_outTradeNo(), userformBLL.getTransferHelp_TrandeNo());

            if (response == "TRADE_SUCCESS")
            {
                timer1.Stop();
            }

        }
    }
}
