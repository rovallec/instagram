using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    public class users : Comparator
    {
        public long idusers;
        public string username;
        public string fullName;
        public string image;
        public string birthDate;

        public users()
        {
            idusers = 0;
            username = null;
            fullName = null;
            birthDate = null;
        }

        public users(long id, string usr, string flName, string img, string brthd)
        {
            idusers = id;
            username = usr;
            fullName = flName;
            image = img;
            birthDate = brthd;
        }

        public bool igualQue(object q)
        {
            users var = (users)q;
            return idusers == var.idusers;
        }

        public bool mayorIgualQue(object q)
        {
            users var = (users)q;
            return idusers >= var.idusers;
        }

        public bool mayorQue(object q)
        {
            users var = (users)q;
            return idusers > var.idusers;
        }

        public bool menorIgualQue(object q)
        {
            users var = (users)q;
            return idusers <= var.idusers;
        }

        public bool menorQue(object q)
        {
            users var = (users)q;
            return idusers < var.idusers;
        }
    }
}
