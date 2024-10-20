using Manager.Definitions;
using Manager.Storage;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace Manager.Utility
{
    internal class PipelineRunner(Pipeline _pipeline)
    {

        private Server _server;
        private SshClient _ssh;
        private SftpClient _sftp;

        public void Run()
        {
            FindServer();
            CreateSSH();

            LogService.Log($"Connecting to server '{_server.Name}'...");
            try
            {
                _ssh.Connect();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error connecting to server: " + ex.Message);
            }

            try
            {
                ExecuteSteps();
            }
            finally
            {
                if (_sftp != null && _sftp.IsConnected)
                {
                    LogService.Log("Disconnecting from sftp...");
                    _sftp.Disconnect();
                }

                LogService.Log("Disconnecting from server...");
                _ssh.Disconnect();
            }

            LogService.Log("Pipeline finished!", Color.Lime);
        }

        private void FindServer()
        {
            _server = Vars.Config.Servers.Find(x => x.Id == _pipeline.ServerId);
            if (_server == null) throw new Exception($"Server '{_pipeline.ServerId}' not found");
        }

        private void CreateSSH()
        {
            var keyFile = new PrivateKeyFile(_server.KeyFile);

            _ssh = new SshClient(_server.Host, _server.Port, _server.User, keyFile);
            _ssh.ErrorOccurred += SSH_ErrorOccurred;
            _ssh.ServerIdentificationReceived += SSH_ServerIdentificationReceived;
        }

        private void SSH_ServerIdentificationReceived(object sender, SshIdentificationEventArgs e)
        {
            LogService.Log("Server identification: " + e.SshIdentification.ToString());
        }

        private void SSH_ErrorOccurred(object sender, ExceptionEventArgs e)
        {
            LogService.Log("Server exception: " + e.Exception.Message, Color.Crimson);
        }

        private void ExecuteSteps()
        {
            foreach (var step in _pipeline.Steps)
            {
                LogService.Log($"Step {step.Name}", Color.Yellow);

                var opDef = OperationDefList.Operations.Find(x => x.Ident == step.Operation);
                if (opDef == null) throw new Exception($"Operation '{step.Operation}' not found");

                LogService.Log("Operation: " + opDef.Name, Color.Purple);

                var args = GetArguments(step);

                var parameters = new OperationParams();
                parameters.Arguments = args;
                parameters.Server = _server;
                parameters.GetSftp = GetSftp;

                opDef.Action(parameters);
            }
        }

        private static ArgumentsDictionary GetArguments(Step step)
        {
            var args = new ArgumentsDictionary();

            var lines = step.Arguments.Split(Environment.NewLine);
            foreach (var line in lines.Select(x => x.Trim()))
            {
                if (line.StartsWith("//")) continue;

                int i = line.IndexOf('=');
                if (i == -1) continue;

                string key = line[..i];
                string value = line[(i + 1)..];

                if (args.ContainsKey(key)) throw new Exception($"Duplicated key '{key}'");

                args.Add(key, value);
            }

            return args;
        }

        private SftpClient GetSftp()
        {
            if (_sftp == null)
            {
                var keyFile = new PrivateKeyFile(_server.KeyFile);

                _sftp = new SftpClient(_server.Host, _server.Port, _server.User, keyFile);
                LogService.Log("Connecting to SFTP service...");
                _sftp.Connect();
                LogService.Log("Connected!");
            }
            return _sftp;
        }

    }
}
