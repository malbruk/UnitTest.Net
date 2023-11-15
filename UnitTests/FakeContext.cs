using BasicAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class FakeContext : IDataContext
    {
        public List<Event> Events { get; set; }

        public FakeContext()
        {
            Events = new List<Event>
            {
                new Event { Id = 1, Title = "Wedding"/*, Start = DateTime.Now*/ },
                new Event { Id = 2, Title = "Appointment"/*, Start = DateTime.Now.AddDays(2)*/}
            };
        }
    }
}
