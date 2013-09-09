using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
