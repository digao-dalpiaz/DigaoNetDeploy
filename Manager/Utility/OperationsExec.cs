using Manager.Definitions;

namespace Manager.Utility
{
    internal class OperationsExec(ArgumentsDictionary _args)
    {

        private string GetArg(string key)
        {
            if (!_args.TryGetValue(key, out string value))
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


        }

    }
}
