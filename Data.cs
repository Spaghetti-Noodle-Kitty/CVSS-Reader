using System.Data;

namespace JSON_Test
{
    public class Data
    {
        public static DataTable dt = new DataTable("Report");
        
        public static void main()
        {
            // Define DataTable with the same Columns the Report.csv has
            dt.Columns.Add(new DataColumn("IP", typeof(string)));
            dt.Columns.Add(new DataColumn("Hostname", typeof(string)));
            dt.Columns.Add(new DataColumn("Port", typeof(string)));
            dt.Columns.Add(new DataColumn("Port Protocol", typeof(string)));
            dt.Columns.Add(new DataColumn("CVSS", typeof(string)));
            dt.Columns.Add(new DataColumn("Severity", typeof(string)));
            dt.Columns.Add(new DataColumn("Solution Type", typeof(string)));
            dt.Columns.Add(new DataColumn("NVT Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Summary", typeof(string)));
            dt.Columns.Add(new DataColumn("Specific Result", typeof(string)));
            dt.Columns.Add(new DataColumn("NVT OID", typeof(string)));
            dt.Columns.Add(new DataColumn("CVEs", typeof(string)));
            dt.Columns.Add(new DataColumn("Task ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Task Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Timestamp", typeof(string)));
            dt.Columns.Add(new DataColumn("Result ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Impact", typeof(string)));
            dt.Columns.Add(new DataColumn("Solution", typeof(string)));
            dt.Columns.Add(new DataColumn("Affected Software/OS", typeof(string)));
            dt.Columns.Add(new DataColumn("Vulnerability Insight", typeof(string)));
            dt.Columns.Add(new DataColumn("Vulnerability Detection Method", typeof(string)));
            dt.Columns.Add(new DataColumn("Product Detection Result", typeof(string)));
            dt.Columns.Add(new DataColumn("BIDs", typeof(string)));
            dt.Columns.Add(new DataColumn("CERTs", typeof(string)));
            dt.Columns.Add(new DataColumn("Other References", typeof(string)));
        }

        public static DataTable ReadCSV(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }


            return dt;
        }
    }
}
