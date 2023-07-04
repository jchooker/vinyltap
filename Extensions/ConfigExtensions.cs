using Microsoft.Extensions.Configuration; //rather than "ConfigurationExtensions.cs"

namespace VinylTap.Extensions
{
    public static class ConfigExtensions
    {
        public static IConfigurationBuilder AddDotEnvFile(this IConfigurationBuilder builder) 
        {
            builder.Add(new DotEnvFileSource());
            return builder;
        }
    }

    public class DotEnvFileSource : IConfigurationSource 
    { 
        public IConfigurationProvider Build(IConfigurationBuilder builder) 
        {
            return new DotEnvFileProvider();
        }
    }

    public class DotEnvFileProvider : ConfigurationProvider
    {
        public override void Load()
        {
            var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
            if (File.Exists(envFilePath))
            {
                var lines = File.ReadAllLines(envFilePath);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;

                    var parts = line.Split('=', 2);
                    if (parts.Length == 2)
                    {
                        Data[parts[0]] = parts[1];
                    }
                }
            }
            else {
                Console.WriteLine("No .env file found");
            }
        }
    }
}
