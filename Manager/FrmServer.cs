using Manager.Storage;

namespace Manager
{
    public partial class FrmServer : ReturningForm<Server>
    {

        public FrmServer()
        {
            InitializeComponent();
        }

        private void FrmServerEdit_Load(object sender, EventArgs e)
        {
            if (ReturningObj != null)
            {
                Text = "Edit Server";

                EdName.Text = ReturningObj.Name;
                EdHost.Text = ReturningObj.Host;
                EdPort.Text = ReturningObj.Port.ToString();
                EdUser.Text = ReturningObj.User;
                EdPassword.Text = ReturningObj.Password;
                EdKeyFile.Text = ReturningObj.KeyFile;
            }
        }

        private static bool ValidateField(TextBox ed, string fieldName)
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

            if (ReturningObj == null)
            {
                ReturningObj = new();
                ReturningObj.Id = Guid.NewGuid();
            }

            ReturningObj.Name = EdName.Text;
            ReturningObj.Host = EdHost.Text;
            ReturningObj.Port = short.Parse(EdPort.Text);
            ReturningObj.User = EdUser.Text;
            ReturningObj.Password = EdPassword.Text;
            ReturningObj.KeyFile = EdKeyFile.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
