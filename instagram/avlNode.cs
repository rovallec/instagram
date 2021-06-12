using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class avlNode: objNode
    {
        public int fe;
        public avlNode(Object valor) : base(valor)
        {
            fe = 0;
        }

        public avlNode(Object valor, avlNode ramaIzdo, avlNode ramaDcho) : base(ramaIzdo, valor, ramaDcho)
        {
            fe = 0;
        }
    }
}
