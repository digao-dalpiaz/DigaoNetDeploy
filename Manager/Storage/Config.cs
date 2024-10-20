﻿using Newtonsoft.Json;

namespace Manager.Storage
{
    internal class Config
    {
        public List<Server> Servers;
        public List<Pipeline> Pipelines;
    }

    public abstract class NamedClass
    {
        public string Name;
    }

    public enum ServerStatus
    {
        DISCONNECTED, CONNECTING, CONNECTED
    }

    public class Server : NamedClass
    {
        public Guid Id;
        public string Host;
        public int Port;
        public string User;
        public string Password;
        public string KeyFile;

        [JsonIgnore]
        public ServerStatus Status = ServerStatus.DISCONNECTED;
    }

    public class Pipeline : NamedClass
    {
        public List<Step> Steps;
    }

    public class Step
    {
        public string Name;
    }
}
