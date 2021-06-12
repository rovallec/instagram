using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class Posts
    {
        public string username;
        public string post;
        public string multimedia;

        public Posts()
        {
            username = null;
            post = null;
            multimedia = null;
        }

        public Posts(string usr, string pst, string im)
        {
            username = usr;
            post = pst;
            multimedia = im;
        }
    }
}
