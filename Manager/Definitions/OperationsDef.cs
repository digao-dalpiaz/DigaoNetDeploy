﻿namespace Manager.Definitions
{
    internal class OperationsDef
    {

        public static List<OperationDef> Operations =
        [
            new()
            {
                Ident = "DEPLOY_APP_CICD",
                Description = "Deploy Application using CI/CD",
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
