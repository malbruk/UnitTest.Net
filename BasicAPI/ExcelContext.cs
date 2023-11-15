using CsvHelper;
using System.Globalization;

namespace BasicAPI
{
    public class ExcelContext : IDataContext
    {
        public List<Event> Events { get; set; }

        public ExcelContext()
        {

            using (var reader = new StreamReader("data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                Events = csv.GetRecords<Event>().ToList();
            }
        }
    }
}
