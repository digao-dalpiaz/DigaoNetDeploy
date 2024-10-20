namespace Manager.Definitions
{
    internal class OperationDefList
    {

        public static List<OperationDef> Operations =
        [
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
