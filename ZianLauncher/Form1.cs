
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
        string ID = "zian1";
        string Password = "null";
        string RAM = "2048";
        string GameRootPath = @"C:\Users\Administrator\Desktop\MEP\minecraft1.8.8";//System.Environment.CurrentDirectory;
        string JavaPath = @"C:\Program Files\Java\jre1.8.0_111\bin\javaw.exe";
        Global P = new Global(true);

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
            builder.Append(" -Xms512M");
            builder.Append(" -Xmx").Append(this.RAM).Append("M");
            builder.Append(" -Djava.library.path=" + this.GameRootPath + @"\.minecraft\versions\1.8.8-forge1.8.8-11.15.0.1655\1.8.8-forge1.8.8-11.15.0.1655-natives-1479119743");
            builder.Append(" -classpath ");
            foreach (string str2 in this.Libraries)
            {
                builder.Append(str2).Append(';');
            }
            builder.Append(this.GameRootPath + @"\.minecraft\versions\1.8.8\1.8.8.jar");
            builder.Append(" net.minecraft.launchwrapper.Launch");
            builder.Append(" --username " + ID);
            builder.Append(" --version 1.8.8-forge1.8.8-11.15.0.1655");
            builder.Append(" --gameDir " + this.GameRootPath + @"\.minecraft");
            builder.Append(" --assetsDir " + this.GameRootPath + @"\.minecraft\assets");
            builder.Append(" --assetIndex 1.8");
            builder.Append(" --uuid ${auth_uuid}");
            builder.Append(" --accessToken ${auth_access_token}");
            builder.Append(" --userProperties {}");
            builder.Append(" --userType Legacy");
            builder.Append(" --tweakClass net.minecraftforge.fml.common.launcher.FMLTweaker");
            return builder.ToString();
        }


        public ZianLauncher()
        {
            InitializeComponent();
            this.textBoxID.Text = ID;
            this.textBoxPassword.Text = Password;
            this.textBoxRAM.Text = RAM;
            this.textBoxRootPath.Text = GameRootPath;
            this.textBoxJava.Text = JavaPath;
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            string ID = this.textBoxID.Text;
            string Password = this.textBoxPassword.Text;
            string RAM = this.textBoxRAM.Text;
            string GameRootPath = this.textBoxRootPath.Text;
            string JavaPath = this.textBoxJava.Text;
            try
            {
                
                ProcessStartInfo startInfo = new ProcessStartInfo(this.JavaPath)
                {
                    Arguments = ToArguments(),
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    WorkingDirectory = this.GameRootPath,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
                Process javaprocess = Process.Start(startInfo);                         
                string output = javaprocess.StandardOutput.ReadToEnd();
                javaprocess.WaitForExit();//等待程序执行完退出进程
                javaprocess.Close();
                P.Print(output);
            }
            catch (Exception ex)
            {
                P.Print(ex.ToString());
            }
        }
    }
}
