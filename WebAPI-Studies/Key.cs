namespace WebAPI_Studies
{
    public class Key
    {
        private static IConfiguration _configuration;

        static Key()
        {
            _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .Build();
        }

        public static string GetSecret()
        {
            return _configuration.GetConnectionString("SecretAuth");
        }
    }
}
