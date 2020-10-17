using System;

namespace parking
{
    public class Reloj
    {
        long inicio;
        public Reloj()
        {
            inicio = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public long getTiempo()
        {
            long t = DateTimeOffset.Now.ToUnixTimeMilliseconds() - inicio;
            return t;
        }
    }
}
