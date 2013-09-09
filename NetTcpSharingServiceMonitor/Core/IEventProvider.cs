using System;

namespace Core
{
    public interface IEventProvider
    {
        event Action<object, EventArgs> OnEntryWritten;
    }
}
