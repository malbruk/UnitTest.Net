using CsvHelper.Configuration.Attributes;

namespace BasicAPI
{
    public class Event
    {
        [Index(0)]
        public int Id { get; set; }

        [Index(1)]
        public string Title { get; set; }

        [Index(2)]
        public DateTime Start { get; set; }
    }
}
