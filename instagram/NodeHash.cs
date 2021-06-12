using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class NodeHash
    {
        public object data;
        public int hashid;

        public NodeHash()
        {
            data = null;
            hashid = 0;
        }

        public NodeHash(object pdata, int pid)
        {
            data = pdata;
            hashid = pid;
        }
    }
}
