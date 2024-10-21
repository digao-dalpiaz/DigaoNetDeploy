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
            bool success = false;
            try
            {
                FindServer();
                CreateSSH();

                LogService.Log($"Connecting to server '{_server.Name}'...");
                _ssh.Connect();
                LogService.Log("Connected!");

                ExecuteSteps();
                success = true;
            }
            catch (Exception ex)
            {
                LogService.Log("ERROR: " + ex.Message, Color.Crimson);
            }

            //close connections
            if (_sftp != null && _sftp.IsConnected)
            {
                LogService.Log("Disconnecting from sftp...");
                _sftp.Disconnect();
            }

            if (_ssh != null && _ssh.IsConnected)
            {
                LogService.Log("Disconnecting from server...");
                _ssh.Disconnect();
            }

            //final log
            if (success)
            {
                LogService.Log("Pipeline finished!", Color.Lime);
            }
            else
            {
                LogService.Log("Pipeline ended unexpectedly!", Color.Gray);
            }
        }

        private void FindServer()
        {
            _server = Vars.Config.Servers.Find(x => x.Id == _pipeline.ServerId);
            if (_server == null) throw new Exception($"Server '{_pipeline.ServerId}' not found");
        }

        private void CreateSSH()
        {
            _ssh = new SshClient(_server.Host, _server.Port, _server.User, new PrivateKeyFile(_server.KeyFile));
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

                LogService.Log("Operation: " + opDef.Name, Color.RebeccaPurple);

                var args = GetArguments(step, opDef);

                var parameters = new OperationParams();
                parameters.Arguments = args;
                parameters.Server = _server;
                parameters.GetSftp = GetSftp;

                opDef.Action(parameters);
            }
        }

        private static ArgumentsDictionary GetArguments(Step step, OperationDef opDef)
        {
            var typedArgs = new ArgumentsDictionary();

            var lines = step.Arguments.Split(Environment.NewLine);
            foreach (var line in lines.Select(x => x.Trim()))
            {
                if (line.StartsWith("//")) continue;

                int i = line.IndexOf('=');
                if (i == -1) continue;

                string key = line[..i].Trim();
                string value = line[(i + 1)..].Trim();

                if (typedArgs.ContainsKey(key)) throw new Exception($"Duplicated key '{key}'");

                typedArgs.Add(key, value);
            }

            //

            var args = new ArgumentsDictionary();

            foreach (var arg in opDef.Arguments)
            {
                if (!typedArgs.TryGetValue(arg.Ident, out string value))
                {
                    if (arg.Default == null) throw new Exception($"Argument '{arg.Ident}' not specifyed");
                    value = arg.Default;
                }

                args.Add(arg.Ident, value);
            }

            return args;
        }

        private SftpClient GetSftp()
        {
            if (_sftp == null)
            {
                _sftp = new SftpClient(_server.Host, _server.Port, _server.User, new PrivateKeyFile(_server.KeyFile));

                _sftp.ErrorOccurred += SFTP_ErrorOccurred;

                LogService.Log("Connecting to SFTP service...");
                _sftp.Connect();
                LogService.Log("Connected!");
            }
            return _sftp;
        }

        private void SFTP_ErrorOccurred(object sender, ExceptionEventArgs e)
        {
            LogService.Log("SFTP exception: " + e.Exception.Message, Color.Crimson);
        }

    }
}
