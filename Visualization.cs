using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Test
{
    internal class Visualization
    {
        public static void PrintUI()
        {
            string timestamp = "";
            foreach (DataRow row in Data.dt.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row.Field<string>("Timestamp")))
                    timestamp = row.Field<string>("Timestamp");
            }
            Console.WriteLine(timestamp);
        }
    }
}
