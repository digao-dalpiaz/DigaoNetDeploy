using Manager.Utility;

namespace Manager.Definitions
{
    internal class OperationDefList
    {

        public static List<OperationDef> Operations =
        [
            new()
            {
                Ident = "EXEC_CMD",
                Name = "Execute command",
                Description = "Execute a command in server side",
                Arguments =
                [
                    new() { Ident = "CMD", Kind = ArgumentKind.STRING, Description = "Command to execute" },
                ],
                Action = (p) => new OperationsExec(p).ExecCmd()
            },

            new()
            {
                Ident = "COPY_FILE",
                Name = "Copy file",
                Description = "Copy a file from this machine to server",
                Arguments =
                [
                    new() { Ident = "LOCAL_FILE", Kind = ArgumentKind.STRING, Description = "Local file (this machine)" },
                    new() { Ident = "REMOTE_FILE", Kind = ArgumentKind.STRING, Description = "Remote file (server)" },
                    new() { Ident = "OVERWRITE", Kind = ArgumentKind.BOOLEAN, Default = "N", Description = "Overwrite existing file on server" },
                    new() { Ident = "REPLACE_VARS", Kind = ArgumentKind.BOOLEAN, Default = "N", Description = "Replace environment variables on remote file" },
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

            new()
            {
                Ident = "GET_CD_SLOT",
                Name = "Get CD Slot",
                Description = "Retrieve slot for Continuous Delivery from server",
                Arguments =
                [
                    new() { Ident = "SERVICE_A", Kind = ArgumentKind.STRING, Description = "Service name for slot A" },
                    new() { Ident = "SERVICE_B", Kind = ArgumentKind.STRING, Description = "Service name for slot B" },
                    new() { Ident = "PORT_A", Kind = ArgumentKind.STRING, Default = "0", Description = "Port for slot A" },
                    new() { Ident = "PORT_B", Kind = ArgumentKind.STRING, Default = "0", Description = "Port for slot B" },
                ],
                Action = (p) => new OperationsExec(p).GetCDSlot()
            },
        ];

    }
}
