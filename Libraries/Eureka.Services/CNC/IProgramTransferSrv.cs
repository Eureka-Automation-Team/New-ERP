using Eureka.Core.Domain.CNC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Services.CNC
{
    public interface IProgramTransferSrv
    {
        List<ProgramListDet> GetProgramList();

        string GetVersionListPCProgram(
          string MacInv,
          string ProgNo,
          out List<ProgramVersionListDet> PrgVerList);

        string GetProgramDataNC(string progno, out string ProgramData);

        string GetProgramDataPC(
          string MacInv,
          string ProgNo,
          int Ver,
          out string PCProgramData);

        string DeleteProgram(string MacInv, string programNo);

        string UploadCNCProgram(int pthID, string FilePath1, out int retValueInt);

        void SaveNCProg(string Msg, string MacINV, string progNo, int TypeOfFilePath);

        void ProgramReadError(ushort h, int readstart);

        void CreateFileForProgramTransfer(string content);

        void DeleteFileProgramTransfer();
    }
}
