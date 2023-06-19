using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cine
{
    public  class TICKET
    {
        private static string pelicula;
        private static string sala;
        private static string dia;
        private static int cantidad;
        private static List<string> asientos=new List<string>();

        public string Sala
        {
            get { return sala; }
            set { sala = value; }
        }


        public string Dia
        {
            get { return dia; }
            set { dia = value; }
        }


        public string Pelicula
        {
            get { return pelicula; }
            set { pelicula = value; }
        }


        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public List<string> Asientos
        {
            get { return asientos; }
            set { asientos = value; }
        }

    }
    
}
