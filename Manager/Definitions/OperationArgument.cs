﻿namespace Manager.Definitions
{
    internal class OperationArgument
    {
        public string Ident;
        public string Description;

        public override string ToString()
        {
            return Ident + " : " + Description;
        }
    }
}
