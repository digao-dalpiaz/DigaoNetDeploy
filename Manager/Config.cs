namespace Manager
{
    internal class Config
    {
        public List<Server> Servers;
        public List<Pipeline> Pipelines;
    }

    public class Server
    {
        public Guid Id;
        public string Name;
        public string Host;
        public short Port;
        public string User;
        public string Password;
        public string KeyFile;
    }

    public class Pipeline
    {
        public string Name;
        public List<Step> Steps;
    }

    public class Step
    {
        public string Name;
    }
}
