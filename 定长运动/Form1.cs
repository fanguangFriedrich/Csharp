using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading; //线程
using Leadshine;


namespace 定长运动
{
    public partial class Form1 : Form
    {

        private Thread thread_1;  //定义一个子线程1
        private Thread thread_2;  //定义一个子线程2

        public Form1()
        {
            InitializeComponent();
            Connect_state();    //获取连接状态
            Get_Offset();       //获取偏移距离
            //
            thread_1 = new Thread(Thread_1_Work); //创建子线程1，传入要执行的方法
            thread_1.Start();                     //启动子线程1
            //
            thread_2 = new Thread(Thread_2_Work); //创建子线程2，传入要执行的方法
            thread_2.Start();                     //启动子线程2
        }
        //
        //子线程1方法
        //
        public void Thread_1_Work()
        {

            try
            {
                while (true)
                {
                    if (Thread_1._Run_State)
                    {
                        LTSMC.smc_write_outbit(Motor._ConnectNo, 0, 1); //设置IO 0 为高电平
                        Thread.Sleep(500);
                        LTSMC.smc_write_outbit(Motor._ConnectNo, 0, 0); //设置IO 0 为低电平
                        Thread.Sleep(500);
                    }
                }
            }
            finally
            {
                //释放占用资源或者关闭连接
                LTSMC.smc_write_outbit(Motor._ConnectNo, 0, 1); //设置IO 0 为高电平
            }
        }
        //
        //子线程2方法
        //
        public void Thread_2_Work()
        {
            try
            {
                while (true)
                {
                    if (Motor._Forth_Back_State) //判断电机往返运动标志位
                    {
                        Motor.Motor_Back_Forth_Move_Init(Motor._Start_Speed,
                                                         Motor._Run_Speed,
                                                         Motor._Stop_Speed,
                                                         Motor._Speed_Time,
                                                         Motor._Slow_Time,
                                                         Motor._S_Time,
                                                         1);
                        Thread.Sleep(1000);
                        LTSMC.smc_stop(Motor._ConnectNo, Motor.axis, 0);
                        Thread.Sleep(100);
                        if (Motor._Forth_Back_State)
                        {
                            Motor.Motor_Back_Forth_Move_Init(Motor._Start_Speed,
                                                             Motor._Run_Speed,
                                                             Motor._Stop_Speed,
                                                             Motor._Speed_Time,
                                                             Motor._Slow_Time,
                                                             Motor._S_Time,
                                                             0);
                            Thread.Sleep(1000);
                            LTSMC.smc_stop(Motor._ConnectNo, Motor.axis, 0);
                            Thread.Sleep(100);
                        }
                    }
                }
            }
            finally
            {
                //释放占用资源或者关闭连接
                LTSMC.smc_stop(Motor._ConnectNo, Motor.axis, 0);
                Motor._Forth_Back_State = false;

            }
        }


        //
        //获取连接状态
        //
        private void Connect_state()
        {
            if (Connect.ConnectState)
            {
                //连接失败 失能按键
                button_Back_Home.Enabled = false;
                button_Motor_Stop.Enabled = false;
                button_open_motor.Enabled = false;
            }
            else
            {
                //连接成功
                timer1.Start();
            }
        }
        //
        //获取偏移距离
        //
        private void Get_Offset()
        {
            double offset;
            offset = decimal.ToDouble(numericUpDown8.Value);
            Motor.Motor_Get_Offset(offset);

        }


        //
        //选择轴
        //
        private void radioButton_X_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_X.Checked)
            {
                Motor.axis = 0; //选中X轴

            }
            else if (radioButton_Y.Checked)
            {
                Motor.axis = 1; //选中Y轴

            }


        }
        //
        //回原点按钮点击事件
        //
        private void button_Back_Home_Click(object sender, EventArgs e)
        {
            ////获取参数配置
            Motor._Start_Speed = decimal.ToDouble(numericUpDown1.Value);//起始速度
            Motor._Back_Home_Speed = decimal.ToDouble(numericUpDown9.Value);//回原点速度
            Motor._Stop_Speed = decimal.ToDouble(numericUpDown3.Value);//停止速度
            Motor._Speed_Time = decimal.ToDouble(numericUpDown4.Value);//加速时间
            Motor._Slow_Time = decimal.ToDouble(numericUpDown5.Value);//减速时间
            Motor._Run_Pos = decimal.ToDouble(numericUpDown6.Value);//S段时间
            Motor._S_Time = decimal.ToDouble(numericUpDown7.Value);//运动距离



            Motor.Motor_Back_Init(Motor._Start_Speed,
                                     Motor._Back_Home_Speed,
                                     Motor._Stop_Speed,
                                     Motor._Speed_Time,
                                     Motor._Slow_Time);



        }
        //
        //停止按钮按钮点击事件
        //
        private void button_Motor_Stop_Click(object sender, EventArgs e)
        {
            Motor.Motor_Stop_Control();//停止  
        }
        //
        //不是很理解
        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            uint n;

            StringBuilder sb = new StringBuilder();
            ushort axis = Motor.axis;
            double speed = 0;
            LTSMC.smc_read_current_speed_unit(Motor._ConnectNo, axis, ref speed);
            sb.AppendFormat("Speed={0},", speed);
            //
            double pos = 0;
            LTSMC.smc_get_position_unit(Motor._ConnectNo, 0, ref pos);
            sb.AppendFormat("X={0},", pos);
            LTSMC.smc_get_position_unit(Motor._ConnectNo, 1, ref pos);
            sb.AppendFormat("Y={0},", pos);
            LTSMC.smc_get_position_unit(Motor._ConnectNo, 2, ref pos);
            sb.AppendFormat("Z={0},", pos);
            LTSMC.smc_get_position_unit(Motor._ConnectNo, 3, ref pos);
            sb.AppendFormat("U={0},", pos);
            LTSMC.smc_get_position_unit(Motor._ConnectNo, 4, ref pos);
            sb.AppendFormat("V={0},", pos);
            LTSMC.smc_get_position_unit(Motor._ConnectNo, 5, ref pos);
            sb.AppendFormat("W={0},", pos);
            //
            textBox2.Text = sb.ToString();
            short axisstatus = LTSMC.smc_check_done(Motor._ConnectNo, axis);
            if (axisstatus == 1)
            {
                textBox1.Text = "停止";
                label_io_0.BackColor = Color.Red;               //设置IO 0 标签颜色
                Thread_1._Run_State = false;
            }
            else
            {
                textBox1.Text = "运行";
                label_io_0.BackColor = Color.Green;             //设置IO 0 标签颜色
                Thread_1._Run_State = true;
            }


            //专用口
            n = LTSMC.smc_axis_io_status(Motor._ConnectNo, 0);       //读取指定轴有关运动信号的状态
            SetAxisStatus(panel1, n);
            //n = LTSMC.smc_axis_io_status(Motor._ConnecNo, 1);
            //SetAxisStatus(panel2, n);
            //n = LTSMC.smc_axis_io_status(Motor._ConnecNo, 2);
            //SetAxisStatus(panel3, n);
            //n = LTSMC.smc_axis_io_status(Motor._ConnecNo, 3);
            //SetAxisStatus(panel4, n);
            //n = LTSMC.smc_axis_io_status(Motor._ConnecNo, 4);
            //SetAxisStatus(panel5, n);
            //n = LTSMC.smc_axis_io_status(Motor._ConnecNo, 5);
            //SetAxisStatus(panel6, n);

        }
        //
        //窗口初始化事件
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            Connect.Connect_Init();
        }

        //
        //设置lab颜色
        //
        private void SetLabel(Label label, bool status)
        {
            if (label != null)
            {
                if (status)
                {
                    label.BackColor = Color.Red;   //低电平红色
                }
                else
                {
                    label.BackColor = Color.Green; //高电平绿色
                }
            }
        }

        private void SetAxisStatus(Panel panel, uint status)
        {
            foreach (Label _label in panel.Controls)
            {
                if (_label != null)
                {
                    if (_label.Text == "ALM")
                    {
                        SetLabel(_label, (status & 1) == 1);
                    }
                    else if (_label.Text == "EL+")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 1)) == (int)Math.Pow(2, 1));
                    }
                    else if (_label.Text == "EL-")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 2)) == (int)Math.Pow(2, 2));
                    }
                    else if (_label.Text == "EMG")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 3)) == (int)Math.Pow(2, 3));
                    }
                    else if (_label.Text == "HOME")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 4)) == (int)Math.Pow(2, 4));
                    }
                    else if (_label.Text == "SL+")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 6)) == (int)Math.Pow(2, 6));
                    }
                    else if (_label.Text == "SL-")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 7)) == (int)Math.Pow(2, 7));
                    }
                    else if (_label.Text == "INP")
                    {
                        SetLabel(_label, (status & (int)Math.Pow(2, 8)) == (int)Math.Pow(2, 8));
                    }
                }
            }
        }
        //
        //获取运动方向
        //
        private void radioButton_move_1_CheckedChanged(object sender, EventArgs e)
        {
            ushort _Direction = 0;
            if (radioButton_move_0.Checked)
            {
                _Direction = 0;   //反方向
                Motor.Motor_Get_Direction(_Direction);
            }
            else if (radioButton_move_1.Checked)
            {
                _Direction = 1;   //正方向
                Motor.Motor_Get_Direction(_Direction);
            }

        }
        //
        //获取回原点方式
        //
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ushort mode = 0; ;

            if (radioButton1.Checked)
            {
                mode = 0;
                Motor.Motor_Get_Back_Mode(mode);
            }
            else if (radioButton2.Checked)
            {
                mode = 1;
                Motor.Motor_Get_Back_Mode(mode);
            }
            else if (radioButton3.Checked)
            {
                mode = 2;
                Motor.Motor_Get_Back_Mode(mode);
            }
            else if (radioButton4.Checked)
            {
                mode = 3;
                Motor.Motor_Get_Back_Mode(mode);
            }
            else if (radioButton5.Checked)
            {
                mode = 4;
                Motor.Motor_Get_Back_Mode(mode);
            }
            else if (radioButton6.Checked)
            {
                mode = 5;
                Motor.Motor_Get_Back_Mode(mode);
            }
            else if (radioButton7.Checked)
            {
                mode = 6;
                Motor.Motor_Get_Back_Mode(mode);
            }
            else if (radioButton8.Checked)
            {
                mode = 7;
                Motor.Motor_Get_Back_Mode(mode);
            }
            else if (radioButton9.Checked)
            {
                mode = 8;
                Motor.Motor_Get_Back_Mode(mode);
            }
            else if (radioButton10.Checked)
            {
                mode = 9;
                Motor.Motor_Get_Back_Mode(mode);
            }

        }
        //
        //获取置零模式
        //
        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            ushort mode;
            if (radioButton11.Checked)
            {
                mode = 0;//无
            }
            else if (radioButton12.Checked)
            {
                mode = 1;//先置零后偏移
            }
            else if (radioButton13.Checked)
            {
                mode = 2;//先偏移置零后
            }

        }
        //
        //启动按钮松开事件
        //
        private void button_open_motor_MouseUp(object sender, MouseEventArgs e)
        {
            Motor.Motor_Stop_Control();
        }
        //
        //启动按键按下事件
        //
        private void button_open_motor_MouseDown(object sender, MouseEventArgs e)
        {
            //获取参数配置
            Motor._Start_Speed = decimal.ToDouble(numericUpDown1.Value);//起始速度
            Motor._Run_Speed = decimal.ToDouble(numericUpDown2.Value);//运行速度
            Motor._Stop_Speed = decimal.ToDouble(numericUpDown3.Value);//停止速度
            Motor._Speed_Time = decimal.ToDouble(numericUpDown4.Value);//加速时间
            Motor._Slow_Time = decimal.ToDouble(numericUpDown5.Value);//减速时间
            Motor._Run_Pos = decimal.ToDouble(numericUpDown6.Value);//S段时间
            Motor._S_Time = decimal.ToDouble(numericUpDown7.Value);//运动距离


            //电机初始化
            Motor.Motor_Init(Motor._Start_Speed,
                                     Motor._Run_Speed,
                                     Motor._Stop_Speed,
                                     Motor._Speed_Time,
                                     Motor._Slow_Time,
                                     Motor._S_Time,
                                     Motor._Run_Pos);
        }
        //
        //Form1主界面关闭事件
        //
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);
            if (thread_1 != null && thread_1.IsAlive) //判断线程1是否为空,以及线程1是否在运行
            {
                thread_1.Abort(); //终止子程序1
                thread_1.Join();  //等待子程序2结束
            }
            if (thread_2 != null && thread_2.IsAlive) //判断线程2是否为空,以及线程2是否在运行
            {
                thread_2.Abort(); //终止子程序2
                thread_2.Join();  //等待子程序2结束
            }

        }
        //
        //启动往返运动按键点击事件
        //
        private void button_start_back_forth_move_Click(object sender, EventArgs e)
        {

            //获取参数配置
            Motor._Start_Speed = decimal.ToDouble(numericUpDown1.Value);//起始速度
            Motor._Run_Speed = decimal.ToDouble(numericUpDown2.Value);//运行速度
            Motor._Stop_Speed = decimal.ToDouble(numericUpDown3.Value);//停止速度
            Motor._Speed_Time = decimal.ToDouble(numericUpDown4.Value);//加速时间
            Motor._Slow_Time = decimal.ToDouble(numericUpDown5.Value);//减速时间
            Motor._S_Time = decimal.ToDouble(numericUpDown6.Value);//S段时间


            Motor._Forth_Back_State = true;


        }
    }
}
