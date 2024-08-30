using System;
using System.Collections;

namespace Proyecto_Integrador_AyP
{
    public class Empresa
    {
        //Campos

        private string nombre;
        private ArrayList obrasEnEjecucion;
        private ArrayList obrasFinalizadas;
        private ArrayList grupos;


        //Constructor

        public Empresa(string nombre)
        {
            this.nombre = nombre;
            obrasEnEjecucion = new ArrayList();
            obrasFinalizadas = new ArrayList();
            grupos = new ArrayList();
        }


        //Propiedades

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public ArrayList ObrasEnEjecucion
        {
            get { return obrasEnEjecucion; }
        }

        public ArrayList ObrasFinalizadas
        {
            get { return obrasFinalizadas; }
        }

        public ArrayList Grupos
        {
            get { return grupos; }
        }


        //Métodos

        public void AgregarObraEnEjecucion(Obra ob)
        {
            obrasEnEjecucion.Add(ob);
        }

        public void EliminarObraEnEjecucion(Obra ob)
        {
            obrasEnEjecucion.Remove(ob);
        }

        public int CantidadObrasEnEjecucion()
        {
            return obrasEnEjecucion.Count;
        }

        public bool ExisteObraEnEjecucion(Obra ob)
        {
            return obrasEnEjecucion.Contains(ob);
        }

        public Obra VerObraEnEjecucion(int i)
        {
            return (Obra)obrasEnEjecucion[i];
        }

        public ArrayList TodasObrasEnEjecucion()
        {
            return obrasEnEjecucion;
        }


        public void AgregarObraFinalizada(Obra ob)
        {
            obrasFinalizadas.Add(ob);
        }

        public void EliminarObraFinalizada(Obra ob)
        {
            obrasFinalizadas.Remove(ob);
        }

        public int CantidadObrasFinalizadas()
        {
            return obrasFinalizadas.Count;
        }

        public bool ExisteObraFinalizada(Obra ob)
        {
            return obrasFinalizadas.Contains(ob);
        }

        public Obra VerObraFinalizada(int i)
        {
            return (Obra)obrasFinalizadas[i];
        }

        public ArrayList TodasObrasFinalizadas()
        {
            return obrasFinalizadas;
        }


        public void AgregarGrupo(Grupo grup)
        {
            grupos.Add(grup);
        }

        public void EliminarGrupo(Grupo grup)
        {
            grupos.Remove(grup);
        }

        public int CantidadGrupos()
        {
            return grupos.Count;
        }

        public bool ExisteGrupo(Grupo grup)
        {
            return grupos.Contains(grup);
        }

        public Grupo VerGrupo(int i)
        {
            return (Grupo)grupos[i];
        }

        public ArrayList TodosGrupos()
        {
            return grupos;
        }

    }
}