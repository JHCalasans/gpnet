
using appgp.Droid.Helpers;
using appgp.Helpers;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabasePath))]
namespace appgp.Droid.Helpers
{
    public class DatabasePath : IDBPath
    {
        public DatabasePath()
        { }
        public string GetDbPath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "EFCoreDB.db");
        }
    }
}