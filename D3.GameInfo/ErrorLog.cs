using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DGI
{
    public class ErrorLog
    {
        public string LogFile { get; set; }
        public ErrorLog(string logFile)
        {
            this.LogFile = logFile;
            VerifyFile(this.LogFile);
        }

        private void VerifyFile(string lf)
        {
            if (!File.Exists(lf))
                File.Create(lf);
        }

        public string[] GetLog()
        {
            VerifyFile(this.LogFile);
            return File.ReadAllLines(this.LogFile);
        }

        public void AddLog(string Class, string Error)
        {
            VerifyFile(this.LogFile);
            Error = VerifyError(Error);
            string stamp = "[" + DateTime.Today.ToString("yyyy/MM/dd") + "] ";
            File.AppendAllText(this.LogFile, stamp + Class + "(): " + Error + Environment.NewLine);
        }

        private string VerifyError(string Error)
        {
            if (Error == null)
                return "Something went wrong...";
            else
                return Regex.Replace(Error, @"\t|\n|\r", "");
        }
    }
}
