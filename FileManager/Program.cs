using System.Text.Json;

namespace FileManager;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        using (var fs = new FileStream("authorization.json", FileMode.OpenOrCreate))
        {
            var auth = new AuthorizationFields() { Login = "asd", Password = "Vetochka" };
            JsonSerializer.Serialize(fs, auth);
        }
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new AdmissionForm());
    }
}