using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineOverheating
{
    public delegate void TestStandHandler(object sender, StandEvents e);

    public class StandEvents
    {
        public string Message { get; private set; }

        public StandEvents(string message)
        {
            Message = message;
        }
    }
}
