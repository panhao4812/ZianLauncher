using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;
using System.IO;

namespace ZianLauncher
{
    public class LauncherWriter
    {
        public string _username { get; set; }
        public Guid _uuid { get; set; }
        public Guid _AccessToken { get; set; }
        public string _password { get; set; }
        public string _Xmx { get; set; }
        public string _JavaPath { get; set; }


        public LauncherWriter()
        {
            DefaultData();
        }
        public void CreateFrom(LauncherWriter _copy)
        {
            DefaultData();
            if (_copy._username != "")_username = _copy._username;
            if (_copy._uuid != Guid.Empty) _uuid = _copy._uuid;
            if (_copy._AccessToken != Guid.Empty) _AccessToken = _copy._AccessToken;
            if (_copy._password != "") _password = _copy._password;
            if (_copy._Xmx != "") _Xmx = _copy._Xmx;
            if (_copy._JavaPath != "") _JavaPath = _copy._JavaPath;
        }
        public void DefaultData()
        {
            _username = "xionghaizi";
            _uuid = Guid.NewGuid();
            _AccessToken = Guid.NewGuid();
            _password = "";
            _Xmx = "2048";
            _JavaPath= @"C:\Program Files\Java\jre1.8.0_111\bin\javaw.exe";
        }
        public void ReadFromFile(string path)
        {
            try
            {
                this.CreateFrom (JsonMapper.ToObject<LauncherWriter>(File.OpenText(path)));
            }
            catch
            {
                DefaultData();
            }

        }
        public void WriteToFile(string path)
        {
            try
            {
            StreamWriter sw = new StreamWriter(path, false);
            sw.Write(JsonMapper.ToJson(this));
            sw.Close();
            }
            catch
            {               
            }
        }

    }
}
