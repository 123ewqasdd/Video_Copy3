using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Video_Copy3.Classes;

namespace Video_Copy3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Helper_INI h_ini;
        Helper_Redis h_redis;
        string str_ini = "config.ini";
        string str_r_rec = "";
        string str_r_rep = "";
        string str_r_rec_disk = "";
        string str_r_rec_disk_info = "";
        string str_search = "";

        //声明一个委托
        public delegate void SetTextBoxValue(string value);

        //委托使用文本框
        void SetMyTextBoxValue(string value)
        {
            // Control.InvokeRequired 属性： 获取一个值，该值指示调用方在对控件进行方法调用时是否必须调用 Invoke 方法，因为调用方位于创建控件所在的线程以外的线程中。当前线程不是创建控件的线程时为true,当前线程中访问是False
            if (this.tb_ReceiveMessage.InvokeRequired)
            {
                SetTextBoxValue objSetTextBoxValue = new SetTextBoxValue(SetMyTextBoxValue);

                // IAsyncResult 接口：表示异步操作的状态。不同的异步操作需要不同的类型来描述，自然可以返回任何对象。
                // Control.BeginInvoke 方法 (Delegate)：在创建控件的基础句柄所在线程上异步执行指定委托。
                IAsyncResult result = this.tb_ReceiveMessage.BeginInvoke(objSetTextBoxValue, new object[] { value });
                try
                {
                    objSetTextBoxValue.EndInvoke(result);
                }
                catch
                {
                }
            }
            else
            {
                this.tb_ReceiveMessage.Text += value + Environment.NewLine;
                this.tb_ReceiveMessage.SelectionStart = this.tb_ReceiveMessage.TextLength;
                this.tb_ReceiveMessage.ScrollToCaret();
            }
        }

        private void b_Connect_Click(object sender, EventArgs e)
        {
            SetMyTextBoxValue(Helper_Redis.Test().ToString());
        }

        private void b_Sender_Click(object sender, EventArgs e)
        {
            Command_info c = new Command_info();
            c.type = 1;
            c.msg = "";
            c.msg2 = "";
            string str_c = Helper_Json.Encode(c);

            long r_l = h_redis.RedisPub(str_r_rep, str_c);
            SetMyTextBoxValue(str_r_rep+ ":"+ str_c);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Command_info c = new Command_info();
            c.type = 2;
            c.msg = "D:\\,E:\\";
            c.msg2 = str_search;
            string str_c = Helper_Json.Encode(c);

            long r_l = h_redis.RedisPub(str_r_rep, str_c);
            SetMyTextBoxValue(str_r_rep + ":" + str_c);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
            h_ini = new Helper_INI(str_ini);


            string r_ip = h_ini.ReadString("redis", "ip2", "localhost");
            string r_port = h_ini.ReadString("redis", "port2", "6379");
            string r_pwd = h_ini.ReadString("redis", "pwd2", "");
            int r_DB = h_ini.ReadInteger("redis", "db", 0);
            str_r_rec = h_ini.ReadString("redis", "chan2", "");         //服务器的接收就是这边的发送
            str_r_rep = h_ini.ReadString("redis", "chan1", "");         //服务器的发送频道就是这边的接收频道
            str_r_rec_disk = h_ini.ReadString("redis", "key_disk", "");
            str_r_rec_disk_info = h_ini.ReadString("redis", "key_disk_info", "");

            str_search = h_ini.ReadString("DEFAULT", "scan_filter", ".avi,.mp4,.rmvb");

            h_redis = new Helper_Redis();
            h_redis.Use(r_ip, r_port, r_pwd, r_DB);

            h_redis.RedisSubMessageEvent += H_redis_RedisSubMessageEvent;
            h_redis.Use(r_DB).RedisSub(str_r_rec);
        }

        private void H_redis_RedisSubMessageEvent(string str)
        {
            //string msg = System.Text.Encoding.UTF8.GetString(str);
            SetMyTextBoxValue(str);
            Result_Info r = (Result_Info)Helper_Json.Decode(str,typeof(Result_Info));
            SetMyTextBoxValue(r.msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = tb_Send.Text;
            Result_Info r = (Result_Info)Helper_Json.Decode(str);
            SetMyTextBoxValue(r.msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str_disk = h_redis.Get(str_r_rec_disk);
            SetMyTextBoxValue(str_disk);
        }


    }
}
