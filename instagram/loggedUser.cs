using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class loggedUser
    {
        public users lgUser = null;

        public loggedUser()
        {
            lgUser = getloggedUser();
        }

        public void setUser(users us)
        {
            lgUser = us;
        }

        public users getloggedUser()
        {
            return lgUser;
        }

    }
}
