﻿namespace Manager.Definitions
{
    internal class OperationDef
    {
        public string Ident;
        public string Name;
        public string Description;
        public List<OperationArgument> Arguments;
        public Action<OperationParams> Action;

        public override string ToString()
        {
            return Name;
        }
    }
}
