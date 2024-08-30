using System;

namespace Proyecto_Integrador_AyP
{
    public class Obrero
    {
        //Campos

        protected string nombre;
        protected int dni;
        protected int legajo;
        protected double sueldo;
        protected string cargo;


        //Constructor

        public Obrero(string nombre, int dni, int legajo, double sueldo, string cargo)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.legajo = legajo;
            this.sueldo = sueldo;
            this.cargo = cargo;
        }


        //Propiedades

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public double Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

    }
}