using System;

namespace Proyecto_Integrador_AyP
{
    public class Obra
    {
        //Campos

        private string nombreProp;
        private int dniProp;
        private int codigo;
        private string tipo;
        private double estadoDeAvance;
        private double costo;
        private Jefe jefeDeObra;


        //Constructor

        public Obra(string nombreProp, int dniProp, int codigo, string tipo, double costo)
        {
            this.nombreProp = nombreProp;
            this.dniProp = dniProp;
            this.codigo = codigo;
            this.tipo = tipo;
            this.costo = costo;
            this.estadoDeAvance = 0;
            this.jefeDeObra = null;
        }


        //Propiedades

        public string NombreProp
        {
            get { return nombreProp; }
            set { nombreProp = value; }
        }

        public int DniProp
        {
            get { return dniProp; }
            set { dniProp = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


        public double EstadoDeAvance
        {
            get { return estadoDeAvance; }
            set { estadoDeAvance = value; }
        }

        public double Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public Jefe JefeDeObra
        {
            get { return jefeDeObra; }
            set { jefeDeObra = value; }
        }

    }
}