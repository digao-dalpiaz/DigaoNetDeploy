using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void BtnOK_Click(object sender, EventArgs e)
        {
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
