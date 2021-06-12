using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class Logic
    {
        Boolean v;
        public Logic(Boolean f)
        {
            v = f;
        }
        public void setLogical(Boolean f)
        {
            v = f;
        }
        public Boolean booleanValue()
        {
            return v;
        }
    }
}
