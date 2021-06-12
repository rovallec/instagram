using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class following_followers
    {
        public string follower;
        public string following;

        public following_followers()
        {
          follower = null;
          following = null;
        }

        public following_followers(string fl, string flw)
        {
            follower = fl;
            following = flw;
        }
    }
}
