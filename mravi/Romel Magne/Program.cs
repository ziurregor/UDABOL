using System;
using System.Collections.Generic;

namespace mravi
{
    class Program
    {
        static void Main(string[] args)
        {

            //string line;
            int l;
            int[,] mat;
            int[] vec;



            //Console.WriteLine("Nvari number off nodes");

            l = Convert.ToInt32(Console.ReadLine());
            mat = new int[l - 1, 4];
            vec = new int[l];

            List<string> tests = new List<string>();
                                                  

            for (int i = 0; i < l - 1; i++)
            {
                string line = Console.ReadLine();

                tests.Add(line);
               // int k = 0;
               // int j = 0;

                //string[] split = line.Split(new char[] { ' ' }, StringSplitOptions.None);
                //long a = Int64.Parse(split[0]);
                //long b = Int64.Parse(split[1]);


                foreach (var test in tests)
                {
                    string[] split = test.Split(new char[] { ' ' }, StringSplitOptions.None);

                    //string begin = split[0];
                    mat[i, 0] = Convert.ToInt32(split[0]);
                    mat[i, 1] = Convert.ToInt32(split[1]);
                    mat[i, 2] = Convert.ToInt32(split[2]);
                    mat[i, 3] = Convert.ToInt32(split[3]);
                    //+ split[1];

                    //string finish = split[2] + split[3];
                }
                //string[] split = test.Split(new char[] { ' ' }, StringSplitOptions.None);
                //for (int i1 = 0; i1 < line.Length; i1++)
                //{
                //    mat[i, i1] = line[i1];
                //}



            }

            //Console.WriteLine("Vector final");
            // string line = Console.ReadLine();

            string line1 = Console.ReadLine();
            List<string> tests1 = new List<string>();
            tests1.Add(line1);
            foreach (var test1 in tests1)
            {
                string[] split = test1.Split(new char[] { ' ' }, StringSplitOptions.None);
                for (int k = 0; k < l; k++)
                {
                    vec[k] = Convert.ToInt32(split[k]);
                }
                
               // vec[1] = Convert.ToInt32(split[1]);
               // vec[2] = Convert.ToInt32(split[2]);
               //// vec[3] = Convert.ToInt32(split[3]);
            }

            //for (int i = 0; i < l; i++)
            //{
            //    Console.WriteLine("imput line (" + i + ")=");
            //    vec[i] = Convert.ToInt32(Console.ReadLine());

            //}



            //Console.WriteLine("Matrix");
            //for (int i = 0; i < l - 1; i++)
            //{
            //    Console.WriteLine(" M(" + i + ",1)=" + mat[i, 0] + " M(" + i + ",2)=" + mat[i, 1] + " M(" + i + ",3)=" + mat[i, 2] + " M(" + i + ",4)=" + mat[i, 3]);
            //}
            //Console.WriteLine("Vector");
            //for (int i = 0; i < l; i++)
            //{
            //    Console.WriteLine(" v(" + i + ")=" + vec[i]);
            //}

            ////// start resolution
            int r1 = mat[0,0];
            for (int i = 0; i < l - 1; i++)
            {
                if (mat[ i,0] > r1)
                {
                r1 = mat[ i,0];
                }

            }


        

        //Console.WriteLine("r1:"+r1);

            int r2=0;
            int sw = 0;
            int el1=0;
            for (int i = 0; i < l-1; i++)
            {
                if (mat[i,0] == r1)
                {
                    if (vec[mat[i,1]-1] > 0 && sw == 0)
                    {
                        r2 = vec[mat[i, 1]-1];
                        sw = 1;
                        el1 = mat[i, 1] - 1;
                    }
                    
                    if (r2 > vec[mat[i, 1]-1] && vec[mat[i, 1]-1] > 0)
                    {
                        r2= vec[mat[i, 1]-1];
                        el1 = mat[i, 1] - 1;

                    }

                }
            }

            //Console.WriteLine("r2:" + r2);

            //Console.WriteLine("El valor de Vec["+ el1+"] = " + r2);

            int l1 = l-1;
            int el2 = el1+1;
            double data1 = vec[el1];
            while (l1 >1)
            {
                for (int i = 0; i < l-1; i++)
                {
                    if (mat[i,1] == el2)
                    {
                        if (mat[i, 3]==1)
                        {
                            data1 = Math.Sqrt(data1);
                        }
                        data1 = (data1 * 100)/ mat[i, 2];
                        el2 = mat[i, 0];
                        l1 = el2;
                    }

                }
                               
            }

            Console.WriteLine(data1);









        }
    }
}
