using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadshine;

//
//连接类:用于上位机与执行器连接
//

namespace 定长运动
{
    public static class Connect
    {
        public static ushort _ConnectNo = 0;
        public static bool ConnectState = false; //连接状态变量
        private static string _IP = "192.168.5.11";     //IP
        private static ushort _COM = 2;                 //端口
        private static uint Baudrate = 115200;          //波特率
        //
        //连接控制器初始化方法
        //
        public static void Connect_Init()
        {
            short res = LTSMC.smc_board_init(_ConnectNo, _COM, _IP, Baudrate);//连接控制器
            if (res != 0)
            {
                ConnectState = false; //连接失败                
            }
            else
            {
                ConnectState = true; //连接成功
            }
        }
    }
}
