using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Net6.API.CleanArchitecture.Domain.Constants
{
    /// <summary>
    /// Class to hold constants for ConnectionString settings (appSettings.json --> ConnectionStrings)
    /// </summary>
    public partial class Constants
    {
        public static class ConnectionStringKeys
        {
            /// <summary>
            /// constant for the MGDemoDb connection string
            /// </summary>
            public const string MG_DEMO_DB_SQL_CONNECTION_STRING = "MGDemoDbConnectionString";
        }
    }
}
