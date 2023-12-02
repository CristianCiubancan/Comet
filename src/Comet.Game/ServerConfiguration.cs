using Microsoft.Extensions.Configuration;

namespace Comet.Game.Database
{
    public class ServerConfiguration 
    {
        public static ServerConfiguration Configuration { get; set; }
        public DatabaseConfiguration Database { get; set; }
        public GameNetworkConfiguration GameNetwork { get; set; }
        public RpcNetworkConfiguration RpcNetwork { get; set; }
        public AuthenticationConfiguration Authentication { get; set; }
        

        public class DatabaseConfiguration
        {
            public string Hostname { get; set; }
            public string Schema { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class GameNetworkConfiguration
        {
            public string IPAddress { get; set; }
            public int Port { get; set; }
            public int MaxConn { get; set; }
        }

        public class RpcNetworkConfiguration
        {
            public string IPAddress { get; set; }
            public int Port { get; set; }
        }

        public class AuthenticationConfiguration
        {
            public bool StrictAuthPass { get; set; }
        }

        public ServerConfiguration(string[] args)
        {
            new ConfigurationBuilder()
                .AddJsonFile("Comet.Game.config")
                .AddCommandLine(args)
                .Build()
                .Bind(this);
        }

        public bool Valid => 
            this.Database != null && 
            this.GameNetwork != null &&
            this.RpcNetwork != null &&
            this.Authentication != null;
    }
}
