namespace WebAPI_Studies
{
    public class Key
    {
        private static IConfiguration _configuration;

        public Key(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetSecret()
        {
            return _configuration.GetConnectionString("SecretAuth");
        }
    }
}
