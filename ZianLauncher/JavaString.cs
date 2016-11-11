using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZianLauncher
{
    public class AuthenticationInfo
    {
        public Guid AccessToken { get; set; }
        public Dictionary<string, string> AdvancedInfo { get; set; }
        public string DisplayName { get; set; }
        public string Error { get; set; }
        public string Properties { get; set; }
        public string UserType { get; set; }
        public Guid UUID { get; set; }
    }
    public class Version
    {
        public string Assets { get; set; }
        public string Id { get; set; }
        public List<Library> Libraries { get; set; }
        public string MainClass { get; set; }
        public string MinecraftArguments { get; set; }
        public List<Native> Natives { get; set; }
        public class Library
        {
            public string Name { get; set; }
            public string NS { get; set; }
            public string Version { get; set; }
        }

        public class Native
        {
            // Properties
            public string Name { get; set; }
            public string NativeSuffix { get; set; }
            public string NS { get; set; }
            public UnzipOptions Options { get; set; }
            public string Version { get; set; }
        }
        public class UnzipOptions
        {
            public UnzipOptions() { }
            public List<string> Exclude { get; set; }
        }
    }
    public class MinecraftLaunchArguments
    {
        // Fields
        AuthenticationInfo authentication;
        Version version;
        // Methods
        public  string DoReplace(this string source, IDictionary<string, string> dic)
        {
            foreach (KeyValuePair<string, string> pair in dic)
            {
                string oldValue = "${" + pair.Key + "}";
                source = source.Replace(oldValue, pair.Value);
            }
            return source;
        }
        public MinecraftLaunchArguments()
        {
            this.CGCEnabled = true;
            this.Tokens = new Dictionary<string, string>();
            this.AdvencedArguments = new List<string>();
        }
        public string ToArguments()
        {
            StringBuilder builder = new StringBuilder();
            if (this.CGCEnabled)
            {
                builder.Append("-Xincgc");
            }
            if (this.MinMemory > 0)
            {
                builder.Append(" -Xms").Append(this.MinMemory).Append("M ");
            }
            if (this.MaxMemory > 0)
            {
                builder.Append(" -Xmx").Append(this.MaxMemory).Append("M");
            }
            else
            {
                builder.Append("-Xmx2048M ");
            }
            foreach (string str in this.AdvencedArguments)
            {
                builder.Append(' ').Append(str);
            }
            builder.Append(" -Djava.library.path=\"").Append(this.NativePath);
            builder.Append("\" -cp \"");
            foreach (string str2 in this.Libraries)
            {
                builder.Append(str2).Append(';');
            }
            builder.Append("\" ").Append(this.MainClass).Append(' ').Append(this.MinecraftArguments.DoReplace(this.Tokens));
            return builder.ToString();
        }
        // Properties
        public List<string> AdvencedArguments { get; set; }
        public bool CGCEnabled { get; set; }
        public List<string> Libraries { get; set; }
        public string MainClass { get; set; }
        public int MaxMemory { get; set; }
        public string MinecraftArguments { get; set; }
        public int MinMemory { get; set; }
        public string NativePath { get; set; }
        public Dictionary<string, string> Tokens { get; set; }

    }



}
