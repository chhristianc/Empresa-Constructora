using System;

namespace Proyecto_Integrador_AyP
{
    public class Jefe : Obrero
    {
        //Campos

        private double bonificacion;
        private int grupoACargo;


        //Constructor

        public Jefe(string nombre, int dni, int legajo, double sueldo, string cargo, double bonificacion, int grupoACargo) : base(nombre, dni, legajo, sueldo, cargo)
        {
            this.bonificacion = bonificacion;
            this.grupoACargo = grupoACargo;
        }


        //Propiedades

        public double Bonificacion
        {
            set { bonificacion = value; }
            get { return bonificacion; }
        }

        public int GrupoACargo
        {
            set { grupoACargo = value; }
            get { return grupoACargo; }
        }

    }
}