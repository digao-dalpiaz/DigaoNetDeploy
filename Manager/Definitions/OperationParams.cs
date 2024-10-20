using Manager.Storage;
using Renci.SshNet;

namespace Manager.Definitions
{
    internal class OperationParams
    {
        public ArgumentsDictionary Arguments;
        public Server Server;
        public Func<SftpClient> GetSftp;
    }
}
