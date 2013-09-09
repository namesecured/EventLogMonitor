using System.Diagnostics;

namespace Core
{
    public interface IEventValidator
    {
        bool IsEventExpected(EntryWrittenEventArgs eventArgs);
    }
}