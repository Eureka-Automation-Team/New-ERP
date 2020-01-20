using Eureka.Core.Domain.CNC;
using Eureka.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Eureka.Services.CNC
{
    public class ProgramTransferSrv : IProgramTransferSrv
    {
        private static readonly string provider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly IFactory factory = Factories.GetFactory(provider);

        //private unitworksccsEntities db = new unitworksccsEntities();
        private ushort port;
        private string ip;
        private int timeout;
        private ushort h;
        private ushort FlibHndl;
        private string FilePath;

        public ProgramTransferSrv(string IP)
        {
            this.port = (ushort)8193;
            this.ip = IP;
            this.timeout = 10;
        }

        public List<ProgramListDet> GetProgramList()
        {
            List<ProgramListDet> programListDetList = new List<ProgramListDet>();
            Focas1.focas_ret focasRet = (Focas1.focas_ret)Focas1.cnc_allclibhndl3((object)this.ip, this.port, this.timeout, out this.h);
            switch (focasRet)
            {
                case Focas1.focas_ret.EW_SOCKET:
                    string str1 = "Socket communication error. " + focasRet.ToString();
                    goto default;
                case Focas1.focas_ret.EW_NODLL:
                    string str2 = "There is no DLL file for each CNC series . " + focasRet.ToString();
                    goto default;
                case Focas1.focas_ret.EW_HANDLE:
                    string str3 = "Allocation of handle number is failed. " + focasRet.ToString();
                    goto default;
                case Focas1.focas_ret.EW_OK:
                    try
                    {
                        int b = 0;
                        short c = 10;
                        Focas1.PRGDIR3 d = new Focas1.PRGDIR3();
                        while (c != (short)0)
                        {
                            short num = Focas1.cnc_rdprogdir3(this.h, (short)2, ref b, ref c, d);
                            switch (num)
                            {
                                case 0:
                                    for (int index = 1; index <= (int)c; ++index)
                                    {
                                        ProgramListDet programListDet = new ProgramListDet();
                                        switch (index)
                                        {
                                            case 1:
                                                programListDet.ProgName = d.dir1.comment.ToUpper();
                                                programListDet.ProgNo = "O" + d.dir1.number.ToString();
                                                programListDet.ProgSize = d.dir1.length.ToString();
                                                programListDet.ProgDate = ((int)d.dir1.mdate.day).ToString() + "-" + (object)d.dir1.mdate.month + "-" + (object)d.dir1.mdate.year + " " + (object)d.dir1.mdate.hour + ":" + (object)d.dir1.mdate.minute;
                                                programListDetList.Add(programListDet);
                                                b = d.dir1.number + 1;
                                                break;
                                            case 2:
                                                programListDet.ProgName = d.dir2.comment.ToUpper();
                                                programListDet.ProgNo = "O" + d.dir2.number.ToString();
                                                programListDet.ProgSize = d.dir2.length.ToString();
                                                programListDet.ProgDate = ((int)d.dir2.mdate.day).ToString() + "-" + (object)d.dir2.mdate.month + "-" + (object)d.dir2.mdate.year + " " + (object)d.dir2.mdate.hour + ":" + (object)d.dir2.mdate.minute;
                                                programListDetList.Add(programListDet);
                                                b = d.dir2.number + 1;
                                                break;
                                            case 3:
                                                programListDet.ProgName = d.dir3.comment.ToUpper();
                                                programListDet.ProgNo = "O" + d.dir3.number.ToString();
                                                programListDet.ProgSize = d.dir3.length.ToString();
                                                programListDet.ProgDate = ((int)d.dir3.mdate.day).ToString() + "-" + (object)d.dir3.mdate.month + "-" + (object)d.dir3.mdate.year + " " + (object)d.dir3.mdate.hour + ":" + (object)d.dir3.mdate.minute;
                                                programListDetList.Add(programListDet);
                                                b = d.dir3.number + 1;
                                                break;
                                            case 4:
                                                programListDet.ProgName = d.dir4.comment.ToUpper();
                                                programListDet.ProgNo = "O" + d.dir4.number.ToString();
                                                programListDet.ProgSize = d.dir4.length.ToString();
                                                programListDet.ProgDate = ((int)d.dir4.mdate.day).ToString() + "-" + (object)d.dir4.mdate.month + "-" + (object)d.dir4.mdate.year + " " + (object)d.dir4.mdate.hour + ":" + (object)d.dir4.mdate.minute;
                                                programListDetList.Add(programListDet);
                                                b = d.dir4.number + 1;
                                                break;
                                            case 5:
                                                programListDet.ProgName = d.dir5.comment.ToUpper();
                                                programListDet.ProgNo = "O" + d.dir5.number.ToString();
                                                programListDet.ProgSize = d.dir5.length.ToString();
                                                programListDet.ProgDate = ((int)d.dir5.mdate.day).ToString() + "-" + (object)d.dir5.mdate.month + "-" + (object)d.dir5.mdate.year + " " + (object)d.dir5.mdate.hour + ":" + (object)d.dir5.mdate.minute;
                                                programListDetList.Add(programListDet);
                                                b = d.dir5.number + 1;
                                                break;
                                            case 6:
                                                programListDet.ProgName = d.dir6.comment.ToUpper();
                                                programListDet.ProgNo = "O" + d.dir6.number.ToString();
                                                programListDet.ProgSize = d.dir6.length.ToString();
                                                programListDet.ProgDate = ((int)d.dir6.mdate.day).ToString() + "-" + (object)d.dir6.mdate.month + "-" + (object)d.dir6.mdate.year + " " + (object)d.dir6.mdate.hour + ":" + (object)d.dir6.mdate.minute;
                                                programListDetList.Add(programListDet);
                                                b = d.dir6.number + 1;
                                                break;
                                            case 7:
                                                programListDet.ProgName = d.dir7.comment.ToUpper();
                                                programListDet.ProgNo = "O" + d.dir7.number.ToString();
                                                programListDet.ProgSize = d.dir7.length.ToString();
                                                programListDet.ProgDate = ((int)d.dir7.mdate.day).ToString() + "-" + (object)d.dir7.mdate.month + "-" + (object)d.dir7.mdate.year + " " + (object)d.dir7.mdate.hour + ":" + (object)d.dir7.mdate.minute;
                                                programListDetList.Add(programListDet);
                                                b = d.dir7.number + 1;
                                                break;
                                            case 8:
                                                programListDet.ProgName = d.dir8.comment.ToUpper();
                                                programListDet.ProgNo = "O" + d.dir8.number.ToString();
                                                programListDet.ProgSize = d.dir8.length.ToString();
                                                programListDet.ProgDate = ((int)d.dir8.mdate.day).ToString() + "-" + (object)d.dir8.mdate.month + "-" + (object)d.dir8.mdate.year + " " + (object)d.dir8.mdate.hour + ":" + (object)d.dir8.mdate.minute;
                                                programListDetList.Add(programListDet);
                                                b = d.dir8.number + 1;
                                                break;
                                            case 9:
                                                programListDet.ProgName = d.dir9.comment.ToUpper();
                                                programListDet.ProgNo = "O" + d.dir9.number.ToString();
                                                programListDet.ProgSize = d.dir9.length.ToString();
                                                programListDet.ProgDate = ((int)d.dir9.mdate.day).ToString() + "-" + (object)d.dir9.mdate.month + "-" + (object)d.dir9.mdate.year + " " + (object)d.dir9.mdate.hour + ":" + (object)d.dir9.mdate.minute;
                                                programListDetList.Add(programListDet);
                                                b = d.dir9.number + 1;
                                                break;
                                            case 10:
                                                programListDet.ProgName = d.dir10.comment.ToUpper();
                                                programListDet.ProgNo = "O" + d.dir10.number.ToString();
                                                programListDet.ProgSize = d.dir10.length.ToString();
                                                programListDet.ProgDate = ((int)d.dir10.mdate.day).ToString() + "-" + (object)d.dir10.mdate.month + "-" + (object)d.dir10.mdate.year + " " + (object)d.dir10.mdate.hour + ":" + (object)d.dir10.mdate.minute;
                                                programListDetList.Add(programListDet);
                                                b = d.dir10.number + 1;
                                                break;
                                        }
                                    }
                                    continue;
                                case 2:
                                    string str4 = "The number of readout (num_prog) is wrong." + (object)num;
                                    continue;
                                case 3:
                                    string str5 = "The start number of program (top_prog) is wrong" + (object)num;
                                    continue;
                                case 4:
                                    string str6 = "Output format (type) is wrong. " + (object)num;
                                    continue;
                                case 7:
                                    string str7 = "Write Operation is Prohibited." + (object)num;
                                    continue;
                                default:
                                    string str8 = "Error No.: " + (object)num;
                                    continue;
                            }
                        }
                    }
                    catch
                    {
                    }
                    int num1 = (int)Focas1.cnc_freelibhndl(this.h);
                    break;
                default:
                    focasRet.ToString();
                    break;
            }
            return programListDetList;
        }

        public string GetVersionListPCProgram(
          string MacInv,
          string ProgNo,
          out List<ProgramVersionListDet> PrgVerList)
        {
            PrgVerList = new List<ProgramVersionListDet>();
            //int macId = this.db.tblmachinedetails.Where<tblmachinedetail>((Expression<Func<tblmachinedetail, bool>>)(m => m.MachineDisplayName == MacInv)).Select<tblmachinedetail, int>((Expression<Func<tblmachinedetail, int>>)(m => m.MachineID)).FirstOrDefault<int>();
            //List<tblNcProgramTransferMain> list = this.db.tblNcProgramTransferMains.Where<tblNcProgramTransferMain>((Expression<Func<tblNcProgramTransferMain, bool>>)(m => m.IsDeleted == (bool?)false)).Where<tblNcProgramTransferMain>((Expression<Func<tblNcProgramTransferMain, bool>>)(m => m.McId == (int?)macId && m.ProgramNumber == ProgNo)).OrderByDescending<tblNcProgramTransferMain, int?>((Expression<Func<tblNcProgramTransferMain, int?>>)(m => m.VersionNumber)).ToList<tblNcProgramTransferMain>();
            string str = string.Empty;
            //if (list.Count > 0)
            //{
            //    foreach (tblNcProgramTransferMain programTransferMain in list)
            //        PrgVerList.Add(new ProgramVersionListDet()
            //        {
            //            ProgNo = programTransferMain.ProgramNumber,
            //            ProgDate = programTransferMain.CreatedDate.ToString(),
            //            ProgVer = programTransferMain.VersionNumber.ToString()
            //        });
            //    str = "Success";
            //}
            //else
            //    str = "No NC Programs have been saved for this Machine: " + MacInv + ".";
            return str;
        }

        public string GetProgramDataNC(string progno, out string ProgramData)
        {
            string str1 = (string)null;
            ProgramData = (string)null;
            Focas1.focas_ret focasRet = (Focas1.focas_ret)Focas1.cnc_allclibhndl3((object)this.ip, this.port, this.timeout, out this.h);
            string str2;
            switch (focasRet)
            {
                case Focas1.focas_ret.EW_SOCKET:
                    str1 = "Socket communication error. " + focasRet.ToString();
                    goto default;
                case Focas1.focas_ret.EW_NODLL:
                    str1 = "There is no DLL file for each CNC series . " + focasRet.ToString();
                    goto default;
                case Focas1.focas_ret.EW_HANDLE:
                    str1 = "Allocation of handle number is failed. " + focasRet.ToString();
                    goto default;
                case Focas1.focas_ret.EW_OK:
                    this.ProgramReadError(this.h, 1);
                    short num1 = Focas1.cnc_upstart(this.h, Convert.ToInt16(progno.Substring(1)));
                    Focas1.ODBUP a = new Focas1.ODBUP();
                    switch (num1)
                    {
                        case -1:
                            str2 = "Busy";
                            break;
                        case 0:
                            str2 = "Success";
                            short num2 = 0;
                            ushort b = 260;
                            int num3 = 0;
                            short num4;
                            while (num2 == (short)0)
                            {
                                num2 = Focas1.cnc_upload(this.h, a, ref b);
                                int length = a.data.Length;
                                string source = new string(a.data);
                                if (num2 == (short)10)
                                {
                                    b = (ushort)256;
                                    num2 = (short)0;
                                }
                                else
                                {
                                    if (num2 == (short)0)
                                        ProgramData += source;
                                    else if (num2 != (short)2)
                                    {
                                        if (num2 == (short)-2)
                                        {
                                            str2 = "Error: " + (object)num2;
                                            num4 = Focas1.cnc_upend3(this.h);
                                            this.ProgramReadError(this.h, 0);
                                            break;
                                        }
                                        str2 = "Else :: Error: " + (object)num2;
                                    }
                                    if (source.Contains<char>('%'))
                                    {
                                        ++num3;
                                        if (num3 >= 2)
                                        {
                                            string[] strArray = ProgramData.ToString().Split('%');
                                            ProgramData = "%" + strArray[1] + "%";
                                            str2 = ".Success";
                                            num4 = Focas1.cnc_upend3(this.h);
                                            this.ProgramReadError(this.h, 0);
                                            break;
                                        }
                                    }
                                }
                            }
                            num4 = Focas1.cnc_upend3(this.h);
                            this.ProgramReadError(this.h, 0);
                            if (num3 == 1)
                            {
                                string[] strArray = ProgramData.ToString().Split('%');
                                ProgramData = "%" + strArray[1] + "%";
                                break;
                            }
                            break;
                        case 1:
                            str2 = "Parameter(No.20,22:Input device) is wrong";
                            break;
                        case 7:
                            str2 = "Write protected on CNC side";
                            break;
                        default:
                            str2 = "cnc_upstart3 :: ErrorNo. :" + (object)num1;
                            break;
                    }
                    int num5 = (int)Focas1.cnc_freelibhndl(this.h);
                    break;
                default:
                    str2 = focasRet.ToString();
                    break;
            }
            return str2;
        }

        public string GetProgramDataPC(
          string MacInv,
          string ProgNo,
          int Ver,
          out string PCProgramData)
        {
            //int macId = this.db.tblmachinedetails.Where<tblmachinedetail>((Expression<Func<tblmachinedetail, bool>>)(m => m.MachineDisplayName == MacInv)).Select<tblmachinedetail, int>((Expression<Func<tblmachinedetail, int>>)(m => m.MachineID)).FirstOrDefault<int>();
            //tblNcProgramTransferMain programTransferMain = this.db.tblNcProgramTransferMains.Where<tblNcProgramTransferMain>((Expression<Func<tblNcProgramTransferMain, bool>>)(m => m.IsDeleted == (bool?)false)).Where<tblNcProgramTransferMain>((Expression<Func<tblNcProgramTransferMain, bool>>)(m => m.McId == (int?)macId && m.ProgramNumber == ProgNo && m.VersionNumber == (int?)Ver)).OrderByDescending<tblNcProgramTransferMain, int?>((Expression<Func<tblNcProgramTransferMain, int?>>)(m => m.VersionNumber)).FirstOrDefault<tblNcProgramTransferMain>();
            string str = string.Empty;
            //if (programTransferMain != null)
            //{
            //    PCProgramData = programTransferMain.ProgramData;
            //    str = "Success";
            //}
            //else
            //{
                PCProgramData = "";
            //    str = "File is unavailable.";
            //}
            return str;
        }

        public string DeleteProgram(string MacInv, string programNo)
        {
            string str1 = (string)null;
            Focas1.focas_ret focasRet = (Focas1.focas_ret)Focas1.cnc_allclibhndl3((object)this.ip, this.port, this.timeout, out this.h);
            string str2;
            switch (focasRet)
            {
                case Focas1.focas_ret.EW_SOCKET:
                    str1 = "Socket communication error. " + focasRet.ToString();
                    goto default;
                case Focas1.focas_ret.EW_NODLL:
                    str1 = "There is no DLL file for each CNC series . " + focasRet.ToString();
                    goto default;
                case Focas1.focas_ret.EW_HANDLE:
                    str1 = "Allocation of handle number is failed. " + focasRet.ToString();
                    goto default;
                case Focas1.focas_ret.EW_OK:
                    short num1 = Focas1.cnc_delete(this.h, Convert.ToInt16(programNo.Substring(1)));
                    switch (num1)
                    {
                        case -1:
                            str2 = "Data is protected.";
                            break;
                        case 0:
                            str2 = "Success";
                            break;
                        case 5:
                            str2 = "PROGRAM " + programNo + " doesn't exist.";
                            break;
                        case 7:
                            str2 = "Write protection on CNC side";
                            break;
                        default:
                            str2 = "ErrorNo." + (object)num1;
                            break;
                    }
                    int num2 = (int)Focas1.cnc_freelibhndl(this.h);
                    break;
                default:
                    str2 = focasRet.ToString();
                    break;
            }
            return str2;
        }

        public string UploadCNCProgram(int pthID, string FilePath1, out int retValueInt)
        {
            string str1 = (string)null;
            retValueInt = 0;
            try
            {

                Focas1.focas_ret focasRet1 = (Focas1.focas_ret)Focas1.cnc_allclibhndl3((object)this.ip, this.port, this.timeout, out this.FlibHndl);

                switch (focasRet1)
                {
                    case Focas1.focas_ret.EW_SOCKET:
                        retValueInt = -16;
                        str1 = "Socket communication error. " + focasRet1.ToString();
                        goto default;
                    case Focas1.focas_ret.EW_NODLL:
                        retValueInt = -15;
                        str1 = "There is no DLL file for each CNC series . " + focasRet1.ToString();
                        goto default;
                    case Focas1.focas_ret.EW_HANDLE:
                        retValueInt = -8;
                        str1 = "Allocation of handle number is failed. " + focasRet1.ToString();
                        goto default;
                    case Focas1.EW_OK:
                        retValueInt = 0;
                        short a = 0;
                        this.FilePath = FilePath1;
                        using (StreamReader streamReader = new StreamReader((Stream)new FileStream(this.FilePath, FileMode.Open, FileAccess.Read), Encoding.UTF8))
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            while (!streamReader.EndOfStream)
                            {
                                string str2 = (string)null;
                                Dictionary<int, string> dictionary = new Dictionary<int, string>();
                                int key1 = 1;
                                string str3;
                                while ((str3 = streamReader.ReadLine()) != null)
                                {
                                    dictionary.Add(key1, str3 + "\n");
                                    ++key1;
                                }
                                Focas1.focas_ret focasRet2 = (Focas1.focas_ret)Focas1.cnc_dwnstart3(this.FlibHndl, a);
                                switch (focasRet2)
                                {
                                    case Focas1.focas_ret.EW_BUSY:
                                        retValueInt = -1;
                                        str1 = "Busy. " + focasRet2.ToString();
                                        continue;
                                    case Focas1.focas_ret.EW_OK:
                                        retValueInt = 0;
                                        int num;
                                        for (int key2 = 1; key2 < dictionary.Count; key2 = num + 1)
                                        {
                                            stringBuilder?.Clear();
                                            if (key2 == 0)
                                                stringBuilder.Append("\n");
                                            string str4 = (string)null;
                                            int length1 = stringBuilder.Length;
                                            for (ushort index = str4 != null ? (ushort)str4.Length : (ushort)0; length1 + (int)index < 250; index = (ushort)str4.Length)
                                            {
                                                if (str4 != null)
                                                    stringBuilder.Append(str4);
                                                length1 = stringBuilder.Length;
                                                str2 = (string)null;
                                                if (dictionary.ContainsKey(key2))
                                                {
                                                    str4 = dictionary[key2++];
                                                }
                                                else
                                                {
                                                    stringBuilder.Append("%");
                                                    break;
                                                }
                                            }
                                            num = key2 - 2;
                                            int length2 = stringBuilder.Length;
                                            object b = (object)stringBuilder;
                                            Focas1.focas_ret focasRet3 = (Focas1.focas_ret)Focas1.cnc_download3(this.FlibHndl, ref length2, b);
                                            switch (focasRet3)
                                            {
                                                case Focas1.focas_ret.EW_RESET:
                                                    retValueInt = -2;
                                                    str1 = "Reset or stop request. " + focasRet3.ToString();
                                                    break;
                                                case Focas1.focas_ret.EW_OK:
                                                    str1 = "Executed Successfully. " + focasRet3.ToString();
                                                    retValueInt = 0;
                                                    break;
                                                case Focas1.focas_ret.EW_FUNC:
                                                    retValueInt = 1;
                                                    str1 = "cnc_dwnstart3 function has not been executed. " + focasRet3.ToString();
                                                    break;
                                                case Focas1.focas_ret.EW_LENGTH:
                                                    retValueInt = 2;
                                                    str1 = "The size of character string is negative. " + focasRet3.ToString();
                                                    break;
                                                case Focas1.focas_ret.EW_DATA:
                                                    retValueInt = 5;
                                                    str1 = "Data error. " + focasRet3.ToString();
                                                    break;
                                                case Focas1.focas_ret.EW_PROT:
                                                    retValueInt = 7;
                                                    str1 = "Tape memory is write-protected by the CNC parameter setting. " + focasRet3.ToString();
                                                    break;
                                                case Focas1.focas_ret.EW_OVRFLOW:
                                                    retValueInt = 8;
                                                    str1 = "Make enough free area in CNC memory. " + focasRet3.ToString();
                                                    break;
                                                case Focas1.focas_ret.EW_BUFFER:
                                                    retValueInt = 10;
                                                    str1 = "Retry because the buffer is full. " + focasRet3.ToString();
                                                    break;
                                                case Focas1.focas_ret.EW_REJECT:
                                                    retValueInt = 13;
                                                    str1 = "Downloading is disable in the current CNC status " + focasRet3.ToString();
                                                    break;
                                                case Focas1.focas_ret.EW_ALARM:
                                                    retValueInt = 15;
                                                    str1 = "Alarm has occurred while downloading. " + focasRet3.ToString();
                                                    break;
                                            }
                                            str1 = focasRet3.ToString();
                                        }
                                        Focas1.focas_ret focasRet4 = (Focas1.focas_ret)Focas1.cnc_dwnend3(this.FlibHndl);
                                        switch (focasRet4)
                                        {
                                            case Focas1.focas_ret.EW_OK:
                                                retValueInt = 0;
                                                //str1 = "cnc_dwnend3 executed succesfully " + focasRet4.ToString();
                                                str1 = "Succesfully";
                                                continue;
                                            case Focas1.focas_ret.EW_FUNC:
                                                retValueInt = 1;
                                                str1 = "cnc_dwnstart3 function has not been executed. " + focasRet4.ToString();
                                                continue;
                                            case Focas1.focas_ret.EW_DATA:
                                                retValueInt = 5;
                                                str1 = "Data error. " + focasRet4.ToString();
                                                continue;
                                            case Focas1.focas_ret.EW_PROT:
                                                retValueInt = 7;
                                                str1 = "Tape memory is write-protected by the CNC parameter setting. " + focasRet4.ToString();
                                                continue;
                                            case Focas1.focas_ret.EW_OVRFLOW:
                                                retValueInt = 8;
                                                str1 = "Make enough free area in CNC memory. " + focasRet4.ToString();
                                                continue;
                                            case Focas1.focas_ret.EW_REJECT:
                                                retValueInt = 13;
                                                str1 = "Downloading is disable in the current CNC status. " + focasRet4.ToString();
                                                continue;
                                            case Focas1.focas_ret.EW_ALARM:
                                                retValueInt = 15;
                                                str1 = "Alarm has occurred while downloading. " + focasRet4.ToString();
                                                continue;
                                            default:
                                                continue;
                                        }
                                    case Focas1.focas_ret.EW_ATTRIB:
                                        retValueInt = 4;
                                        str1 = "Data type (type) is illegal. " + focasRet2.ToString();
                                        continue;
                                    case Focas1.focas_ret.EW_NOOPT:
                                        retValueInt = 6;
                                        str1 = "No option. " + focasRet2.ToString();
                                        continue;
                                    case Focas1.focas_ret.EW_PARAM:
                                        retValueInt = 9;
                                        str1 = "CNC parameter error. " + focasRet2.ToString();
                                        continue;
                                    case Focas1.focas_ret.EW_MODE:
                                        retValueInt = 12;
                                        str1 = "CNC mode error. " + focasRet2.ToString();
                                        continue;
                                    case Focas1.focas_ret.EW_REJECT:
                                        retValueInt = 13;
                                        str1 = "CNC is machining, so Rejected. " + focasRet2.ToString();
                                        continue;
                                    case Focas1.focas_ret.EW_ALARM:
                                        retValueInt = 15;
                                        str1 = "Alarm State error, reset the alarm on CNC. " + focasRet2.ToString();
                                        continue;
                                    case Focas1.focas_ret.EW_PASSWD:
                                        retValueInt = 17;
                                        str1 = "Specified CNC data cannot be written because the data is protected.. " + focasRet2.ToString();
                                        continue;
                                    default:
                                        continue;
                                }
                            }
                        }
                        int num1 = (int)Focas1.cnc_freelibhndl(this.h);
                        break;
                    default:
                        //str1 = str1;// + focasRet1.ToString();
                        break;
                }
                //using (unitworksccsEntities unitworksccsEntities = new unitworksccsEntities())
                //{
                //    tblprogramtransferhistory entity = unitworksccsEntities.tblprogramtransferhistories.Find((object)pthID);
                //    if (entity != null)
                //    {
                //        entity.ReturnTime = new DateTime?(DateTime.Now);
                //        entity.ReturnStatus = new int?(retValueInt);
                //        entity.ReturnDesc = str1;
                //        unitworksccsEntities.Entry<tblprogramtransferhistory>(entity).State = EntityState.Modified;
                //        unitworksccsEntities.SaveChanges();
                //    }
                //}
                int num2 = (int)Focas1.cnc_freelibhndl(this.FlibHndl);
            }
            catch (Exception ex)
            {
                str1 += ex.ToString();
            }
            return str1;
        }

        public void SaveNCProg(string Msg, string MacINV, string progNo, int TypeOfFilePath)
        {
            string str = "";// this.db.tbl_genericfilepath.Where<tbl_genericfilepath>((Expression<Func<tbl_genericfilepath, bool>>)(m => m.TypeofFilePath == (int?)TypeOfFilePath && m.IsDeleted == (int?)0)).Select<tbl_genericfilepath, string>((Expression<Func<tbl_genericfilepath, string>>)(m => m.CompleteFilePath)).FirstOrDefault<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(str + "\\" + MacINV);
            try
            {
                if (!directoryInfo.Exists)
                    directoryInfo.Create();
                FileInfo[] files = directoryInfo.GetFiles(progNo + "_*.txt");
                if (((IEnumerable<FileInfo>)files).Count<FileInfo>() > 0)
                {
                    Array.Sort<FileInfo>(files, (Comparison<FileInfo>)((f1, f2) => f2.CreationTime.CompareTo(f1.CreationTime)));
                    string name = files[files.Length - 1].Name;
                    string s = name.Substring(name.IndexOf('_') + 1, name.LastIndexOf('.') - (name.LastIndexOf('_') + 1));
                    int num1 = 0;
                    ref int local = ref num1;
                    int.TryParse(s, out local);
                    int num2 = 0;
                    int num3 = num1;
                    while (num2 == 0)
                    {
                        FileInfo fileInfo = new FileInfo(files[0].DirectoryName + "\\" + progNo + "_" + (object)num3 + ".txt");
                        if (fileInfo.Exists)
                        {
                            ++num3;
                        }
                        else
                        {
                            ++num2;
                            using (StreamWriter text = fileInfo.CreateText())
                                text.Write(Msg);
                        }
                    }
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(str + MacINV + "\\" + progNo + "_1.txt");
                    if (!fileInfo.Exists)
                        return;
                    using (StreamWriter text = fileInfo.CreateText())
                        text.Write(Msg);
                }
            }
            catch
            {
            }
        }

        public void ProgramReadError(ushort h, int readstart)
        {
            short a = 3202;
            Focas1.IODBPSD_1 iodbpsd1_1 = new Focas1.IODBPSD_1();
            Focas1.IODBPSD_1 iodbpsd1_2 = new Focas1.IODBPSD_1();
            Focas1.IODBPSD_1 iodbpsd1_3 = new Focas1.IODBPSD_1();
            int num1 = (int)Focas1.cnc_rdparam(h, a, (short)0, (short)68, iodbpsd1_1);
            int cdata = (int)iodbpsd1_1.cdata;
            switch (readstart)
            {
                case 0:
                    iodbpsd1_1.cdata = (byte)24;
                    break;
                case 1:
                    iodbpsd1_1.cdata = (byte)64;
                    break;
            }
            int num2 = (int)Focas1.cnc_wrparam(h, (short)5, iodbpsd1_1);
        }

        public void CreateFileForProgramTransfer(string content)
        {
            try
            {
                string path1 = "C:\\NCProgram";
                if (!Directory.Exists(path1))
                    Directory.CreateDirectory(path1);
                string path2 = path1 + "\\NcProgram.txt";
                if (!File.Exists(path2))
                    File.Create(path2).Dispose();
                using (StreamWriter streamWriter = File.AppendText(path2))
                {
                    streamWriter.WriteLine(content);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void DeleteFileProgramTransfer()
        {
            string path = "C:\\NCProgram\\NcProgram.txt";
            try
            {
                if (!File.Exists(path))
                    return;
                File.Delete(path);
            }
            catch
            {
            }
        }
    }
}
