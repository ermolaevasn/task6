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
            double a,b,c,max=1,min=1;
            int N;
            Vvod("введите a1",out a); //ввод первых чисел последовательности а1,а2,а3     
            Vvod("введите а2", out b);           
            Vvod("введите а3", out c);           
            VvodTwo("введите N", out N);//ввод числа N элементов, стоящие на нечетных местах
            Proverka("число N", ref N);

            double[] mas = new double[2*N-1];//массив для хранения последовательности
            function(a,b,c,2*N-1,3,ref mas);//функция, для вычисления последующих элементов последовательности
           
            mas[0] = a;
            mas[1] = b;
            mas[2] = c;

            Console.WriteLine();
            for (int h = 0; h < (2 * N - 1); h++)//вывод последовательности на экран
            {
                if (h % 2==0) Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{" + (h + 1) + "} " + mas[h] + "  ");
                Console.ResetColor();
            }

            for (int j = 0; j < mas.Length-2; j = j + 2)//проверка последовательности на монотонность
            {
                if (mas[j + 2] >= mas[j]) max++;
                if (mas[j + 2] <= mas[j]) min++;
            }
            Console.WriteLine();
            if (max == N) Console.WriteLine("Неубывающая подпоследовательность");
            else  if (min == N) Console.WriteLine("Невозврастающая подпоследовательность");
            else Console.WriteLine("Не монотонна");

            Console.ReadKey();
        }
        static double function(double x, double y, double z,int razm,int i,ref double[] mas)//функция для
        {                                                                                   //вычисления значения
            double a;                                                                       //элемента
            if (razm==i)
            {
                return 1;
            }
            else
            {
                a=0.7 * z-0.2*y+(i+1)*x;//вычисление значения элемента
                mas[i] = a;//занесение данного значения в массив
                Console.Write(a + " ");
                i++;
                x = y;
                y = z;
                z = a;
                return function(x,y,z,razm,i,ref mas);
            }
        }
        static double Vvod(string s, out double n)//ввод чисел с проверкой
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
     
        static double VvodTwo(string s, out int n)//ввод для числа N
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
        static void Proverka(string s, ref int a)//проверка ввода на отрицательность
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
