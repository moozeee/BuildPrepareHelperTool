using System;
using System.Windows.Forms;

namespace BuildPrepareHelperTool
{
    public  class Logger
    {
        public  event System.EventHandler<CustomEventArgs> MyEvent;
        public  void WriteToConsole(string s)
        {
            MyEvent?.Invoke(this, new CustomEventArgs(s));
        }
    }
}
