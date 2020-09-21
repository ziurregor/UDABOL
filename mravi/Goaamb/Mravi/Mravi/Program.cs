using System;
using System.Linq;

namespace Mravi
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(System.Console.ReadLine());

            int[,,] m= new int[n,n,2];
            double[] elementos = new double[n];

            for (int i = 0; i < n - 1; i++)
            {
                int[] cadena = System.Console.ReadLine().Split(" ").Select(p=>int.Parse(p)).ToArray();

                int a = cadena[0];
                int b = cadena[1];
                int x = cadena[2];
                int t = cadena[3];
                m[a - 1,b - 1,0] = x;
                m[a - 1,b - 1,1] = t;
            }

            elementos = System.Console.ReadLine().Split(" ").Select(p => double.Parse(p)).ToArray();
            
            for (int i = n - 1; i >= 0; i--)
            {
                double mayor = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j && m[i,j,0] > 0)
                    {
                        if (m[i,j,1] == 0)
                        {
                            elementos[i] = elementos[j] * 100 / m[i,j,0];
                        }
                        else
                        {
                            elementos[i] = Math.Sqrt(elementos[j]) * 100 / m[i,j,0];
                        }
                        if (mayor < elementos[i])
                        {
                            mayor = elementos[i];
                        }
                    }
                }
                if (mayor > 0)
                {
                    elementos[i] = mayor;
                }
            }
            System.Console.WriteLine(Decimal.Round((Decimal)elementos[0],3));
        }
    }
}
