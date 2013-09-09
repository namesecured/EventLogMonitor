using System.Diagnostics;

namespace Core
{
    public interface IHealthMonitor
    {
        void OnEntryWritten(object sender, EntryWrittenEventArgs e);
    }
}
