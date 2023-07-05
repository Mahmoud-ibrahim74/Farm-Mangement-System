using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace FMS
{
    class RegisterKey
    {
        private string SerialKey = "6P99N-YF42M-TPGBG-9VMJP-YKHCF";

        public void WriteKey()
        {
            if (!File.Exists(@"$tn/s.txt"))
                File.Create(@"$tn/s.txt");
            else
            {
                File.WriteAllText(@"$tn/s.txt", SerialKey);
            }

        }

    }
}
