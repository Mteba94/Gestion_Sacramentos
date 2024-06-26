namespace Api_SCI.Dtos
{
    public class AppSettingsJson
    {
        public static string ApplicationExeDirectory()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appRoot = System.IO.Path.GetDirectoryName(location);

            return appRoot;
        }

        public static IConfigurationRoot GetAppSettings()
        {
            var appRoot = ApplicationExeDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(appRoot)
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
