using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Manager
{
    public class DALProxy
    {
        private IDALManager _manager;

        public IDALManager Manager
        {
            get { return _manager; }
            private set { _manager = value; }
        }

        public DALProxy()
        {
            // Change if you want to use Stub data or DB data
            //Manager = new StubDALManager();
            Manager = new DALManager();
        }
    }
}
