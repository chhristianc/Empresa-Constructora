using System;

namespace Proyecto_Integrador_AyP
{
    class Program
    {
        public static void Main(string[] args)
        {
            Empresa emp = new Empresa("Constructora");

            AgregarGrupos(emp, 8); // Se crean 8 Grupos de Obreros por especificación del enunciado del proyecto

            MostrarMenu();
            string ingreso = Console.ReadLine();

            while (ingreso != "0")
            {
                try
                {
                    switch (ingreso)
                    {
                        case "1":
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("Contratar Obrero");
                            Console.WriteLine("---------------------------------------------------");
                            ContratarObrero(emp);
                            Console.WriteLine("---------------------------------------------------");
                            break;

                        case "2":
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("Eliminar Obrero");
                            Console.WriteLine("---------------------------------------------------");
                            EliminarObrero(emp);
                            Console.WriteLine("---------------------------------------------------");
                            break;

                        case "3":
                            Console.WriteLine("---------------------------------------------------");
                            try
                            {
                                if (HayGruposLibres(emp))
                                {
                                    Obra obra = BuscarObraSinJefe(emp);
                                    if (obra != null) ContratarJefe(emp, obra);
                                }

                                else
                                {
                                    throw new SinGrupoLibreException();
                                }
                            }

                            catch (SinGrupoLibreException)
                            {
                                Console.WriteLine("No hay grupos libres para asignar");
                            }

                            Console.WriteLine("---------------------------------------------------");
                            break;

                        case "4":
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("Dar de Baja Jefe de Obra");
                            Console.WriteLine("---------------------------------------------------");
                            DarBajaJefe(emp);
                            Console.WriteLine("---------------------------------------------------");
                            break;

                        case "5":
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("Agregar Obra");
                            Console.WriteLine("---------------------------------------------------");
                            AgregarObra(emp);
                            Console.WriteLine("---------------------------------------------------");
                            break;

                        case "6":
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("Modificar Estado de Avance de una Obra");
                            Console.WriteLine("---------------------------------------------------");
                            ModificarAvance(emp);
                            Console.WriteLine("---------------------------------------------------");
                            break;

                        case "7":
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("Submenú de impresión");
                            Console.WriteLine("---------------------------------------------------");
                            ImplementarSubmenu(emp);
                            Console.WriteLine("---------------------------------------------------");
                            break;

                        default:
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("Ingrese una opción válida");
                            Console.WriteLine("---------------------------------------------------");
                            break;

                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Se ingresó un formato incorrecto");
                }

                Console.WriteLine("Presione cualquier tecla para volver al menú principal");
                Console.ReadKey();
                Console.Clear();

                MostrarMenu();
                ingreso = Console.ReadLine();
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        public static void MostrarMenu()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Menú Principal");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Ingrese la opción que desea realizar");
            Console.WriteLine("1 - Contratar un obrero nuevo");
            Console.WriteLine("2 - Eliminar un obrero");
            Console.WriteLine("3 - Contratar un jefe de obra");
            Console.WriteLine("4 - Dar de baja a un jefe");
            Console.WriteLine("5 - Agregar Obra");
            Console.WriteLine("6 - Modificar el estado de avance de una obra");
            Console.WriteLine("7 - Submenú de Impresión");
            Console.WriteLine("0 - Salir");
            Console.WriteLine("---------------------------------------------------");
        }

        public static void MostrarSubMenu()
        {
            Console.WriteLine("Ingrese la opción que desea realizar");
            Console.WriteLine("1 - Listado de Obreros");
            Console.WriteLine("2 - Listado de Obras en Ejecución");
            Console.WriteLine("3 - Listado de Obras Finalizadas");
            Console.WriteLine("4 - Listado de Jefes");
            Console.WriteLine("5 - Porcentaje de Obras de Remodelación sin Finalizar");
            Console.WriteLine("0 - Volver");
            Console.WriteLine("---------------------------------------------------");
        }

        public static void ImplementarSubmenu(Empresa emp)
        {
            MostrarSubMenu();
            string respuesta = Console.ReadLine();

            while (respuesta != "0")
            {
                switch (respuesta)
                {
                    case "1":
                        Console.WriteLine("---------------------------------------------------");
                        VerObreros(emp);
                        Console.WriteLine("---------------------------------------------------");
                        break;

                    case "2":
                        Console.WriteLine("---------------------------------------------------");
                        VerObrasEnEjecucion(emp);
                        Console.WriteLine("---------------------------------------------------");
                        break;

                    case "3":
                        Console.WriteLine("---------------------------------------------------");
                        VerObrasFinalizadas(emp);
                        Console.WriteLine("---------------------------------------------------");
                        break;

                    case "4":
                        Console.WriteLine("---------------------------------------------------");
                        VerJefes(emp);
                        Console.WriteLine("---------------------------------------------------");
                        break;

                    case "5":
                        Console.WriteLine("---------------------------------------------------");
                        VerRemodelacionSinFin(emp);
                        Console.WriteLine("---------------------------------------------------");
                        break;

                    default:
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Ingrese una opción válida");
                        break;
                }

                Console.WriteLine("Presione cualquier tecla para volver al menú Submenú de Impresión");
                Console.ReadKey();
                Console.Clear();

                MostrarSubMenu();
                respuesta = Console.ReadLine();
            }
        }

        public static void ContratarObrero(Empresa emp)
        {
            Console.WriteLine("Ingrese nombre y apellido");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese DNI");
            int dni = int.Parse(Console.ReadLine());
            Console.WriteLine("Legajo");
            int legajo = int.Parse(Console.ReadLine());
            Console.WriteLine("Sueldo");
            double sueldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el cargo del obrero");
            string cargo = Console.ReadLine();
            Obrero obr = new Obrero(nombre, dni, legajo, sueldo, cargo);
            AsignarGrupoAObrero(emp, obr);
        }

        public static void AsignarGrupoAObrero(Empresa emp, Obrero obr)
        {
            int nroGrupo;
            bool continuar = true;

            while (continuar)  // Bucle hasta que se ingrese un grupo de obreros válido
            {
                Console.WriteLine("Ingrese el número de grupo al que quiere sumar el obrero");
                nroGrupo = int.Parse(Console.ReadLine());
                Console.WriteLine("---------------------------------------------------");

                if (ExisteNroGrupo(emp, nroGrupo))
                {
                    emp.VerGrupo(nroGrupo - 1).AgregarObrero(obr);
                    Console.WriteLine("Obrero con dni {0} fue agregado con éxito al grupo {1}", obr.Dni, nroGrupo);
                    continuar = false;
                }

                else
                {
                    Console.WriteLine("No existe el número de grupo ingresado");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Los grupos de obreros son:");
                    VerGrupos(emp);
                    Console.WriteLine("---------------------------------------------------");
                }
            }
        }

        public static void EliminarObrero(Empresa emp)
        {
            Obrero aux = BuscarObrero(emp);

            if (aux != null)
            {
                foreach (Grupo elem in emp.Grupos)
                {
                    if (elem.ExisteObrero(aux))
                    {
                        elem.EliminarObrero(aux);
                        Console.WriteLine("El obrero con dni {0} fue eliminado con éxito", aux.Dni);
                    }
                }
            }
        }

        public static Obrero BuscarObrero(Empresa emp)
        {
            bool existe = false;
            Obrero aux = null;
            Console.WriteLine("Ingrese el dni del obrero");
            int dni = int.Parse(Console.ReadLine());

            foreach (Grupo elem in emp.Grupos)
            {
                foreach (Obrero elem2 in elem.Obreros)
                {
                    if (elem2.Dni == dni)
                    {
                        aux = elem2;
                        existe = true;
                        break;
                    }
                }

                if (existe) break;
            }

            Console.WriteLine("---------------------------------------------------");
            if (!existe) Console.WriteLine("No existe un obrero con el dni ingresado");

            return aux;
        }

        public static void ContratarJefe(Empresa emp, Obra obra)
        {
            Console.WriteLine("Ingrese 1 para agregar un nuevo Jefe de Obra");
            Console.WriteLine("Ingrese 2 para asignar el cargo de Jefe de Obra a un obrero existente");
            Console.WriteLine("Presione cualquier otra tecla para salir");
            Console.WriteLine("---------------------------------------------------");
            string respuesta = Console.ReadLine();
            Console.WriteLine("---------------------------------------------------");
            if (respuesta == "1") CrearJefe(emp, obra);
            else if (respuesta == "2") ConvertirObreroEnJefe(emp, obra);
        }

        public static void CrearJefe(Empresa emp, Obra obra)
        {
            Console.WriteLine("Ingrese nombre y apellido");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese DNI");
            int dni = int.Parse(Console.ReadLine());
            Console.WriteLine("Legajo");
            int legajo = int.Parse(Console.ReadLine());
            Console.WriteLine("Sueldo");
            double sueldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor de la bonificación");
            double bonificacion = double.Parse(Console.ReadLine());
            Grupo grupo = BuscarGrupoLibre(emp);
            int nroGrupo = grupo.NroGrupo;
            Jefe jefeDeObra = new Jefe(nombre, dni, legajo, sueldo, "Jefe de Obra", bonificacion, nroGrupo);
            obra.JefeDeObra = jefeDeObra;
            Console.WriteLine("Jefe de Obra agregado con éxito a la obra con código {0}", obra.Codigo);
            grupo.CodigoDeObra = obra.Codigo;
        }

        public static void ConvertirObreroEnJefe(Empresa emp, Obra obra)
        {
            Obrero aux = BuscarObrero(emp);

            if (aux != null)
            {
                Console.WriteLine("Ingrese el valor de la bonificación");
                double bonificacion = double.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese uno de los siguientes grupos libres para asignar a la obra");
                Console.WriteLine("Tener en cuenta que el obrero que se convertirá en Jefe de la obra aparece en su grupo");
                Grupo grupo = BuscarGrupoLibre(emp);
                int nroGrupo = grupo.NroGrupo;
                Jefe nuevoJefe = new Jefe(aux.Nombre, aux.Dni, aux.Legajo, aux.Sueldo, "Jefe de Obra", bonificacion, nroGrupo);
                obra.JefeDeObra = nuevoJefe;
                Console.WriteLine("El obrero con dni {0} ahora es Jefe de la obra con código {1}", aux.Dni, obra.Codigo);
                grupo.CodigoDeObra = obra.Codigo;

                //Elimino el obrero del grupo de obreros

                foreach (Grupo elem in emp.Grupos)
                {
                    if (elem.ExisteObrero(aux))
                    {
                        elem.EliminarObrero(aux);
                        Console.WriteLine("Fue eliminado del grupo de obreros");
                    }
                }
            }
        }

        public static void ConvertirJefeEnObrero(Empresa emp, Jefe jefe)
        {
            Console.WriteLine("Ingrese el nuevo cargo que tendrá");
            string cargo = Console.ReadLine();
            Obrero obr = new Obrero(jefe.Nombre, jefe.Dni, jefe.Legajo, jefe.Sueldo, cargo);
            AsignarGrupoAObrero(emp, obr);
        }

        public static void DarBajaJefe(Empresa emp)
        {
            bool existe = false;
            int codObra = 0;
            Jefe aux = null;

            Console.WriteLine("Ingrese el dni del Jefe de Obra que quiere dar de baja");
            int dni = int.Parse(Console.ReadLine());

            foreach (Obra elem in emp.ObrasEnEjecucion)
            {
                if (elem.JefeDeObra != null && elem.JefeDeObra.Dni == dni)
                {
                    aux = elem.JefeDeObra;
                    elem.JefeDeObra = null;
                    Console.WriteLine("Se eliminó el Jefe de obra de la obra con código {0} con exito", elem.Codigo);
                    codObra = elem.Codigo;
                    existe = true;
                    break;
                }
            }

            if (existe)
            {
                // Se libera el grupo que tenía a cargo

                foreach (Grupo elem in emp.Grupos)
                {
                    if (elem.CodigoDeObra == codObra)
                    {
                        elem.CodigoDeObra = 0;
                        Console.WriteLine("Se liberó el grupo que tenía a su cargo (Grupo N°{0})", elem.NroGrupo);
                        break;
                    }
                }

                // Si se desea se convierte a Obrero

                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Si desea asignarle el puesto de Obrero al Jefe de Obra dado de baja ingrese 1");
                Console.WriteLine("O presione enter para continuar");
                string respuesta = Console.ReadLine();
                if (respuesta == "1") ConvertirJefeEnObrero(emp, aux);
            }

            else
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("No existe un Jefe de Obra con el DNI ingresado");
            }
        }

        public static void VerObreros(Empresa emp)
        {
            bool hayObreros = false;

            Console.WriteLine("Listado de Obreros");

            foreach (Grupo elem in emp.Grupos)
            {
                if (elem.CantidadObreros() > 0) hayObreros = true;

                foreach (Obrero elem2 in elem.Obreros)
                {
                    Console.Write("Nombre: {0}, ", elem2.Nombre);
                    Console.Write("Dni: {0}, ", elem2.Dni);
                    Console.Write("Legajo: {0}, ", elem2.Legajo);
                    Console.WriteLine("Cargo: {0}, ", elem2.Cargo);
                }
            }

            if (!hayObreros)
            {
                Console.WriteLine("No hay obreros contratados");
            }
        }

        public static void VerObrasEnEjecucion(Empresa emp)
        {
            if (emp.CantidadObrasEnEjecucion() > 0)
            {
                foreach (Obra elem in emp.ObrasEnEjecucion)
                {
                    Console.Write("Codigo de obra: {0}, ", elem.Codigo);
                    Console.Write("Nombre Propietario: {0}, ", elem.NombreProp);
                    Console.Write("Dni Propietario: {0}, ", elem.DniProp);
                    Console.Write("Tipo: {0}, ", elem.Tipo);
                    Console.WriteLine("Porcentaje de avance: {0}%", elem.EstadoDeAvance);
                }
            }

            else
            {
                Console.WriteLine("No hay obras en ejecución");
            }
        }

        public static void VerObrasFinalizadas(Empresa emp)
        {
            if (emp.CantidadObrasFinalizadas() > 0)
            {
                foreach (Obra elem in emp.ObrasFinalizadas)
                {
                    Console.Write("Codigo de obra: {0}, ", elem.Codigo);
                    Console.Write("Nombre Propietario: {0}, ", elem.NombreProp);
                    Console.Write("Dni Propietario: {0}, ", elem.DniProp);
                    Console.WriteLine("Tipo: {0}, ", elem.Tipo);
                }
            }

            else
            {
                Console.WriteLine("No hay obras finalizadas");
            }
        }

        public static void VerJefes(Empresa emp)
        {
            bool existe = false;

            Console.WriteLine("Listado de Jefes de Obras En Ejecución");

            foreach (Obra elem in emp.ObrasEnEjecucion)
            {
                if (elem.JefeDeObra != null)
                {
                    Console.Write("Nombre: {0}, ", elem.JefeDeObra.Nombre);
                    Console.Write("Dni: {0}, ", elem.JefeDeObra.Dni);
                    Console.Write("Legajo: {0}, ", elem.JefeDeObra.Legajo);
                    Console.Write("Código de Obra a Cargo: {0}, ", elem.Codigo);
                    Console.WriteLine("Obreros a Cargo: Grupo N°{0}", elem.JefeDeObra.GrupoACargo);
                    existe = true;
                }
            }

            if (!existe)
            {
                Console.WriteLine("No existen datos cargados");
            }

            Console.WriteLine("---------------------------------------------------");

            existe = false;

            Console.WriteLine("Listado de Jefes de Obras Finalizadas");

            foreach (Obra elem in emp.ObrasFinalizadas)
            {
                if (elem.JefeDeObra != null)
                {
                    Console.Write("Nombre: {0}, ", elem.JefeDeObra.Nombre);
                    Console.Write("Dni: {0}, ", elem.JefeDeObra.Dni);
                    Console.Write("Legajo: {0}, ", elem.JefeDeObra.Legajo);
                    Console.WriteLine("Código de Obra a Cargo: {0}, ", elem.Codigo);
                    existe = true;
                }

            }

            if (!existe)
            {
                Console.WriteLine("No existen datos cargados");
            }
        }

        public static void VerRemodelacionSinFin(Empresa emp)
        {
            int totalRemod = 0;
            int sinTerminarRemod = 0;

            foreach (Obra elem in emp.ObrasEnEjecucion)
            {
                if (elem.Tipo == "remodelacion")
                {
                    totalRemod++;
                    sinTerminarRemod++;
                }
            }

            foreach (Obra elem in emp.ObrasFinalizadas)
            {
                if (elem.Tipo == "remodelacion")
                {
                    totalRemod++;
                }
            }

            if (totalRemod > 0)
            {
                double porcentaje = (double)sinTerminarRemod * 100 / totalRemod;
                Console.WriteLine("El porcentaje de las obras de remodelación que no fueron terminadas es {0}%", porcentaje);
            }

            else
            {
                Console.WriteLine("No existen obras de remodelación cargadas");
            }
        }

        public static void AgregarGrupos(Empresa emp, int cantidad)
        {
            int cantGrupos = emp.CantidadGrupos();
            int ultimoNroGrupo = 0;

            if (cantGrupos != 0)
            {
                ultimoNroGrupo = emp.VerGrupo(cantGrupos - 1).NroGrupo;
            }

            for (int i = 0; i < cantidad; i++)
            {
                Grupo grup = new Grupo(ultimoNroGrupo + 1);
                emp.AgregarGrupo(grup);
                ultimoNroGrupo++;
            }
        }

        public static bool HayGruposLibres(Empresa emp)
        {
            bool libre = false;

            foreach (Grupo elem in emp.Grupos)
            {
                if (elem.CodigoDeObra == 0)
                {
                    libre = true;
                    break;
                }
            }

            return libre;
        }

        public static void VerGruposLibres(Empresa emp)
        {
            foreach (Grupo elem in emp.Grupos)
            {
                if (elem.CodigoDeObra == 0)
                {
                    Console.WriteLine("Grupo: {0}, Cantidad de Integrantes: {1}", elem.NroGrupo, elem.CantidadObreros());
                }
            }

            Console.WriteLine("---------------------------------------------------");
        }

        public static bool ExisteNroGrupo(Empresa emp, int nroGrupo)
        {
            bool existe = false;

            foreach (Grupo elem in emp.Grupos)
            {
                if (elem.NroGrupo == nroGrupo)
                {
                    existe = true;
                }
            }

            return existe;
        }

        public static void VerGrupos(Empresa emp)
        {
            foreach (Grupo elem in emp.Grupos)
            {
                Console.WriteLine("Grupo N°: {0}, Cantidad de Obreros: {1}", elem.NroGrupo, elem.CantidadObreros());
            }
        }

        public static Grupo BuscarGrupoLibre(Empresa emp)
        {
            Grupo aux = null;
            bool continuar = true;

            while (continuar) // Bucle hasta que se ingrese un grupo válido de obreros libres
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Elija uno de los siguientes grupos libres para asignar a la obra");
                VerGruposLibres(emp);
                Console.WriteLine("Ingrese el número de grupo que quiere asignar");
                int grupo = int.Parse(Console.ReadLine());
                Console.WriteLine("---------------------------------------------------");

                foreach (Grupo elem in emp.Grupos)
                {
                    if (elem.NroGrupo == grupo && elem.CodigoDeObra == 0)
                    {
                        aux = elem;
                        continuar = false;
                        break;
                    }
                }

                if (continuar)
                {
                    Console.WriteLine("Se ingresó un número de grupo inválido");
                }
            }

            return aux;
        }

        public static void AgregarObra(Empresa emp)
        {
            Console.WriteLine("Ingrese el nombre del propietario");
            string nombreProp = Console.ReadLine();
            Console.WriteLine("Ingrese el dni del propietario");
            int dniProp = int.Parse(Console.ReadLine());
            int codigo = emp.CantidadObrasEnEjecucion() + emp.CantidadObrasFinalizadas() + 1;
            Console.WriteLine("Ingrese el tipo de obra");
            string tipo = Console.ReadLine();
            Console.WriteLine("Ingrese el costo de la obra");
            double costo = double.Parse(Console.ReadLine());
            Obra nuevaObra = new Obra(nombreProp, dniProp, codigo, tipo, costo);
            emp.AgregarObraEnEjecucion(nuevaObra);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("La obra fué agregada con éxito. Se le asignó el código de obra {0}", nuevaObra.Codigo);
            Console.WriteLine("---------------------------------------------------");

            try
            {
                if (HayGruposLibres(emp))
                {
                    ContratarJefe(emp, nuevaObra);
                }
                else
                {
                    throw new SinGrupoLibreException();
                }
            }

            catch (SinGrupoLibreException)
            {
                Console.WriteLine("No es posible agregar un Jefe de Obra porque no hay grupos libres");
            }
        }

        public static void ModificarAvance(Empresa emp)
        {
            bool finObra = false;
            Obra aux = BuscarObra(emp);

            if (aux != null)
            {
                Console.WriteLine("Ingrese el nuevo estado (porcentaje de avance)");
                double nuevoEstado = double.Parse(Console.ReadLine());
                if (nuevoEstado > 0 && nuevoEstado < 100)
                {
                    aux.EstadoDeAvance = nuevoEstado;
                    Console.WriteLine("Se modificó el estado de avance con éxito");
                }

                else if (nuevoEstado == 100)
                {
                    aux.EstadoDeAvance = 100;
                    Console.WriteLine("Se modificó el estado de avance con éxito");
                    Console.WriteLine("La obra fue finalizada");
                    finObra = true;
                }

                else
                {
                    Console.WriteLine("El porcentaje de avance debe ser entre 0 y 100");
                }
            }

            if (finObra)
            {
                emp.EliminarObraEnEjecucion(aux);
                emp.AgregarObraFinalizada(aux);
                foreach (Grupo elem in emp.Grupos) // Se libera el grupo de obreros por finalización de obra
                {
                    if (elem.CodigoDeObra == aux.Codigo)
                    {
                        elem.CodigoDeObra = 0;
                        Console.WriteLine("El grupo {0} fue liberado por finalización de obra", elem.NroGrupo);
                    }
                }
            }
        }

        public static Obra BuscarObra(Empresa emp)
        {
            Obra aux = null;

            Console.WriteLine("Ingrese el código de obra");
            int codigo = int.Parse(Console.ReadLine());

            Console.WriteLine("---------------------------------------------------");

            foreach (Obra elem in emp.ObrasEnEjecucion)
            {
                if (elem.Codigo == codigo)
                {
                    aux = elem;
                    break;
                }
            }

            if (aux == null)
            {
                Console.WriteLine("No existen obras con el código ingresado");
                Console.WriteLine("---------------------------------------------------");
            }

            return aux;
        }

        public static bool HayObrasSinJefe(Empresa emp)
        {
            bool sinJefe = false;

            foreach (Obra elem in emp.ObrasEnEjecucion)
            {
                if (elem.JefeDeObra == null)
                {
                    sinJefe = true;
                }
            }

            return sinJefe;
        }

        public static Obra BuscarObraSinJefe(Empresa emp)
        {
            Obra aux = null;

            if (HayObrasSinJefe(emp))
            {
                bool continuar = true;
                while (continuar)
                {
                    Console.WriteLine("Ingrese el código de obra");

                    int codigo = int.Parse(Console.ReadLine());
                    Console.WriteLine("---------------------------------------------------");

                    foreach (Obra elem in emp.ObrasEnEjecucion)
                    {
                        if (elem.Codigo == codigo && elem.JefeDeObra == null)
                        {
                            aux = elem;
                            continuar = false;
                            break;
                        }
                    }

                    if (continuar)
                    {
                        Console.WriteLine("No hay obras sin Jefe con el código ingresado");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Elija una de las siguientes obras para asignarle el jefe");
                        VerObrasSinJefes(emp);
                        Console.WriteLine("---------------------------------------------------");

                    }
                }

            }

            else
            {
                Console.WriteLine("No hay obras para asignar");
            }

            return aux;
        }

        public static void VerObrasSinJefes(Empresa emp)
        {
            bool existe = false;

            foreach (Obra elem in emp.ObrasEnEjecucion)
            {
                existe = true;
                if (elem.JefeDeObra == null)
                {
                    Console.WriteLine("Codigo de Obra: {0}", elem.Codigo);
                }
            }

            if (!existe)
            {
                Console.WriteLine("No hay obras sin jefes asignados");
            }
        }
    }
}