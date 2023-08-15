namespace VinylTap.Helpers;
//used for accessing application settings via objects that are injected into classes using the .NET 6.0 dependency injection (DI) system
//optional - may omit
public class AppSettings
{
    public string Secret {get; set;}
}