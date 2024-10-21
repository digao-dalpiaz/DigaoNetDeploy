namespace Manager.Definitions
{
    internal class OperationArgument
    {
        public string Ident;
        public string Description;
        public ArgumentKind Kind;
        public string Default;

        public override string ToString()
        {
            return $"{Ident} [{Kind}] - {Description}" + (Default != null ? $" (default {Default})" : "");
        }
    }
}
