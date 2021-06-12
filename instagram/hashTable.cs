using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class hashTable
    {
        public int lenght;
        public object[] hash_objects;

        public hashTable(int plenght)
        {
            lenght = plenght;
            hash_objects = new object[plenght];
        }

        public void insertOnhash(long pid, object padata)
        {
            int hash_pos = (int)(pid % lenght);
            while(hash_pos <= lenght)
            {
                if (hash_objects[hash_pos] != null)
                {
                    hash_pos = hash_pos + 1;
                }
                else
                {
                    hash_objects[hash_pos] = padata;
                    break;
                }
            }
        }

        public object getFromHash(long pid, object search)
        {
            int hash_pos = (int)(pid % lenght);
            while(hash_pos <= lenght)
            {
                if(hash_objects[hash_pos] == search)
                {
                    return hash_objects[hash_pos];
                }
            }
            return null;
        }

    }
}
