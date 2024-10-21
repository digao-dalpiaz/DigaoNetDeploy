namespace Manager.Definitions
{
    internal class OperationArgument
    {
        public string Ident;
        public string Description;
        public ArgumentKind Kind;
        public bool Optional;

        public override string ToString()
        {
            return Ident + " : " + Description;
        }
    }
}
