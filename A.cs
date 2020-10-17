using System;

namespace parking
{
    class A
    {
        /// <summary>Devuelve dependiendo del instante de tiempo si un vecino aparcaría, saldría o nada.</summary>
        /// <param name="t">minutos transcurridos desde las 00:00</param>
        /// <returns>0: NADA | -1: SALIR | 1: APARCAR</returns>
        public static int Vecino(long t)
        {
            //Console.WriteLine(t/60);
            int v;
            if (t < 7 * 60)
            {
                return 0;
            }
            else if (t < 9 * 60)
            {
                v = RandomNumber(0, 100);
                if (v < 20)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else if (t < 16 * 60)
            {
                v = RandomNumber(0, 100);
                if (v < 10)
                {
                    return 1;
                }
                else if (v < 20)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else if (t < 17 * 60)
            {
                v = RandomNumber(0, 100);
                if (v < 20)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (t < 22 * 60)
            {
                v = RandomNumber(0, 100);
                if (v < 15)
                {
                    return 1;
                }
                else if (v < 20)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>Devuelve dependiendo del instante de tiempo si un trabajador aparcaría, saldría o nada.</summary>
        /// <param name="t">minutos transcurridos desde las 00:00</param>
        /// <returns>0: NADA | -1: SALIR | 1: APARCAR</returns>
        public static int Trabajador(long t)
        {
            int v;
            if (t < 7.5 * 60)
            {
                return 0;
            }
            else if (t < 9.0 * 60)
            {
                v = RandomNumber(0, 100);
                if (v < 20)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (t < 14 * 60)
            {
                v = RandomNumber(0, 100);
                if (v < 10)
                {
                    return 1;
                }
                else if (v < 20)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else if (t < 17 * 60)
            {
                v = RandomNumber(0, 100);
                if (v < 20)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                v = RandomNumber(0, 100);
                if (v < 10)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>Devuelve dependiendo del instante de tiempo si un trabajador aparcaría, saldría o nada.</summary>
        /// <param name="t">minutos transcurridos desde las 00:00</param>
        /// <returns>0: NADA | -1: SALIR | 1: APARCAR</returns>
        public static int Otro(long t)
        {
            int v;
            if (t < 9 * 60)
            {
                return 0;
            }
            else if (t < 21 * 60)
            {
                v = RandomNumber(0, 100);
                if (v < 33)
                {
                    return 1;
                }
                else if (v < 66)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        /// <summary>Genera un valor aleatorio entre min y max.</summary>
        /// <see cref=">https://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number/768001#768001"/>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
