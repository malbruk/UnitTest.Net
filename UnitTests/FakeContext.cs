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
        public List<string> Values { get; set; }

        public FakeContext()
        {
            Values = new List<string>
            {
                "text a",
                "text b"
            };
        }
    }
}
