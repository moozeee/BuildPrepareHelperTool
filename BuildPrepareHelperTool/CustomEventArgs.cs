using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildPrepareHelperTool
{
    public class CustomEventArgs : EventArgs
    {
        public string TextForConsoleField;
        public CustomEventArgs(string textForConsoleField)
        {
            TextForConsoleField = textForConsoleField;
        }
    }
}
