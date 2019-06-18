using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<empleado> listaEmp = new List<empleado>();
            empleado emp;
            string ruta = "NuevosEmpleados.csv";
            string[] lineaJunta;
            string[] lineaSeparada;
            lineaJunta = File.ReadAllLines("Empleados.csv");
            for (int i = 0; i <= lineaJunta.Count(); i++)
            {
                lineaSeparada = lineaJunta[i].Split(';');
                emp = empleadoDeArreglo(lineaSeparada);
                listaEmp.Add(emp);
            }
            for (int i = 0; i <= listaEmp.Count(); i++)
            {
                escribirArchivo(ruta, listaEmp[i]);
            }
            backUpEmpleados(ruta);
            Console.ReadKey();
        }

        public static empleado empleadoDeArreglo(string[] lineaSeparada)
        {
            string nombre = lineaSeparada[0];
            string apellido = lineaSeparada[1];
            string[] fecha = lineaSeparada[2].Split('/');
            int dia = int.Parse(fecha[0]);
            int mes = int.Parse(fecha[1]);
            int anio = int.Parse(fecha[2]);
            DateTime fechaNac = new DateTime(anio, mes, dia);
            EstadoCivil estado;

            if (lineaSeparada[3] == "Casadx")
            {
                estado = (EstadoCivil)1;
            }
            else
                if (lineaSeparada[3] == "solterx")
                {
                    estado = (EstadoCivil)2;
                }
                else
                {
                    estado = (EstadoCivil)3;
                }
            Genero genero;
            if (lineaSeparada[4] == "masculino")
            {
                genero = (Genero)1;
            }
            else
            {
                genero = (Genero)2;
            }

            string[] fecha2 = lineaSeparada[7].Split('/');
            dia = int.Parse(fecha2[0]);
            mes = int.Parse(fecha2[1]);
            anio = int.Parse(fecha2[2]);
            DateTime fechaIngreso = new DateTime(anio, mes, dia);
            double sueldo = double.Parse(lineaSeparada[8]);
            string carg = lineaSeparada[9];
            cargo Cargo;
            if (carg == "auxiliar")
            {
                Cargo = (cargo)1;
            }
            else
                if (carg == "administrativo")
                {
                    Cargo = (cargo)2;
                }
                else
                    if (carg == "ingeniero")
                    {
                        Cargo = (cargo)3;
                    }
                    else
                        if (carg == "especialista")
                        {
                            Cargo = (cargo)4;
                        }
                        else
                        {
                            Cargo = (cargo)5;
                        }
            int hijos = int.Parse(lineaSeparada[5]);
            empleado emp = new empleado(nombre, apellido, fechaNac, estado, genero, hijos, fechaIngreso, sueldo, Cargo);
            return (emp);
        }

        public static int cantidadDeEmpleados(List<empleado> lista)
        {
            int cant = 0;
            cant = lista.Count;
            return (cant);
        }

        public static void escribirArchivo(string ruta, empleado empl)
        {
            string fecha;
            using (StreamWriter file = new StreamWriter(ruta, true))
            {
                file.Write(empl.nombre + ";");
                file.Write(empl.apellido + ";");
                fecha = Convert.ToDateTime(empl.fechaNac).ToString("dd/MM/yy");
                file.Write(fecha + ";");
                file.Write(empl.genero + ";");
                file.Write(empl.estadoCivil + ";");
                file.Write(empl.fechaIngreso + ";");
                fecha = Convert.ToDateTime(empl.fechaIngreso).ToString("dd/MM/yy");
                file.Write(fecha + ";");
                file.Write(empl.actual + ";");
                file.Write(empl.hijos + ";");
                file.Close();
            }
        }

        public static void backUpEmpleados(string ruta)
        {
            string[] directorio = System.IO.Directory.GetLogicalDrives();
            string destino;
            int opcion = 0;
            Console.WriteLine("¿en que unidad desea hacer la copia de seguridad? \n1 - {0} \n2 - {1}\n", directorio[0], directorio[4]);
            opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1: destino = @"C:\BackUp";
                    break;
                default: destino = @"H:\BackUp";
                    break;
            }
            if (!Directory.Exists(destino))
            {
                Directory.CreateDirectory(destino);
            }
            if (!File.Exists(destino + @"\NuevosEmpleados.bk"))
            {
                File.Copy(ruta, destino + @"\NuevosEmpleados.bk");
            }
            else
            {
                Console.WriteLine("Ya existe una copia del archivo en el directorio: {0}", destino);
            }
        }
    }
}