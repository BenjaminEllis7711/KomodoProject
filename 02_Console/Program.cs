using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 200;
            ClaimsUI run = new ClaimsUI();
            run.Run();
        }
    }
}
