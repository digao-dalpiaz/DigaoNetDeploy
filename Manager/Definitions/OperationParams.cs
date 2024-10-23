using Manager.Storage;
using Renci.SshNet;

namespace Manager.Definitions
{
    internal class OperationParams
    {
        public ArgumentsDictionary Arguments;
        public Server Server;
        public SshClient Ssh;
        public Func<SftpClient> GetSftp;

        public EnvVarsDictionary EnvVars;
    }
}
