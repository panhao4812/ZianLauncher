using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ZianLauncher
{
   

    public class LaunchHandle
    {
        // Fields
        internal StreamReader _gameerror;
        internal StreamReader _gameoutput;
        internal Thread _thError;
        internal Thread _thOutput;
        internal int code;
        internal LauncherCore core;
        public readonly AuthenticationInfo info;
        internal Process process;

        // Methods
        internal LaunchHandle(AuthenticationInfo info)
        {
            this.info = info;
        }

        internal void Logger()
        {
            this._gameoutput = this.process.StandardOutput;
            this._gameerror = this.process.StandardError;
            this._thOutput = new Thread(delegate
            {
                Label_0000:
                try
                {
                    if (!this._gameoutput.EndOfStream)
                    {
                        string line = this._gameoutput.ReadLine();
                        this.core.log(this, line);
                    }
                    goto Label_0000;
                }
                catch (Exception exception)
                {
                    string stackTrace = exception.StackTrace;
                    this.core.log(this, stackTrace);
                    goto Label_0000;
                }
            });
            this._thError = new Thread(delegate
            {
                Label_0000:
                try
                {
                    if (!this._gameerror.EndOfStream)
                    {
                        string line = this._gameerror.ReadLine();
                        this.core.log(this, line);
                    }
                    goto Label_0000;
                }
                catch (Exception exception)
                {
                    string stackTrace = exception.StackTrace;
                    this.core.log(this, stackTrace);
                    goto Label_0000;
                }
            });
            this._thOutput.IsBackground = true;
            this._thError.IsBackground = true;
            this._thOutput.Start();
            this._thError.Start();
        }

        internal void work()
        {
            this.Logger();
        }
    }
}

