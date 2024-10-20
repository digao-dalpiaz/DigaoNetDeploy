﻿using Manager.Definitions;

namespace Manager.Utility
{
    internal class OperationsExec(OperationParams _params)
    {

        private string GetArg(string key)
        {
            return _params.Arguments[key];
        }

        private bool GetBoolArg(string key)
        {
            return GetArg(key) == "Y";
        }

        public void CopyFile()
        {
            string from = GetArg("LOCAL_FILE");
            string to = GetArg("REMOTE_FILE");

            LogService.Log("Local File: " + from);
            LogService.Log("Remote File: " + to);

            var sftp = _params.GetSftp();


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

    }
}
