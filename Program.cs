namespace JSON_Test
{
    public class Program
    {
        public static string ReportPath = "";
        public static void Main()
        {
            Console.Write("Enter full path to exported Report: ");
            ReportPath = Console.ReadLine();
            if (File.Exists(ReportPath) && ReportPath.EndsWith(".csv"))
            {
                // Populate Datatable
                Data.dt = Data.ReadCSV(Data.dt,ReportPath);
            }
            Visualization.PrintUI();
            Console.ReadLine();
        }
    }
}