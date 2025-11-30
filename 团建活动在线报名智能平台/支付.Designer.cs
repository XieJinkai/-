namespace 团建活动在线报名智能平台
{
    partial class 支付
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.jine = new Sunny.UI.UITextBox();
            this.hdm = new Sunny.UI.UITextBox();
            this.dingdanhao = new Sunny.UI.UITextBox();
            this.fukuanma = new Sunny.UI.UITextBox();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiButton1 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // jine
            // 
            this.jine.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.jine.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jine.Location = new System.Drawing.Point(265, 170);
            this.jine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.jine.MinimumSize = new System.Drawing.Size(1, 16);
            this.jine.Name = "jine";
            this.jine.Padding = new System.Windows.Forms.Padding(5);
            this.jine.ShowText = false;
            this.jine.Size = new System.Drawing.Size(270, 31);
            this.jine.TabIndex = 14;
            this.jine.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.jine.Watermark = "";
            // 
            // hdm
            // 
            this.hdm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hdm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hdm.Location = new System.Drawing.Point(265, 118);
            this.hdm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hdm.MinimumSize = new System.Drawing.Size(1, 16);
            this.hdm.Name = "hdm";
            this.hdm.Padding = new System.Windows.Forms.Padding(5);
            this.hdm.ShowText = false;
            this.hdm.Size = new System.Drawing.Size(270, 31);
            this.hdm.TabIndex = 15;
            this.hdm.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hdm.Watermark = "";
            // 
            // dingdanhao
            // 
            this.dingdanhao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dingdanhao.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dingdanhao.Location = new System.Drawing.Point(265, 224);
            this.dingdanhao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dingdanhao.MinimumSize = new System.Drawing.Size(1, 16);
            this.dingdanhao.Name = "dingdanhao";
            this.dingdanhao.Padding = new System.Windows.Forms.Padding(5);
            this.dingdanhao.ShowText = false;
            this.dingdanhao.Size = new System.Drawing.Size(270, 31);
            this.dingdanhao.TabIndex = 16;
            this.dingdanhao.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dingdanhao.Watermark = "";
            // 
            // fukuanma
            // 
            this.fukuanma.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fukuanma.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fukuanma.Location = new System.Drawing.Point(265, 274);
            this.fukuanma.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fukuanma.MinimumSize = new System.Drawing.Size(1, 16);
            this.fukuanma.Name = "fukuanma";
            this.fukuanma.Padding = new System.Windows.Forms.Padding(5);
            this.fukuanma.ShowText = false;
            this.fukuanma.Size = new System.Drawing.Size(270, 31);
            this.fukuanma.TabIndex = 14;
            this.fukuanma.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.fukuanma.Watermark = "";
            this.fukuanma.TextChanged += new System.EventHandler(this.fukuanma_TextChanged);
            this.fukuanma.Enter += new System.EventHandler(this.fukuanma_Enter);
            // 
            // uiLabel13
            // 
            this.uiLabel13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel13.Location = new System.Drawing.Point(133, 274);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(100, 31);
            this.uiLabel13.TabIndex = 26;
            this.uiLabel13.Text = "付款码";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(133, 224);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 31);
            this.uiLabel1.TabIndex = 27;
            this.uiLabel1.Text = "订单号";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(133, 170);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 28;
            this.uiLabel2.Text = "金额";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.Click += new System.EventHandler(this.uiLabel2_Click);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(133, 118);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.TabIndex = 29;
            this.uiLabel3.Text = "活动名称";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(331, 343);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.TabIndex = 30;
            this.uiButton1.Text = "支付";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // 支付
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiLabel13);
            this.Controls.Add(this.fukuanma);
            this.Controls.Add(this.dingdanhao);
            this.Controls.Add(this.hdm);
            this.Controls.Add(this.jine);
            this.Name = "支付";
            this.Text = "支付界面";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.支付_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox jine;
        private Sunny.UI.UITextBox hdm;
        private Sunny.UI.UITextBox dingdanhao;
        private Sunny.UI.UITextBox fukuanma;
        private Sunny.UI.UILabel uiLabel13;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UIButton uiButton1;
    }
}