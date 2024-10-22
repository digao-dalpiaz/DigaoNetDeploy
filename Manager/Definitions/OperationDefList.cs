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

            new()
            {
                Ident = "GET_NEXT_CD_SLOT",
                Name = "Get Next CD Slot",
                Description = "Retrieve next slot for Continuous Delivery from server",
                Arguments =
                [
                    new() { Ident = "SLOT_FILE", Kind = ArgumentKind.STRING, Description = "Remote slot file (server)" },
                    new() { Ident = "PORT_A", Kind = ArgumentKind.STRING, Default = "0", Description = "Port for slot A" },
                    new() { Ident = "PORT_B", Kind = ArgumentKind.STRING, Default = "0", Description = "Port for slot B" },
                ],
                Action = (p) => new OperationsExec(p).GetNextCDSlot()
            },

            new()
            {
                Ident = "SAVE_CD_SLOT",
                Name = "Save CD Slot",
                Description = "Save new slot into slot file on server (require previous slot retrieving)",
                Arguments =
                [
                ],
                Action = (p) => new OperationsExec(p).SaveCDSlot()
            },
        ];

    }
}
