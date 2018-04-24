namespace DataGather
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal class MXIO_CS
    {
        public const int ACTTAG_AI_0_10V = 20;
        public const int ACTTAG_AI_0_150MV = 0x11;
        public const int ACTTAG_AI_0_20MA = 15;
        public const int ACTTAG_AI_0_500MV = 0x12;
        public const int ACTTAG_AI_0_5V = 0x13;
        public const int ACTTAG_AI_10_10V = 14;
        public const int ACTTAG_AI_150_150MV = 11;
        public const int ACTTAG_AI_4_20MA = 0x10;
        public const int ACTTAG_AI_5_5V = 13;
        public const int ACTTAG_AI_500_500MV = 12;
        public const int ACTTAG_AI_DISABLE = 10;
        public const int ACTTAG_AO_0_10V = 0x1f;
        public const int ACTTAG_AO_0_20MA = 0x21;
        public const int ACTTAG_AO_0_5V = 0x23;
        public const int ACTTAG_AO_10_10V = 0x22;
        public const int ACTTAG_AO_4_20MA = 0x20;
        public const int ACTTAG_AO_DISABLE = 30;
        public const int ACTTAG_DI_CNT = 2;
        public const int ACTTAG_DI_DI = 0;
        public const int ACTTAG_DI_DI_DISABLE = 4;
        public const int ACTTAG_DO_DO = 1;
        public const int ACTTAG_DO_DO_DISABLE = 5;
        public const int ACTTAG_DO_PULSE = 3;
        public const int ACTTAG_E1210_ID = 0xe210;
        public const int ACTTAG_E1210T_ID = 80;
        public const int ACTTAG_E1211_ID = 0xe211;
        public const int ACTTAG_E1211T_ID = 0x51;
        public const int ACTTAG_E1212_ID = 0xe212;
        public const int ACTTAG_E1212T_ID = 0x52;
        public const int ACTTAG_E1213_ID = 0x5b;
        public const int ACTTAG_E1213T_ID = 0x5c;
        public const int ACTTAG_E1214_ID = 0xe214;
        public const int ACTTAG_E1214T_ID = 0x53;
        public const int ACTTAG_E1240_ID = 0xe240;
        public const int ACTTAG_E1240T_ID = 0x54;
        public const int ACTTAG_E1241_ID = 0xe241;
        public const int ACTTAG_E1241T_ID = 0x55;
        public const int ACTTAG_E1242_ID = 0xe242;
        public const int ACTTAG_E1242T_ID = 0x56;
        public const int ACTTAG_E1260_ID = 0xe260;
        public const int ACTTAG_E1260T_ID = 0x57;
        public const int ACTTAG_E1261_ID = 90;
        public const int ACTTAG_E1261H_ID = 0x340;
        public const int ACTTAG_E1261H_T_ID = 0x341;
        public const int ACTTAG_E1261T_ID = 0x59;
        public const int ACTTAG_E1262_ID = 0xe262;
        public const int ACTTAG_E1262T_ID = 0x58;
        public const int ACTTAG_E1263H_ID = 0x342;
        public const int ACTTAG_E1263H_T_ID = 0x343;
        public const int ACTTAG_E1510_ID = 0x220;
        public const int ACTTAG_E1510_T_ID = 0x221;
        public const int ACTTAG_E1512_ID = 0x222;
        public const int ACTTAG_E1512_T_ID = 0x223;
        public const int ACTTAG_E2210_ID = 0x2210;
        public const int ACTTAG_E2210_V2_ID = 0x2211;
        public const int ACTTAG_E2210T_ID = 0x150;
        public const int ACTTAG_E2212_ID = 0x2212;
        public const int ACTTAG_E2212T_ID = 0x151;
        public const int ACTTAG_E2214_ID = 0x2214;
        public const int ACTTAG_E2214T_ID = 0x152;
        public const int ACTTAG_E2240_ID = 0x2240;
        public const int ACTTAG_E2240_V2_ID = 0x2241;
        public const int ACTTAG_E2240T_ID = 0x153;
        public const int ACTTAG_E2242_ID = 0x2242;
        public const int ACTTAG_E2242T_ID = 340;
        public const int ACTTAG_E2260_ID = 0x2260;
        public const int ACTTAG_E2260T_ID = 0x155;
        public const int ACTTAG_E2262_ID = 0x2262;
        public const int ACTTAG_E2262T_ID = 0x156;
        public const int ACTTAG_E4200_ID = 0x4200;
        public const int ACTTAG_INDEX_CHABLE_OFSLOT = 0x451;
        public const int ACTTAG_INDEX_CHLOCK_OFSLOT = 0x14d1;
        public const int ACTTAG_INDEX_CHTYPE_OFSLOT = 0x31;
        public const int ACTTAG_INDEX_CHVALUE_OFSLOT = 0x4d1;
        public const int ACTTAG_INDEX_ID_OFSLOT = 0x431;
        public const int ACTTAG_INDEX_IP = 10;
        public const int ACTTAG_INDEX_LASTCH_OFSLOT = 0x21;
        public const int ACTTAG_INDEX_LASTSLOT = 0x20;
        public const int ACTTAG_INDEX_MAC = 14;
        public const int ACTTAG_INDEX_MODEL = 8;
        public const int ACTTAG_INDEX_MSGSUBTYPE = 0x15;
        public const int ACTTAG_INDEX_MSGTYPE = 20;
        public const int ACTTAG_INDEX_TIME_DAY = 0x1a;
        public const int ACTTAG_INDEX_TIME_HOUR = 0x1b;
        public const int ACTTAG_INDEX_TIME_MIN = 0x1c;
        public const int ACTTAG_INDEX_TIME_MONTH = 0x19;
        public const int ACTTAG_INDEX_TIME_MSEC = 30;
        public const int ACTTAG_INDEX_TIME_SEC = 0x1d;
        public const int ACTTAG_INDEX_TIME_YEAR = 0x17;
        public const int ACTTAG_IOPAC_8020_5_M12_C_ID = 0x202;
        public const int ACTTAG_IOPAC_8020_5_M12_C_T_ID = 0x182;
        public const int ACTTAG_IOPAC_8020_5_M12_IEC_ID = 0x206;
        public const int ACTTAG_IOPAC_8020_5_M12_IEC_T_ID = 390;
        public const int ACTTAG_IOPAC_8020_5_RJ45_C_ID = 0x201;
        public const int ACTTAG_IOPAC_8020_5_RJ45_C_T_ID = 0x181;
        public const int ACTTAG_IOPAC_8020_5_RJ45_IEC_ID = 0x205;
        public const int ACTTAG_IOPAC_8020_5_RJ45_IEC_T_ID = 0x185;
        public const int ACTTAG_IOPAC_8020_9_M12_C_ID = 0x204;
        public const int ACTTAG_IOPAC_8020_9_M12_C_T_ID = 0x184;
        public const int ACTTAG_IOPAC_8020_9_M12_IEC_ID = 520;
        public const int ACTTAG_IOPAC_8020_9_M12_IEC_T_ID = 0x188;
        public const int ACTTAG_IOPAC_8020_9_RJ45_C_ID = 0x203;
        public const int ACTTAG_IOPAC_8020_9_RJ45_C_T_ID = 0x183;
        public const int ACTTAG_IOPAC_8020_9_RJ45_IEC_ID = 0x207;
        public const int ACTTAG_IOPAC_8020_9_RJ45_IEC_T_ID = 0x187;
        public const int ACTTAG_IOPAC_8020_T_ID = 0x180;
        public const int ACTTAG_MSG_CONFIG = 3;
        public const int ACTTAG_MSG_HEARTBEAT = 2;
        public const int ACTTAG_MSG_IO_STATUS = 4;
        public const int ACTTAG_MSG_POWER_ON = 1;
        public const int ACTTAG_MSG_SUB_CLIENT_DISCONNECT = 3;
        public const int ACTTAG_MSG_SUB_HEARTBEAT_TIMEOUT = 1;
        public const int ACTTAG_MSG_SUB_READWRITE_TIMEOUT = 2;
        public const int ACTTAG_MSG_SUB_SERVER_DISCONNECT = 4;
        public const int ACTTAG_MSG_SYSTEM = 5;
        public const int ACTTAG_RLY_DO = 6;
        public const int ACTTAG_RLY_PULSE = 7;
        public const int ACTTAG_RTD_CU10_C = 0x73;
        public const int ACTTAG_RTD_CU10_F = 0x87;
        public const int ACTTAG_RTD_DISABLE = 100;
        public const int ACTTAG_RTD_JPT100_C = 0x6a;
        public const int ACTTAG_RTD_JPT100_F = 0x7e;
        public const int ACTTAG_RTD_JPT1000_C = 0x6d;
        public const int ACTTAG_RTD_JPT1000_F = 0x81;
        public const int ACTTAG_RTD_JPT200_C = 0x6b;
        public const int ACTTAG_RTD_JPT200_F = 0x7f;
        public const int ACTTAG_RTD_JPT500_C = 0x6c;
        public const int ACTTAG_RTD_JPT500_F = 0x80;
        public const int ACTTAG_RTD_NI100_C = 110;
        public const int ACTTAG_RTD_NI100_F = 130;
        public const int ACTTAG_RTD_NI1000_C = 0x71;
        public const int ACTTAG_RTD_NI1000_F = 0x85;
        public const int ACTTAG_RTD_NI120_C = 0x72;
        public const int ACTTAG_RTD_NI120_F = 0x86;
        public const int ACTTAG_RTD_NI200_C = 0x6f;
        public const int ACTTAG_RTD_NI200_F = 0x83;
        public const int ACTTAG_RTD_NI500_C = 0x70;
        public const int ACTTAG_RTD_NI500_F = 0x84;
        public const int ACTTAG_RTD_PT100_C = 0x66;
        public const int ACTTAG_RTD_PT100_F = 0x7a;
        public const int ACTTAG_RTD_PT1000_C = 0x69;
        public const int ACTTAG_RTD_PT1000_F = 0x7d;
        public const int ACTTAG_RTD_PT200_C = 0x67;
        public const int ACTTAG_RTD_PT200_F = 0x7b;
        public const int ACTTAG_RTD_PT50_C = 0x65;
        public const int ACTTAG_RTD_PT50_F = 0x79;
        public const int ACTTAG_RTD_PT500_C = 0x68;
        public const int ACTTAG_RTD_PT500_F = 0x7c;
        public const int ACTTAG_RTD_RESISTANCE_1_1250_ = 0x8f;
        public const int ACTTAG_RTD_RESISTANCE_1_2000_ = 0x91;
        public const int ACTTAG_RTD_RESISTANCE_1_2200_ = 0x90;
        public const int ACTTAG_RTD_RESISTANCE_1_310_ = 0x8d;
        public const int ACTTAG_RTD_RESISTANCE_1_327_ = 0x92;
        public const int ACTTAG_RTD_RESISTANCE_1_620_ = 0x8e;
        public const int ACTTAG_SYSTEM_CONNECTION = 0xff;
        public const int ACTTAG_TC_DISABLE = 50;
        public const int ACTTAG_TC_Type_B_C = 0x36;
        public const int ACTTAG_TC_Type_B_F = 0x4a;
        public const int ACTTAG_TC_Type_C_C = 0x3d;
        public const int ACTTAG_TC_Type_C_F = 0x51;
        public const int ACTTAG_TC_Type_D_C = 0x3e;
        public const int ACTTAG_TC_Type_D_F = 0x52;
        public const int ACTTAG_TC_Type_E_C = 0x39;
        public const int ACTTAG_TC_Type_E_F = 0x4d;
        public const int ACTTAG_TC_Type_J_C = 0x34;
        public const int ACTTAG_TC_Type_J_F = 0x48;
        public const int ACTTAG_TC_Type_K_C = 0x33;
        public const int ACTTAG_TC_Type_K_F = 0x47;
        public const int ACTTAG_TC_Type_L_C = 0x3b;
        public const int ACTTAG_TC_Type_L_F = 0x4f;
        public const int ACTTAG_TC_Type_N_C = 0x3a;
        public const int ACTTAG_TC_Type_N_F = 0x4e;
        public const int ACTTAG_TC_Type_R_C = 0x37;
        public const int ACTTAG_TC_Type_R_F = 0x4b;
        public const int ACTTAG_TC_Type_S_C = 0x38;
        public const int ACTTAG_TC_Type_S_F = 0x4c;
        public const int ACTTAG_TC_Type_T_C = 0x35;
        public const int ACTTAG_TC_Type_T_F = 0x49;
        public const int ACTTAG_TC_Type_U_C = 60;
        public const int ACTTAG_TC_Type_U_F = 80;
        public const int ACTTAG_TC_VOLTAGE_19_532MV = 0x5d;
        public const int ACTTAG_TC_VOLTAGE_32_7MV = 0x5f;
        public const int ACTTAG_TC_VOLTAGE_39_062MV = 0x5c;
        public const int ACTTAG_TC_VOLTAGE_65_5MV = 0x60;
        public const int ACTTAG_TC_VOLTAGE_78_126MV = 0x5b;
        public const int ACTTAG_TC_VOLTAGE_78MV = 0x5e;
        public const int ACTTAG_VIRTUAL_CH_AVG_C = 0xc9;
        public const int ACTTAG_VIRTUAL_CH_AVG_F = 0xcb;
        public const int ACTTAG_VIRTUAL_CH_DIF_C = 0xca;
        public const int ACTTAG_VIRTUAL_CH_DIF_F = 0xcc;
        public const int ACTTAG_VIRTUAL_CH_DISABLE = 0xce;
        public const int ACTTAG_VIRTUAL_CH_MCONNECT = 0xcd;
        public const int ACTTAG_VIRTUAL_CH_VALUE = 0xcf;
        public const int ACTTAG_W5312_HSDPA_ID = 0x107;
        public const int ACTTAG_W5312_HSDPA_JPN_ID = 0x10d;
        public const int ACTTAG_W5312_HSDPA_JPS_ID = 0x111;
        public const int ACTTAG_W5312_ID = 0x5312;
        public const int ACTTAG_W5312SLOT_ID = 0x103;
        public const int ACTTAG_W5312T_HSDPA_ID = 0x10a;
        public const int ACTTAG_W5312T_HSDPA_JPN_ID = 0x10f;
        public const int ACTTAG_W5312T_HSDPA_JPS_ID = 0x113;
        public const int ACTTAG_W5312TSLOT_ID = 0x101;
        public const int ACTTAG_W5340_AP_ID = 0x114;
        public const int ACTTAG_W5340_HSDPA_ID = 0x106;
        public const int ACTTAG_W5340_HSDPA_JPN_ID = 0x10c;
        public const int ACTTAG_W5340_HSDPA_JPS_ID = 0x110;
        public const int ACTTAG_W5340_ID = 0x5340;
        public const int ACTTAG_W5340SLOT_ID = 0x102;
        public const int ACTTAG_W5340T_HSDPA_ID = 0x109;
        public const int ACTTAG_W5340T_HSDPA_JPN_ID = 270;
        public const int ACTTAG_W5340T_HSDPA_JPS_ID = 0x112;
        public const int ACTTAG_W5340TSLOT_ID = 0x100;
        public const int ACTTAG_W5341_HSDPA_ID = 0x108;
        public const int ACTTAG_W5341SLOT_ID = 260;
        public const int ACTTAG_W5341T_HSDPA_ID = 0x10b;
        public const int ACTTAG_W5341TSLOT_ID = 0x105;
        public const int ACTTAG_W5348_GPRS_C_ID = 0x115;
        public const int ACTTAG_W5348_GPRS_C_T_ID = 0x119;
        public const int ACTTAG_W5348_GPRS_IEC_ID = 0x117;
        public const int ACTTAG_W5348_GPRS_IEC_T_ID = 0x11b;
        public const int ACTTAG_W5348_HSDPA_C_ID = 0x116;
        public const int ACTTAG_W5348_HSDPA_C_T_ID = 0x11a;
        public const int ACTTAG_W5348_HSDPA_IEC_ID = 280;
        public const int ACTTAG_W5348_HSDPA_IEC_T_ID = 0x11c;
        public const int ADD_INFO_TABLE_FAIL = 0x1389;
        public const int AOPC_SERVER = 0x100;
        public const int BIT_5 = 0;
        public const int BIT_6 = 1;
        public const int BIT_7 = 2;
        public const int BIT_8 = 3;
        public const int BUS_COMMUNICATION_FAULT = 2;
        public const int BUS_IDLE = 5;
        public const int BUS_INIT = 0;
        public const int BUS_INIT_FAULT = 2;
        public const int BUS_INIT_NET = 1;
        public const int BUS_IO = 3;
        public const int BUS_IO_FAULT = 4;
        public const int BUS_STANDYBY = 1;
        public const int CHANNEL_OUT_OF_RANGE = 0xfa4;
        public const int CHECK_CONNECTION_FAIL = 1;
        public const int CHECK_CONNECTION_OK = 0;
        public const int CHECK_CONNECTION_TIME_OUT = 2;
        public const int CHECKSUM_ERROR = 1;
        public const int CHECKSUM_NO_ERROR = 0;
        public const int COIL_INPUT = 2;
        public const int COIL_OUTPUT = 1;
        public const int COIL_TYPE_ERROR = 0xfa5;
        public const int CREATE_MUTEX_FAIL = 0xfac;
        public const int E1200_SERIES = 8;
        public const int E1500_SERIES = 0x40;
        public const int E2000_SERIES = 2;
        public const int E4000_SERIES = 1;
        public const int E4200_SERIES = 4;
        public const int EIO_CREATING_SOCKET_ERROR = 0x7d3;
        public const int EIO_INIT_SOCKETS_FAIL = 0x7d2;
        public const int EIO_PASSWORD_INCORRECT = 0x7d7;
        public const int EIO_RESPONSE_BAD = 0x7d4;
        public const int EIO_SOCKET_DISCONNECT = 0x7d5;
        public const int EIO_TIME_OUT = 0x7d1;
        public const int ENUM_NET_INTERFACE_FAIL = 0x1388;
        public const int EXPASION_COMBINATION_ERROR = 4;
        public const int EXPASION_COMMUNICATION_ERROR = 1;
        public const int EXPASION_MODBUS_ERROR = 2;
        public const int EXPASION_NETWORK_ERROR = 4;
        public const int EXPASION_NO_ERROR = 0;
        public const int EXPASION_OFFLINE = 0;
        public const int EXPASION_ONLINE = 1;
        public const int EXPASION_OUT_OF_MEMORY_ERROR = 5;
        public const int EXPASION_PENDING_ERROR = 3;
        public const int EXPASION_RETURN_MODBUS_EXCEPTION = 3;
        public const int EXPASION_UNMATCH_TYPE = 2;
        public const int FIELD_POWER_OFF = 1;
        public const int FIELD_POWER_ON = 0;
        public const int FIRMWARE_NOT_SUPPORT = 0xfab;
        public const int FUNCTION_NOT_SUPPORT = 0xfa7;
        public const int HANDLE_ERROR = 0xfa2;
        public const int HIGH_LIMIT = 3;
        public const int HOLD_LAST_STATE = 1;
        public const int ILLEGAL_DATA_ADDRESS = 0x3ea;
        public const int ILLEGAL_DATA_VALUE = 0x3eb;
        public const int ILLEGAL_FUNCTION = 0x3e9;
        public const int INPUT_VALUE_OUT_OF_RANGE = 0xfa9;
        public const int LOW_LIMIT = 2;
        public const int M2K_AI_RANGE_0_10V = 9;
        public const int M2K_AI_RANGE_0_150mv = 6;
        public const int M2K_AI_RANGE_0_20mA = 4;
        public const int M2K_AI_RANGE_0_500mv = 7;
        public const int M2K_AI_RANGE_0_5V = 8;
        public const int M2K_AI_RANGE_10V = 3;
        public const int M2K_AI_RANGE_150mv = 0;
        public const int M2K_AI_RANGE_4_20mA = 5;
        public const int M2K_AI_RANGE_500mv = 1;
        public const int M2K_AI_RANGE_5V = 2;
        public const int MODBUS_ASCII = 1;
        public const int MODBUS_RTU = 0;
        public const int MX_IF_INDEX_DESC = 0x1a;
        public const int MX_IF_INDEX_IP = 4;
        public const int MX_IF_INDEX_MAC = 20;
        public const int MX_IF_INDEX_NUM = 0;
        public const int MX_IF_ONE_IF_SIZE = 0x11a;
        public const int MX_ML_INDEX_BYTLANUSE = 0x2e;
        public const int MX_ML_INDEX_SZIP0 = 2;
        public const int MX_ML_INDEX_SZIP1 = 0x18;
        public const int MX_ML_INDEX_SZMAC0 = 0x12;
        public const int MX_ML_INDEX_SZMAC1 = 40;
        public const int MX_ML_INDEX_WHWID = 0;
        public const int MX_ML_MODULE_LIST_SIZE = 0x2f;
        public const int MXIO_OK = 0;
        public const int NO_EXPANSION_SLOT = 4;
        public const int NORMAL_OPERATION = 0;
        public const int OUTPUT_VALUE_OUT_OF_RANGE = 0xfa8;
        public const int P_EVEN = 0x18;
        public const int P_MRK = 40;
        public const int P_NONE = 0;
        public const int P_ODD = 8;
        public const int P_SPC = 0x38;
        public const int PRODUCT_NOT_SUPPORT = 0xfa1;
        public const int PROTOCOL_TCP = 1;
        public const int PROTOCOL_TYPE_ERROR = 0x7d6;
        public const int PROTOCOL_UDP = 2;
        public const int REGISTER_INPUT = 4;
        public const int REGISTER_OUTPUT = 3;
        public const int REGISTER_TYPE_ERROR = 0xfa6;
        public const int SAFE_VALUE = 0;
        public const int SETUP_ERROR = 1;
        public const int SETUP_NO_ERROR = 0;
        public const int SIO_BAUDRATE_NOT_SUPPORT = 0xbc5;
        public const int SIO_CLEAR_COMM_FAIL = 0xbc2;
        public const int SIO_CLOSE_FAIL = 0xbbb;
        public const int SIO_FLUSH_FILE_BUFFERS_FAIL = 0xbbd;
        public const int SIO_GET_COMM_STATE_FAIL = 0xbbe;
        public const int SIO_OPEN_FAIL = 0xbb9;
        public const int SIO_PURGE_COMM_FAIL = 0xbbc;
        public const int SIO_RESPONSE_BAD = 0xbc3;
        public const int SIO_SET_COMM_STATE_FAIL = 0xbbf;
        public const int SIO_SET_COMM_TIME_OUT_FAIL = 0xbc1;
        public const int SIO_SETUP_COMM_FAIL = 0xbc0;
        public const int SIO_TIME_OUT = 0xbba;
        public const int SIO_TRANSMISSION_MODE_ERROR = 0xbc4;
        public const int SLAVE_DEVICE_BUSY = 0x3ee;
        public const int SLAVE_DEVICE_FAILURE = 0x3ec;
        public const int SLOT_CONFIGURATION_FAILED = 3;
        public const int SLOT_NOT_EXIST = 0xfaa;
        public const int SLOT_OUT_OF_RANGE = 0xfa3;
        public const int STOP_1 = 0;
        public const int STOP_2 = 4;
        public const int SUPPORT_MAX_CHANNEL = 0x40;
        public const int SUPPORT_MAX_SLOT = 0x10;
        public const int SupportMaxChOfBit = 8;
        public const int TABLE_NET_INTERFACE_FAIL = 0x138b;
        public const int TYPE_GPRS = 1;
        public const int TYPE_HSDPA = 2;
        public const int TYPE_WIDE_TEMP = 1;
        public const int UNKNOWN_NET_INTERFACE_FAIL = 0x138a;
        public const int W5000_SERIES = 0x10;
        public const int WATCHDOG_ERROR = 1;
        public const int WATCHDOG_NO_ERROR = 0;

        [DllImport("MXIO_NET.dll")]
        public static extern int Adp4K_ClearStatus(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int Adp4K_ReadAlarmedSlot(int hConnection, uint[] dwAlarm);
        [DllImport("MXIO_NET.dll")]
        public static extern int Adp4K_ReadFirmwareDate(int hConnection, ushort[] wDate);
        [DllImport("MXIO_NET.dll")]
        public static extern int Adp4K_ReadFirmwareRevision(int hConnection, ushort[] wRevision);
        [DllImport("MXIO_NET.dll")]
        public static extern int Adp4K_ReadSlotAmount(int hConnection, ushort[] wAmount);
        [DllImport("MXIO_NET.dll")]
        public static extern int Adp4K_ReadStatus(int hConnection, ushort[] wBusStatus, ushort[] wFPStatus, ushort[] wEWStatus, ushort[] wESStatus, ushort[] wECStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI_Read(int hConnection, byte bytSlot, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI_ReadRaw(int hConnection, byte bytSlot, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI_ReadRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_GetChannelStatus(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_GetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_GetRange(int hConnection, byte bytChannel, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_GetRanges(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ReadMax(int hConnection, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ReadMaxRaw(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ReadMaxRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ReadMaxs(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ReadMin(int hConnection, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ReadMinRaw(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ReadMinRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ReadMins(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ResetMax(int hConnection, byte bytChannel);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ResetMaxs(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ResetMin(int hConnection, byte bytChannel);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_ResetMins(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_SetChannelStatus(int hConnection, byte bytChannel, ushort wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_SetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_SetRange(int hConnection, byte bytChannel, ushort wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int AI2K_SetRanges(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_GetSafeRaw(int hConnection, byte bytSlot, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_GetSafeRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_GetSafeValue(int hConnection, byte bytSlot, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_GetSafeValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_Read(int hConnection, byte bytSlot, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_ReadRaw(int hConnection, byte bytSlot, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_ReadRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_SetSafeRaw(int hConnection, byte bytSlot, byte bytChannel, ushort wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_SetSafeRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_SetSafeValue(int hConnection, byte bytSlot, byte bytChannel, double dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_SetSafeValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_Write(int hConnection, byte bytSlot, byte bytChannel, double dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_WriteRaw(int hConnection, byte bytSlot, byte bytChannel, ushort wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_WriteRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO_Writes(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_GetPowerOnRaw(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_GetPowerOnRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_GetPowerOnValue(int hConnection, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_GetRange(int hConnection, byte bytChannel, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_GetRanges(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_SetPowerOnRaw(int hConnection, byte bytChannel, ushort wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_SetPowerOnRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_SetPowerOnValue(int hConnection, byte bytChannel, double dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_SetRange(int hConnection, byte bytChannel, ushort wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO2K_SetRanges(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO4K_GetSafeAction(int hConnection, byte bytSlot, byte bytChannel, ushort[] wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO4K_GetSafeActions(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO4K_SetSafeAction(int hConnection, byte bytSlot, byte bytChannel, ushort wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int AO4K_SetSafeActions(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_Clear(int hConnection, byte bytChannel);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_ClearOverflow(int hConnection, byte bytChannel);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_ClearOverflows(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_Clears(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetFilter(int hConnection, byte bytChannel, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetOverflow(int hConnection, byte bytChannel, byte[] bytStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetOverflows(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetPowerOnValue(int hConnection, byte bytChannel, byte[] bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetSafeValue(int hConnection, byte bytChannel, byte[] bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetSaveStatusesOnPowerFail(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetStartStatus(int hConnection, byte bytChannel, byte[] bytStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetTriggerType(int hConnection, byte bytChannel, byte[] bytType);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetTriggerTypes(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwType);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetTriggerTypeWord(int hConnection, byte bytChannel, ushort[] wType);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_GetTriggerTypeWords(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wType);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_Read(int hConnection, byte bytChannel, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_Reads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetFilter(int hConnection, byte bytChannel, ushort wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetPowerOnValue(int hConnection, byte bytChannel, byte bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetSafeValue(int hConnection, byte bytChannel, byte bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetSaveStatusesOnPowerFail(int hConnection, byte bytStartChannel, byte bytCount, uint dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetStartStatus(int hConnection, byte bytChannel, byte bytStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetTriggerType(int hConnection, byte bytChannel, byte bytType);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetTriggerTypes(int hConnection, byte bytStartChannel, byte bytCount, uint dwType);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetTriggerTypeWord(int hConnection, byte bytChannel, ushort wType);
        [DllImport("MXIO_NET.dll")]
        public static extern int Cnt2K_SetTriggerTypeWords(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wType);
        [DllImport("MXIO_NET.dll")]
        public static extern int DI_Read(int hConnection, byte bytSlot, byte bytChannel, byte[] bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DI_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DI2K_GetFilter(int hConnection, byte bytChannel, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int DI2K_GetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int DI2K_GetMode(int hConnection, byte bytChannel, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DI2K_GetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DI2K_SetFilter(int hConnection, byte bytChannel, ushort wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int DI2K_SetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int DI2K_SetMode(int hConnection, byte bytChannel, ushort wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DI2K_SetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DIO2K_GetIOMode(int hConnection, byte bytChannel, byte[] bytMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DIO2K_GetIOModes(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DIO2K_SetIOMode(int hConnection, byte bytChannel, byte bytMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DIO2K_SetIOModes(int hConnection, byte bytStartChannel, byte bytCount, uint dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO_GetSafeValue(int hConnection, byte bytSlot, byte bytChannel, byte[] bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO_GetSafeValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO_GetSafeValues_W(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValues);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO_Read(int hConnection, byte bytSlot, byte bytChannel, byte[] bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO_SetSafeValue(int hConnection, byte bytSlot, byte bytChannel, byte bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO_SetSafeValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO_SetSafeValues_W(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValues);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO_Write(int hConnection, byte bytSlot, byte bytChannel, byte bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO_Writes(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO2K_GetMode(int hConnection, byte bytChannel, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO2K_GetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO2K_GetPowerOnSeqDelaytimes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO2K_GetPowerOnValue(int hConnection, byte bytChannel, byte[] bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO2K_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO2K_SetMode(int hConnection, byte bytChannel, ushort wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO2K_SetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO2K_SetPowerOnSeqDelaytimes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO2K_SetPowerOnValue(int hConnection, byte bytChannel, byte bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO2K_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO4K_GetSafeAction(int hConnection, byte bytSlot, byte bytChannel, ushort[] wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO4K_GetSafeActions(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO4K_SetSafeAction(int hConnection, byte bytSlot, byte bytChannel, ushort wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int DO4K_SetSafeActions(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_GetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_GetRanges(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_ReadMaxRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_ReadMaxs(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_ReadMinRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_ReadMins(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_ReadRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_Reads(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_ResetMaxs(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_ResetMins(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AI_SetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_GetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_GetPowerOnRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_GetRanges(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_GetSafeRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_GetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_ReadRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_Reads(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_SetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_SetPowerOnRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_SetRanges(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_SetSafeRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_SetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_WriteRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_AO_Writes(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_ClearSafeStatus(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_ClearOverflows(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_Clears(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_GetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_GetOverflows(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_GetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_GetSaveStatusesOnPowerFail(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_GetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_GetTriggerTypeWords(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wType);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_Reads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_SetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_SetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_SetSaveStatusesOnPowerFail(int hConnection, byte bytStartChannel, byte bytCount, uint dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_SetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Cnt_SetTriggerTypeWords(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wType);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DI_GetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DI_GetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DI_Reads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DI_SetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DI_SetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DIO_GetIOModes(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DIO_SetIOModes(int hConnection, byte bytStartChannel, byte bytCount, uint dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DO_GetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DO_GetPowerOnSeqDelaytimes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DO_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DO_GetSafeValues_W(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DO_Reads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DO_SetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DO_SetPowerOnSeqDelaytimes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DO_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DO_SetSafeValues_W(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_DO_Writes(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_GetSafeStatus(int hConnection, ushort[] wStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Pulse_GetOutputCounts(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwOutputCounts);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Pulse_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Pulse_GetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Pulse_GetSignalWidths(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wHiWidth, ushort[] wLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Pulse_GetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Pulse_SetOutputCounts(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwOutputCounts);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Pulse_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Pulse_SetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Pulse_SetSignalWidths(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wHiWidth, ushort[] wLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_Pulse_SetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RLY_TotalCntReads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_GetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_GetEngUnits(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_GetSensorTypes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_ReadMaxRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_ReadMaxs(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_ReadMinRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_ReadMins(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_ReadRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_Reads(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_ResetMaxs(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_ResetMins(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_SetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_SetEngUnits(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_RTD_SetSensorTypes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_GetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_GetEngUnits(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_GetSensorTypes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_ReadMaxRaws(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_ReadMaxs(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_ReadMinRaws(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_ReadMins(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_ReadRaws(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_Reads(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_ResetMaxs(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_ResetMins(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_SetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_SetEngUnits(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int E1K_TC_SetSensorTypes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AI_ReadRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AI_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AO_GetFaultValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AO_GetPowerOnValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AO_GetSafeActions(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AO_ReadRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AO_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AO_SetFaultValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AO_SetPowerOnValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AO_SetSafeActions(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AO_WriteRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_AO_Writes(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_ClearSafeStatus(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_ClearStatus(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_DI_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_DO_GetFaultValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_DO_GetPowerOnValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_DO_GetSafeActions(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint[] wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_DO_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_DO_SetFaultValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_DO_SetPowerOnValues(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_DO_SetSafeActions(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint wAction);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_DO_Writes(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_GetInternalRegs(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_GetIOMapMode(int hConnection, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_GetWorkInternalRegs(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_Logic_GetStartStatus(int hConnection, ushort[] wStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_Logic_SetStartStatus(int hConnection, ushort wStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_Message_Start(int iProtocol, ushort wPort, pfnCALLBACK iProcAddress);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_Message_Stop(int iProtocol);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_Modbus_List(int hConnection, byte[] FilePath);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_ReadFirmwareDate(int hConnection, ushort[] wDate);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_ReadFirmwareRevision(int hConnection, byte[] bytRevision);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_ReadSlotAmount(int hConnection, ushort[] wAmount);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_ReadStatus(int hConnection, ushort[] wState, ushort[] wLastErrorCode);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_RTD_GetEngUnit(int hConnection, byte bytSlot, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_RTD_GetSensorType(int hConnection, byte bytSlot, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_RTD_ReadRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_RTD_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_RTD_SetEngUnit(int hConnection, byte bytSlot, ushort wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_RTD_SetSensorType(int hConnection, byte bytSlot, ushort wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_SetInternalRegs(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_SetIOMapMode(int hConnection, ushort wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_SetWorkInternalRegs(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_TC_GetEngUnit(int hConnection, byte bytSlot, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_TC_GetSensorType(int hConnection, byte bytSlot, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_TC_ReadRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_TC_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_TC_SetEngUnit(int hConnection, byte bytSlot, ushort wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int E42_TC_SetSensorType(int hConnection, byte bytSlot, ushort wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int Logic2K_GetStartStatus(int hConnection, ushort[] wStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Logic2K_SetStartStatus(int hConnection, ushort wStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Message2K_Start(int iProtocol, ushort wPort, pfnCALLBACK iProcAddress);
        [DllImport("MXIO_NET.dll")]
        public static extern int Message2K_Stop(int iProtocol);
        [DllImport("MXIO_NET.dll")]
        public static extern int Module2K_ClearSafeStatus(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int Module2K_GetInternalReg(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Module2K_GetInternalRegs(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Module2K_GetSafeStatus(int hConnection, ushort[] wStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Module2K_SetInternalReg(int hConnection, byte bytChannel, ushort wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Module2K_SetInternalRegs(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXEIO_CheckConnection(int hConnection, uint dwTimeOut, byte[] bytStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXEIO_Connect(byte[] szIP, ushort wPort, uint dwTimeOut, out int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXEIO_Connect(byte[] szIP, ushort wPort, uint dwTimeOut, int[] hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXEIO_Disconnect(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXEIO_E1K_Connect(byte[] szIP, ushort wPort, uint dwTimeOut, int[] hConnection, byte[] szPassword);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXEIO_E1K_Connect(byte[] szIP, ushort wPort, uint dwTimeOut, out int hConnection, byte[] szPassword);
        [DllImport("MXIO_NET.dll")]
        public static extern void MXEIO_Exit();
        [DllImport("MXIO_NET.dll")]
        public static extern int MXEIO_Init();
        [DllImport("MXIO_NET.dll")]
        public static extern int MXEIO_W5K_Connect(byte[] szIP, ushort wPort, uint dwTimeOut, out int hConnection, byte[] szMACAddr);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXEIO_W5K_Connect(byte[] szIP, ushort wPort, uint dwTimeOut, int[] hConnection, byte[] szMACAddr);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_AutoSearch(uint nType, uint nRetryCount, uint nTimeout, uint[] nNumber, byte[] struML);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_ChangeDupIP(byte[] szIP, ushort wPort, byte[] szMACAddr, uint dwTimeOut, byte[] szPassword, byte[] szNewIP);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_Close_ActiveTag();
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_Connect_ActiveTag(uint dwTimeOut, out int hConnection, byte[] szMACAddr, ushort wPort, byte[] szPassword);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_Connect_ActiveTag(uint dwTimeOut, int[] hConnection, byte[] szMACAddr, ushort wPort, byte[] szPassword);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_GetDevsInfo_ActiveTag(ushort wDeviceCount, byte[] szDeviceInfo);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_GetDllBuildDate();
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_GetDllVersion();
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_GetIFInfo(ushort wIFCount, byte[] szIFInfo);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_GetModuleType(int hConnection, byte bytSlot, ushort[] wType);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_GetSubType(int hConnection, byte bytSlot, uint[] dwSubType);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_Init_ActiveTag_Ex(ushort wDataPort, ushort wCmdPort, uint dwToleranceTimeout, uint dwCmdTimeout, pfnCALLBACK iProcAddress, ushort wSize);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_ListDevs_ActiveTag(ushort[] wDeviceCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_ListIF(ushort[] wDeviceCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_ReadCoils(int hConnection, byte bytCoilType, ushort wStartCoil, ushort wCount, byte[] bytCoils);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_ReadCoils_Ex(int hConnection, byte bytCoilType, ushort wStartCoil, ushort wCount, byte[] bytCoils);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_ReadFirmwareDate(int hConnection, ushort[] wDate);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_ReadFirmwareRevision(int hConnection, byte[] bytRevision);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_ReadRegs(int hConnection, byte bytRegisterType, ushort wStartRegister, ushort wCount, ushort[] wRegister);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_ReadRegs_Ex(int hConnection, byte bytRegisterType, ushort wStartRegister, ushort wCount, ushort[] wRegister);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_RelLock_ActiveTag();
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_Reset(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_Restart(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_SelectIF(ushort wIFCount, byte[] szIFInfo, uint dwIFIndex);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_WriteCoils(int hConnection, ushort wStartCoil, ushort wCount, byte[] bytCoils);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_WriteCoils_Ex(int hConnection, ushort wStartCoil, ushort wCount, byte[] bytCoils);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_WriteRegs(int hConnection, ushort wStartRegister, ushort wCount, ushort[] wRegister);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXIO_WriteRegs_Ex(int hConnection, ushort wStartRegister, ushort wCount, ushort[] wRegister);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXSIO_CloseCommport(int hCommport);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXSIO_Connect(int hCommport, byte bytUnitID, byte bytTransmissionMode, out int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXSIO_Connect(int hCommport, byte bytUnitID, byte bytTransmissionMode, int[] hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXSIO_Disconnect(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int MXSIO_OpenCommport(byte[] szCommport, uint dwBaudrate, byte bytDataFormat, uint dwTimeout, int[] hCommport);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetOutputCount(int hConnection, byte bytChannel, uint[] dwOutputCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetOutputCounts(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwOutputCounts);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetPowerOnValue(int hConnection, byte bytChannel, byte[] bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetSafeValue(int hConnection, byte bytChannel, byte[] bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetSignalWidth(int hConnection, byte bytChannel, ushort[] wHiWidth, ushort[] wLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetSignalWidth32(int hConnection, byte bytChannel, uint[] dwHiWidth, uint[] dwLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetSignalWidths(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wHiWidth, ushort[] wLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetSignalWidths32(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwHiWidth, uint[] dwLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetStartStatus(int hConnection, byte bytChannel, byte[] bytStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_GetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetOutputCount(int hConnection, byte bytChannel, uint dwOutputCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetOutputCounts(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwOutputCounts);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetPowerOnValue(int hConnection, byte bytChannel, byte bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetSafeValue(int hConnection, byte bytChannel, byte bytValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetSignalWidth(int hConnection, byte bytChannel, ushort wHiWidth, ushort wLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetSignalWidth32(int hConnection, byte bytChannel, uint dwHiWidth, uint dwLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetSignalWidths(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wHiWidth, ushort[] wLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetSignalWidths32(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwHiWidth, uint[] dwLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetStartStatus(int hConnection, byte bytChannel, byte bytStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int Pulse2K_SetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int RLY2K_CurrentCntRead(int hConnection, byte bytChannel, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RLY2K_CurrentCntReads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RLY2K_GetResetTime(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RLY2K_ResetCnt(int hConnection, byte bytChannel);
        [DllImport("MXIO_NET.dll")]
        public static extern int RLY2K_ResetCnts(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int RLY2K_TotalCntRead(int hConnection, byte bytChannel, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RLY2K_TotalCntReads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD_Read(int hConnection, byte bytSlot, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD_ReadRaw(int hConnection, byte bytSlot, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD_ReadRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_GetChannelStatus(int hConnection, byte bytChannel, byte[] bytStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_GetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_GetEngUnit(int hConnection, byte bytChannel, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_GetEngUnits(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_GetMathPar(int hConnection, byte bytChannel, ushort[] wMathPar);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_GetMathPars(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMathPar);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_GetSensorType(int hConnection, byte bytChannel, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_GetSensorTypes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ReadMax(int hConnection, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ReadMaxRaw(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ReadMaxRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ReadMaxs(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ReadMin(int hConnection, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ReadMinRaw(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ReadMinRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ReadMins(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ResetMax(int hConnection, byte bytChannel);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ResetMaxs(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ResetMin(int hConnection, byte bytChannel);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_ResetMins(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_SetChannelStatus(int hConnection, byte bytChannel, byte bytStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_SetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_SetChnAvg(int hConnection, byte bytChannel, byte[] bytChnIdx, byte bytChCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_SetChnDev(int hConnection, byte bytChannel, byte bytChMinued, byte bytChSub);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_SetEngUnit(int hConnection, byte bytChannel, ushort wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_SetEngUnits(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_SetMathPar(int hConnection, byte bytChannel, ushort wMathPar);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_SetMathPars(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMathPar);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_SetSensorType(int hConnection, byte bytChannel, ushort wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int RTD2K_SetSensorTypes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC_Read(int hConnection, byte bytSlot, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC_ReadRaw(int hConnection, byte bytSlot, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC_ReadRaws(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC_Reads(int hConnection, byte bytSlot, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_GetChannelStatus(int hConnection, byte bytChannel, byte[] bytStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_GetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_GetEngUnit(int hConnection, byte bytChannel, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_GetEngUnits(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_GetMathPar(int hConnection, byte bytChannel, ushort[] wMathPar);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_GetMathPars(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMathPar);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_GetSensorType(int hConnection, byte bytChannel, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_GetSensorTypes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ReadMax(int hConnection, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ReadMaxRaw(int hConnection, byte bytChannel, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ReadMaxRaws(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ReadMaxs(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ReadMin(int hConnection, byte bytChannel, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ReadMinRaw(int hConnection, byte bytChannel, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ReadMinRaws(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ReadMins(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ReadRaw(int hConnection, byte bytChannel, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ReadRaws(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ResetMax(int hConnection, byte bytChannel);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ResetMaxs(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ResetMin(int hConnection, byte bytChannel);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_ResetMins(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_SetChannelStatus(int hConnection, byte bytChannel, byte bytStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_SetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_SetChnAvg(int hConnection, byte bytChannel, byte[] bytChnIdx, byte bytChCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_SetChnDev(int hConnection, byte bytChannel, byte bytChMinued, byte bytChSub);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_SetEngUnit(int hConnection, byte bytChannel, ushort wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_SetEngUnits(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wEngUnit);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_SetMathPar(int hConnection, byte bytChannel, ushort wMathPar);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_SetMathPars(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMathPar);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_SetSensorType(int hConnection, byte bytChannel, ushort wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int TC2K_SetSensorTypes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wSensorType);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_GetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_GetRanges(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_GetRanges_Ex(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wRange, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ReadMaxRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ReadMaxRaws_Ex(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ReadMaxs(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ReadMaxs_Ex(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ReadMinRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ReadMinRaws_Ex(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ReadMins(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ReadMins_Ex(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ReadRaws(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ReadRaws_Ex(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_Reads(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_Reads_Ex(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ResetMaxs(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_ResetMins(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_SetChannelStatuses(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_AI_SetRanges(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wRange);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_ClearSafeStatus(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_ClearOverflows(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_Clears(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_Clears_Ex(int hConnection, byte bytStartChannel, byte bytCount, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_GetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_GetOverflows(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_GetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_GetSaveStatusesOnPowerFail(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_GetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_GetTriggerTypeWords(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wType);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_Reads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_Reads_Ex(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_SetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_SetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_SetSaveStatusesOnPowerFail(int hConnection, byte bytStartChannel, byte bytCount, uint dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_SetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Cnt_SetTriggerTypeWords(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wType);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DI_GetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DI_GetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DI_GetModes_Ex(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DI_Reads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DI_Reads_Ex(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DI_SetFilters(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wFilter);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DI_SetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DIO_GetIOModes(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DIO_GetIOModes_Ex(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwMode, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DIO_SetIOModes(int hConnection, byte bytStartChannel, byte bytCount, uint dwMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_GetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_GetModes_Ex(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_GetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_Reads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_Reads_Ex(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_SetModes(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wMode);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_SetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_Writes(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_DO_Writes_Ex(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Exp_Reconnect(int hConnection);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Exp_Status(int hConnection, ushort[] wState);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_GetCallerID(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_GetGprsSignal(int hConnection, ushort[] wSignal);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_GetInternalRegs(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_GetOpcDevicesInfo(byte[] szIP, uint dwTimeOut, ushort wDeviceCount, byte[] szDeviceInfo);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_GetOpcHostName(byte[] szIP, uint dwTimeOut, byte[] szAliasName);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_GetSafeStatus(int hConnection, ushort[] wStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_GetWorkInternalRegs(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_ListOpcDevices(byte[] szIP, uint dwTimeOut, ushort[] wDeviceCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Logic_GetStartStatus(int hConnection, ushort[] wStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Logic_SetStartStatus(int hConnection, ushort wStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Message_Start(int iProtocol, ushort wPort, pfnCALLBACK iProcAddress);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Message_Stop(int iProtocol);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Modbus_List(int hConnection, byte[] FilePath);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_GetOutputCounts(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwOutputCounts);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_GetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_GetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_GetSignalWidths32(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwHiWidth, uint[] dwLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_GetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_GetStartStatuses_Ex(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwStatus, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_SetOutputCounts(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwOutputCounts);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_SetPowerOnValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_SetSafeValues(int hConnection, byte bytStartChannel, byte bytCount, uint dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_SetSignalWidths32(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwHiWidth, uint[] dwLoWidth);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_SetStartStatuses(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_Pulse_SetStartStatuses_Ex(int hConnection, byte bytStartChannel, byte bytCount, uint dwStatus, byte bytSlot);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_ReadLastSlotIndex(int hConnection, ushort[] wAmount);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_ReadSlotAmount(int hConnection, ushort[] wAmount);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_ReadStatus(int hConnection, ushort[] wState, ushort[] wLastErrorCode);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_RLY_CurrentCntReads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_RLY_GetResetTime(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_RLY_ResetCnts(int hConnection, byte bytStartChannel, byte bytCount);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_RLY_TotalCntReads(int hConnection, byte bytStartChannel, byte bytCount, uint[] dwValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_SetCallerID(int hConnection, byte bytChannel, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_SetInternalRegs(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_SetWorkInternalRegs(int hConnection, byte bytStartChannel, byte bytCount, ushort[] wValue);
        [DllImport("MXIO_NET.dll")]
        public static extern int W5K_VC_Reads_Ex(int hConnection, byte bytStartChannel, byte bytCount, double[] dValue, byte bytSlot);

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct _ACTDEV_IO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
            public byte[] BytSrcMAC;
            public int iHandle;
        }

        [StructLayout(LayoutKind.Explicit, Size=4, Pack=1)]
        public struct _ANALOG_VAL
        {
            [FieldOffset(0)]
            public byte BytVal_0;
            [FieldOffset(1)]
            public byte BytVal_1;
            [FieldOffset(2)]
            public byte BytVal_2;
            [FieldOffset(3)]
            public byte BytVal_3;
            [FieldOffset(0)]
            public float fVal;
            [FieldOffset(0)]
            public uint iVal;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct _IOLOGIKSTRUCT
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
            public byte[] BytMagic;
            public ushort wVersion;
            public ushort wLength;
            public ushort wHWID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
            public byte[] dwSrcIP;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
            public byte[] BytSrcMAC;
            public byte BytMsgType;
            public ushort wMsgSubType;
            public ushort wYear;
            public byte BytMonth;
            public byte BytDay;
            public byte BytHour;
            public byte BytMin;
            public byte BytSec;
            public ushort wMSec;
            public byte BytLastSlot;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x10)]
            public byte[] BytLastCh;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x400)]
            public byte[] BytChType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x10)]
            public ushort[] wSlotID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x80)]
            public byte[] BytChNumber;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x400)]
            public MXIO_CS._ANALOG_VAL[] dwChValue;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x80)]
            public byte[] BytChLocked;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct _MODULE_LIST
        {
            public ushort nModuleID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x10)]
            public byte[] szModuleIP;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
            public byte[] szMAC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x10)]
            public byte[] szModuleIP1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
            public byte[] szMAC1;
            public byte bytLanUse;
        }

        [Flags]
        public enum MXIO_ActiveTagChType
        {
            ACTTAG_AI_0_10V = 20,
            ACTTAG_AI_0_150MV = 0x11,
            ACTTAG_AI_0_20MA = 15,
            ACTTAG_AI_0_500MV = 0x12,
            ACTTAG_AI_0_5V = 0x13,
            ACTTAG_AI_10_10V = 14,
            ACTTAG_AI_150_150MV = 11,
            ACTTAG_AI_4_20MA = 0x10,
            ACTTAG_AI_5_5V = 13,
            ACTTAG_AI_500_500MV = 12,
            ACTTAG_AI_DISABLE = 10,
            ACTTAG_AO_0_10V = 0x1f,
            ACTTAG_AO_0_20MA = 0x21,
            ACTTAG_AO_0_5V = 0x23,
            ACTTAG_AO_10_10V = 0x22,
            ACTTAG_AO_4_20MA = 0x20,
            ACTTAG_AO_DISABLE = 30,
            ACTTAG_DI_CNT = 2,
            ACTTAG_DI_DI = 0,
            ACTTAG_DI_DI_DISABLE = 4,
            ACTTAG_DO_DO = 1,
            ACTTAG_DO_DO_DISABLE = 5,
            ACTTAG_DO_PULSE = 3,
            ACTTAG_RLY_DO = 6,
            ACTTAG_RLY_PULSE = 7,
            ACTTAG_RTD_CU10_C = 0x73,
            ACTTAG_RTD_CU10_F = 0x87,
            ACTTAG_RTD_DISABLE = 100,
            ACTTAG_RTD_JPT100_C = 0x6a,
            ACTTAG_RTD_JPT100_F = 0x7e,
            ACTTAG_RTD_JPT1000_C = 0x6d,
            ACTTAG_RTD_JPT1000_F = 0x81,
            ACTTAG_RTD_JPT200_C = 0x6b,
            ACTTAG_RTD_JPT200_F = 0x7f,
            ACTTAG_RTD_JPT500_C = 0x6c,
            ACTTAG_RTD_JPT500_F = 0x80,
            ACTTAG_RTD_NI100_C = 110,
            ACTTAG_RTD_NI100_F = 130,
            ACTTAG_RTD_NI1000_C = 0x71,
            ACTTAG_RTD_NI1000_F = 0x85,
            ACTTAG_RTD_NI120_C = 0x72,
            ACTTAG_RTD_NI120_F = 0x86,
            ACTTAG_RTD_NI200_C = 0x6f,
            ACTTAG_RTD_NI200_F = 0x83,
            ACTTAG_RTD_NI500_C = 0x70,
            ACTTAG_RTD_NI500_F = 0x84,
            ACTTAG_RTD_PT100_C = 0x66,
            ACTTAG_RTD_PT100_F = 0x7a,
            ACTTAG_RTD_PT1000_C = 0x69,
            ACTTAG_RTD_PT1000_F = 0x7d,
            ACTTAG_RTD_PT200_C = 0x67,
            ACTTAG_RTD_PT200_F = 0x7b,
            ACTTAG_RTD_PT50_C = 0x65,
            ACTTAG_RTD_PT50_F = 0x79,
            ACTTAG_RTD_PT500_C = 0x68,
            ACTTAG_RTD_PT500_F = 0x7c,
            ACTTAG_RTD_RESISTANCE_1_1250_ = 0x8f,
            ACTTAG_RTD_RESISTANCE_1_2000_ = 0x91,
            ACTTAG_RTD_RESISTANCE_1_2200_ = 0x90,
            ACTTAG_RTD_RESISTANCE_1_310_ = 0x8d,
            ACTTAG_RTD_RESISTANCE_1_327_ = 0x92,
            ACTTAG_RTD_RESISTANCE_1_620_ = 0x8e,
            ACTTAG_SYSTEM_CONNECTION = 0xff,
            ACTTAG_TC_DISABLE = 50,
            ACTTAG_TC_Type_B_C = 0x36,
            ACTTAG_TC_Type_B_F = 0x4a,
            ACTTAG_TC_Type_C_C = 0x3d,
            ACTTAG_TC_Type_C_F = 0x51,
            ACTTAG_TC_Type_D_C = 0x3e,
            ACTTAG_TC_Type_D_F = 0x52,
            ACTTAG_TC_Type_E_C = 0x39,
            ACTTAG_TC_Type_E_F = 0x4d,
            ACTTAG_TC_Type_J_C = 0x34,
            ACTTAG_TC_Type_J_F = 0x48,
            ACTTAG_TC_Type_K_C = 0x33,
            ACTTAG_TC_Type_K_F = 0x47,
            ACTTAG_TC_Type_L_C = 0x3b,
            ACTTAG_TC_Type_L_F = 0x4f,
            ACTTAG_TC_Type_N_C = 0x3a,
            ACTTAG_TC_Type_N_F = 0x4e,
            ACTTAG_TC_Type_R_C = 0x37,
            ACTTAG_TC_Type_R_F = 0x4b,
            ACTTAG_TC_Type_S_C = 0x38,
            ACTTAG_TC_Type_S_F = 0x4c,
            ACTTAG_TC_Type_T_C = 0x35,
            ACTTAG_TC_Type_T_F = 0x49,
            ACTTAG_TC_Type_U_C = 60,
            ACTTAG_TC_Type_U_F = 80,
            ACTTAG_TC_VOLTAGE_19_532MV = 0x5d,
            ACTTAG_TC_VOLTAGE_32_7MV = 0x5f,
            ACTTAG_TC_VOLTAGE_39_062MV = 0x5c,
            ACTTAG_TC_VOLTAGE_65_5MV = 0x60,
            ACTTAG_TC_VOLTAGE_78_126MV = 0x5b,
            ACTTAG_TC_VOLTAGE_78MV = 0x5e,
            ACTTAG_VIRTUAL_CH_AVG_C = 0xc9,
            ACTTAG_VIRTUAL_CH_AVG_F = 0xcb,
            ACTTAG_VIRTUAL_CH_DIF_C = 0xca,
            ACTTAG_VIRTUAL_CH_DIF_F = 0xcc,
            ACTTAG_VIRTUAL_CH_DISABLE = 0xce,
            ACTTAG_VIRTUAL_CH_MCONNECT = 0xcd,
            ACTTAG_VIRTUAL_CH_VALUE = 0xcf
        }

        [Flags]
        public enum MXIO_ActiveTagModuleType
        {
            ACTTAG_E1210_ID = 0xe210,
            ACTTAG_E1210T_ID = 80,
            ACTTAG_E1211_ID = 0xe211,
            ACTTAG_E1211T_ID = 0x51,
            ACTTAG_E1212_ID = 0xe212,
            ACTTAG_E1212T_ID = 0x52,
            ACTTAG_E1213_ID = 0x5b,
            ACTTAG_E1213T_ID = 0x5c,
            ACTTAG_E1214_ID = 0xe214,
            ACTTAG_E1214T_ID = 0x53,
            ACTTAG_E1240_ID = 0xe240,
            ACTTAG_E1240T_ID = 0x54,
            ACTTAG_E1241_ID = 0xe241,
            ACTTAG_E1241T_ID = 0x55,
            ACTTAG_E1242_ID = 0xe242,
            ACTTAG_E1242T_ID = 0x56,
            ACTTAG_E1260_ID = 0xe260,
            ACTTAG_E1260T_ID = 0x57,
            ACTTAG_E1261_ID = 90,
            ACTTAG_E1261H_ID = 0x340,
            ACTTAG_E1261H_T_ID = 0x341,
            ACTTAG_E1261T_ID = 0x59,
            ACTTAG_E1262_ID = 0xe262,
            ACTTAG_E1262T_ID = 0x58,
            ACTTAG_E1263H_ID = 0x342,
            ACTTAG_E1263H_T_ID = 0x343,
            ACTTAG_E1510_ID = 0x220,
            ACTTAG_E1510_T_ID = 0x221,
            ACTTAG_E1512_ID = 0x222,
            ACTTAG_E1512_T_ID = 0x223,
            ACTTAG_E2210_ID = 0x2210,
            ACTTAG_E2210_V2_ID = 0x2211,
            ACTTAG_E2210T_ID = 0x150,
            ACTTAG_E2212_ID = 0x2212,
            ACTTAG_E2212T_ID = 0x151,
            ACTTAG_E2214_ID = 0x2214,
            ACTTAG_E2214T_ID = 0x152,
            ACTTAG_E2240_ID = 0x2240,
            ACTTAG_E2240_V2_ID = 0x2241,
            ACTTAG_E2240T_ID = 0x153,
            ACTTAG_E2242_ID = 0x2242,
            ACTTAG_E2242T_ID = 340,
            ACTTAG_E2260_ID = 0x2260,
            ACTTAG_E2260T_ID = 0x155,
            ACTTAG_E2262_ID = 0x2262,
            ACTTAG_E2262T_ID = 0x156,
            ACTTAG_E4200_ID = 0x4200,
            ACTTAG_IOPAC_8020_5_M12_C_ID = 0x202,
            ACTTAG_IOPAC_8020_5_M12_C_T_ID = 0x182,
            ACTTAG_IOPAC_8020_5_M12_IEC_ID = 0x206,
            ACTTAG_IOPAC_8020_5_M12_IEC_T_ID = 390,
            ACTTAG_IOPAC_8020_5_RJ45_C_ID = 0x201,
            ACTTAG_IOPAC_8020_5_RJ45_C_T_ID = 0x181,
            ACTTAG_IOPAC_8020_5_RJ45_IEC_ID = 0x205,
            ACTTAG_IOPAC_8020_5_RJ45_IEC_T_ID = 0x185,
            ACTTAG_IOPAC_8020_9_M12_C_ID = 0x204,
            ACTTAG_IOPAC_8020_9_M12_C_T_ID = 0x184,
            ACTTAG_IOPAC_8020_9_M12_IEC_ID = 520,
            ACTTAG_IOPAC_8020_9_M12_IEC_T_ID = 0x188,
            ACTTAG_IOPAC_8020_9_RJ45_C_ID = 0x203,
            ACTTAG_IOPAC_8020_9_RJ45_C_T_ID = 0x183,
            ACTTAG_IOPAC_8020_9_RJ45_IEC_ID = 0x207,
            ACTTAG_IOPAC_8020_9_RJ45_IEC_T_ID = 0x187,
            ACTTAG_IOPAC_8020_T_ID = 0x180,
            ACTTAG_W5312_HSDPA_ID = 0x107,
            ACTTAG_W5312_HSDPA_JPN_ID = 0x10d,
            ACTTAG_W5312_HSDPA_JPS_ID = 0x111,
            ACTTAG_W5312_ID = 0x5312,
            ACTTAG_W5312SLOT_ID = 0x103,
            ACTTAG_W5312T_HSDPA_ID = 0x10a,
            ACTTAG_W5312T_HSDPA_JPN_ID = 0x10f,
            ACTTAG_W5312T_HSDPA_JPS_ID = 0x113,
            ACTTAG_W5312TSLOT_ID = 0x101,
            ACTTAG_W5340_AP_ID = 0x114,
            ACTTAG_W5340_HSDPA_ID = 0x106,
            ACTTAG_W5340_HSDPA_JPN_ID = 0x10c,
            ACTTAG_W5340_HSDPA_JPS_ID = 0x110,
            ACTTAG_W5340_ID = 0x5340,
            ACTTAG_W5340SLOT_ID = 0x102,
            ACTTAG_W5340T_HSDPA_ID = 0x109,
            ACTTAG_W5340T_HSDPA_JPN_ID = 270,
            ACTTAG_W5340T_HSDPA_JPS_ID = 0x112,
            ACTTAG_W5340TSLOT_ID = 0x100,
            ACTTAG_W5341_HSDPA_ID = 0x108,
            ACTTAG_W5341SLOT_ID = 260,
            ACTTAG_W5341T_HSDPA_ID = 0x10b,
            ACTTAG_W5341TSLOT_ID = 0x105,
            ACTTAG_W5348_GPRS_C_ID = 0x115,
            ACTTAG_W5348_GPRS_C_T_ID = 0x119,
            ACTTAG_W5348_GPRS_IEC_ID = 0x117,
            ACTTAG_W5348_GPRS_IEC_T_ID = 0x11b,
            ACTTAG_W5348_HSDPA_C_ID = 0x116,
            ACTTAG_W5348_HSDPA_C_T_ID = 0x11a,
            ACTTAG_W5348_HSDPA_IEC_ID = 280,
            ACTTAG_W5348_HSDPA_IEC_T_ID = 0x11c
        }

        [Flags]
        public enum MXIO_ActiveTagMsgSubType
        {
            ACTTAG_MSG_SUB_CLIENT_DISCONNECT = 3,
            ACTTAG_MSG_SUB_HEARTBEAT_TIMEOUT = 1,
            ACTTAG_MSG_SUB_READWRITE_TIMEOUT = 2,
            ACTTAG_MSG_SUB_SERVER_DISCONNECT = 4
        }

        [Flags]
        public enum MXIO_ActiveTagMsgType
        {
            ACTTAG_MSG_CONFIG = 3,
            ACTTAG_MSG_HEARTBEAT = 2,
            ACTTAG_MSG_IO_STATUS = 4,
            ACTTAG_MSG_POWER_ON = 1,
            ACTTAG_MSG_SYSTEM = 5
        }

        [Flags]
        public enum MXIO_ActiveTagStructIndex
        {
            ACTTAG_INDEX_CHABLE_OFSLOT = 0x451,
            ACTTAG_INDEX_CHLOCK_OFSLOT = 0x14d1,
            ACTTAG_INDEX_CHTYPE_OFSLOT = 0x31,
            ACTTAG_INDEX_CHVALUE_OFSLOT = 0x4d1,
            ACTTAG_INDEX_ID_OFSLOT = 0x431,
            ACTTAG_INDEX_IP = 10,
            ACTTAG_INDEX_LASTCH_OFSLOT = 0x21,
            ACTTAG_INDEX_LASTSLOT = 0x20,
            ACTTAG_INDEX_MAC = 14,
            ACTTAG_INDEX_MODEL = 8,
            ACTTAG_INDEX_MSGSUBTYPE = 0x15,
            ACTTAG_INDEX_MSGTYPE = 20,
            ACTTAG_INDEX_TIME_DAY = 0x1a,
            ACTTAG_INDEX_TIME_HOUR = 0x1b,
            ACTTAG_INDEX_TIME_MIN = 0x1c,
            ACTTAG_INDEX_TIME_MONTH = 0x19,
            ACTTAG_INDEX_TIME_MSEC = 30,
            ACTTAG_INDEX_TIME_SEC = 0x1d,
            ACTTAG_INDEX_TIME_YEAR = 0x17
        }

        [Flags]
        public enum MXIO_AIChannelType
        {
            M2K_AI_RANGE_150mv,
            M2K_AI_RANGE_500mv,
            M2K_AI_RANGE_5V,
            M2K_AI_RANGE_10V,
            M2K_AI_RANGE_0_20mA,
            M2K_AI_RANGE_4_20mA,
            M2K_AI_RANGE_0_150mv,
            M2K_AI_RANGE_0_500mv,
            M2K_AI_RANGE_0_5V,
            M2K_AI_RANGE_0_10V
        }

        [Flags]
        public enum MXIO_AutoSearchType
        {
            AOPC_SERVER = 0x100,
            E1200_SERIES = 8,
            E1500_SERIES = 0x40,
            E2000_SERIES = 2,
            E4000_SERIES = 1,
            E4200_SERIES = 4,
            W5000_SERIES = 0x10
        }

        [Flags]
        public enum MXIO_CheckConnectinStatus
        {
            CHECK_CONNECTION_OK,
            CHECK_CONNECTION_FAIL,
            CHECK_CONNECTION_TIME_OUT
        }

        [Flags]
        public enum MXIO_CoilTypeSetting
        {
            COIL_INPUT = 2,
            COIL_OUTPUT = 1
        }

        [Flags]
        public enum MXIO_DataLength
        {
            BIT_5,
            BIT_6,
            BIT_7,
            BIT_8
        }

        [Flags]
        public enum MXIO_E4KAOSafeAction
        {
            SAFE_VALUE,
            HOLD_LAST_STATE,
            LOW_LIMIT,
            HIGH_LIMIT
        }

        [Flags]
        public enum MXIO_E4KBusStatus
        {
            NORMAL_OPERATION,
            BUS_STANDYBY,
            BUS_COMMUNICATION_FAULT,
            SLOT_CONFIGURATION_FAILED,
            NO_EXPANSION_SLOT
        }

        [Flags]
        public enum MXIO_E4KFieldPowerStatus
        {
            FIELD_POWER_ON,
            FIELD_POWER_OFF
        }

        [Flags]
        public enum MXIO_E4KModbusErrorCheckStatus
        {
            CHECKSUM_NO_ERROR,
            CHECKSUM_ERROR
        }

        [Flags]
        public enum MXIO_E4KModbusErrorSetupStatus
        {
            SETUP_NO_ERROR,
            SETUP_ERROR
        }

        [Flags]
        public enum MXIO_E4KWatchdogStatus
        {
            WATCHDOG_NO_ERROR,
            WATCHDOG_ERROR
        }

        public enum MXIO_ErrorCode
        {
            ADD_INFO_TABLE_FAIL = 0x1389,
            CHANNEL_OUT_OF_RANGE = 0xfa4,
            COIL_TYPE_ERROR = 0xfa5,
            CREATE_MUTEX_FAIL = 0xfac,
            EIO_CREATING_SOCKET_ERROR = 0x7d3,
            EIO_INIT_SOCKETS_FAIL = 0x7d2,
            EIO_PASSWORD_INCORRECT = 0x7d7,
            EIO_RESPONSE_BAD = 0x7d4,
            EIO_SOCKET_DISCONNECT = 0x7d5,
            EIO_TIME_OUT = 0x7d1,
            ENUM_NET_INTERFACE_FAIL = 0x1388,
            FIRMWARE_NOT_SUPPORT = 0xfab,
            FUNCTION_NOT_SUPPORT = 0xfa7,
            HANDLE_ERROR = 0xfa2,
            ILLEGAL_DATA_ADDRESS = 0x3ea,
            ILLEGAL_DATA_VALUE = 0x3eb,
            ILLEGAL_FUNCTION = 0x3e9,
            INPUT_VALUE_OUT_OF_RANGE = 0xfa9,
            MXIO_OK = 0,
            OUTPUT_VALUE_OUT_OF_RANGE = 0xfa8,
            PRODUCT_NOT_SUPPORT = 0xfa1,
            PROTOCOL_TYPE_ERROR = 0x7d6,
            REGISTER_TYPE_ERROR = 0xfa6,
            SIO_BAUDRATE_NOT_SUPPORT = 0xbc5,
            SIO_CLEAR_COMM_FAIL = 0xbc2,
            SIO_CLOSE_FAIL = 0xbbb,
            SIO_FLUSH_FILE_BUFFERS_FAIL = 0xbbd,
            SIO_GET_COMM_STATE_FAIL = 0xbbe,
            SIO_OPEN_FAIL = 0xbb9,
            SIO_PURGE_COMM_FAIL = 0xbbc,
            SIO_RESPONSE_BAD = 0xbc3,
            SIO_SET_COMM_STATE_FAIL = 0xbbf,
            SIO_SET_COMM_TIME_OUT_FAIL = 0xbc1,
            SIO_SETUP_COMM_FAIL = 0xbc0,
            SIO_TIME_OUT = 0xbba,
            SIO_TRANSMISSION_MODE_ERROR = 0xbc4,
            SLAVE_DEVICE_BUSY = 0x3ee,
            SLAVE_DEVICE_FAILURE = 0x3ec,
            SLOT_NOT_EXIST = 0xfaa,
            SLOT_OUT_OF_RANGE = 0xfa3,
            TABLE_NET_INTERFACE_FAIL = 0x138b,
            UNKNOWN_NET_INTERFACE_FAIL = 0x138a
        }

        [Flags]
        public enum MXIO_IFDataIndex
        {
            MX_IF_INDEX_DESC = 0x1a,
            MX_IF_INDEX_IP = 4,
            MX_IF_INDEX_MAC = 20,
            MX_IF_INDEX_NUM = 0,
            MX_IF_ONE_IF_SIZE = 0x11a
        }

        [Flags]
        public enum MXIO_ModbusTransModeSetting
        {
            MODBUS_RTU,
            MODBUS_ASCII
        }

        [Flags]
        public enum MXIO_ModuleDataIndex
        {
            MX_ML_INDEX_BYTLANUSE = 0x2e,
            MX_ML_INDEX_SZIP0 = 2,
            MX_ML_INDEX_SZIP1 = 0x18,
            MX_ML_INDEX_SZMAC0 = 0x12,
            MX_ML_INDEX_SZMAC1 = 40,
            MX_ML_INDEX_WHWID = 0,
            MX_ML_MODULE_LIST_SIZE = 0x2f
        }

        [Flags]
        public enum MXIO_Parity
        {
            P_EVEN = 0x18,
            P_MRK = 40,
            P_NONE = 0,
            P_ODD = 8,
            P_SPC = 0x38
        }

        [Flags]
        public enum MXIO_ProtocolType
        {
            PROTOCOL_TCP = 1,
            PROTOCOL_UDP = 2
        }

        [Flags]
        public enum MXIO_RegisterTypeSetting
        {
            REGISTER_INPUT = 4,
            REGISTER_OUTPUT = 3
        }

        [Flags]
        public enum MXIO_StopBit
        {
            STOP_1 = 0,
            STOP_2 = 4
        }

        [Flags]
        public enum MXIO_W53xxBusState
        {
            BUS_INIT,
            BUS_INIT_NET,
            BUS_INIT_FAULT,
            BUS_IO,
            BUS_IO_FAULT,
            BUS_IDLE
        }

        [Flags]
        public enum MXIO_W53xxExpModuleErrorCode
        {
            EXPASION_NO_ERROR,
            EXPASION_COMMUNICATION_ERROR,
            EXPASION_MODBUS_ERROR,
            EXPASION_PENDING_ERROR,
            EXPASION_COMBINATION_ERROR,
            EXPASION_OUT_OF_MEMORY_ERROR
        }

        [Flags]
        public enum MXIO_W53xxExpModuleState
        {
            EXPASION_OFFLINE,
            EXPASION_ONLINE,
            EXPASION_UNMATCH_TYPE,
            EXPASION_RETURN_MODBUS_EXCEPTION,
            EXPASION_NETWORK_ERROR
        }

        public delegate void pfnCALLBACK(IntPtr bytData, ushort wSize);

        public delegate void pfnTagDataCALLBACK(MXIO_CS._IOLOGIKSTRUCT[] ios, ushort[] wMutex);
    }
}

