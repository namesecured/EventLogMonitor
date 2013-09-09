using System;

namespace Core
{
    public interface IEventValidator
    {
        bool IsEventExpected(EventArgs e);
    }
}