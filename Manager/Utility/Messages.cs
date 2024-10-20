namespace Manager.Utility
{
    internal class Messages
    {

        public static void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
