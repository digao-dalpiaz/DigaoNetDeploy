﻿using Manager.Definitions;
using Renci.SshNet;

namespace Manager.Utility
{
    internal class OperationsExec(OperationParams _params)
    {

        private string GetArg(string key)
        {
            if (!_params.Arguments.TryGetValue(key, out string value))
            {
                throw new Exception($"Argument '{key}' not found");
            }
            return value;
        }

        public void CopyFolder()
        {
            string from = GetArg("LOCAL_FOLDER");
            string to = GetArg("REMOTE_FOLDER");

            LogService.Log("Local Folder: " + from);
            LogService.Log("Remote Folder: " + to);

            using (var sftp = new SftpClient(_params.Server.Host, _params.Server.Port, _params.Server.User, _params.Server.Password))
            {
                sftp.Connect();

                if (sftp.Exists(to)) sftp.DeleteDirectory(to);
                sftp.CreateDirectory(to);

                var localFiles = Directory.GetFiles(from);
                foreach (var file in localFiles)
                {
                    using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        string remoteFileName = to + "/" + Path.GetFileName(file);

                        LogService.Log($"Send file from '{file}' to '{remoteFileName}'");
                        //sftp.UploadFile(fileStream, remoteFileName);
                    }
                }

                sftp.Disconnect();
            }
        }

    }
}
