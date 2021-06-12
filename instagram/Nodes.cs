using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class Nodes
    {

        public Nodes node;
        public Object data;
        public Nodes next;
        public Nodes last;

        public Nodes()
        {
            node = null;
            data = null;
        }

        public Nodes(Object pData)
        {
            node = null;
            data = pData;
        }
    }
}
