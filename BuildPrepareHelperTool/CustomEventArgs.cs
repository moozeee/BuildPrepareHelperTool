using System;

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
