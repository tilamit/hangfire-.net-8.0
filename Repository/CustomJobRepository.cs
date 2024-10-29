using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using OurAppWithHangfire.Interface;
using System.Globalization;
using System.IO;
using System.Text;

namespace OurAppWithHangfire.Repository
{
    public class CustomJobRepository : ICustomJob
    {
        private readonly string? _connectionString;
        public CustomJobRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DbConnectionString");
        }

        public void RunJob()
        {
            string date = DateTime.Now.Date.ToString("dd-mmm-yyyy");
            string time = DateTime.Now.Ticks.ToString();

            string str = DateTime.Now.ToString("MdyyyyHHmmss", CultureInfo.InvariantCulture);
            DateTime dt = DateTime.ParseExact(str, "MdyyyyHHmmss", CultureInfo.InvariantCulture);

            string fileName = "dbBackup_" + str + ".sql";
            string targetFile = @"File Path Here" + fileName;

            var script = new StringBuilder();

            Server server = new Server(new ServerConnection(new SqlConnection(_connectionString)));
            Database database = server.Databases["SampleDb"];
            ScriptingOptions options = new ScriptingOptions
            {
                ScriptData = true,
                ScriptSchema = true,
                ScriptDrops = false,
                Indexes = true,
                IncludeHeaders = true
            };

            foreach (Table table in database.Tables)
            {
                foreach (var statement in table.EnumScript(options))
                {
                    script.Append(statement);
                    script.Append(Environment.NewLine);
                }
            }

            System.IO.File.Create(targetFile).Dispose();
            System.IO.File.WriteAllText(targetFile, script.ToString());
        }
    }
}
