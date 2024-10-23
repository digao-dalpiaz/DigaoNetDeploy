using Manager.Definitions;
using System.Text;

namespace Manager.Utility
{
    internal class OperationsExec(OperationParams _params)
    {

        private void ReplaceAllEnvVars(ref string input)
        {
            foreach (var sVar in _params.EnvVars)
            {
                input = input.Replace("{$" + sVar.Key + "}", sVar.Value);
            }
        }

        private string GetArg(string key)
        {
            string value = _params.Arguments[key];
            ReplaceAllEnvVars(ref value);
            return value;
        }

        private bool GetBoolArg(string key)
        {
            return GetArg(key) == "Y";
        }

        public void ExecCmd()
        {
            string cmdLine = GetArg("CMD");

            LogService.Log("> " + cmdLine);

            var command = _params.Ssh.CreateCommand(cmdLine);
            command.Execute();

            if (!string.IsNullOrEmpty(command.Result))
            {
                LogService.Log(command.Result.Trim(), Color.Bisque);
            }

            if (command.ExitStatus != 0)
            {
                throw new Exception("Error on command: " + command.Error.Trim());
            }
        }

        public void CopyFile()
        {
            string from = GetArg("LOCAL_FILE");
            string to = GetArg("REMOTE_FILE");

            bool overwrite = GetBoolArg("OVERWRITE");
            bool replaceVars = GetBoolArg("REPLACE_VARS");

            LogService.Log("Local File: " + from);
            LogService.Log("Remote File: " + to);

            var sftp = _params.GetSftp();

            using (var fileStream = new FileStream(from, FileMode.Open, FileAccess.Read))
            {
                Stream finalStream;
                if (replaceVars)
                {
                    string content;
                    using (var reader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        content = reader.ReadToEnd();
                    }
                    ReplaceAllEnvVars(ref content);
                    finalStream = new MemoryStream(Encoding.UTF8.GetBytes(content));
                }
                else
                {
                    finalStream = fileStream;
                }

                sftp.UploadFile(finalStream, to, overwrite);
            }
        }

        public void CopyFolder()
        {
            string from = GetArg("LOCAL_FOLDER");
            string to = GetArg("REMOTE_FOLDER");

            bool deleteExistingFiles = GetBoolArg("DELETE_EXISTING_FILES");
            bool overwriteExistingFiles = GetBoolArg("OVERWRITE_EXISTING_FILES");

            LogService.Log("Local Folder: " + from);
            LogService.Log("Remote Folder: " + to);

            var sftp = _params.GetSftp();

            if (sftp.Exists(to))
            {
                if (deleteExistingFiles)
                {
                    var remoteFiles = sftp.ListDirectory(to).Where(x => x.IsRegularFile).ToList();
                    if (remoteFiles.Count > 0) LogService.Log("Files to delete: " + remoteFiles.Count);
                    foreach (var file in remoteFiles)
                    {
                        LogService.Log($"Deleting existing file '{file.FullName}'...");
                        sftp.DeleteFile(file.FullName);
                    }
                }
            }
            else
            {
                sftp.CreateDirectory(to);
            }

            var localFiles = Directory.GetFiles(from);
            LogService.Log("Files to upload: " + localFiles.Length);
            foreach (var file in localFiles)
            {
                string remoteFileName = to + "/" + Path.GetFileName(file);

                LogService.Log($"Send file from '{file}' to '{remoteFileName}'");

                if (!overwriteExistingFiles && sftp.Exists(remoteFileName))
                {
                    throw new Exception("File already exists on server");
                }

                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    sftp.UploadFile(fileStream, remoteFileName, overwriteExistingFiles);
                }
            }
        }

        public void GetCDSlot()
        {
            string serviceA = GetArg("SERVICE_A");
            string serviceB = GetArg("SERVICE_B");

            string portA = GetArg("PORT_A");
            string portB = GetArg("PORT_B");

            bool IsActive(string service)
            {
                var cmd = _params.Ssh.RunCommand($"systemctl is-active {service}");
                return cmd.ExitStatus == 0;
            }

            bool activeA = IsActive(serviceA);
            bool activeB = IsActive(serviceB);

            if (activeA && activeB) throw new Exception("Both slots are active!");

            _params.EnvVars["SLOT_CURR_FLAG"] = activeA ? "A" : "B";
            _params.EnvVars["SLOT_NEXT_FLAG"] = !activeA ? "A" : "B";
            _params.EnvVars["SLOT_NEXT_PORT"] = !activeA ? portA : portB;

            LogService.Log("Next Slot = " + _params.EnvVars["SLOT_NEXT_FLAG"]);
        }

    }
}
