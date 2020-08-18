
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace ZianLauncher2
{
    public partial class LauncherForm2 : Form
    {
        public enum loadMode
        {
            Offline,
            OfflineForge
        }
        public static bool DebugMode = true;
        string _GameRootPath = System.Environment.CurrentDirectory + @"\.minecraft";
        public Global P = new Global(DebugMode);//debug


        public string ToArguments(loadMode mode)
        {
            string str = "";
            if (mode == loadMode.Offline)
            {            
                str += " -Dfml.ignoreInvalidMinecraftCertificates=true";
                str += " -Dfml.ignorePatchDiscrepancies=true";
                str += " -Xmx" + textBoxRAM.Text + "M";
                str += " -Djava.library.path=" + _GameRootPath + @"\versions\1.16.1\1.16.1-natives";
                str += " "+mc_1_16_1.ToArguments(_GameRootPath);
                str += " net.minecraft.client.main.Main";
                str += " --username " + textBoxID.Text;
                str += " --version " + mc_1_16_1.relese;
                str += " --gameDir " + _GameRootPath;
                str += " --assetsDir " + _GameRootPath + @"\assets";
                str += " --assetIndex " + mc_1_16_1.version;
                str += " --uuid ${auth_uuid}";
                str += " --accessToken ${auth_access_token}";
                str += " --userType Legacy";
                str += " --versionType release";
            }
            return str;
        }
        public LauncherForm2()
        {
            InitializeComponent();
        }
        private void buttonF_Click(object sender, EventArgs e)
        {

        }
        private void buttonO_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.textBoxJava.Text))
            {
                this.textBoxJava.Text = "Select Java path!";
                return;
            }
            string arguments = ToArguments(loadMode.Offline);
            if (DebugMode)
            {
                StreamWriter sw = new StreamWriter(System.Environment.CurrentDirectory + @"\ZianLauncherArguments.txt", false);
                sw.Write(arguments);
                sw.Close();
            }
            ProcessStartInfo startInfo = new ProcessStartInfo(this.textBoxJava.Text)
            {
                Arguments = arguments,
                UseShellExecute = false,
                WorkingDirectory = this._GameRootPath,//log文件夹
                RedirectStandardError = false,
                RedirectStandardOutput = false
            };
            Process javaprocess = Process.Start(startInfo);
            javaprocess.Close();
            if (!DebugMode) this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = System.Environment.CurrentDirectory;
            ofd.RestoreDirectory = true;
            ofd.Filter = "(*.exe)|*.exe";
            ofd.Title = "Please select jawaw.exe or java.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBoxJava.Text = ofd.FileName;
            }
        }
    }
}
