
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LitJson;
namespace ZianLauncher.LauncherForm
{

    public partial class LauncherForm : Form
    {
        List<string> _classpass = new List<string>();//-cp
        string _mainclass="";
        string _username = "";
        string _password = "";
        string _Xmx = "2048";
        string _GameRootPath = System.Environment.CurrentDirectory + @"\.minecraft";
        string _JavaPath = @"C:\Program Files\Java\jre1.8.0_111\bin\javaw.exe";
        public static Global P = new Global(false);//debug
        ForgeJson FJ = new ForgeJson();//json文件
        OriginalJson OJ = new OriginalJson();//json文件
        private void ReadJson()//初始化json文件类
        {
            string FJpath = ""; ;
            string OJpath = "";
            List<string> output = new List<string>();
            Global._SearchFiles(_GameRootPath + @"\versions", ".json", ref output);
            if (output.Count != 2) { P.Print("error read json file"); return; }
            if (Path.GetFileNameWithoutExtension(output[0]).Contains("Forge") || Path.GetFileNameWithoutExtension(output[0]).Contains("forge"))
            { FJpath = output[0]; OJpath = output[1]; }
            else { FJpath = output[1]; OJpath = output[0]; }
            FJ = JsonMapper.ToObject<ForgeJson>(File.OpenText(FJpath));
            OJ = JsonMapper.ToObject<OriginalJson>(File.OpenText(OJpath));
            output.Clear();
            Global._SearchFiles(_GameRootPath + @"\versions", ".jar", ref output);
            _mainclass = output[0];
            //  P.Print(FJ.ToArgumentsOffLine(_username, _GameRootPath));
        }
        
        public string ToArguments()
        {       
            return ToArgumentsOffLine();
        }
        private string ToArgumentsOffLine()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("-Xincgc");
            builder.Append(" -Xmx" + this._Xmx + "M");
            builder.Append(" -Dfml.ignoreInvalidMinecraftCertificates=true");
            builder.Append(" -Dfml.ignorePatchDiscrepancies=true");
            builder.Append(" -Djava.library.path=" + (char)34 + this._GameRootPath + @"\$natives" + (char)34);
            builder.Append(" -cp " + (char)34);
            builder.Append(FJ.CPArguments(_GameRootPath));
            builder.Append(OJ.CPArguments(_GameRootPath));
            builder.Append(this._mainclass);
            builder.Append((char)34+" ");
            builder.Append(FJ.ToArgumentsOffLine(_username,_GameRootPath));   
            return builder.ToString();
        }
        public LauncherForm()
        {
            InitializeComponent();
            this.textBoxID.Text = Process.GetCurrentProcess().ProcessName;
            this.textBoxPassword.Text = _password;
            this.textBoxRAM.Text = _Xmx;
            this.textBoxRootPath.Text = _GameRootPath;
            this.textBoxJava.Text = _JavaPath;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            _username = this.textBoxID.Text;
            _password = this.textBoxPassword.Text;
            _Xmx = this.textBoxRAM.Text;
            _GameRootPath = this.textBoxRootPath.Text;
            _JavaPath = this.textBoxJava.Text;
            ReadJson();
            ///*
            string arguments = ToArguments();
           // StreamWriter sw = new StreamWriter(System.Environment.CurrentDirectory + @"\mc3.txt");
           // sw.Write(arguments);
           // sw.Close();
            ProcessStartInfo startInfo = new ProcessStartInfo(this._JavaPath)
            {
                Arguments = arguments,
                UseShellExecute = false,
                WorkingDirectory = this._GameRootPath,//log文件夹
                RedirectStandardError = false,
                RedirectStandardOutput = false
            };
            Process javaprocess = Process.Start(startInfo);
            javaprocess.Close();
              this.Close();
            //*/
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = System.Environment.CurrentDirectory;
            ofd.RestoreDirectory = true;
            ofd.Filter = "(*.exe)|*.exe";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
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
