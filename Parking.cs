using System;
using System.Text;
using System.Threading;

namespace parking
{
    public class Parking
    {
        private readonly object bloqueo = new object();
        private char[] plazas;
        private Reloj reloj;
        private int size;
        private int count;

        public Parking(Reloj reloj, char[] plazas)
        {
            this.reloj = reloj;
            this.plazas = plazas;
            this.size = plazas.Length;
            this.count = 0;
            for (int i = 0; i < size; i++)
            {
                if (this.plazas[i] != '_')
                {
                    this.count++;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('|');
            for (int i = 0; i < size; i++)
            {
                sb.Append(plazas[i]);
                sb.Append('|');
            }
            return sb.ToString();
        }

        public void Salir(char tipo)
        {
            lock (bloqueo)
            {
                if (count > 0)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (plazas[i] == tipo)
                        {
                            plazas[i] = '_';
                            count--;
                            Log.msg(reloj.getTiempo(), this, tipo, "- sale");
                            Monitor.Pulse(bloqueo);
                            break;
                        }
                    }
                }
            }
        }

        public void Aparcar(char tipo, int timeout)
        {
            lock (bloqueo)
            {
                if (count < size)
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (plazas[i] == '_')
                        {
                            plazas[i] = tipo;
                            count++;
                            Log.msg(reloj.getTiempo(), this, tipo, "+ aparca");
                            break;
                        }
                    }
                }
                else
                {
                    Log.msg(reloj.getTiempo(), this, tipo, ". espera");
                    Monitor.Wait(bloqueo, timeout);
                    if (count < size)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            if (plazas[i] == '_')
                            {
                                plazas[i] = tipo;
                                count++;
                                Log.msg(reloj.getTiempo(), this, tipo, "* consigue aparcar");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Log.msg(reloj.getTiempo(), this, tipo, "! se va sin aparcar");
                    }
                }
            }
        }
    }
}