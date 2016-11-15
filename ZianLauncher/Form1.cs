
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZianLauncher
{

    public partial class ZianLauncher : Form
    {
        public List<string> Libraries = new List<string>();
        string ID = "null";
        string Password = "null";
        string RAM = "2048";
        string GameRootPath = System.Environment.CurrentDirectory;
        string JavaPath = @"C:\Program Files\Java\jre1.8.0_111\bin\javaw.exe";
       // Global P = new Global(true);

        public static void _SearchFiles(string dir, string type, ref List<string> output)
        {
            if (Directory.Exists(dir))
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                    {
                        string name = Path.GetFileNameWithoutExtension(d);
                        string extension = Path.GetExtension(d);

                        if (extension == type) { output.Add(d); }
                    }
                    else
                        _SearchFiles(d, type, ref output);
                }
            }
        }

        public string ToArguments()
        {
            _SearchFiles(this.GameRootPath + @"\.minecraft\libraries", ".jar", ref Libraries);
            StringBuilder builder = new StringBuilder();
            builder.Append("-Xincgc");
            builder.Append(" -Xmx" + this.RAM + "M");
            builder.Append(" -Dfml.ignoreInvalidMinecraftCertificates=true");
            builder.Append(" -Dfml.ignorePatchDiscrepancies=true");
            builder.Append(" -Djava.library.path="+(char)34+ this.GameRootPath + @"\.minecraft\$natives"+(char)34);
            builder.Append(" -cp "+(char)34);
            foreach (string str2 in this.Libraries)
            {
                builder.Append(str2).Append(';');
            }
            builder.Append(this.GameRootPath + @"\.minecraft\versions\1.8.8\1.8.8.jar;"+(char)34);
            builder.Append(" net.minecraft.launchwrapper.Launch");
            builder.Append(" --username " + ID);
            builder.Append(" --version 1.8.8-forge1.8.8-11.15.0.1655");
            builder.Append(" --gameDir "+ (char)34+this.GameRootPath + @"\.minecraft"+ (char)34);
            builder.Append(" --assetsDir "+ (char)34+this.GameRootPath + @"\.minecraft\assets"+ (char)34);
            builder.Append(" --assetIndex 1.8");
            builder.Append(" --uuid ${auth_uuid}");
            builder.Append(" --accessToken ${auth_access_token}");
            builder.Append(" --userProperties {}");
           // builder.Append(" --userType Legacy");
            builder.Append(" --userType Mojang");
            builder.Append(" --tweakClass net.minecraftforge.fml.common.launcher.FMLTweaker");
            return builder.ToString();
        }


        public ZianLauncher()
        {
            InitializeComponent();
            this.textBoxID.Text = Process.GetCurrentProcess().ProcessName;
            this.textBoxPassword.Text = Password;
            this.textBoxRAM.Text = RAM;
            this.textBoxRootPath.Text = GameRootPath;
            this.textBoxJava.Text = JavaPath;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ID = this.textBoxID.Text;
             Password = this.textBoxPassword.Text;
             RAM = this.textBoxRAM.Text;
             GameRootPath = this.textBoxRootPath.Text;
             JavaPath = this.textBoxJava.Text;

           // StreamWriter sw = new StreamWriter("D:/mc2.txt");
           // sw.Write(ToArguments());
          //  sw.Close();
           ///*
            ProcessStartInfo startInfo = new ProcessStartInfo(this.JavaPath)
            {
                Arguments = ToArguments(),
                UseShellExecute = false,
                CreateNoWindow = false,
                WorkingDirectory = this.GameRootPath,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };
            Process javaprocess =  Process.Start(startInfo);
            javaprocess.StandardOutput.ReadToEnd();
            //javaprocess.WaitForExit();//等待程序执行完退出进程
            Task.Factory.StartNew(javaprocess.WaitForExit).ContinueWith(t=>javaprocess.Close()) ;
            //*/      
            this.Close(); 
        }

        void RunCMD(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string str = sr.ReadToEnd();
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序
            p.StandardInput.WriteLine(str); sr.Close();
            // p.StandardInput.AutoFlush = true;
            p.StandardOutput.ReadToEnd();
            //p.WaitForExit();//等待程序执行完退出进程
            p.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = System.Environment.CurrentDirectory;
            ofd.RestoreDirectory = true;
            ofd.Filter = "(*.exe)|*.exe";
         
            if (ofd.ShowDialog() == DialogResult.OK) {
                this.textBoxJava.Text = ofd.FileName;
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.SelectedPath = System.Environment.CurrentDirectory;        
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBoxRootPath.Text = ofd.SelectedPath;
            }
        }
    }
}
