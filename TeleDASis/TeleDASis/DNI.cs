using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDASis
{
    class DNI
    {
        static void Main(string[] args)
        {
            int dni = 0;
            string sdni;

            do
            {
                Console.Write("Escribe tu dni: ");
                sdni = Console.ReadLine();//lee num entrado por teclado y lo pasa a string
            }
            while (!esNumero(sdni) || Int32.Parse(sdni) > 9);

            dni = Int32.Parse(sdni);//pasa de string a num
            Console.WriteLine($"El factorial de tu DNI({dni}) es {comprobacion(dni)}");
            Console.ReadLine();
        }
        //
        static bool esNumero(string s)
        {
            if (s.IndexOf("1") != -1 ||
                s.IndexOf("2") != -1 ||
                s.IndexOf("3") != -1 ||
                s.IndexOf("4") != -1 ||
                s.IndexOf("5") != -1 ||
                s.IndexOf("6") != -1 ||
                s.IndexOf("7") != -1 ||
                s.IndexOf("8") != -1 ||
                s.IndexOf("9") != -1 ||
                s.IndexOf("0") != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public long comprobacion(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n * comprobacion(n - 1);
            }
        }
    }
}
