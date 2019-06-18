using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    public enum cargo { auxiliar, administrativo, ingeniero, especialista, investigador };
    public enum EstadoCivil { casadx, solterx, viudx };
    public enum Genero { masculino = 1, femenino = 2 };

    class empleado
    {
        public string nombre;
        public string apellido;
        public DateTime fechaNac;
        public EstadoCivil estadoCivil;
        public int hijos;
        public Genero genero;
        public DateTime fechaIngreso;
        public double sueldoBasico;
        public cargo actual;

        public empleado(string _nombre, string _apellido, DateTime _fechaNac, EstadoCivil _estadoCivil, Genero _genero, int _hijos, DateTime _fechaIngreso, double _sueldoBasico, cargo _actual)
        {
            nombre = _nombre;
            apellido = _apellido;
            fechaNac = _fechaNac;
            estadoCivil = _estadoCivil;
            genero = _genero;
            hijos = _hijos;
            fechaIngreso = _fechaIngreso;
            sueldoBasico = _sueldoBasico;
            actual = _actual;
        }

        public void mostrarEmpleado()
        {
            Console.Write("nombre = {0}\n", nombre);
            Console.Write("apellido = {0}\n", apellido);
            Console.Write("fecha de nacimiento = {0}\n", fechaNac);
            Console.Write("estado civil = {0}\n", estadoCivil);
            Console.Write("cantidad de hijos = {0}\n", hijos);
            Console.Write("genero = {0}\n", genero);
            Console.Write("fehca de ingreso = {0}\n", fechaIngreso);
            Console.Write("sueldo  = {0}\n", sueldoBasico);
            Console.Write("cargo = {0}\n", actual);
        }

        public static void ingresarEmpleado(List<empleado> lista, empleado nuevo)
        {
            lista.Add(nuevo);
        }

        public static int AntiguedadEmpleado(DateTime fechaIngreso, DateTime hoy)
        {
            int antiguedad = 0;
            antiguedad = hoy.Year - fechaIngreso.Year;
            return antiguedad;
        }

        public static int edadEmpleado(DateTime fechaNac, DateTime hoy)
        {
            int edad = 0;
            edad = hoy.Year - fechaNac.Year;
            return edad;
        }

        public static int añosParaJubilarse(DateTime fechaNac, DateTime hoy, empleado nuevoEmpleado)
        {
            int jub = 0, aux = 0;
            aux = edadEmpleado(fechaNac, hoy);
            if (nuevoEmpleado.genero == Genero.masculino)
            {
                jub = 65 - aux;
            }
            else
            {
                jub = 60 - aux;
            }
            return (jub);
        }

        public static double salario(empleado nuevoEmpleado, DateTime hoy, DateTime fechaIngreso)
        {
            double salario = 0;
            double adicional = 0;
            if (AntiguedadEmpleado(fechaIngreso, hoy) <= 20)
            {
                adicional = ((nuevoEmpleado.sueldoBasico * 0.02) * (AntiguedadEmpleado(fechaIngreso, hoy)));
            }
            else
            {
                adicional = (nuevoEmpleado.sueldoBasico * 1.25);
            }
            switch (nuevoEmpleado.actual)
            {
                case cargo.ingeniero:
                case cargo.especialista:
                    adicional = adicional * 1.50;
                    break;
                default:
                    break;
            }
            if (nuevoEmpleado.estadoCivil == EstadoCivil.casadx && nuevoEmpleado.hijos >= 2)
            {
                adicional = adicional + 5000;
            }
            salario = nuevoEmpleado.sueldoBasico + adicional;
            return (salario);
        }

        public static int calcularMD(int aux, DateTime fecha1, DateTime hoy)
        {
            if (hoy.Month > fecha1.Month)
            {
                aux = aux - 1;
            }
            else
            {
                if (hoy.Day > fecha1.Day)
                {
                    aux = aux - 1;
                }
            }
            return (aux);
        }
    }
}