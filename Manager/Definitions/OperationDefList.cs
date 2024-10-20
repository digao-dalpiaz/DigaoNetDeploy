using Manager.Utility;

namespace Manager.Definitions
{
    internal class OperationDefList
    {

        public static List<OperationDef> Operations =
        [
            new()
            {
                Ident = "COPY_FILE",
                Name = "Copy file",
                Description = "Copy a file from this machine to server",
                Arguments =
                [
                    new() { Ident = "LOCAL_FILE", Description = "Local file (this machine)" },
                    new() { Ident = "REMOTE_FILE", Description = "Remote file (server)" },
                ]
            },

            new()
            {
                Ident = "COPY_FOLDER",
                Name = "Copy folder",
                Description = "Copy a folder from this machine to server",
                Arguments =
                [
                    new() { Ident = "LOCAL_FOLDER", Description = "Local folder (this machine)" },
                    new() { Ident = "REMOTE_FOLDER", Description = "Remote folder (server)" },
                ],
                Action = (p) => new OperationsExec(p).CopyFolder()
            },



            new()
            {
                Ident = "DEPLOY_APP_CICD",
                Name = "Deploy Application using CI/CD",
                Description = "...",
                Arguments =
                [
                    new() { Ident = "", Description = "" },
                    new() { Ident = "", Description = "" },
                    new() { Ident = "", Description = "" },
                ]
            },
        ];

    }
}
