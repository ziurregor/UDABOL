using System;
using System.Collections.Generic;

namespace mravi
{
    class Program
    {
        static void Main(string[] args)
        {
            int l;
            int[,] matriz;
            int[] vector;

            l = Convert.ToInt32(Console.ReadLine());
            matriz = new int[l - 1, 4];
            vector = new int[l];
            List<string> tests = new List<string>();
            for (int i = 0; i < l - 1; i++)
            {
                string line = Console.ReadLine();
                tests.Add(line);
                 foreach (var test in tests)
                {
                    string[] split = test.Split(new char[] { ' ' }, StringSplitOptions.None);
                    matriz[i, 0] = Convert.ToInt32(split[0]);
                    matriz[i, 1] = Convert.ToInt32(split[1]);
                    matriz[i, 2] = Convert.ToInt32(split[2]);
                    matriz[i, 3] = Convert.ToInt32(split[3]);
                 }
            }
            string line1 = Console.ReadLine();
            List<string> tests1 = new List<string>();
            tests1.Add(line1);
            foreach (var test1 in tests1)
            {
                string[] split = test1.Split(new char[] { ' ' }, StringSplitOptions.None);
                for (int k = 0; k < l; k++)
                {
                    vector[k] = Convert.ToInt32(split[k]);
                }
            }
            int r1 = matriz[0, 0];
            for (int i = 0; i < l - 1; i++)
            {
                if (matriz[i,0] > r1)
                {
                    r1 = matriz[i,0];
                }
            }
            int r2 = 0;
            int sw = 0;
            int el1 = 0;
            for (int i = 0; i < l - 1; i++)
            {
                if (matriz[i, 0] == r1)
                {
                    if (vector[matriz[i, 1] - 1] > 0 && sw == 0)
                    {
                        r2 = vector[matriz[i, 1] - 1];
                        sw = 1;
                        el1 = matriz[i, 1] - 1;
                    }
                    if (r2 > vector[matriz[i, 1] - 1] && vector[matriz[i, 1] - 1] > 0)
                    {
                        r2 = vector[matriz[i, 1] - 1];
                        el1 = matriz[i, 1] - 1;
                    }
                }
            }
            int l1 = l - 1;
            int el2 = el1 + 1;
            double data1 = vector[el1];
            while (l1 > 1)
            {
                for (int i = 0; i < l - 1; i++)
                {
                    if (matriz[i, 1] == el2)
                    {
                        if (matriz[i, 3] == 1)
                        {
                            data1 = Math.Sqrt(data1);
                        }
                        data1 = (data1 * 100) / matriz[i, 2];
                        el2 = matriz[i, 0];
                        l1 = el2;
                    }
                }
            }
            Console.WriteLine(data1);
            //Finished
        }
    }
}