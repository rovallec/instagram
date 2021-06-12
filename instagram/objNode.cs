using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class objNode
    {
        protected Object dato;
        protected objNode izdo;
        protected objNode dcho;


        public objNode(Object valor)
        {
            dato = valor;
            izdo = dcho = null;
        }

        public objNode(objNode ramaIzdo, Object valor, objNode ramaDcho)
        {
            this.dato = valor;
            izdo = ramaIzdo;
            dcho = ramaDcho;
        }

        // operaciones de acceso
        public Object valorNodo()
        {
            return dato;
        }

        public objNode subarbolIzdo() { return izdo; }
        public objNode subarbolDcho() { return dcho; }


        public void nuevoValor(Object d)
        {
            dato = d;
        }


        public void ramaIzdo(objNode n) { izdo = n; }
        public void ramaDcho(objNode n) { dcho = n; }
        public string visitar()
        {
            return dato.ToString();
        }
    }
}
