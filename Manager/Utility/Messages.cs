namespace Manager.Utility
{
    internal class Messages
    {

        public static void Error(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool ValidateField(TextBox ed, string fieldName)
        {
            ed.Text = ed.Text.Trim();
            if (ed.Text == string.Empty)
            {
                Messages.Error($"{fieldName} is empty");
                ed.Focus();
                return false;
            }

            return true;
        }

    }
}
