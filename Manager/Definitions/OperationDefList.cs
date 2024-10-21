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
                    new() { Ident = "LOCAL_FILE", Kind = ArgumentKind.STRING, Description = "Local file (this machine)" },
                    new() { Ident = "REMOTE_FILE", Kind = ArgumentKind.STRING, Description = "Remote file (server)" },
                ],
                Action = (p) => new OperationsExec(p).CopyFile()
            },

            new()
            {
                Ident = "COPY_FOLDER",
                Name = "Copy folder",
                Description = "Copy a folder from this machine to server",
                Arguments =
                [
                    new() { Ident = "LOCAL_FOLDER", Kind = ArgumentKind.STRING, Description = "Local folder (this machine)" },
                    new() { Ident = "REMOTE_FOLDER", Kind = ArgumentKind.STRING, Description = "Remote folder (server)" },
                    new() { Ident = "DELETE_EXISTING_FILES", Kind = ArgumentKind.BOOLEAN, Default = "N", Description = "Delete existing files on server" },
                    new() { Ident = "OVERWRITE_EXISTING_FILES", Kind = ArgumentKind.BOOLEAN, Default = "N", Description = "Overwrite existing files on server" },
                ],
                Action = (p) => new OperationsExec(p).CopyFolder()
            },
        ];

    }
}
