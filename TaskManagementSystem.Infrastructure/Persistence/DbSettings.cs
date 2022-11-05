

namespace TaskManagementSystem.Infrastructure.Persistence
{
    public class DbSettings
    {
        public static string ConnectionStringSection = "DbSettings:ConnectionString";
        public string ConnectionString { get; set; }
    }
}
