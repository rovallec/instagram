using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class Lists
    {

        public Nodes first;
        public Nodes last;

        public Lists()
        {
            first = null;
        }

        public void InsertOnTop(object pObj)
        {
            Nodes new_node = new Nodes(pObj);
            first.next = new_node;
            new_node.node = first;
            first = new_node;
        }

        public void InsertAtLast(object pObj)
        {
            Nodes new_node = new Nodes(pObj);
            if (last != null)
            {
                last.next = new_node;
                new_node.node = last;
                last = new_node;
            }
            else
            {
                new_node.node = null;
                last = new_node;
            }
        }

        public Nodes FindLists(object find)
        {
            Nodes found_index;
            for (found_index = first; found_index != null; found_index = found_index.node)
                if (find.Equals(found_index.data))
                    return found_index;
            return null;
        }

        public void ClearList()
        {
            first = null;
        }

        public Object GetFirst()
        {
            Nodes rt = last;
            if (last != null)
            {
                last = last.node;
                return rt.data;
            }
            else
            {
                return null;
            }
        }
    }
}
