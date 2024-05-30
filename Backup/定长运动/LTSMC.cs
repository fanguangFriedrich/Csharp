using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Leadshine
{
    public static class LTSMC
    {
        /*********************************************************************************************************
        功能函数 
        ***********************************************************************************************************/
        //板卡信息	
        [DllImport("LTSMC.dll")]
        public static extern short smc_board_init(ushort ConnectNo, ushort type, string pconnectstring, uint baud);
        [DllImport("LTSMC.dll")]
        public static extern short smc_board_init_ex(ushort ConnectNo, ushort type, string pconnectstring, uint dwBaudRate, uint dwByteSize, uint dwParity, uint dwStopBits);
        [DllImport("LTSMC.dll")]
        public static extern short smc_board_close(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_CardInfList(ref ushort CardNum, uint[] CardTypeList, ushort[] CardIdList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_card_version(ushort ConnectNo, ref uint CardVersion);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_card_soft_version(ushort ConnectNo, ref uint FirmID, ref uint SubFirmID);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_card_lib_version(ref uint LibVer);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_total_axes(ushort ConnectNo, ref uint TotalAxis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_total_liners(ushort ConnectNo, ref uint TotalLiner);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_debug_mode(ushort mode, string FileName);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_debug_mode(ref ushort mode, ref string FileName);
	[DllImport("LTSMC.dll")]
        public static extern short smc_format_flash(ushort ConnectNo);
	[DllImport("LTSMC.dll")]
        public static extern short smc_set_ipaddr(ushort ConnectNo, string IpAddr);
	[DllImport("LTSMC.dll")]
        public static extern short smc_get_ipaddr(ushort ConnectNo, ref string IpAddr);
	[DllImport("LTSMC.dll")]
        public static extern short smc_set_com(ushort ConnectNo, ushort com, uint dwBaudRate, ushort wByteSize, ushort wParity, ushort wStopBits);
	[DllImport("LTSMC.dll")]
        public static extern short smc_get_com(ushort ConnectNo, ushort com, ref uint dwBaudRate, ref ushort wByteSize, ref ushort wParity, ref ushort wStopBits);

        //序列号
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_sn(ushort ConnectNo, UInt64 sn);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_sn(ushort ConnectNo, ref UInt64 sn);
        //加密
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_password(ushort ConnectNo, string str_pass);
        [DllImport("LTSMC.dll")]
        public static extern short smc_check_password(ushort ConnectNo, string str_pass);
        //脉冲模式		
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_pulse_outmode(ushort ConnectNo, ushort axis, ushort outmode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_pulse_outmode(ushort ConnectNo, ushort axis, ref ushort outmode);
        //脉冲当量
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_equiv(ushort ConnectNo, ushort axis, double equiv);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_equiv(ushort ConnectNo, ushort axis, ref double equiv);
        //反向间隙
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_backlash_unit(ushort ConnectNo, ushort axis, double backlash);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_backlash_unit(ushort ConnectNo, ushort axis, ref double backlash);
        /*********************************************************************************************************
        单轴速度参数
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_profile_unit(ushort ConnectNo, ushort axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_profile_unit(ushort ConnectNo, ushort axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_s_profile(ushort ConnectNo, ushort axis, ushort s_mode, double s_para);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_s_profile(ushort ConnectNo, ushort axis, ushort s_mode, ref double s_para);
        /*********************************************************************************************************
        单轴运动
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_pmove_unit(ushort ConnectNo, ushort axis, double Dist, ushort posi_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_vmove(ushort ConnectNo, ushort axis, ushort dir);
        [DllImport("LTSMC.dll")]
        public static extern short smc_change_speed_unit(ushort ConnectNo, ushort axis, double New_Vel, double Taccdec);
        [DllImport("LTSMC.dll")]
        public static extern short smc_reset_target_position_unit(ushort ConnectNo, ushort axis, double New_Pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_update_target_position_unit(ushort ConnectNo, ushort axis, double New_Pos);
	//正弦曲线定长运动
	[DllImport("LTSMC.dll")]
        public static extern short smc_set_plan_mode(ushort ConnectNo, ushort axis,ushort mode);
	[DllImport("LTSMC.dll")]
        public static extern short smc_get_plan_mode(ushort ConnectNo, ushort axis,ref ushort mode);
	[DllImport("LTSMC.dll")]
        public static extern short smc_pmove_sin_unit(ushort ConnectNo, ushort axis, double Dist, ushort posi_mode,double MaxVel,double MaxAcc);
        /*********************************************************************************************************
        回零运动
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_home_pin_logic(ushort ConnectNo, ushort axis, ushort org_logic, double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_home_pin_logic(ushort ConnectNo, ushort axis, ref ushort org_logic, ref double filter);
	[DllImport("LTSMC.dll")]
        public static extern short smc_set_ez_mode(ushort ConnectNo, ushort axis, ushort ez_logic, ushort ez_mode, double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ez_mode(ushort ConnectNo, ushort axis, ref ushort ez_logic, ref ushort ez_mode, ref double filter);
	[DllImport("LTSMC.dll")]
        public static extern short smc_set_ez_count(ushort ConnectNo, ushort axis, ushort ez_count);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ez_count(ushort ConnectNo, ushort axis, ref ushort ez_count);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_homemode(ushort ConnectNo, ushort axis, ushort home_dir, double vel_mode, ushort mode, ushort source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_homemode(ushort ConnectNo, ushort axis, ref ushort home_dir, ref double vel_mode, ref ushort home_mode, ref ushort source);
	[DllImport("LTSMC.dll")]
        public static extern short smc_set_homespeed_unit(ushort ConnectNo, ushort axis, double homespeed);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_homespeed_unit(ushort ConnectNo, ushort axis, ref double homespeed);
	[DllImport("LTSMC.dll")]
        public static extern short smc_set_home_profile_unit(ushort ConnectNo, ushort axis, double Low_Vel, double High_Vel, double Tacc, double Tdec);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_home_profile_unit(ushort ConnectNo, ushort axis, ref double Low_Vel, ref double High_Vel, ref double Tacc, ref double Tdec);
        [DllImport("LTSMC.dll")]
        public static extern short smc_home_move(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_home_result(ushort ConnectNo, ushort axis, ref ushort state);
	[DllImport("LTSMC.dll")]
        public static extern short smc_set_el_home(ushort ConnectNo, ushort axis, ushort mode);
	[DllImport("LTSMC.dll")]
        public static extern short smc_set_home_position_unit(ushort ConnectNo, ushort axis, double position);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_home_position_unit(ushort ConnectNo, ushort axis, ref double position);
        /*********************************************************************************************************
        PVT运动 SMC104不支持
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_pvt_table_unit(ushort ConnectNo, ushort iaxis, uint count, double[] pTime, double[] pPos, double[] pVel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_pts_table_unit(ushort ConnectNo, ushort iaxis, uint count, double[] pTime, double[] pPos, double[] pPercent);
        [DllImport("LTSMC.dll")]
        public static extern short smc_pvts_table_unit(ushort ConnectNo, ushort iaxis, uint count, double[] pTime, double[] pPos, double velBegin, double velEnd);
        [DllImport("LTSMC.dll")]
        public static extern short smc_ptt_table_unit(ushort ConnectNo, ushort iaxis, uint count, double[] pTime, double[] pPos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_pvt_move(ushort ConnectNo, ushort AxisNum, ushort[] AxisList);
        /*********************************************************************************************************
        手轮运动 SMC104不支持
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_set_axislist(ushort ConnectNo, ushort AxisSelIndex, ushort AxisNum, ushort[] AxisList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_get_axislist(ushort ConnectNo, ushort AxisSelIndex, ref ushort AxisNum, ushort[] AxisList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_set_ratiolist(ushort ConnectNo, ushort AxisSelIndex, ushort StartRatioIndex, ushort RatioSelNum, double[] RatioList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_get_ratiolist(ushort ConnectNo, ushort AxisSelIndex, ushort StartRatioIndex, ushort RatioSelNum, double[] RatioList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_set_mode(ushort ConnectNo, ushort InMode, ushort IfHardEnable);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_get_mode(ushort ConnectNo, ref ushort InMode, ref ushort IfHardEnable);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_set_index(ushort ConnectNo, ushort AxisSelIndex, ushort RatioSelIndex);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_get_index(ushort ConnectNo, ref ushort AxisSelIndex, ref ushort RatioSelIndex);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_move(ushort ConnectNo, ushort ForceMove);
        [DllImport("LTSMC.dll")]
        public static extern short smc_handwheel_stop(ushort ConnectNo);
        /*********************************************************************************************************
        原点锁存 SMC104不支持
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_homelatch_mode(ushort ConnectNo, ushort axis, ushort enable, ushort logic, ushort source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_homelatch_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort logic, ref ushort source);
        [DllImport("LTSMC.dll")]
        public static extern int smc_get_homelatch_flag(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_reset_homelatch_flag(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_homelatch_value_unit(ushort ConnectNo, ushort axis, ref double pos_by_mm);
/*********************************************************************************************************
        EZ锁存 SMC104不支持
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ezlatch_mode(ushort ConnectNo, ushort axis, ushort enable, ushort logic, ushort source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ezlatch_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort logic, ref ushort source);
        [DllImport("LTSMC.dll")]
        public static extern int smc_get_ezlatch_flag(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_reset_ezlatch_flag(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ezlatch_value_unit(ushort ConnectNo, ushort axis, ref double pos_by_mm);        /*********************************************************************************************************
        高速锁存 SMC104不支持
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ltc_mode(ushort ConnectNo, ushort axis, ushort ltc_logic, ushort ltc_mode, double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ltc_mode(ushort ConnectNo, ushort axis, ref ushort ltc_logic, ref ushort ltc_mode, ref double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_latch_mode(ushort ConnectNo, ushort axis, ushort all_enable, ushort latch_source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_latch_mode(ushort ConnectNo, ushort axis, ref ushort all_enable, ref ushort latch_source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_latch_flag(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_reset_latch_flag(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_latch_value_unit(ushort ConnectNo, ushort axis, ref double pos_by_mm);
        /*********************************************************************************************************
        安全机制
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_el_mode(ushort ConnectNo, ushort axis, ushort enable, ushort el_logic, ushort el_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_el_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort el_logic, ref ushort el_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_emg_mode(ushort ConnectNo, ushort axis, ushort enable, ushort emg_logic);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_emg_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort emg_logic);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_softlimit_unit(ushort ConnectNo, ushort axis, ushort enable, ushort source_sel, ushort SL_action, double N_limit, double P_limit);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_softlimit_unit(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort source_sel, ref ushort SL_action, ref double N_limit, ref double P_limit);
        /*********************************************************************************************************
        轴IO映射 SMC104不支持
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_axis_io_map(ushort ConnectNo, ushort Axis, ushort IoType, ushort MapIoType, ushort MapIoIndex, double Filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_axis_io_map(ushort ConnectNo, ushort Axis, ushort IoType, ref ushort MapIoType, ref ushort MapIoIndex, ref double Filter);
        /*********************************************************************************************************
        编码器功能
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_counter_inmode(ushort ConnectNo, ushort axis, ushort mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_counter_inmode(ushort ConnectNo, ushort axis, ref ushort mode);
	[DllImport("LTSMC.dll")]
        public static extern short smc_set_counter_reverse(ushort ConnectNo, ushort axis, ushort reverse);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_counter_reverse(ushort ConnectNo, ushort axis, ref ushort reverse);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_encoder_unit(ushort ConnectNo, ushort axis, double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_encoder_unit(ushort ConnectNo, ushort axis, ref double pos);
        /*********************************************************************************************************
        状态监控
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_check_done(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_stop(ushort ConnectNo, ushort axis, ushort stop_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_emg_stop(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_check_done_multicoor(ushort ConnectNo, ushort Crd);
        [DllImport("LTSMC.dll")]
        public static extern short smc_stop_multicoor(ushort ConnectNo, ushort Crd, ushort stop_mode);
        [DllImport("LTSMC.dll")]
        public static extern uint smc_axis_io_status(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_axis_run_mode(ushort ConnectNo, ushort axis, ref ushort run_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_current_speed_unit(ushort ConnectNo, ushort axis, ref double current_speed);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_position_unit(ushort ConnectNo, ushort axis, double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_position_unit(ushort ConnectNo, ushort axis, ref double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_target_position_unit(ushort ConnectNo, ushort axis, ref double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_workpos_unit(ushort ConnectNo, ushort axis, double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_workpos_unit(ushort ConnectNo, ushort axis, ref double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_stop_reason(ushort ConnectNo, ushort axis, ref int StopReason);
        [DllImport("LTSMC.dll")]
        public static extern short smc_clear_stop_reason(ushort ConnectNo, ushort axis);
        /*********************************************************************************************************
        通用IO操作
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_inbit(ushort ConnectNo, ushort bitno);
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_outbit(ushort ConnectNo, ushort bitno, ushort on_off);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_outbit(ushort ConnectNo, ushort bitno);
        [DllImport("LTSMC.dll")]
        public static extern uint smc_read_inport(ushort ConnectNo, ushort portno);
        [DllImport("LTSMC.dll")]
        public static extern uint smc_read_outport(ushort ConnectNo, ushort portno);
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_outport(ushort ConnectNo, ushort portno, uint outport_val);
        [DllImport("LTSMC.dll")]
        public static extern short smc_reverse_outbit(ushort ConnectNo, ushort bitno, double reverse_time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_io_count_mode(ushort ConnectNo, ushort bitno, ushort mode, double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_io_count_mode(ushort ConnectNo, ushort bitno, ref ushort mode, ref double filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_io_count_value(ushort ConnectNo, ushort bitno, uint CountValue);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_io_count_value(ushort ConnectNo, ushort bitno, ref uint CountValue);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_io_dstp_mode(ushort ConnectNo, ushort axis, ushort enable, ushort logic);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_io_dstp_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort logic);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_dec_stop_time(ushort ConnectNo, ushort axis, double time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_dec_stop_time(ushort ConnectNo, ushort axis, ref double time);
        //虚拟IO映射 用于输入滤波功能 SMC104不支持
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_io_map_virtual(ushort ConnectNo, ushort bitno, ushort MapIoType, ushort MapIoIndex, double Filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_io_map_virtual(ushort ConnectNo, ushort bitno, ref ushort MapIoType, ref ushort MapIoIndex, ref double Filter);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_inbit_virtual(ushort ConnectNo, ushort bitno);
        /*********************************************************************************************************
        专用IO操作
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_alm_mode(ushort ConnectNo, ushort axis, ushort enable, ushort alm_logic, ushort alm_action);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_alm_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort alm_logic, ref ushort alm_action);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_inp_mode(ushort ConnectNo, ushort axis, ushort enable, ushort inp_logic);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_inp_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort inp_logic);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_rdy_mode(ushort ConnectNo, ushort axis, ushort enable, ushort rdy_logic);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_rdy_mode(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort rdy_logic);
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_sevon_pin(ushort ConnectNo, ushort axis, ushort on_off);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_sevon_pin(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_rdy_pin(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_erc_pin(ushort ConnectNo, ushort axis, ushort on_off);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_erc_pin(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_alarm_pin(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_inp_pin(ushort ConnectNo, ushort axis);
	[DllImport("LTSMC.dll")]
        public static extern short smc_read_org_pin(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_elp_pin(ushort ConnectNo, ushort axis);
	[DllImport("LTSMC.dll")]
        public static extern short smc_read_eln_pin(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_emg_pin(ushort ConnectNo, ushort axis);
        /*********************************************************************************************************
        插补参数设置 SMC104只支持单段直线
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_tacc(ushort ConnectNo, ushort Crd, double Tacc);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_acc(ushort ConnectNo, ushort Crd, double acc);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_speed_unit(ushort ConnectNo, ushort Crd, double Max_vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_vector_tacc(ushort ConnectNo, ushort Crd, ref double Tacc);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_vector_acc(ushort ConnectNo, ushort Crd, ref double acc);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_vector_speed_unit(ushort ConnectNo, ushort Crd, ref double Max_vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_profile_unit(ushort ConnectNo, ushort Crd, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_vector_profile_unit(ushort ConnectNo, ushort Crd, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_vector_s_profile(ushort ConnectNo, ushort Crd, ushort s_mode, double s_para);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_vector_s_profile(ushort ConnectNo, ushort Crd, ushort s_mode, ref double s_para);
        //单段插补
        [DllImport("LTSMC.dll")]
        public static extern short smc_line_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Dist, ushort posi_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_arc_move_center_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort Arc_Dir, int Circle, ushort posi_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_arc_move_radius_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double Arc_Radius, ushort Arc_Dir, int Circle, ushort posi_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_arc_move_3points_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, int Circle, ushort posi_mode);
        //连续插补
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_open_list(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_close_list(ushort ConnectNo, ushort Crd);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_stop_list(ushort ConnectNo, ushort Crd, ushort stop_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_pause_list(ushort ConnectNo, ushort Crd);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_start_list(ushort ConnectNo, ushort Crd);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_check_done(ushort ConnectNo, ushort Crd);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_get_run_state(ushort ConnectNo, ushort Crd);
        [DllImport("LTSMC.dll")]
        public static extern int smc_conti_remain_space(ushort ConnectNo, ushort Crd);
        [DllImport("LTSMC.dll")]
        public static extern int smc_conti_read_current_mark(ushort ConnectNo, ushort Crd);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_change_speed_ratio(ushort ConnectNo, ushort Crd, double percent);
        //blend模式
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_blend(ushort ConnectNo, ushort Crd, ushort enable);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_get_blend(ushort ConnectNo, ushort Crd, ref ushort enable);
        //设置每段速度比例
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_override(ushort ConnectNo, ushort Crd, double Percent);
        //连续插补IO功能
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_wait_input(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double TimeOut, long mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_delay_outbit_to_start(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double delay_value, ushort delay_mode, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_delay_outbit_to_stop(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double delay_time, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_ahead_outbit_to_stop(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double ahead_value, ushort ahead_mode, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_accurate_outbit_unit(ushort ConnectNo, ushort Crd, ushort cmp_no, ushort on_off, ushort axis, double abs_pos, ushort pos_source, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_write_outbit(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_clear_io_action(ushort ConnectNo, ushort Crd, uint Io_Mask);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_pause_output(ushort ConnectNo, ushort Crd, ushort action, long mask, long state);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_get_pause_output(ushort ConnectNo, ushort Crd, ref ushort action, ref int mask, ref int state);
        //连续插补轨迹段
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_line_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] pPosList, ushort posi_mode, long mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_arc_move_center_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, ushort Arc_Dir, long Circle, ushort posi_mode, long mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_arc_move_radius_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double Arc_Radius, ushort Arc_Dir, long Circle, ushort posi_mode, long mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_arc_move_3points_unit(ushort ConnectNo, ushort Crd, ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Mid_Pos, long Circle, ushort posi_mode, long mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_pmove_unit(ushort ConnectNo, ushort Crd, ushort axis, double dist, ushort posi_mode, ushort mode, long mark);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_delay(ushort ConnectNo, ushort Crd, double delay_time, long mark);
        /*********************************************************************************************************
        PWM功能 SMC104不支持
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_pwm_output(ushort ConnectNo, ushort PwmNo, double fDuty, double fFre);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_pwm_output(ushort ConnectNo, ushort PwmNo, ref double fDuty, ref double fFre);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_pwm_output(ushort ConnectNo, ushort Crd, ushort PwmNo, double fDuty, double fFre);
        /**********PWM速度跟随***********************************************************************************
        mode:跟随模式0-不跟随 保持状态 1-不跟随 输出低电平2-不跟随 输出高电平3-跟随 占空比自动调整4-跟随 频率自动调整
        MaxVel:最大运行速度，单位unit
        MaxValue:最大输出占空比或者频率
        OutValue：设置输出频率或占空比
        *******************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_set_pwm_follow_speed(ushort ConnectNo, ushort Crd, ushort pwm_no, ushort mode, double MaxVel, double MaxValue, double OutValue);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_get_pwm_follow_speed(ushort ConnectNo, ushort Crd, ushort pwm_no, ref ushort mode, ref double MaxVel, ref double MaxValue, ref double OutValue);
        //设置PWM开关对应的占空比
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_pwm_onoff_duty(ushort ConnectNo, ushort PwmNo, double fOnDuty, double fOffDuty);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_pwm_onoff_duty(ushort ConnectNo, ushort PwmNo, ref double fOnDuty, ref double fOffDuty);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_delay_pwm_to_start(ushort ConnectNo, ushort Crd, ushort pwmno, ushort on_off, double delay_value, ushort delay_mode, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_ahead_pwm_to_stop(ushort ConnectNo, ushort Crd, ushort bitno, ushort on_off, double ahead_value, ushort ahead_mode, double ReverseTime);
        [DllImport("LTSMC.dll")]
        public static extern short smc_conti_write_pwm(ushort ConnectNo, ushort Crd, ushort pwmno, ushort on_off, double ReverseTime);
        /*********************************************************************************************************
        位置比较 SMC104不支持
        *********************************************************************************************************/
        //单轴位置比较		
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_set_config(ushort ConnectNo, ushort axis, ushort enable, ushort cmp_source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_config(ushort ConnectNo, ushort axis, ref ushort enable, ref ushort cmp_source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_clear_points(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_add_point_unit(ushort ConnectNo, ushort axis, double pos, ushort dir, ushort action, uint actpara);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_current_point_unit(ushort ConnectNo, ushort axis, ref double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_points_runned(ushort ConnectNo, ushort axis, ref int pointNum);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_points_remained(ushort ConnectNo, ushort axis, ref int pointNum);
        //二维位置比较
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_set_config_extern(ushort ConnectNo, ushort enable, ushort cmp_source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_config_extern(ushort ConnectNo, ref ushort enable, ref ushort cmp_source);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_clear_points_extern(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_add_point_extern_unit(ushort ConnectNo, ushort[] axis, double[] pos, ushort[] dir, ushort action, uint actpara);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_current_point_extern_unit(ushort ConnectNo, ref double pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_points_runned_extern(ushort ConnectNo, ref int pointNum);
        [DllImport("LTSMC.dll")]
        public static extern short smc_compare_get_points_remained_extern(ushort ConnectNo, ref int pointNum);
        //高速位置比较
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_set_mode(ushort ConnectNo, ushort hcmp, ushort cmp_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_get_mode(ushort ConnectNo, ushort hcmp, ref ushort cmp_mode);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_set_config(ushort ConnectNo, ushort hcmp, ushort axis, ushort cmp_source, ushort cmp_logic, long time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_get_config(ushort ConnectNo, ushort hcmp, ref ushort axis, ref ushort cmp_source, ref ushort cmp_logic, ref int time);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_add_point_unit(ushort ConnectNo, ushort hcmp, double cmp_pos);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_set_liner_unit(ushort ConnectNo, ushort hcmp, double Increment, int Count);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_get_liner_unit(ushort ConnectNo, ushort hcmp, ref double Increment, ref int Count);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_get_current_state_unit(ushort ConnectNo, ushort hcmp, ref int remained_points, ref double current_point, ref int runned_points);
        [DllImport("LTSMC.dll")]
        public static extern short smc_hcmp_clear_points(ushort ConnectNo, ushort hcmp);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_cmp_pin(ushort ConnectNo, ushort axis);
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_cmp_pin(ushort ConnectNo, ushort axis, ushort on_off);
        /*********************************************************************************************************
        SMC104模拟量操作
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern double smc_get_ain(ushort ConnectNo, ushort channel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ain_action(ushort ConnectNo, ushort channel, ushort mode, double fvoltage, ushort action, double actpara);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ain_action(ushort ConnectNo, ushort channel, ref ushort mode, ref double fvoltage, ref ushort action, ref double actpara);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_ain_state(ushort ConnectNo, ushort channel);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_ain_state(ushort ConnectNo, ushort channel);
        /*********************************************************************************************************
        文件操作添加
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_download_file(ushort ConnectNo, byte[] pfilename, byte[] pfilenameinControl, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_download_memfile(ushort ConnectNo, byte[] pbuffer, uint buffsize, byte[] pfilenameinControl, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_upload_file(ushort ConnectNo, byte[] pfilename, byte[] pfilenameinControl, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_upload_memfile(ushort ConnectNo, byte[] pbuffer, uint buffsize, byte[] pfilenameinControl, ref uint puifilesize, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_download_file_to_ram(ushort ConnectNo, byte[] pfilename, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_download_memfile_to_ram(ushort ConnectNo, byte[] pbuffer, uint buffsize, ushort filetype);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_progress(ushort ConnectNo, ref float process);
        /*********************************************************************************************************
        寄存器操作
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_modbus_0x(ushort ConnectNo, ushort start, ushort inum, byte[] pdata);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_modbus_0x(ushort ConnectNo, ushort start, ushort inum, byte[] pdata);
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_modbus_4x(ushort ConnectNo, ushort start, ushort inum, ushort[] pdata);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_modbus_4x(ushort ConnectNo, ushort start, ushort inum, ushort[] pdata);
/*********************************************************************************************************
        掉电保存寄存器操作
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_set_persistent_reg(ushort ConnectNo, uint start, uint inum, byte[] pdata);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_persistent_reg(ushort ConnectNo, uint start, uint inum, byte[] pdata);        /*********************************************************************************************************
        Basic程序控制
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_array(ushort ConnectNo, byte[] name, uint index, long[] var, ref int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_modify_array(ushort ConnectNo, byte[] name, uint index, long[] var, int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_read_var(ushort ConnectNo, byte[] varstring, long[] var, ref int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_modify_var(ushort ConnectNo, byte[] varstring, long[] var, ref int varnum);
        [DllImport("LTSMC.dll")]
        public static extern short smc_write_array(ushort ConnectNo, byte[] name, uint startindex, long[] var, int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_get_stringtype(ushort ConnectNo, byte[] varstring, ref int m_Type, ref int num);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_run(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_stop(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_pause(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_step_run(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_step_over(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_continue_run(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_state(ushort ConnectNo, ref ushort State);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_current_line(ushort ConnectNo, ref uint line);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_break_info(ushort ConnectNo, uint[] line, uint linenum);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_message(ushort ConnectNo, byte[] pbuff, uint uimax, ref uint puiread);
        [DllImport("LTSMC.dll")]
        public static extern short smc_basic_command(ushort ConnectNo, byte[] pszCommand, byte[] psResponse, uint uiResponseLength);
        /*********************************************************************************************************
        G代码程序控制 SMC104不支持
        *********************************************************************************************************/
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_check_file(ushort ConnectNo, byte[] pfilenameinControl, ref byte pbIfExist, ref uint pFileSize);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_delete_file(ushort ConnectNo, byte[] pfilenameinControl);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_clear_file(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_get_first_file(ushort ConnectNo, byte[] pfilenameinControl, ref uint pFileSize);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_get_next_file(ushort ConnectNo, byte[] pfilenameinControl, ref uint pFileSize);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_start(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_stop(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_pause(ushort ConnectNo);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_state(ushort ConnectNo, ref ushort State);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_set_current_file(ushort ConnectNo, byte[] pFileName);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_get_current_file(ushort ConnectNo, byte[] pfilenameinControl);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_current_line(ushort ConnectNo, ref uint line, byte[] pCurLine);
        [DllImport("LTSMC.dll")]
        public static extern short smc_gcode_get_file_profile(ushort ConnectNo, ref uint maxfilenum, ref uint maxfilesize, ref uint savedfilenum);

    }
}
