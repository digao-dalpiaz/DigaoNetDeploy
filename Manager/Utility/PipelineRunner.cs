using Manager.Storage;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace Manager.Utility
{
    internal class PipelineRunner(Pipeline _pipeline)
    {

        private Server _server;
        private SshClient _ssh;

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
            _ssh = new SshClient(_server.Host, _server.Port, _server.User, _server.Password);
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
            }
        }

    }
}
