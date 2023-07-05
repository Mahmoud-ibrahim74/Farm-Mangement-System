using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace FMS.Hardware
{
    static class  Record
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        private static string _fileName = Application.StartupPath + @"\Recording\mk.wav";

        public static string RecordPath
        {
            get { return _fileName; }
        }

        public static void  Recording()
        {

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Media (.wav)|*.wav" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _fileName = sfd.FileName;
                    mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
                    mciSendString("record recsound", "", 0, 0);
                }
            }
        }
        public static void StopRecord()
        {
            mciSendString("save recsound " + _fileName, "", 0, 0);
            mciSendString("close recsound", "", 0, 0);
        }

    }
}
