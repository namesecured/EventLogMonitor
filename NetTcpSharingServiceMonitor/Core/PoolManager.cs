using System;
using System.IO;

namespace Core
{
    public class PoolManager : IPoolManager
    {
        public void Reset()
        {
            try
            {
                this.ResetInternal();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void ResetInternal()
        {
            var path = Path.Combine(Environment.SystemDirectory, "System32", "iisreset.exe");

            System.Diagnostics.Process.Start(path);
        }
    }
}
