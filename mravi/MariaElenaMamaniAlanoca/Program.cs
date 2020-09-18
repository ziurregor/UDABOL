using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

                //Console.WriteLine("Ingrese N° de nodos");
                int n = Int32.Parse(Console.ReadLine());
                int[] padre = new int[n + 1];
                int[] porcentaje = new int[n + 1];
                int[] tuberia = new int[n + 1];

                for (int i = 1; i < n; i++)
                {
                    int x = Int32.Parse(Console.ReadLine());
                    int y = Int32.Parse(Console.ReadLine());
                    padre[y] = x;
                porcentaje[y] = Int32.Parse(Console.ReadLine());
                    tuberia[y] = Int32.Parse(Console.ReadLine());

                }
            Double p = 0;
                for (int j = 1; j < n + 1; j++)
                {
                    double resp = Double.Parse(Console.ReadLine());
                    if (resp >= 0)
                    {
                        int r = j;
                        while (r > 1)
                        {
                            if (tuberia[r] == 1)
                            {
                                resp = Math.Sqrt(resp);
                            }
            
                            resp = resp * (100 / porcentaje[r]);
                            r = padre[r];
                
                    }
                        if (resp > p)
                        {
                            p = resp;
                        }
                    }
                }
            Console.WriteLine(p);

        }
    }
}
