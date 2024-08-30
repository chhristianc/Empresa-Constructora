using System;
using System.Collections;

namespace Proyecto_Integrador_AyP
{
    public class Grupo
    {
        //Campos

        private int nroGrupo;
        private int codigoDeObra;
        private ArrayList obreros;


        //Constructor

        public Grupo(int nroGrupo)
        {
            codigoDeObra = 0;
            this.nroGrupo = nroGrupo;
            obreros = new ArrayList();
        }


        //Propiedades

        public int NroGrupo
        {
            set { nroGrupo = value; }
            get { return nroGrupo; }
        }

        public int CodigoDeObra
        {
            set { codigoDeObra = value; }
            get { return codigoDeObra; }
        }

        public ArrayList Obreros
        {
            get { return obreros; }
        }


        //Métodos

        public void AgregarObrero(Obrero obr)
        {
            obreros.Add(obr);
        }

        public void EliminarObrero(Obrero obr)
        {
            obreros.Remove(obr);
        }

        public int CantidadObreros()
        {
            return obreros.Count;
        }

        public bool ExisteObrero(Obrero obr)
        {
            return obreros.Contains(obr);
        }

        public Obrero VerObrero(int i)
        {
            return (Obrero)obreros[i];
        }

        public ArrayList TodosObreros()
        {
            return obreros;
        }

    }
}
