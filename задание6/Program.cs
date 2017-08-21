using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание6
{
    class Program
    {
        static void Main(string[] args)
        {
            double a,b,c,tmp;
            int N, k;
            Vvod("введите a",out a);            
            Vvod("введите b", out b);           
            Vvod("введите c", out c);           
            VvodTwo("введите N", out N);
            Proverka("число N", ref N);
            VvodTwo("введите k", out k);
            Proverka("число k", ref k);
            function(a,b,c,k+4,4);
            Console.ReadKey();
            double[] mas = new double[k];

        }
        static double function(double x, double y, double z,int razm,int i)
        {
            double a;
            if (razm==i)
            {
                return 1;
            }
            else
            {
                a=0.7 * z-0.2*y+i*x;
                Console.Write(a + " ");
                i++;
                x = y;
                y = z;
                z = a;
                return function(x,y,z,razm,i);
            }
        }
        static double Vvod(string s, out double n)//проверка ввода
        {
            bool ok;
            string buf;
            do
            {
                Console.Write(s + " = ");
                buf = Console.ReadLine();
                ok = double.TryParse(buf, out n);
                if (!ok) Console.WriteLine("Введите " + s + " заново");
            } while (!ok);
            return n;
        }
     
        static double VvodTwo(string s, out int n)//проверка ввода
        {
            bool ok;
            string buf;
            do
            {
                Console.Write(s + " = ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out n);
                if (!ok) Console.WriteLine("Введите " + s + " заново");
            } while (!ok);
            return n;
        }
        static void Proverka(string s, ref int a)
        {
            bool ok = false;
            string buf;
            do
            {
                if (a > 0) ok = true;
                else
                {
                    if (!ok) Console.WriteLine("\aВведите " + s + " заново");
                    Console.Write(s + " = ");
                    buf = Console.ReadLine();
                    ok = Int32.TryParse(buf, out a);
                    ok = false;
                }
            } while (!ok);
        }
    }
}
