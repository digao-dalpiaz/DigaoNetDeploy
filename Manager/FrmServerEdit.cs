namespace Manager
{
    public partial class FrmServerEdit : Form
    {

        public Server Server;

        public FrmServerEdit()
        {
            InitializeComponent();
        }

        private void FrmServerEdit_Load(object sender, EventArgs e)
        {
            if (Server != null)
            {
                Text = "Edit Server";

                EdName.Text = Server.Name;
                EdHost.Text = Server.Host;
                EdPort.Text = Server.Port.ToString();
                EdUser.Text = Server.User;
                EdPassword.Text = Server.Password;
                EdKeyFile.Text = Server.KeyFile;
            }
        }

        private bool ValidateField(TextBox ed, string fieldName)
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
 
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateField(EdName, "Name")) return;
            if (!ValidateField(EdHost, "Host")) return;
            if (!ValidateField(EdPort, "Port")) return;
            
            if (!short.TryParse(EdPort.Text, out _))
            {
                Messages.Error("Port is invalid");
                return;
            }

            if (!ValidateField(EdUser, "User")) return;

            //

            if (Server == null)
            {
                Server = new();
                Server.Id = Guid.NewGuid();
            }

            Server.Name = EdName.Text;
            Server.Host = EdHost.Text;
            Server.Port = short.Parse(EdPort.Text);
            Server.User = EdUser.Text;
            Server.Password = EdPassword.Text;
            Server.KeyFile = EdKeyFile.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
