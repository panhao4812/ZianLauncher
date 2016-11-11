using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ZianLauncher
{
    class LauncherCore
    {
        internal int currentCode;
        private Action<LaunchHandle, int> GameExit;
        private Action<LaunchHandle, string> GameLog;
        internal object locker;
        internal Random random;


        public string GameRootPath { get; private set; }
        public string JavaPath { get; set; }

        public LaunchHandle Launch(LaunchOptions options, params Action<MinecraftLaunchArguments>[] argumentsOperators)
        {
            lock (this.locker)
            {
                if (!File.Exists(this.JavaPath))
                {
                    return null;
                }
                this.currentCode = this.random.Next();
                MinecraftLaunchArguments arguments = this.GenerateArguments(options);
                if (arguments == null)
                {
                    return null;
                }
                if (argumentsOperators != null)
                {
                    foreach (Action<MinecraftLaunchArguments> action in argumentsOperators)
                    {
                        if (action != null)
                        {
                            action(arguments);
                        }
                    }
                }
                return this.launch(arguments);
            }
        }



        private LaunchHandle launch(MinecraftLaunchArguments args)
        {
            try
            {
                LaunchHandle handle = new LaunchHandle(args.authentication)
                {
                    code = this.currentCode,
                    core = this
                };
                ProcessStartInfo startInfo = new ProcessStartInfo(this.JavaPath)
                {
                    Arguments = args.ToArguments(),
                    UseShellExecute = false,
                    WorkingDirectory = this.GameRootPath,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
                handle.process = Process.Start(startInfo);
                handle.work();
                Task.Factory.StartNew(delegate {
                    handle.process.WaitForExit();
                }).ContinueWith(delegate (Task t) {
                    Directory.Delete(args.NativePath, true);
                    handle._thError.Abort();
                    handle._thOutput.Abort();
                    this.exit(handle, handle.process.ExitCode);
                });
                return handle;
            }
            catch (Exception)
            {
                return null;
            }
        }





    }
}
