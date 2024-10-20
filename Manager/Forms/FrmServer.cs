using Manager.Storage;
using Manager.Utility;

namespace Manager
{
    public partial class FrmServer : Form
    {

        public Server ReturningObj { get; set; }

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

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!Messages.ValidateField(EdName, "Name")) return;
            if (!Messages.ValidateField(EdHost, "Host")) return;
            if (!Messages.ValidateField(EdPort, "Port")) return;

            if (!int.TryParse(EdPort.Text, out var port))
            {
                Messages.Error("Port is invalid");
                return;
            }

            if (!Messages.ValidateField(EdUser, "User")) return;

            //

            if (ReturningObj == null)
            {
                ReturningObj = new();
                ReturningObj.Id = Guid.NewGuid();
            }

            ReturningObj.Name = EdName.Text;
            ReturningObj.Host = EdHost.Text;
            ReturningObj.Port = port;
            ReturningObj.User = EdUser.Text;
            ReturningObj.Password = EdPassword.Text;
            ReturningObj.KeyFile = EdKeyFile.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
