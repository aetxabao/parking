using System;

namespace parking
{
    public class Log
    {
        public static void msg(long reloj_time, Parking parking, char tipo, string txt)
        {
            TimeSpan t;
            string ts;
            t = TimeSpan.FromSeconds(reloj_time * 12);
            ts = string.Format("{0:D2}:{1:D2}", t.Hours, t.Minutes);
            Console.WriteLine("{0} {1} {2} {3}", ts, parking, tipo, txt);
        }
    }
}