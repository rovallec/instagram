using System;
using System.Collections.Generic;
using System.Text;

namespace instagram
{
    class avlTree
    {
        protected avlNode raiz;
        private int pila = 0;
        private int cuenta = 1;
        private int cuenta2 = 0;

        public avlTree()
        {
            raiz = null;
        }

        public avlNode raizArbol()
        {
            return raiz;
        }




        public void objNodesCont()
        {
            pila = pila + cuenta;
            cuenta2 = cuenta2 + pila;
        }
        private avlNode rotacionII(avlNode n, avlNode n1)
        {
            n.ramaIzdo(n1.subarbolDcho());
            n1.ramaDcho(n);
            // actualización de los factores de equilibrio
            if (n1.fe == -1) // se cumple en la inserción
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = -1;
                n1.fe = 1;
            }
            return n1;
        }


        private avlNode rotacionDD(avlNode n, avlNode n1)
        {
            n.ramaDcho(n1.subarbolIzdo());
            n1.ramaIzdo(n);
            // actualización de los factores de equilibrio
            if (n1.fe == +1) // se cumple en la inserción
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = +1;
                n1.fe = -1;
            }
            return n1;
        }


        private avlNode rotacionID(avlNode n, avlNode n1)
        {
            avlNode n2;
            n2 = (avlNode)n1.subarbolDcho();
            n.ramaIzdo(n2.subarbolDcho());
            n2.ramaDcho(n);
            n1.ramaDcho(n2.subarbolIzdo());
            n2.ramaIzdo(n1);
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                n1.fe = -1;
            else
                n1.fe = 0;
            if (n2.fe == -1)
                n.fe = 1;
            else
                n.fe = 0;
            n2.fe = 0;
            return n2;
        }


        private avlNode rotacionDI(avlNode n, avlNode n1)
        {
            avlNode n2;
            n2 = (avlNode)n1.subarbolIzdo();
            n.ramaDcho(n2.subarbolIzdo());
            n2.ramaIzdo(n);
            n1.ramaIzdo(n2.subarbolDcho());
            n2.ramaDcho(n1);
            // actualización de los factores de equilibrio
            if (n2.fe == +1)
                n.fe = -1;
            else
                n.fe = 0;
            if (n2.fe == -1)
                n1.fe = 1;
            else
                n1.fe = 0;
            n2.fe = 0;
            return n2;
        }



        public void insertar(Object valor)//throws Exception
        {
            Comparator dato;
           Logic h = new Logic(false); // intercambia un valor booleano
            dato = (Comparator)valor;
            raiz = insertarAvl(raiz, dato, h);
        }



        private avlNode insertarAvl(avlNode raiz, Comparator dt,Logic h)
        //throws Exception
        {
            avlNode n1;
            if (raiz == null)
            {
                raiz = new avlNode(dt);
                h.setLogical(true);
            }
            else if (dt.menorQue(raiz.valorNodo()))
            {
                avlNode iz;
                iz = insertarAvl((avlNode)raiz.subarbolIzdo(), dt, h);
                raiz.ramaIzdo(iz);
                // regreso por los objNodes del camino de búsqueda
                if (h.booleanValue())
                {
                    // decrementa el fe por aumentar la altura de rama izquierda
                    switch (raiz.fe)
                    {
                        case 1:
                            raiz.fe = 0;
                            h.setLogical(false);
                            break;
                        case 0:
                            raiz.fe = -1;
                            break;
                        case -1: // aplicar rotación a la izquierda
                            n1 = (avlNode)raiz.subarbolIzdo();
                            if (n1.fe == -1)
                                raiz = rotacionII(raiz, n1);
                            else
                                raiz = rotacionID(raiz, n1);
                            h.setLogical(false);
                            break;
                    }
                }
            }
            else if (dt.mayorQue(raiz.valorNodo()))
            {
                avlNode dr;
                dr = insertarAvl((avlNode)raiz.subarbolDcho(), dt, h);
                raiz.ramaDcho(dr);
                // regreso por los objNodes del camino de búsqueda
                if (h.booleanValue())
                {
                    // incrementa el fe por aumentar la altura de rama izquierda
                    switch (raiz.fe)
                    {
                        case 1: // aplicar rotación a la derecha
                            n1 = (avlNode)raiz.subarbolDcho();
                            if (n1.fe == +1)
                                raiz = rotacionDD(raiz, n1);
                            else
                                raiz = rotacionDI(raiz, n1);
                            h.setLogical(false);
                            break;
                        case 0:
                            raiz.fe = +1;
                            break;
                        case -1:
                            raiz.fe = 0;
                            h.setLogical(false);
                            break;
                    }
                }
            }
            else
                throw new Exception("No puede haber claves repetidas ");
            return raiz;
        }

        public void eliminar(Object valor) //throws Exception
        {
            Comparator dato;
            dato = (Comparator)valor;
           Logic flag = new Logic(false);
            raiz = borrarAvl(raiz, dato, flag);
        }


        private avlNode borrarAvl(avlNode r, Comparator clave,
       Logic cambiaAltura) //throws Exception
        {
            if (r == null)
            {
                throw new Exception(" objNode no encontrado ");
            }
            else if (clave.menorQue(r.valorNodo()))
            {
                avlNode iz;
                iz = borrarAvl((avlNode)r.subarbolIzdo(), clave, cambiaAltura);
                r.ramaIzdo(iz);
                if (cambiaAltura.booleanValue())
                    r = equilibrar1(r, cambiaAltura);
            }
            else if (clave.mayorQue(r.valorNodo()))
            {
                avlNode dr;
                dr = borrarAvl((avlNode)r.subarbolDcho(), clave, cambiaAltura);
                r.ramaDcho(dr);
                if (cambiaAltura.booleanValue())
                    r = equilibrar2(r, cambiaAltura);
            }
            else // objNode encontrado
            {
                avlNode q;
                q = r; // objNode a quitar del árbol
                if (q.subarbolIzdo() == null)
                {
                    r = (avlNode)q.subarbolDcho();
                    cambiaAltura.setLogical(true);
                }
                else if (q.subarbolDcho() == null)
                {
                    r = (avlNode)q.subarbolIzdo();
                    cambiaAltura.setLogical(true);
                }
                else
                { // tiene rama izquierda y derecha
                    avlNode iz;
                    iz = reemplazar(r, (avlNode)r.subarbolIzdo(), cambiaAltura);
                    r.ramaIzdo(iz);
                    if (cambiaAltura.booleanValue())
                        r = equilibrar1(r, cambiaAltura);
                }
                q = null;
            }
            return r;
        }


        private avlNode reemplazar(avlNode n, avlNode act,Logic cambiaAltura)
        {
            if (act.subarbolDcho() != null)
            {
                avlNode d;
                d = reemplazar(n, (avlNode)act.subarbolDcho(), cambiaAltura);
                act.ramaDcho(d);
                if (cambiaAltura.booleanValue())
                    act = equilibrar2(act, cambiaAltura);
            }
            else
            {
                n.nuevoValor(act.valorNodo());
                n = act;
                act = (avlNode)act.subarbolIzdo();
                n = null;
                cambiaAltura.setLogical(true);
            }
            return act;
        }

        private avlNode equilibrar1(avlNode n,Logic cambiaAltura)
        {
            avlNode n1;
            switch (n.fe)
            {
                case -1:
                    n.fe = 0;
                    break;
                case 0:
                    n.fe = 1;
                    cambiaAltura.setLogical(false);
                    break;
                case +1: //se aplicar un tipo de rotación derecha
                    n1 = (avlNode)n.subarbolDcho();
                    if (n1.fe >= 0)
                    {
                        if (n1.fe == 0) //la altura no vuelve a disminuir
                            cambiaAltura.setLogical(false);
                        n = rotacionDD(n, n1);
                    }
                    else
                        n = rotacionDI(n, n1);
                    break;
            }
            return n;
        }

        private avlNode equilibrar2(avlNode n,Logic cambiaAltura)
        {
            avlNode n1;
            switch (n.fe)
            {
                case -1: // Se aplica un tipo de rotación izquierda
                    n1 = (avlNode)n.subarbolIzdo();
                    if (n1.fe <= 0)
                    {
                        if (n1.fe == 0)
                            cambiaAltura.setLogical(false);
                        n = rotacionII(n, n1);
                    }
                    else
                        n = rotacionID(n, n1);
                    break;
                case 0:
                    n.fe = -1;
                    cambiaAltura.setLogical(false);
                    break;
                case +1:
                    n.fe = 0;
                    break;
            }
            return n;
        }

        /////////////////////////////////
        /// <summary>
        /// Comprueba el estatus del árbol
        /// </summary>
        /// <returns></returns>
        bool esVacio()
        {
            return raiz == null;
        }

        public static avlNode nuevoArbol(avlNode ramaIzqda, Object dato, avlNode ramaDrcha)
        {
            return new avlNode(dato, ramaIzqda, ramaDrcha);
        }


        //binario en preorden
        public static string preorden(objNode r)
        {
            if (r != null)
            {
                return r.visitar() + preorden(r.subarbolIzdo()) + preorden(r.subarbolDcho());
            }
            return "";
        }

        // Recorrido de un árbol binario en inorden
        public static string inorden(objNode r)
        {
            if (r != null)
            {
                return inorden(r.subarbolIzdo()) + r.visitar() + inorden(r.subarbolDcho());
            }
            return "";
        }

        // Recorrido de un árbol binario en postorden
        public static string postorden(objNode r)
        {
            if (r != null)
            {
                return postorden(r.subarbolIzdo()) + postorden(r.subarbolDcho()) + r.visitar();
            }
            return "";
        }

        //Devuelve el número de objNodes que tiene el árbol
        public static int numobjNodes(objNode raiz)
        {
            if (raiz == null)
                return 0;
            else
                return 1 + numobjNodes(raiz.subarbolIzdo()) +
                numobjNodes(raiz.subarbolDcho());
        }

        public objNode buscar(Object buscado)
        {
            Comparator dato;
            dato = (Comparator)buscado;
            if (raiz == null)
                return null;
            else
                return buscar(raizArbol(), dato);
        }
        protected objNode buscar(objNode raizSub, Comparator buscado)
        {
            objNodesCont();
            if (raizSub == null)
                return null;
            else if (buscado.igualQue(raizSub.valorNodo()))
                return raizSub;
            else if (buscado.menorQue(raizSub.valorNodo()))
                return buscar(raizSub.subarbolIzdo(), buscado);
            else
                return buscar(raizSub.subarbolDcho(), buscado);
            pila = 0;
        }
    }
}
