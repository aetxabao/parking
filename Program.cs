using System;

namespace parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INICIO");
            Reloj r = new Reloj();
            //Vecinos:6, Trabajadores:2, Otros:1, _vacio:3 = 12 plazas
            char[] plazas = "VVVVVVTTO___".ToCharArray();
            Parking p = new Parking(r, plazas);
            Hilo trabajadores, vecinos, otros;
            trabajadores = new Hilo(r, p, 'T', A.Trabajador, 2, 8, 0.25, 1);
            vecinos = new Hilo(r, p, 'V', A.Vecino, 5, 15, 1, 10);
            otros = new Hilo(r, p, 'O', A.Otro, 5, 15, 1, 6);
            trabajadores.Empieza();
            vecinos.Empieza();
            otros.Empieza();
            trabajadores.Termina();
            vecinos.Termina();
            otros.Termina();
            Console.WriteLine("FIN");
        }
    }
}
