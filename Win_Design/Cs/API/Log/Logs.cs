using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_Design.Cs.API.Log
{
    class Logs
    {
        public static void WriteLine(dynamic message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}][Debug]:{message}");
        }
    }
}
