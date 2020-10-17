using System;
using System.Threading;

namespace parking
{
    public class Hilo
    {
        private Reloj reloj;
        private Parking parking;
        private Thread thread;
        private Func<long, int> accion;
        private char tipo;
        private double t1_sig, t2_sig, t1_out, t2_out;

        public Hilo(Reloj reloj, Parking parking, char tipo, Func<long, int> accion,
                    double t1_sig, double t2_sig, double t1_out, double t2_out)
        {
            this.reloj = reloj;
            this.parking = parking;
            this.tipo = tipo;
            this.accion = accion;
            this.t1_sig = t1_sig;
            this.t2_sig = t2_sig;
            this.t1_out = t1_out;
            this.t2_out = t2_out;
        }
        public void Empieza()
        {
            this.thread = new Thread(() => this.Simulacion());
            this.thread.Start();
        }

        public void Termina()
        {
            thread.Join();
        }

        private void Simulacion()
        {
            int accion, t_siguiente, t_timeout, t1, t2;
            //1ms de reloj equivalen a 12s simulados, 
            //luego 2ms -> 24s, 10ms -> 2min, ...
            while (reloj.getTiempo() * 12 < 24 * 60 * 60)
            { // 24*60*60/12 = 7200ms después termina
                t1 = (int)(t1_sig * 60 / 12);
                t2 = (int)(t2_sig * 60 / 12);
                t_siguiente = A.RandomNumber(t1, t2);
                Thread.Sleep(t_siguiente);
                accion = this.accion(reloj.getTiempo() * 12 / 60);
                if (accion == 1)//APARCAR
                {
                    t1 = (int)(t1_out * 60 / 12);
                    t2 = (int)(t2_out * 60 / 12);
                    t_timeout = A.RandomNumber(t1, t2);
                    parking.Aparcar(tipo, t_timeout);
                }
                else if (accion == -1)//SALIR
                {
                    parking.Salir(tipo);
                }
                //0 NADA
            }
        }
    }
}