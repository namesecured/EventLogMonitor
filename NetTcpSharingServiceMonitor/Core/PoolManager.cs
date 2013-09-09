using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Web.Administration;

namespace Core
{
    public class PoolManager : IPoolManager
    {
        private readonly ISettings settings;

        public PoolManager(ISettings settings)
        {
            this.settings = settings;
        }

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
