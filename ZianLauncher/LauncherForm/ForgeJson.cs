using System;
using System.Collections.Generic;
using LitJson;
using System.Text;
using System.IO;

namespace ZianLauncher.LauncherForm
{
    public class CPlibrary
    {
        public string name { get; set; }
        public List<string> ToPath(string _GameRootPath)
        {
            string[] str = name.Split(':');
            if (str.Length <= 0)
            {// Console.Print("error CPlibrary.ToPath()");
                return null;
            }
            string[] str2 = str[0].Split('.');
            string path = _GameRootPath + @"\libraries\";
            for (int i = 0; i < str2.Length; i++) { path += str2[i] + @"\"; }
            if (str.Length > 1)
            {
                for (int i = 1; i < str.Length; i++)
                {
                    path += str[i];
                    if (i != str.Length - 1) path += @"\";
                }
            }
            List<string> output = new List<string>();
            Global._SearchFiles(path, ".jar", ref output);
            return output;
        }
    }
    public class ForgeJson//对于Json文件的信息提取
    {
        public ForgeJson()
        {

            id = ""; minecraftArguments = ""; mainClass = ""; assets = "";
        }
        public string id { get; set; }
        public string minecraftArguments { get; set; }
        public string mainClass { get; set; }
        public string assets { get; set; }
        public JsonData libraries { get; set; }

        public string CPArguments(string _GameRootPath)
        {
            StringBuilder builder = new StringBuilder();
            List<string> cp = new List<string>();
            for (int i = 0; i < this.libraries.Count; i++)
            {
                JsonData cpdata = libraries[i];
                CPlibrary lib = JsonMapper.ToObject<CPlibrary>(cpdata.ToJson());
                cp.AddRange(lib.ToPath(_GameRootPath));
            }
            foreach (string str2 in cp)
            {
                builder.Append(str2 + ';');
            }
            return builder.ToString();
        }
        public string ToArgumentsOffLine(string _username, string _GameRootPath)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(mainClass + " ");
            string Arguments = minecraftArguments;
            Arguments = Arguments.Replace("${auth_player_name}", _username);
            Arguments = Arguments.Replace("${version_name}", id);
            Arguments = Arguments.Replace("${game_directory}", (char)34 + _GameRootPath + (char)34);
            Arguments = Arguments.Replace("${assets_root}", (char)34 + _GameRootPath + @"\assets" + (char)34);
            if (this.assets != "")
            {
                Arguments = Arguments.Replace("${assets_index_name}", assets);
            }
            else
            {
                List<string> str123 = new List<string>();

                Global._SearchFiles(_GameRootPath + @"\assets\imdexes", ".json", ref str123);
                if (str123.Count == 0)
                {
                    string[] str3 = id.Split('.');
                    assets = str3[0] + "." + str3[1];
                    Arguments = Arguments.Replace("${assets_index_name}", assets);
                }
                else
                {
                    assets = Path.GetFileNameWithoutExtension(str123[0]);
                    Arguments = Arguments.Replace("${assets_index_name}", assets);
                }
            }
            Arguments = Arguments.Replace("${user_properties}", "{}");
            Arguments = Arguments.Replace("${user_type}", "Mojang");
            builder.Append(Arguments);
            return builder.ToString();
        }
    }
    public class OriginalJson
    {
        public string CPArguments(string _GameRootPath)
        {
            StringBuilder builder = new StringBuilder();
            List<string> cp = new List<string>();
            for (int i = 0; i < this.libraries.Count; i++)
            {
                JsonData cpdata = libraries[i];
                CPlibrary lib = JsonMapper.ToObject<CPlibrary>(cpdata.ToJson());
                cp.AddRange(lib.ToPath(_GameRootPath));
            }
            foreach (string str2 in cp)
            {
                builder.Append(str2 + ';');
            }
            return builder.ToString();
        }
        public string ToArgumentsOffLine(string _username, string _GameRootPath)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(mainClass + " ");
            string Arguments = minecraftArguments;
            Arguments = Arguments.Replace("${auth_player_name}", _username);
            Arguments = Arguments.Replace("${version_name}", id);
            Arguments = Arguments.Replace("${game_directory}", (char)34 + _GameRootPath + (char)34);
            Arguments = Arguments.Replace("${assets_root}", (char)34 + _GameRootPath + @"\assets" + (char)34);
            if (this.assets != "")
            {
                Arguments = Arguments.Replace("${assets_index_name}", assets);
            }
            else
            {
                List<string> str123 = new List<string>();

                Global._SearchFiles(_GameRootPath + @"\assets\imdexes", ".json", ref str123);
                if (str123.Count == 0)
                {
                    string[] str3 = id.Split('.');
                    assets = str3[0] + "." + str3[1];
                    Arguments = Arguments.Replace("${assets_index_name}", assets);
                }
                else
                {
                    assets = Path.GetFileNameWithoutExtension(str123[0]);
                    Arguments = Arguments.Replace("${assets_index_name}", assets);
                }
            }
            // LauncherForm.P.Print("==>" + assets);
            Arguments = Arguments.Replace("${user_properties}", "{}");
            Arguments = Arguments.Replace("${user_type}", "Mojang");
            builder.Append(Arguments);
            return builder.ToString();
        }
        public OriginalJson() { id = ""; minecraftArguments = ""; mainClass = ""; assets = ""; }
        public string id { get; set; }
        public string assets { get; set; }
        public string minecraftArguments { get; set; }
        public string mainClass { get; set; }
        public JsonData libraries { get; set; }
    }
}
