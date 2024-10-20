namespace Manager.Utility
{
    internal class LogService
    {

        public static RichTextBox LogControl { get; set; }

        //--
        private const int EM_GETSCROLLPOS = 0x0400 + 221;
        private const int EM_SETSCROLLPOS = 0x0400 + 222;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref Point lParam);
        //--

        //--
        private static void BeginUpdate(RichTextBox richTextBox)
        {
            SendMessage(richTextBox.Handle, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero);
        }

        private static void EndUpdate(RichTextBox richTextBox)
        {
            SendMessage(richTextBox.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
            richTextBox.Invalidate();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private const int WM_SETREDRAW = 0x000B;
        //--

        public static void Log(string message, Color? color = null)
        {
            var ts = DateTime.Now;

            //File.AppendAllText(Path.Combine(AppContext.BaseDirectory, "log.txt"),
            //    dh.ToString("dd/MM/yyyy HH:mm:ss") + " - " + message + Environment.NewLine);

            LogControl.Invoke(() =>
            {
                var ed = LogControl;

                BeginUpdate(ed);

                Point pt = new Point();
                SendMessage(ed.Handle, EM_GETSCROLLPOS, IntPtr.Zero, ref pt);

                var currentSelStart = ed.SelectionStart;
                var currentSelLength = ed.SelectionLength;
                bool wasAtEnd = (currentSelStart == ed.TextLength);

                ed.SelectionStart = ed.TextLength;

                //ed.SelectionColor = Color.Gray;
                //ed.SelectedText = dh.ToString("HH:mm:ss") + " - ";

                ed.SelectionColor = color == null ? Color.White : color.Value;
                ed.SelectedText = message + Environment.NewLine;

                if (wasAtEnd)
                {
                    ed.ScrollToCaret();
                }
                else
                {
                    ed.Select(currentSelStart, currentSelLength);
                    SendMessage(ed.Handle, EM_SETSCROLLPOS, IntPtr.Zero, ref pt);
                }

                EndUpdate(ed);
            });
        }

    }
}
