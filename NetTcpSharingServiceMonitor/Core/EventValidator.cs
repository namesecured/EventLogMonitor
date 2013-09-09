using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class EventValidator :IEventValidator
    {
        public bool IsEventExpected(EntryWrittenEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
