using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveOrganizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //MFUserInfo a = new MFUserInfo();
            //MFGame lastGame = a.games.Last<MFGame>();
            //MFProfile prof = lastGame.ProfileWithName("other");
            //MFSave save = prof.SaveWithName("shit");
            //Console.WriteLine("Load sucess? {0}", save.Load());
            //lastGame.currentProfile = prof;
            //lastGame.BackupCurrentSave();

            //Console.WriteLine(lastGame.ToString());
            //Console.WriteLine(lastGame.profiles.ToString());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
