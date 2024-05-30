using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadshine;

//
//电机类：用于初始化和配置电机轴控制所需的参数
//


namespace 定长运动
{
    public static class Motor
    {
        public static double _Start_Speed;  //起始速度
        public static double _Run_Speed;    //运行速度
        public static double _Stop_Speed;   //停止速度
        public static double _Back_Home_Speed;    //回原点速度
        public static double _Speed_Time;   //加速时间
        public static double _Slow_Time;    //减速时间
        public static double _S_Time;       //S段时间
        public static double _Run_Pos;      //运动距离
        public static ushort _Direction;    //运动方向
        public static ushort _Back_Mode;    //回原点模式
        public static ushort _OffsetMode;   //置零模式
        public static double _Offset;       //偏移距离
        public static bool _Forth_Back_State;       //往返运动标志位
        public static ushort _ConnectNo = 0;
        public static ushort axis = 0;         //轴选

        //
        //电机启动初始化
        //
        public static void Motor_Init(double Motor_Start_Speed,
                                      double Motor_Run_Speed,
                                      double Motor_Stop_Speed,
                                      double Motor_Speed_Time,
                                      double Motor_Slow_Time,
                                      double Motor_Run_Pos,
                                      double Motor_S_Time)
        {
            LTSMC.smc_set_pulse_outmode(_ConnectNo, axis, 0); //设置脉冲模式
            LTSMC.smc_set_equiv(_ConnectNo, axis, 1);         //设置脉冲当量
            LTSMC.smc_set_alm_mode(_ConnectNo, axis, 0, 0, 0);//设置报警使能，关闭报警
            LTSMC.smc_write_sevon_pin(_ConnectNo, axis, 0);   //打开伺服使能
            LTSMC.smc_set_s_profile(_ConnectNo, axis, 0, Motor_S_Time);//设置S段时间（0-1s)
            LTSMC.smc_set_profile_unit(_ConnectNo,
                                       axis,
                                       Motor_Start_Speed,
                                       Motor_Run_Speed,
                                       Motor_Speed_Time,
                                       Motor_Slow_Time,
                                       Motor_Stop_Speed); //设置起始速度、运行速度、停止速度、加速时间、减速时间

            LTSMC.smc_set_dec_stop_time(_ConnectNo, axis, Motor_Slow_Time);
            //LTSMC.smc_pmove_unit(_ConnectNo, axis, Motor_Run_Pos, 0);//定长运动
            LTSMC.smc_vmove(_ConnectNo, axis, _Direction); //连续运动方向
            //LTSMC.smc_stop(_ConnectNo, axis, 0);
        }

        //
        //电机回原点初始化
        //
        public static void Motor_Back_Init(double Motor_Start_Speed,
                                      double _Back_Home_Speed,
                                      double Motor_Stop_Speed,
                                      double Motor_Speed_Time,
                                      double Motor_Slow_Time)
        {
            LTSMC.smc_set_pulse_outmode(_ConnectNo, axis, 0);    //设置脉冲模式
            LTSMC.smc_set_equiv(_ConnectNo, axis, 1);            //设置脉冲当量
            LTSMC.smc_set_alm_mode(_ConnectNo, axis, 0, 0, 0);   //设置报警使能，关闭报警
            LTSMC.smc_write_sevon_pin(_ConnectNo, axis, 0);      //打开伺服使能
            LTSMC.smc_set_home_pin_logic(_ConnectNo, axis, 0, 0);//设置原点低电平有效
            LTSMC.smc_set_home_profile_unit(_ConnectNo,
                                  axis,
                                  Motor_Start_Speed,
                                  _Back_Home_Speed,
                                  Motor_Speed_Time,
                                  Motor_Slow_Time); //设置起始速度、运行速度、停止速度、加速时间、减速时间
            LTSMC.smc_set_homemode(_ConnectNo, axis, _Direction, 1, _Back_Mode, 0);  //设置回零模式
            LTSMC.smc_set_home_position_unit(_ConnectNo, axis, _OffsetMode, _Offset);//设置偏移模式
            LTSMC.smc_home_move(_ConnectNo, axis); //启动回零

        }

        //
        //电机反复运动初始化
        //
        public static void Motor_Back_Forth_Move_Init(double Motor_Start_Speed,
                                      double Motor_Run_Speed,
                                      double Motor_Stop_Speed,
                                      double Motor_Speed_Time,
                                      double Motor_Slow_Time,
                                      double Motor_S_Time,
                                      ushort Motor_Directio
                                      )
        {
            LTSMC.smc_set_pulse_outmode(_ConnectNo, axis, 0);    //设置脉冲模式
            LTSMC.smc_set_equiv(_ConnectNo, axis, 1);            //设置脉冲当量
            LTSMC.smc_set_alm_mode(_ConnectNo, axis, 0, 0, 0);   //设置报警使能，关闭报警
            LTSMC.smc_write_sevon_pin(_ConnectNo, axis, 0);      //打开伺服使能
            LTSMC.smc_set_s_profile(_ConnectNo, axis, 0, 0.01);//设置S段时间（0-1s)
            LTSMC.smc_set_profile_unit(_ConnectNo,
                                       axis,
                                       Motor_Start_Speed,
                                       Motor_Run_Speed,
                                       Motor_Speed_Time,
                                       Motor_Slow_Time,
                                       Motor_Stop_Speed); //设置起始速度、运行速度、停止速度、加速时间、减速时间
            LTSMC.smc_set_dec_stop_time(_ConnectNo, axis, Motor_Slow_Time);//设置减速停止时间
            LTSMC.smc_vmove(_ConnectNo, axis, Motor_Directio); //连续运动
            //LTSMC.smc_pmove_unit(_ConnectNo, axis, _Run_Pos, 0);



        }
        //
        //电机回原点控制方法
        //
        public static void Motor_Back_Home_Control()
        {
            LTSMC.smc_set_position_unit(_ConnectNo, axis, 0);//位置清零
        }
        //
        //电机停止控制方法
        //
        public static void Motor_Stop_Control()
        {
            _Forth_Back_State = false;  //电机停止同时将往返运动线程关闭
            LTSMC.smc_stop(_ConnectNo, axis, 0);
        }

        //
        //获取方向方法
        //
        public static void Motor_Get_Direction(ushort Motor_Direction)
        {
            _Direction = Motor_Direction;
        }

        //
        //获取回原点模式方法
        //
        public static void Motor_Get_Back_Mode(ushort Motor_Back_Mode)
        {
            _Back_Mode = Motor_Back_Mode;
        }

        //
        //获取置零模式方法
        //
        public static void Motor_Get_OffsetMode(ushort Motor_OffsetMode)
        {
            _OffsetMode = Motor_OffsetMode;
        }

        //
        //获取偏移距离方法
        //
        public static void Motor_Get_Offset(double Motor_Offset)
        {
            _Offset = Motor_Offset;
        }
    }
}
