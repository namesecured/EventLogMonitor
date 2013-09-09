using System;
using System.Diagnostics;

namespace Core
{
    public interface IEventProvider
    {
        event Action<object, EntryWrittenEventArgs> OnEntryWritten;
    }
}
