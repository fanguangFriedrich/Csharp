using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadshine;

namespace 定长运动
{
    public partial class Form1 : Form
    {
        private ushort _ConnectNo = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            short res = LTSMC.smc_board_init(_ConnectNo,2,"192.168.5.11",115200);//连接控制器
            if (res!=0)
            {
                MessageBox.Show("连接错误!", "出错");
                textBox1.Text = "未连接";
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
            }
            else
            {
                timer1.Start();
            }

            
        }
        private ushort GetAxis()
        {
            ushort axis = 0;
            if (radioButton1.Checked)
            {
                axis = 0;
            }
            else if (radioButton2.Checked)
            {
                axis= 1;
            }
            else if (radioButton3.Checked)
            {
                axis = 2;
            }
            else if (radioButton4.Checked)
            {
                axis = 3;
            }
            else if (radioButton5.Checked)
            {
                axis = 4;
            }
            else if (radioButton6.Checked)
            {
                axis = 5;
            }
            return axis;
        }
        //运行
        private void button1_Click(object sender, EventArgs e)
        {
            ushort axis=GetAxis();
            double start = decimal.ToDouble(numericUpDown1.Value);
            double speed=decimal.ToDouble(numericUpDown2.Value);
            double stop=decimal.ToDouble(numericUpDown3.Value);
            double acc=decimal.ToDouble(numericUpDown4.Value);
            double dec=decimal.ToDouble(numericUpDown5.Value);
            double dis = decimal.ToDouble(numericUpDown6.Value);
            double s = decimal.ToDouble(numericUpDown7.Value);
            //
            LTSMC.smc_set_pulse_outmode(_ConnectNo, axis, 0);//设置脉冲模式
            LTSMC.smc_set_s_profile(_ConnectNo, axis, 0, s);//设置S段时间（0-1s)
            LTSMC.smc_set_profile_unit(_ConnectNo, axis, start, speed, acc, dec, stop);//设置起始速度、运行速度、停止速度、加速时间、减速时间
            LTSMC.smc_set_dec_stop_time(_ConnectNo, axis, dec);
            LTSMC.smc_pmove_unit(_ConnectNo, axis, dis, 0);//定长运动
            //
        }
        //位置清零
        private void button2_Click(object sender, EventArgs e)
        {
            ushort axis = GetAxis();
            LTSMC.smc_set_position_unit(_ConnectNo, axis, 0);//位置清零
        }
        //减速停止
        private void button3_Click(object sender, EventArgs e)
        {
            ushort axis = GetAxis();
            LTSMC.smc_stop(_ConnectNo, axis, 0);
        }
        //在线变速
        private void button4_Click(object sender, EventArgs e)
        {
            ushort axis = GetAxis();
            double speed = decimal.ToDouble(numericUpDown2.Value);
            LTSMC.smc_change_speed_unit(_ConnectNo, axis, speed, 0);//在线变速
        }
        //立即停止
        private void button5_Click(object sender, EventArgs e)
        {
            ushort axis = GetAxis();
            LTSMC.smc_stop(_ConnectNo, axis, 1);
        }
        //在线变位
        private void button6_Click(object sender, EventArgs e)
        {
            ushort axis = GetAxis();
            int dis = decimal.ToInt32(numericUpDown6.Value);
            LTSMC.smc_reset_target_position_unit(_ConnectNo, axis, dis);//在线变位
        }
        //退出
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            ushort axis=GetAxis();
            double speed =0;
            LTSMC.smc_read_current_speed_unit(_ConnectNo, axis,ref speed);
            sb.AppendFormat("Speed={0},", speed);
            //
            double pos = 0;
            LTSMC.smc_get_position_unit(_ConnectNo, 0,ref pos);
            sb.AppendFormat("X={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 1,ref pos);
            sb.AppendFormat("Y={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 2,ref pos);
            sb.AppendFormat("Z={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 3,ref pos);
            sb.AppendFormat("U={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 4, ref pos);
            sb.AppendFormat("V={0},", pos);
            LTSMC.smc_get_position_unit(_ConnectNo, 5, ref pos);
            sb.AppendFormat("W={0},", pos);
            //
            textBox2.Text = sb.ToString();
            //
            short xs = LTSMC.smc_check_done(_ConnectNo, 0);
            short ys = LTSMC.smc_check_done(_ConnectNo, 1);
            short zs = LTSMC.smc_check_done(_ConnectNo, 2);
            short us = LTSMC.smc_check_done(_ConnectNo, 3);
            short vs = LTSMC.smc_check_done(_ConnectNo, 4);
            short ws = LTSMC.smc_check_done(_ConnectNo, 5);
            if (xs == 1 && ys == 1 && zs == 1 && us == 1 && vs == 1 && ws == 1)
            {
                textBox1.Text = "停止";
            }
            else
            {
                textBox1.Text = "运行";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            LTSMC.smc_board_close(_ConnectNo);
        }
    }
}
